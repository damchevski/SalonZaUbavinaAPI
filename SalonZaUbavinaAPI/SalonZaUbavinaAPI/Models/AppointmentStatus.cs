using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SalonZaUbavinaAPI.Models
{
    [Table("AppointmentStatuses")]
    public class AppointmentStatus : Base
    {
        public string Status { get; set; }
    }
}
