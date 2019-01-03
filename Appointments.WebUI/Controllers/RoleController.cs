using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Appointments.Domain.Entities;
using Appointments.WebUI.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Appointments.WebUI.Controllers
{
    [Authorize/*(Roles = "Team Leader,Supervisor,Admin")*/]
    public class RoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Role
        public async Task<ActionResult> Index()
        {
            return View(await db.Roles.ToListAsync());
        }

        public ActionResult RolesWithUsers()
        {
            var rolesWithUsers = (from role in db.Roles
                                  select new
                                  {
                                      RoleId = role.Id,
                                      Name = role.Name,
                                      UserNames = (from roleUser in role.Users
                                                   join user in db.Users on roleUser.UserId
                                                   equals user.Id
                                                   select user.UserName).ToList()
                                  }).ToList().Select(p => new Roles_with_Users_Viewmodel()

                                  {
                                      RoleId = p.RoleId,
                                      Role = p.Name,
                                      Username = string.Join(" ,", p.UserNames)

                                      //Role = string.Join(",", p.RoleNames)
                                  });


            return View(rolesWithUsers);
        }

        // GET: Role/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ApplicationRole applicationRole = db.Roles.Find(id);
        //    if (applicationRole == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(applicationRole);
        //}

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,DateCreated,DateUpdated,CreatedBy,UpdatedBy,IsDeleted,DateDeleted,DeletedBy")] ApplicationRole applicationRole)
        {
            if (ModelState.IsValid)
            {
                applicationRole.DateCreated = DateTime.Now;
                applicationRole.DateUpdated = DateTime.Now;
                applicationRole.CreatedBy = this.User.Identity.Name;
                applicationRole.UpdatedBy = this.User.Identity.Name;

                db.Roles.Add(applicationRole);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(applicationRole);
        }

        // GET: Role/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ApplicationRole applicationRole = db.Roles.Find(id);
        //    if (applicationRole == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(applicationRole);
        //}

        // POST: Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,DateCreated,DateUpdated,CreatedBy,UpdatedBy,IsDeleted,DateDeleted,DeletedBy")] ApplicationRole applicationRole)
        {
            if (ModelState.IsValid)
            {
                applicationRole.DateUpdated = DateTime.Now;
                applicationRole.UpdatedBy = this.User.Identity.Name;

                db.Entry(applicationRole).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(applicationRole);
        }

        // GET: Role/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ApplicationRole applicationRole = db.Roles.Find(id);
        //    if (applicationRole == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(applicationRole);
        //}

        // POST: Role/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(string id)
        //{
        //    ApplicationRole applicationRole = db.Roles.Find(id);
        //    applicationRole.IsDeleted = true;
        //    applicationRole.DateDeleted = applicationRole.DateUpdated;
        //    applicationRole.DeletedBy = this.User.Identity.Name;

        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

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
