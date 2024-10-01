using DanceQualifiers.Application.Interfaces;
using DanceQualifiers.Core.ViewModels;
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
        public async Task<IActionResult> CreateDirection(CreateDirectionViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _directionService.CreateDirectionAsync(model);
            return Ok("Direction created successfully");
        }
    }
}
