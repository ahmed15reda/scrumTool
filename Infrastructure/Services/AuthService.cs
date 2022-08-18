using AutoMapper;
using Core.Dto;
using Core.Entities;
using Core.Enum;
using Core.Interfaces;
using Infrastructure.Exceptions;
using Infrastructure.IServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITFSUserRepository _tFSUserRepository;
        private readonly IGenericRepository<TFSUser> _genericRepository;
        private readonly ICryptography _cryptography;
        private readonly IConfiguration _configuration;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AuthService(ITFSUserRepository tFSUserRepository, IGenericRepository<TFSUser> genericRepository, ICryptography cryptography, IConfiguration configuration, ITokenService tokenService , IMapper mapper)
        {
            _tFSUserRepository = tFSUserRepository;
            _genericRepository = genericRepository;
            _cryptography = cryptography;
            _configuration = configuration;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<bool> ChangePassword(int id, ResetPasswordDto resetPasswordDto)
        {
            var user = await _genericRepository.GetById(id);
            if (user == null) throw new UserNotFoundException();

            var password = await _cryptography.EncryptPassword(resetPasswordDto.CurrentPassword);

            if (!user.Password.Equals(password)) throw new Exception("Invalid Credentials");

            if (!resetPasswordDto.NewPassword.Equals(resetPasswordDto.ConfirmNewPassword))
                return false;

            user.Password = await _cryptography.EncryptPassword(resetPasswordDto.NewPassword);

            await _genericRepository.Update(user);

            return true;
        }

        //public Task<bool> CheckCurrentPassword(int id, string currentPassword)
        //{
        //    throw new System.NotImplementedException();
        //}

        public async Task<UserSessionDto> Login(LoginDto loginDto)
        {
            var user = await _tFSUserRepository.GetByUsername(loginDto.UserName) 
                                ?? await _tFSUserRepository.GetByTFSName(loginDto.UserName);

            if (user == null) throw new UserNotFoundException("Invalid Credentials");

            if (user.IsActive == false) throw new Exception("You are blocked");

            var password = await _cryptography.EncryptPassword(loginDto.Password);

            if (password != user.Password) throw new UserNotFoundException("Invalid Credentials");

            return new UserSessionDto
            {
                User = _mapper.Map<TFSUserDto>(user),
                UserRole = (UserRoles)user.UserRoleId,
                UserToken = _tokenService.CreateToken(user)
            };
        }

        //public async Task Logout()
        //{
        //    var jwtHelper = new JwtHelper(_configuration);

        //    await jwtHelper.DeactivateCurrentAsync();
        //}
    }
}
