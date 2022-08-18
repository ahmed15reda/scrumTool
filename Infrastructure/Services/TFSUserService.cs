using AutoMapper;
using Core.Dto;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Exceptions;
using Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class TFSUserService : ITFSUserService
    {
        private readonly ITFSUserRepository _tFSUserRepository;
        private readonly IGenericRepository<TFSUser> _genericRepository;
        private readonly ICryptography _cryptography;
        private readonly IMapper _mapper;

        public TFSUserService(ITFSUserRepository tFSUserRepository, IGenericRepository<TFSUser> genericRepository, ICryptography cryptography, IMapper mapper)
        {
            _tFSUserRepository = tFSUserRepository;
            _genericRepository = genericRepository;
            _cryptography = cryptography;
            _mapper = mapper;
        }
        public async Task<int> AddUser(TFSUser tfsUser)
        {
            var user = await _tFSUserRepository.GetByTFSOrUserName(tfsUser.TFSName, tfsUser.Password);

            if (user != null)
                throw new Exception("Failed adding new user as email aleardy exist");
            user = await _tFSUserRepository.GetByNameType(tfsUser.UserName);
            if (user != null)
                throw new Exception("Failed adding new user as user name aleardy exist");

            tfsUser.CreatedAt = DateTime.Now;
            tfsUser.Password = await _cryptography.EncryptPassword(tfsUser.Password);
            return await _genericRepository.Create(tfsUser);
        }
        public async Task<int> ChangeStatus(int id, bool status)
        {
            if (!await IsUserExist(id)) throw new UserNotFoundException();

            return await _tFSUserRepository.ChangeStatus(id, status);
        }
        public async Task<int> DeleteUser(int id)
        {
            if (!await IsUserExist(id)) throw new UserNotFoundException();

            return await _genericRepository.Delete(id);
        }
        public async Task<int> UpdateUser(TFSUser user)
        {
            if (!await IsUserExist(user.Id)) throw new UserNotFoundException();

            var userByName = await _tFSUserRepository.GetByNameType(user.TFSName);
            if (userByName != null && user.Id != userByName.Id)
                throw new Exception("Failed updating user as email aleardy exist");

            userByName = await _tFSUserRepository.GetByNameType(user.UserName);
            if (userByName != null && user.Id != userByName.Id)
                throw new Exception("Failed updating user as user name aleardy exist");

            return await _genericRepository.Update(user);
        }

        public async Task<List<TFSUserDto>> GetAll()
        {
            var users = await _genericRepository.GetAll();

            return _mapper.Map<List<TFSUserDto>>(users);
        }

        public async Task<TFSUserDto> GetTFSUserById(int id)
        {
            if (!await IsUserExist(id)) throw new UserNotFoundException();
            var user = await _genericRepository.GetById(id);
            return _mapper.Map<TFSUserDto>(user);
        }
        private async Task<bool> IsUserExist(int id)
        {
            return await _genericRepository.GetById(id) != null;
        }
    }
}
