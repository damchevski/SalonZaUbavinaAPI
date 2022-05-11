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
            if (!dbContext.ScheduleStatuses.Any(x => x.Status.Equals("New")))
            {
                dbContext.ScheduleStatuses.Add(new ScheduleStatus() { Status = "New" });
            }

            if (!dbContext.ScheduleStatuses.Any(x => x.Status.Equals("Approved")))
            {
                dbContext.ScheduleStatuses.Add(new ScheduleStatus() { Status = "Approved" });
            }

            dbContext.SaveChanges();
        }
    }
}
