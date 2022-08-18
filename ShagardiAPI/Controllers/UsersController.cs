using Core.Dto;
using Core.Entities;
using Infrastructure.IServices;
using Infrastructure.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShagardiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ITFSUserService _tFSUserService;

        public UsersController(ITFSUserService tFSUserService)
        {
            _tFSUserService = tFSUserService;
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _tFSUserService.GetAll();
            if (users.Count == 0)
                return NotFound(new ErrorMessageResponse("No users found!"));
            return Ok(new DataResponse<List<TFSUserDto>>(users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _tFSUserService.GetTFSUserById(id);
                return Ok(new DataResponse<TFSUserDto>(user));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessageResponse(ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] TFSUser user)
        {
            try
            {
                await _tFSUserService.AddUser(user);
                return Ok(new SuccessMessageResponse($"User [{user.Name}] Created Successfully!"));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessageResponse(ex.Message));
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] TFSUser user)
        {
            try
            {
                await _tFSUserService.UpdateUser(user);
                return Ok(new SuccessMessageResponse($"User [{user.Name}] Updated Successfully!"));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessageResponse(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _tFSUserService.DeleteUser(id);
                return Ok(new SuccessMessageResponse($"User Deleted Successfully!"));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessageResponse(ex.Message));
            }
        }

        [HttpPut("{id}/{status}")]
        public async Task<IActionResult> ChangeUserStatus(int id, bool status)
        {
            try
            {
                await _tFSUserService.ChangeStatus(id, status);
                return Ok(new SuccessMessageResponse($"User Status Updated Successfully!"));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessageResponse(ex.Message));
            }
        }
    }
}
