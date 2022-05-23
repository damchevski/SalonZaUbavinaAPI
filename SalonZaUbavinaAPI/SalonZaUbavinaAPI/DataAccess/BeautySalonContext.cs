using Microsoft.EntityFrameworkCore;
using SalonZaUbavinaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonZaUbavinaAPI.DataAccess
{
    public class BeautySalonContext : DbContext
    {
        public BeautySalonContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<AppointmentStatus> AppointmentStatuses { get; set; }

    }
}
