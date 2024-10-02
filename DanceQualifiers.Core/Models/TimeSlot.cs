using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
