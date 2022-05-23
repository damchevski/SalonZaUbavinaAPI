using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonZaUbavinaAPI.Models.Dto
{
    public class AppointmentDto
    {
        public string DateTime { get; set; }
        public string User { get; set; }
        public string AppointmentDescription { get; set; }
        public string PhoneNumber { get; set; }
        public string UserEmail { get; set; }
    }
}
