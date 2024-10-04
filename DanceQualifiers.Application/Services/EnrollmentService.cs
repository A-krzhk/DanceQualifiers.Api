using DanceQualifiers.Application.Interfaces;
using DanceQualifiers.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace DanceQualifiers.Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly DanceQualifiersDbContext _context;

        public EnrollmentService(DanceQualifiersDbContext context)
        {
            _context = context;
        }

        public async Task<bool> EnrollUserInTimeSlotAsync(string userId, int timeSlotId)
        {
            
            var timeSlot = await _context.TimeSlots
                .Include(ts => ts.UserEnrollments)
                .FirstOrDefaultAsync(ts => ts.Id == timeSlotId);

            if (timeSlot == null)
            {
                throw new Exception("Time slot is not found");
            }

            var userAlreadyEnrolledInDirection = await _context.UserEnrollments
                .Include(ue => ue.TimeSlot)
                .AnyAsync(ue => ue.User.Id == userId && ue.TimeSlot.DirectionId == timeSlot.DirectionId);

            if (userAlreadyEnrolledInDirection)
            {
                throw new Exception("User is alredy enrolled to this direction");
            }

            if (timeSlot.RegisteredParticipants >= timeSlot.MaxParticipants)
            {
                throw new Exception("There are no available time slots");
            }

            var enrollment = new UserEnrollment
            {
                UserId = userId,
                TimeSlotId = timeSlotId
            };

            timeSlot.UserEnrollments.Add(enrollment);
            timeSlot.RegisteredParticipants++;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> CancelEnrollmentAsync(string userId, int timeSlotId)
        {
            var enrollment = await _context.UserEnrollments
                .FirstOrDefaultAsync(e => e.UserId == userId && e.TimeSlotId == timeSlotId);

            if (enrollment == null)
                return false;

            _context.UserEnrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }        
    }
}
