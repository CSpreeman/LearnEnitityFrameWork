using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LearnEF;
using LearnEF.Models;

namespace LearnEF.Controllers.ApiControllers
{
    [RoutePrefix("api/appt")]
    public class AppointmentsApiController : ApiController
    {
        private VetDbModel db = new VetDbModel();

        // GET: api/AppointmentsApi
        [Route(""), HttpGet]
        public IQueryable<Appointment> GetAnimals()
        {
            return db.Appointments;
        }

        // GET: api/AppointmentsApi/5
        [Route("{id:int}"), HttpGet]
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult GetAppointment(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return Ok(appointment);
        }

        // PUT: api/AppointmentsApi/5
        [Route("{id:int}", Name = "ConfirmAppointment"), HttpPut]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAppointment(int id, Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != appointment.Appointment_Id)
            {
                return BadRequest();
            }

            db.Entry(appointment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtRoute("ConfirmAppointment", new { id = appointment.Appointment_Id }, id);
        }

        // POST: api/AppointmentsApi
        [Route("", Name = "PostAppointment"), HttpPost]
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult PostAppointment(Appointment appointment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            appointment.AppointmentStatus = 0;
            appointment.CreatedDateTime = DateTime.Now;
            db.Animals.Add(appointment);
            db.SaveChanges();

            return CreatedAtRoute("PostAppointment", new { id = appointment.Appointment_Id }, appointment);
        }

        // DELETE: api/AppointmentsApi/5
        [Route("{id:int}"), HttpDelete]
        [ResponseType(typeof(Appointment))]
        public IHttpActionResult DeleteAppointment(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return NotFound();
            }

            db.Animals.Remove(appointment);
            db.SaveChanges();

            return Ok(appointment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppointmentExists(int id)
        {
            return db.Animals.Count(e => e.Animal_Id == id) > 0;
        }
    }
}