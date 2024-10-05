namespace DanceQualifiers.Core.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public DateTime Date { get; set; }
        public int MaxParticipants { get; set; }
        public int RegisteredParticipants { get; set; }
        public int DirectionId { get; set; }
        public ICollection<UserEnrollment>? UserEnrollments { get; set; }
    }
}
