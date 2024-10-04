using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceQualifiers.Application.Interfaces
{
    public interface IEnrollmentService
    {
        Task<bool> EnrollUserInTimeSlotAsync(string userId, int timeSlotId);
        Task<bool> CancelEnrollmentAsync(string userId, int timeSlotId);
    }
}
