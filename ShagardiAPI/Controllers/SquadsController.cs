using Core.Dto;
using Core.Entities;
using Infrastructure.IServices;
using Infrastructure.Response;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShagardiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquadsController : ControllerBase
    {
        private readonly ISquadService _squadService;

        public SquadsController(ISquadService squadService)
        {
            _squadService = squadService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSquads()
        {
            var squads = await _squadService.GetAll();
            if (squads.Count == 0)
                return NotFound(new ErrorMessageResponse("No squads found!"));
            return Ok(new DataResponse<List<SquadDto>>(squads));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSquadById(int id)
        {
            try
            {
                var squad = await _squadService.GetSquadById(id);
                return Ok(new DataResponse<SquadDto>(squad));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessageResponse(ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSquad([FromBody] Squad squad)
        {
            try
            {
                await _squadService.AddSquad(squad);
                return Ok(new SuccessMessageResponse($"Squad [{squad.Name}] Created Successfully!"));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessageResponse(ex.Message));
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSquad([FromBody] Squad squad)
        {
            try
            {
                await _squadService.UpdateSquad(squad);
                return Ok(new SuccessMessageResponse($"Squad [{squad.Name}] Updated Successfully!"));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessageResponse(ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSquad(int id)
        {
            try
            {
                await _squadService.DeleteSquad(id);
                return Ok(new SuccessMessageResponse($"Squad Deleted Successfully!"));
            }
            catch (Exception ex)
            {
                return NotFound(new ErrorMessageResponse(ex.Message));
            }
        }
    }
}
