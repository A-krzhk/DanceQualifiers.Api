using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceQualifiers.Core.Models
{
    public class UserEnrollment
    {
        public int Id { get; set; }

        public string? UserId { get; set; }
        public AppUser? User { get; set; }

        public int TimeSlotId { get; set; }
        public TimeSlot? TimeSlot { get; set; }
    }
}
