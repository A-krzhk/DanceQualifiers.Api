using DanceQualifiers.Core.DTO;
using DanceQualifiers.Core.Models;

namespace DanceQualifiers.Application.Interfaces
{
    public interface IDirectionService
    {
        Task<Direction> CreateDirectionAsync(CreateDirectionDto model);
        Task<bool> DeleteDirectionAsync(int directionId);
        Task<IEnumerable<Direction>> GetAllDirectionsAsync();
        Task<TimeSlot> AddTimeSlotAsync(int directionId, CreateTimeSlotDto timeSlotDto);
        Task<bool> DeleteTimeSlotAsync(int timeSlotId);
    }
}
