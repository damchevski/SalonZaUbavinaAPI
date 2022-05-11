using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonZaUbavinaAPI.Models.Dto
{
    public class ScheduleDto
    {
        public string DateTime { get; set; }
        public string User { get; set; }
        public string ScheduleDescription { get; set; }
        public string PhoneNumber { get; set; }
        public string UserEmail { get; set; }
    }
}
