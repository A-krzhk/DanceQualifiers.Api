using DanceQualifiers.Application.Interfaces;
using DanceQualifiers.Core.DTO;
using DanceQualifiers.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DanceQualifiers.Application.Services
{
    public class DirectionService : IDirectionService
    {
        private readonly DanceQualifiersDbContext _context;

        public DirectionService(DanceQualifiersDbContext context)
        {
            _context = context;
        }

        public async Task CreateDirectionAsync(CreateDirectionDto model)
        {
            var direction = new Direction
            {
                Name = model.Name,
                TimeSlots = model.TimeSlots.Select(ts => new TimeSlot
                {
                    StartTime = ts.StartTime,
                    MaxParticipants = ts.MaxParticipants,
                    Date = ts.Date,

                    RegisteredParticipants = 0
                }).ToList()
            };

            _context.Directions.Add(direction);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteDirectionAsync(int directionId)
        {
            var direction = await _context.Directions.FindAsync(directionId);

            if (direction == null)
                return false;

            _context.Directions.Remove(direction);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Direction>> GetAllDirectionsAsync()
        {
            return await _context.Directions.Include(q => q.TimeSlots).ToListAsync();
        }
    }
}
