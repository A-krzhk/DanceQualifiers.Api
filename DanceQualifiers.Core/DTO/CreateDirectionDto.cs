namespace DanceQualifiers.Core.DTO
{
    public class CreateDirectionDto
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<CreateTimeSlotDto> TimeSlots { get; set; }
    }
}
