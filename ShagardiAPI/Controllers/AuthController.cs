using Core.Dto;
using Infrastructure.IServices;
using Infrastructure.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ShagardiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            try
            {
                return Ok(new DataResponse<UserSessionDto>(await _authService.Login(loginDto)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorMessageResponse(ex.Message));
            }
        }
        [Authorize]
        [HttpPut("changepassword/{id}")]
        public async Task<ActionResult> ChangePassword(int id, ResetPasswordDto resetPasswordDto)
        {
            try
            {
                if (!await _authService.ChangePassword(id, resetPasswordDto))
                    throw new Exception("Can not change password");
                return Ok(new SuccessMessageResponse("Password changed successfuly"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorMessageResponse(ex.Message));
            }
        }
        //[Authorize]
        //[HttpPost("logout")]
        //public async Task<ActionResult> Logout()
        //{
        //    await _authService.Logout();
        //    return Ok(new SuccessMessageResponse("Logedout Successfuly"));
        //}

    }
}
