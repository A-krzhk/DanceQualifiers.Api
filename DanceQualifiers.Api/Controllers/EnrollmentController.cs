using DanceQualifiers.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DanceQualifiers.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        [HttpPost("enroll")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> RegisterForTimeSlot(string userId, int timeSlotId)
        {
            var result = await _enrollmentService.EnrollUserInTimeSlotAsync(userId, timeSlotId);
            if (result)
            {
                return Ok(new { message = "Successfully" });
            }

            return BadRequest(new { message = "Failed to enroll for the time slot." });
        }

        [HttpPost("cancel")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CancelRegistration(string userId, int timeSlotId)
        {
            var result = await _enrollmentService.CancelEnrollmentAsync(userId, timeSlotId);
            if (result)
            {
                return Ok(new { message = "Successfully" });
            }

            return BadRequest(new { message = "The registration could not be cancelled" });
        }
    }
}
