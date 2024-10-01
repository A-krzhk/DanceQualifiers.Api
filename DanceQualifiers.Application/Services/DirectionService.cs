using DanceQualifiers.Application.Interfaces;
using DanceQualifiers.Core.Models;
using DanceQualifiers.Core.ViewModels;

namespace DanceQualifiers.Application.Services
{
    public class DirectionService : IDirectionService
    {
        private readonly DanceQualifiersDbContext _context;

        public DirectionService(DanceQualifiersDbContext context)
        {
            _context = context;
        }

        public async Task CreateDirectionAsync(CreateDirectionViewModel model)
        {
            var direction = new Direction
            {
                Name = model.Name,
                Date = model.Date,
                TimeSlots = model.TimeSlots.Select(ts => new TimeSlot
                {
                    StartTime = ts.StartTime,
                    MaxParticipants = ts.MaxParticipants,
                    RegisteredParticipants = 0
                }).ToList()
            };

            _context.Directions.Add(direction);
            await _context.SaveChangesAsync();
        }
    }
}
