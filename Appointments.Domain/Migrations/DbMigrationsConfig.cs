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

    public sealed class DbMigrationsConfig : DbMigrationsConfiguration<ApplicationDbContext>
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

            const string email = "admin@admin.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";
            const string username = "admin";

            if (!context.Roles.Any(r => r.Name == roleName))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole { Name = roleName };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == username))
            {

                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = username, Email = email };

                manager.Create(user, password);
                manager.AddToRole(user.Id, "Admin");
            }

            const string email1 = "spv@admin.com";
            const string password1 = "Spv@123456";
            const string roleName1 = "Supervisor";
            const string username1 = "spv";

            if (!context.Roles.Any(r => r.Name == roleName1))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole { Name = roleName1 };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == username1))
            {

                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = username1, Email = email1 };

                manager.Create(user, password1);
                manager.AddToRole(user.Id, "Supervisor");
            }

            const string email2 = "tl@admin.com";
            const string password2 = "Tl@123456";
            const string roleName2 = "Team Leader";
            const string username2 = "tl";

            if (!context.Roles.Any(r => r.Name == roleName2))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole { Name = roleName2 };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == username2))
            {

                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = username2, Email = email2 };

                manager.Create(user, password2);
                manager.AddToRole(user.Id, "Team Leader");
            }

            const string email3 = "salesrep@admin.com";
            const string password3 = "SalesRep@123456";
            const string roleName3 = "Sales Rep";
            const string username3 = "salesrep";

            if (!context.Roles.Any(r => r.Name == roleName3))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole { Name = roleName3 };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == username3))
            {

                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);
                var user = new User { UserName = username3, Email = email3 };

                manager.Create(user, password3);
                manager.AddToRole(user.Id, "Team Leader");
            }

            context.Results.AddOrUpdate(
                r => r.ResultName,
                new Result { ResultName = "амоивто яамтебоу", DateCreated = DateTime.Now, DateUpdated = DateTime.Now, CreatedBy = "admin", UpdatedBy = "admin" },
                new Result { ResultName = "хетийос", DateCreated = DateTime.Now, DateUpdated = DateTime.Now, CreatedBy = "admin", UpdatedBy = "admin" },
                new Result { ResultName = "аямгтийос", DateCreated = DateTime.Now, DateUpdated = DateTime.Now, CreatedBy = "admin", UpdatedBy = "admin" },
                new Result { ResultName = "ха то сйежтеи", DateCreated = DateTime.Now, DateUpdated = DateTime.Now, CreatedBy = "admin", UpdatedBy = "admin" },
                new Result { ResultName = "деслеусг", DateCreated = DateTime.Now, DateUpdated = DateTime.Now, CreatedBy = "admin", UpdatedBy = "admin" },
                new Result { ResultName = "дем гтам сто выяо", DateCreated = DateTime.Now, DateUpdated = DateTime.Now, CreatedBy = "admin", UpdatedBy = "admin" },
                new Result { ResultName = "меа сумамтгсг", DateCreated = DateTime.Now, DateUpdated = DateTime.Now, CreatedBy = "admin", UpdatedBy = "admin" },
                new Result { ResultName = "кахос йатавыягсг", DateCreated = DateTime.Now, DateUpdated = DateTime.Now, CreatedBy = "admin", UpdatedBy = "admin" }
                );
        }
    }
}
