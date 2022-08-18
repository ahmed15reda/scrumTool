using Core.Dto;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.IServices;
using Infrastructure.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShagardiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemConfigsController : ControllerBase
    {
        private readonly ISystemConfigsService _systemConfigsService;

        public SystemConfigsController(ISystemConfigsService systemConfigsService)
        {
            _systemConfigsService = systemConfigsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var configs = await _systemConfigsService.GetSystemConfig();
            if (configs.Count == 0)
                return NotFound(new ErrorMessageResponse("No configs found!"));
            return Ok(new DataResponse<List<SystemConfig>>(configs));

        }
        [HttpPut]
        public async Task<IActionResult> Update(SystemConfig systemConfig)
        {
            try
            {
                await _systemConfigsService.Update(systemConfig);
                return Ok(new SuccessMessageResponse($"System Config Updated Successfully!"));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessageResponse(ex.Message));
            }
        }
    }
}
