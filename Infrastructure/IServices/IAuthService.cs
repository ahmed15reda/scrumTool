using Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IServices
{
    public interface IAuthService
    {
        Task<UserSessionDto> Login(LoginDto loginDto);
        Task<bool> ChangePassword(int id, ResetPasswordDto resetPasswordDto);
        //Task<bool> CheckCurrentPassword(int id, string currentPassword);
        //Task Logout();

    }
}
