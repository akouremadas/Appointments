using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Appointments.Domain.Entities;
using Appointments.WebUI.Models;

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


                var role = db.Roles.FirstOrDefault(m => m.Name == "Sales Rep");
                ViewBag.UserId = new SelectList(db.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)), "Id","FullName");

                ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name");
                ViewBag.ResultId = new SelectList(db.Results, "Id", "ResultName");
                

                return View();
            }

            else
            {
                var role = db.Roles.FirstOrDefault(m => m.Name == "Sales Rep");
                ViewBag.UserId = new SelectList(db.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)), "Id", "FullName");

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
        public ActionResult Create([Bind(Include = "Id,StartDateTime,ResultId,ClientId,Comments,DateCreated,DateUpdated,CreatedBy,UpdatedBy,UserId,SalesMan")] Appointment appointment, int? clID)
        {
            

            if (clID == null)
            {
                if (ModelState.IsValid)
                {
                    appointment.DateCreated = DateTime.Now;
                    appointment.DateUpdated = DateTime.Now;
                    appointment.CreatedBy = User.Identity.Name;
                    appointment.UpdatedBy = User.Identity.Name;


                    //commented code is not working!
                    //if (User.IsInRole("Sales Rep"))
                    //{
                    //    User user = db.Users.Find(User.Identity.Name);

                    //    appointment.UserId = user.Id;

                    //}

                    db.Appointments.Add(appointment);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                var role = db.Roles.FirstOrDefault(m => m.Name == "Sales Rep");
                ViewBag.UserId = new SelectList(db.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)), "Id", "FullName");

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

                    //commented code is not working!
                    //if (User.IsInRole("Sales Rep"))
                    //{
                    //    User user = db.Users.Find(User.Identity.Name);

                    //    appointment.UserId = user.Id;

                    //}

                    db.Appointments.Add(appointment);
                    db.SaveChanges();
                    return RedirectToAction("Details", "Client", new { id = clID});
                }

                var role = db.Roles.FirstOrDefault(m => m.Name == "Sales Rep");
                ViewBag.UserId = new SelectList(db.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)), "Id", "FullName");

                ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", appointment.ClientId = (int)clID);
                ViewBag.ResultId = new SelectList(db.Results, "Id", "ResultName", appointment.ResultId);
                return View(appointment);
            }

            
        }

        // GET: Appointment/Edit/5
        public ActionResult Edit(int? id, int? clID, string uid)
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

                var role = db.Roles.FirstOrDefault(m => m.Name == "Sales Rep");
                ViewBag.UserId = new SelectList(db.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)), "Id", "FullName", appointment.UserId == uid);
            }
            else //not working!!!
            {
                ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", appointment.ClientId = (int)clID);

                var role = db.Roles.FirstOrDefault(m => m.Name == "Sales Rep");
                ViewBag.UserId = new SelectList(db.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)), "Id", "FullName", appointment.UserId == uid);
            }
            
            ViewBag.ResultId = new SelectList(db.Results, "Id", "ResultName", appointment.ResultId);
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDateTime,ResultId,ClientId,Comments,DateCreated,DateUpdated,CreatedBy,UpdatedBy,UserId,SalesMan")] Appointment appointment, int? clID)
        {

            if (clID == null)
            {
                if (ModelState.IsValid)
                {
                    appointment.DateUpdated = DateTime.Now;
                    appointment.UpdatedBy = User.Identity.Name;

                    //commented code is not working!
                    //if (User.IsInRole("Sales Rep"))
                    //{
                    //    User user = db.Users.Find(User.Identity.Name);

                    //    appointment.UserId = user.Id;

                    //}

                    db.Entry(appointment).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                var role = db.Roles.FirstOrDefault(m => m.Name == "Sales Rep");
                ViewBag.UserId = new SelectList(db.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)), "Id", "FullName");

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

                    //commented code is not working!
                    //if (User.IsInRole("Sales Rep"))
                    //{
                    //    User user = db.Users.Find(User.Identity.Name);

                    //    appointment.UserId = user.Id;

                    //}

                    db.Entry(appointment).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Details", "Client", new { id = clID });
                }

                var role = db.Roles.FirstOrDefault(m => m.Name == "Sales Rep");
                ViewBag.UserId = new SelectList(db.Users.Where(m => m.Roles.Any(r => r.RoleId == role.Id)), "Id", "FullName");

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

            appointment.IsDeleted = true;
            appointment.DateDeleted = appointment.DateUpdated;
            appointment.DeletedBy = appointment.UpdatedBy;
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
