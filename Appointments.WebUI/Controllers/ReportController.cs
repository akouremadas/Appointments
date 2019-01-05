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
    }
}