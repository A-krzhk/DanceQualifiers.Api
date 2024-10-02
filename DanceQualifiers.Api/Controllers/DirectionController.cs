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
        public async Task<IActionResult> DeleteDirection(int directionId)
        {
            var result = await _directionService.DeleteDirectionAsync(directionId);
            if (!result)
                return NotFound();

            return Ok($"Direction with the id {directionId} deleted");
        }

        [HttpPost("{directionId}")]
        public async Task<IActionResult> AddTimeSlot(int directionId, CreateTimeSlotDto timeSlotDto)
        {
            var timeSlot = await _directionService.AddTimeSlotAsync(directionId, timeSlotDto);
            if (timeSlot == null) return NotFound();
            return CreatedAtAction(nameof(AddTimeSlot), new { id = timeSlot.Id }, timeSlot);
        }

        [HttpDelete("timeSlots/{timeSlotId}")]
        public async Task<IActionResult> DeleteTimeSlot(int timeSlotId)
        {
            var deleted = await _directionService.DeleteTimeSlotAsync(timeSlotId);
            if (!deleted) return NotFound();
            return Ok($"Time slot with id {timeSlotId} was deleted");
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
            return NotFound("Qualifieres not found");
        }
    }
}
