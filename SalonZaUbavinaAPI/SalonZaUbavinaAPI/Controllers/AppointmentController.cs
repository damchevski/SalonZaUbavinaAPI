using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalonZaUbavinaAPI.DataAccess;
using SalonZaUbavinaAPI.Models;
using SalonZaUbavinaAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SalonZaUbavinaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private BeautySalonContext dbContext;

        public AppointmentController(BeautySalonContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("CreateAppointment")]
        public IActionResult CreateAppointment([FromBody] AppointmentDto appointment)
        {
            if(string.IsNullOrEmpty(appointment.User) 
                || string.IsNullOrEmpty(appointment.AppointmentDescription)
                || string.IsNullOrEmpty(appointment.DateTime)
                || string.IsNullOrEmpty(appointment.UserEmail))
            {
                return BadRequest("Please fill all fields!");
            }

            AppointmentStatus statusNew = dbContext.AppointmentStatuses.Where(x => x.Status.Equals("New")).FirstOrDefault();

            if (statusNew == null)
                return BadRequest("Error, please try again later!");

            Appointment newappointment = new Appointment()
            {
                DateTime = DateTime.Parse(appointment.DateTime,CultureInfo.InvariantCulture),
                AppointmentDescription = appointment.AppointmentDescription,
                StatusId = statusNew.Id,
                User = appointment.User,
                UserEmail = appointment.UserEmail,
                PhoneNumber = appointment.PhoneNumber
            };

            List<Appointment> allappointments = dbContext.Appointments.ToList();

            if (allappointments.Any(x => x.DateTime.Equals(newappointment.DateTime)))
                return BadRequest("The term is reserved!");

            dbContext.Appointments.Add(newappointment);
            dbContext.SaveChanges();

            return Ok(newappointment);
        }

        [HttpGet("GetAllAppointmentsForDate")]
        public IActionResult GetAllAppointmentsForDate([FromQuery] string date)
        {
            if (string.IsNullOrEmpty(date))
                return Ok(dbContext.Appointments
                    .Include(x => x.Status)
                    .ToList());

            DateTime dateRequest = DateTime.Parse(date);

            return Ok(dbContext.Appointments
                .Include(x => x.Status)
                .Where(x => x.DateTime.Day == dateRequest.Day && x.DateTime.Month == dateRequest.Month)
                .ToList());
        }

        [HttpGet("GetAllFreeTermsForDay")]
        public IActionResult GetAllFreeTermsForDay([FromQuery] int day)
        {
            List<Appointment> allappointmentsForDay = new List<Appointment>();

            foreach(var sch in dbContext.Appointments.ToList())
            {
                var schDateParsed = DateTime.Parse(sch.DateTime.ToString(), CultureInfo.InvariantCulture);
                if (schDateParsed.Month == DateTime.Now.Month &&
                    schDateParsed.Day == day)
                {
                    allappointmentsForDay.Add(sch);
                }
            }

            List<int> times = new List<int>();

            for(int i = 8; i <= 16; i++)
            {
                if (!allappointmentsForDay.Any(x => x.DateTime.Hour == i)){
                    times.Add(i);
                }
            }

            return Ok(times);
        }

        [HttpPost("MarkAppointmentAs")]
        public IActionResult MarkAppointmentAs([FromQuery] int appointmentId, [FromQuery] bool approved)
        {
            Appointment appointment = dbContext.Appointments
                .Where(x => x.Id == appointmentId)
                .FirstOrDefault();

            if (appointment == null)
                return BadRequest("Appointment doesn't exists!");

            string searchStatus = "Approved";
            if (!approved) { searchStatus = "Denied"; }

            AppointmentStatus statusApproved = dbContext.AppointmentStatuses
                .Where(x => x.Status == searchStatus)
                .FirstOrDefault();

            if (statusApproved == null)
                return BadRequest("Error!");

            appointment.StatusId = statusApproved.Id;

            dbContext.Update(appointment);
            dbContext.SaveChanges();

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("testakau35@gmail.com", "Proekt123!")
            };

            var additionalMessage = searchStatus == "Approved" ? "We expect you on: " + appointment.DateTime.ToString() : "";
            using (var message = new MailMessage("testakau35@gmail.com", appointment.UserEmail)
            {
                Subject = "Your term was "+ searchStatus +"!",
                Body = "Your term in our salon was " + searchStatus + "!" + additionalMessage
            })
            {
                smtp.Send(message);
            }

            return Ok(appointment);
        }

        [HttpGet("GetAppointmentDetails")]
        public IActionResult GetAppointmentDetails([FromQuery] int appointmentId)
        {
            Appointment appointment = dbContext.Appointments
                .Include(x => x.Status)
                .Where(x => x.Id == appointmentId)
                .FirstOrDefault();

            if (appointment == null)
                return BadRequest("Appointment doesn't exists!");

            return Ok(appointment);
        }
    }
}
