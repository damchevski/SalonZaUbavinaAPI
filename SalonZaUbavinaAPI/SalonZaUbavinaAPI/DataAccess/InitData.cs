using SalonZaUbavinaAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalonZaUbavinaAPI.DataAccess
{
    public static class InitData
    {
        public static void Seed(this BeautySalonContext dbContext)
        {
            if (!dbContext.AppointmentStatuses.Any(x => x.Status.Equals("New")))
            {
                dbContext.AppointmentStatuses.Add(new AppointmentStatus() { Status = "New" });
            }

            if (!dbContext.AppointmentStatuses.Any(x => x.Status.Equals("Approved")))
            {
                dbContext.AppointmentStatuses.Add(new AppointmentStatus() { Status = "Approved" });
            }

            if (!dbContext.AppointmentStatuses.Any(x => x.Status.Equals("Denied")))
            {
                dbContext.AppointmentStatuses.Add(new AppointmentStatus() { Status = "Denied" });
            }

            dbContext.SaveChanges();
        }
    }
}
