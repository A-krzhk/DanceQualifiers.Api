using DanceQualifiers.Core.DTO;
using DanceQualifiers.Core.Models;

namespace DanceQualifiers.Application.Interfaces
{
    public interface IDirectionService
    {
        Task CreateDirectionAsync(CreateDirectionDto model);
        Task<bool> DeleteDirectionAsync(int directionId);
        Task<IEnumerable<Direction>> GetAllDirectionsAsync();
    }
}
