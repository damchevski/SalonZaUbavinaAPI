using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonZaUbavinaAPI.Models
{
    public class Schedule : Base
    {
        public DateTime DateTime { get; set; }
        public string User { get; set; }
        public string ScheduleDescription { get; set; }
        public int StatusId { get; set; }
        public virtual ScheduleStatus Status { get; set; }
        public string PhoneNumber { get; set; }
        public string UserEmail { get; set; }
    }
}
