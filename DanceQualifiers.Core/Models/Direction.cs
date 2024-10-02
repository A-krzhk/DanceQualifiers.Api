using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceQualifiers.Core.Models
{
    public class Direction
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<TimeSlot> TimeSlots { get; set; }

    }
}
