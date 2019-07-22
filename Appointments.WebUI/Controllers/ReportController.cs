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
    public class ReportController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Report

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Appointment()
        {
            var appointments = db.Appointments.Include(a => a.Client).Include(a => a.Result);
            return View(appointments.ToList());
        }

        public ActionResult Client()
        {
            return View(db.Clients.ToList());
        }

        public ActionResult _Appointment()
        {
           
            var appointments = db.Appointments.Where(a => a.SalesMan == User.Identity.Name).Include(a => a.Client).Include(a => a.Result);
            if (appointments.Count()>0)
            {
                return PartialView(appointments.ToList());
            }
            else
            {
                return Content("Δεν υπάρχουν καταχωρημένα ραντεβού για σήμερα!");
            }
        }

        public ActionResult _Client()
        {
            return PartialView(db.Clients.ToList());
        }
    }
}