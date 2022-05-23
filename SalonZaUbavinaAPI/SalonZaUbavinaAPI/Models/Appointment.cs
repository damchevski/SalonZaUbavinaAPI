using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalonZaUbavinaAPI.Models
{
    [Table("Appointments")]
    public class Appointment : Base
    {
        public DateTime DateTime { get; set; }
        public string User { get; set; }
        public string AppointmentDescription { get; set; }
        public int StatusId { get; set; }
        public virtual AppointmentStatus Status { get; set; }
        public string PhoneNumber { get; set; }
        public string UserEmail { get; set; }
    }
}
