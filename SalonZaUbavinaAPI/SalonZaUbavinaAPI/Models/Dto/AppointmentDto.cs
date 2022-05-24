using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonZaUbavinaAPI.Models.Dto
{
    public class AppointmentDto
    {
        public string DateTime { get; set; }
        public string ClientName { get; set; }
        public string ServiceDescription { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
