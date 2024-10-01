using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceQualifiers.Core.ViewModels
{
    public class CreateTimeSlotViewModel
    {
        public TimeSpan StartTime { get; set; }
        public int MaxParticipants { get; set; }
    }
}
