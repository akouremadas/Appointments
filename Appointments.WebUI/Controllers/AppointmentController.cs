using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Appointments.Domain.Entities;

namespace Appointments.WebUI.Controllers
{
    [Authorize]
    public class AppointmentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Appointment
        public ActionResult Index()
        {
            var appointments = db.Appointments.Include(a => a.Client).Include(a => a.Result);
            return View(appointments.ToList());
        }

        // GET: Appointment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // GET: Appointment/Create
        public ActionResult Create(int? clID)
        {
            if (clID == null)
            {
                ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name");
                ViewBag.ResultId = new SelectList(db.Results, "Id", "ResultName");
                return View();
            }

            else
            {
                ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", clID);
                ViewBag.ResultId = new SelectList(db.Results, "Id", "ResultName");
                return View();
            }

        }

        // POST: Appointment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartDateTime,ResultId,ClientId,Comments,DateCreated,DateUpdated,CreatedBy,UpdatedBy")] Appointment appointment, int? clID)
        {

            if (clID == null)
            {
                if (ModelState.IsValid)
                {
                    appointment.DateCreated = DateTime.Now;
                    appointment.DateUpdated = DateTime.Now;
                    appointment.CreatedBy = User.Identity.Name;
                    appointment.UpdatedBy = User.Identity.Name;

                    db.Appointments.Add(appointment);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", appointment.ClientId);
                ViewBag.ResultId = new SelectList(db.Results, "Id", "ResultName", appointment.ResultId);
                return View(appointment);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    appointment.DateCreated = DateTime.Now;
                    appointment.DateUpdated = DateTime.Now;
                    appointment.CreatedBy = User.Identity.Name;
                    appointment.UpdatedBy = User.Identity.Name;
                    appointment.ClientId = (int)clID;

                    db.Appointments.Add(appointment);
                    db.SaveChanges();
                    return RedirectToAction("Details", "Client", new { id = clID});
                }

                ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", appointment.ClientId = (int)clID);
                ViewBag.ResultId = new SelectList(db.Results, "Id", "ResultName", appointment.ResultId);
                return View(appointment);
            }

            
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int? id, int? clID)
        {
            

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }

            if (clID == null)
            {
                ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", appointment.ClientId);
            }
            else //not working!!!
            {
                ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", appointment.ClientId == clID);
            }
            
            ViewBag.ResultId = new SelectList(db.Results, "Id", "ResultName", appointment.ResultId);
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDateTime,ResultId,ClientId,Comments,DateCreated,DateUpdated,CreatedBy,UpdatedBy")] Appointment appointment, int? clID)
        {

            if (clID == null)
            {
                if (ModelState.IsValid)
                {
                    appointment.DateUpdated = DateTime.Now;
                    appointment.UpdatedBy = User.Identity.Name;

                    db.Entry(appointment).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", appointment.ClientId);
                ViewBag.ResultId = new SelectList(db.Results, "Id", "ResultName", appointment.ResultId);
                return View(appointment);
            }

            else
            {
                if (ModelState.IsValid)
                {
                    appointment.DateUpdated = DateTime.Now;
                    appointment.UpdatedBy = User.Identity.Name;
                    appointment.ClientId = (int)clID;

                    db.Entry(appointment).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Details", "Client", new { id = clID });
                }
                ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", appointment.ClientId = (int)clID);
                ViewBag.ResultId = new SelectList(db.Results, "Id", "ResultName", appointment.ResultId);
                return View(appointment);
            }
            
        }

        // GET: Appointment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointments.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment appointment = db.Appointments.Find(id);
            db.Appointments.Remove(appointment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
