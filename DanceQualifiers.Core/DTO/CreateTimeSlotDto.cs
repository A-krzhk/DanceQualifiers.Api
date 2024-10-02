namespace DanceQualifiers.Core.DTO
{
    public class CreateTimeSlotDto
    {
        public TimeSpan StartTime { get; set; }
        public DateTime Date { get; set; }
        public int MaxParticipants { get; set; }
    }
}
