using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalonZaUbavinaAPI.DataAccess;
using SalonZaUbavinaAPI.Models;
using SalonZaUbavinaAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SalonZaUbavinaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : Controller
    {
        private BeautySalonContext dbContext;

        public ScheduleController(BeautySalonContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("CreateSchedule")]
        public IActionResult CreateSchedule([FromBody] ScheduleDto schedule)
        {
            if(string.IsNullOrEmpty(schedule.User) 
                || string.IsNullOrEmpty(schedule.ScheduleDescription)
                || string.IsNullOrEmpty(schedule.DateTime)
                || string.IsNullOrEmpty(schedule.UserEmail))
            {
                return BadRequest("Please fill all fields!");
            }

            ScheduleStatus statusNew = dbContext.ScheduleStatuses.Where(x => x.Status.Equals("New")).FirstOrDefault();

            if (statusNew == null)
                return BadRequest("Error, please try again later!");

            Schedule newSchedule = new Schedule()
            {
                DateTime = DateTime.Parse(schedule.DateTime,CultureInfo.InvariantCulture),
                ScheduleDescription = schedule.ScheduleDescription,
                StatusId = statusNew.Id,
                User = schedule.User,
                UserEmail = schedule.UserEmail,
                PhoneNumber = schedule.PhoneNumber
            };

            List<Schedule> allSchedules = dbContext.Schedules.ToList();

            if (allSchedules.Any(x => x.DateTime.Equals(newSchedule.DateTime)))
                return BadRequest("The term is reserved!");

            dbContext.Schedules.Add(newSchedule);
            dbContext.SaveChanges();

            return Ok(newSchedule);
        }

        [HttpGet("GetAllSchedulesForDate")]
        public IActionResult GetAllSchedulesForDate([FromQuery] string date)
        {
            if (string.IsNullOrEmpty(date))
                return Ok(dbContext.Schedules
                    .Include(x => x.Status)
                    .ToList());

            DateTime dateRequest = DateTime.Parse(date);

            return Ok(dbContext.Schedules
                .Include(x => x.Status)
                .Where(x => x.DateTime.Day == dateRequest.Day && x.DateTime.Month == dateRequest.Month)
                .ToList());
        }

        [HttpGet("GetAllFreeTermsForDay")]
        public IActionResult GetAllFreeTermsForDay([FromQuery] int day)
        {
            List<Schedule> allSchedulesForDay = new List<Schedule>();

            foreach(var sch in dbContext.Schedules.ToList())
            {
                var schDateParsed = DateTime.Parse(sch.DateTime.ToString(), CultureInfo.InvariantCulture);
                if (schDateParsed.Month == day &&
                    schDateParsed.Day == DateTime.Now.Month)
                {
                    allSchedulesForDay.Add(sch);
                }
            }

            List<int> times = new List<int>();

            for(int i = 8; i <= 16; i++)
            {
                if (!allSchedulesForDay.Any(x => x.DateTime.Hour == i)){
                    times.Add(i);
                }
            }

            return Ok(times);
        }

        [HttpPost("MarkScheduleAs")]
        public IActionResult MarkScheduleAs([FromQuery] int scheduleId, [FromQuery] bool approved)
        {
            Schedule schedule = dbContext.Schedules
                .Where(x => x.Id == scheduleId)
                .FirstOrDefault();

            if (schedule == null)
                return BadRequest("Schedule doesn't exists!");

            string searchStatus = "Approved";
            if (!approved) { searchStatus = "Denied"; }

            ScheduleStatus statusApproved = dbContext.ScheduleStatuses
                .Where(x => x.Status == searchStatus)
                .FirstOrDefault();

            if (statusApproved == null)
                return BadRequest("Error!");

            schedule.StatusId = statusApproved.Id;

            dbContext.Update(schedule);
            dbContext.SaveChanges();

            //send email to user

            return Ok(schedule);
        }

        [HttpGet("GetScheduleDetails")]
        public IActionResult GetScheduleDetails([FromQuery] int scheduleId)
        {
            Schedule schedule = dbContext.Schedules
                .Include(x => x.Status)
                .Where(x => x.Id == scheduleId)
                .FirstOrDefault();

            if (schedule == null)
                return BadRequest("Schedule doesn't exists!");

            return Ok(schedule);
        }
    }
}
