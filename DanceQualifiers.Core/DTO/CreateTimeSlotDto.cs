using System.ComponentModel.DataAnnotations;

namespace DanceQualifiers.Core.DTO
{
    public class CreateTimeSlotDto
    {
        [Required]
        public TimeSpan StartTime { get; set; }
        public DateTime Date { get; set; }
        public int MaxParticipants { get; set; }

    }
}
