namespace Appointments.Domain.Migrations
{
    using Appointments.Domain.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;

    public sealed class DbMigrationsConfig : DbMigrationsConfiguration<Appointments.Domain.Entities.ApplicationDbContext>
    {
        public DbMigrationsConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            const string name = "admin@admin.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";


            if (!context.Roles.Any(r => r.Name == roleName))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = roleName };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == name))
            {

                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser {UserName = name, Email = name };

                manager.Create(user, password) ;
                manager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
