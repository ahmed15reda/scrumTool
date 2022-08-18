using Core.Dto;
using Core.Entities;
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
    public class AbsentTypesController : ControllerBase
    {
        private readonly IAbsenceTypesService _absentTypesService;

        public AbsentTypesController(IAbsenceTypesService absentTypesService)
        {
            _absentTypesService = absentTypesService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAbsentTypes()
        {
            var types = await _absentTypesService.GetAll();
            if (types.Count == 0)
                return NotFound(new ErrorMessageResponse("No types found!"));
            return Ok(new DataResponse<List<AbsenceTypesDto>>(types));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbsentTypeById(int id)
        {
            try
            {
                var type = await _absentTypesService.GetAbsentTypeById(id);
                return Ok(new DataResponse<AbsenceTypesDto>(type));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessageResponse(ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAbsentType([FromBody] AbsenceTypes type)
        {
            try
            {
                await _absentTypesService.AddAbsentType(type);
                return Ok(new SuccessMessageResponse($"AbsentType [{type.Name}] Created Successfully!"));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessageResponse(ex.Message));
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbsentType([FromBody] AbsenceTypes type)
        {
            try
            {
                await _absentTypesService.UpdateAbsentType(type);
                return Ok(new SuccessMessageResponse($"AbsentType [{type.Name}] Updated Successfully!"));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessageResponse(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbsentType(int id)
        {
            try
            {
                await _absentTypesService.DeleteAbsentType(id);
                return Ok(new SuccessMessageResponse($"AbsentType Deleted Successfully!"));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessageResponse(ex.Message));
            }
        }
    }
}
