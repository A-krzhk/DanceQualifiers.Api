using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanceQualifiers.Core.ViewModels
{
    public class CreateDirectionViewModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<CreateTimeSlotViewModel> TimeSlots { get; set; }
    }
}
