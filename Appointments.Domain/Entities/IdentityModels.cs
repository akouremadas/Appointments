using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Appointments.Domain.Entities
{
    // You can add profile data for the user by adding more properties to your User class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        
        public string FullName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool IsDeleted { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime? DateDeleted { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string DeletedBy { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime DateCreated { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime DateUpdated { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string CreatedBy { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UpdatedBy { get; set; }

        public ICollection<ApplicationUserRole> UserRoles { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole: IdentityRole
    {
        [HiddenInput(DisplayValue = false)]
        public DateTime? DateCreated { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime? DateUpdated { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string CreatedBy { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string UpdatedBy { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool? IsDeleted { get; set; }

        [HiddenInput(DisplayValue = false)]
        public DateTime? DateDeleted { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string DeletedBy { get; set; }

        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }

    public class ApplicationUserRole: IdentityUserRole
    {
        public ApplicationUserRole() : base() { }

        public ApplicationRole Role { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Result> Results { get; set; }

        public DbSet<ApplicationRole> IdentityRoles { get; set; }
        public DbSet<ApplicationUserRole> UserRoles { get; set; }

        //public DbSet<Phone> Phones { get; set; }
        //public DbSet<Address> Addresses { get; set; }
    }
}