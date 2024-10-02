using DanceQualifiers.Application.Interfaces;
using DanceQualifiers.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DanceQualifiers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectionController : ControllerBase
    {
        private readonly IDirectionService _directionService;

        public DirectionController(IDirectionService directionService)
        {
            _directionService = directionService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateDirection(CreateDirectionDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _directionService.CreateDirectionAsync(model);
            return Ok("Direction created successfully");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirection(int id)
        {
            var result = await _directionService.DeleteDirectionAsync(id);
            if (!result)
                return NotFound();

            return Ok($"Direction with the id {id} deleted");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllQualifiers()
        {
            var directions = await _directionService.GetAllDirectionsAsync();
            if (directions != null)
            {
                return Ok(directions);
            }
            return NotFound("Отборочные не найдены.");
        }
    }
}
