using DanceQualifiers.Application.Interfaces;
using DanceQualifiers.Core.DTO;
using DanceQualifiers.Core.Models;
using DanceQualifiers.Infrastructure;
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

        public async Task<Direction> CreateDirectionAsync(CreateDirectionDto directionDto)
        {
            var direction = new Direction
            {
                Name = directionDto.Name,
                TimeSlots = new List<TimeSlot>()
            };

            _context.Directions.Add(direction);
            await _context.SaveChangesAsync();
            return direction;
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

        public async Task<TimeSlot> AddTimeSlotAsync(int directionId, CreateTimeSlotDto timeSlotDto)
        {
            var direction = await _context.Directions.FindAsync(directionId);
            if (direction == null) return null;

            var timeSlot = new TimeSlot
            {
                StartTime = timeSlotDto.StartTime,
                Date = timeSlotDto.Date,
                MaxParticipants = timeSlotDto.MaxParticipants,
                DirectionId = directionId
            };

            _context.TimeSlots.Add(timeSlot);
            await _context.SaveChangesAsync();
            return timeSlot;
        }

        public async Task<bool> DeleteTimeSlotAsync(int timeSlotId)
        {
            var timeSlot = await _context.TimeSlots.FindAsync(timeSlotId);
            if (timeSlot == null) return false;

            _context.TimeSlots.Remove(timeSlot);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
