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

        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ScheduleStatus> ScheduleStatuses { get; set; }

    }
}
