using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Appointments.Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Appointments.Domain.Entities
{
    // You can add profile data for the user by adding more properties to your User class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        [Display(Name ="Full Name")]
        public string FullName { get; set; }

        [Display(Name = "User Status")]
        [HiddenInput(DisplayValue = false)]
        public bool IsDeleted { get; set; }

        [Display(Name = "Date Status Changed")]
        [HiddenInput(DisplayValue = false)]
        public DateTime? DateDeleted { get; set; }

        [Display(Name = "Status Changed By")]
        [HiddenInput(DisplayValue = false)]
        public string DeletedBy { get; set; }

        [Display(Name = "Date Created")]
        [HiddenInput(DisplayValue = false)]
        public DateTime? DateCreated { get; set; }

        [Display(Name = "Date Updated")]
        [HiddenInput(DisplayValue = false)]
        public DateTime? DateUpdated { get; set; }

        [Display(Name = "Created By")]
        [HiddenInput(DisplayValue = false)]
        public string CreatedBy { get; set; }

        [Display(Name = "Updated By")]
        [HiddenInput(DisplayValue = false)]
        public string UpdatedBy { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, string> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        [Display(Name = "Date Created")]
        [HiddenInput(DisplayValue = false)]
        public DateTime? DateCreated { get; set; }

        [Display(Name = "Date Updated")]
        [HiddenInput(DisplayValue = false)]
        public DateTime? DateUpdated { get; set; }

        [Display(Name = "Created By")]
        [HiddenInput(DisplayValue = false)]
        public string CreatedBy { get; set; }

        [Display(Name = "Updated By")]
        [HiddenInput(DisplayValue = false)]
        public string UpdatedBy { get; set; }

        [Display(Name = "User Role Status")]
        [HiddenInput(DisplayValue = false)]
        public bool? IsDeleted { get; set; }

        [Display(Name = "Date Status Changed")]
        [HiddenInput(DisplayValue = false)]
        public DateTime? DateDeleted { get; set; }

        [Display(Name = "Status Changed By")]
        [HiddenInput(DisplayValue = false)]
        public string DeletedBy { get; set; }

        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }

    public class ExpandedUserDTO
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "User Status")]
        [HiddenInput(DisplayValue = false)]
        public bool IsDeleted { get; set; }

        [Display(Name = "Date Status Changed")]
        [HiddenInput(DisplayValue = false)]
        public DateTime? DateDeleted { get; set; }

        [Display(Name = "Status Changed By")]
        [HiddenInput(DisplayValue = false)]
        public string DeletedBy { get; set; }

        [Display(Name = "Date Created")]
        [HiddenInput(DisplayValue = false)]
        public DateTime? DateCreated { get; set; }

        [Display(Name = "Date Updated")]
        [HiddenInput(DisplayValue = false)]
        public DateTime? DateUpdated { get; set; }

        [Display(Name = "Created By")]
        [HiddenInput(DisplayValue = false)]
        public string CreatedBy { get; set; }

        [Display(Name = "Updated By")]
        [HiddenInput(DisplayValue = false)]
        public string UpdatedBy { get; set; }
        [Key]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        public IEnumerable<UserRolesDTO> Roles { get; set; }
    }

    public class UserRolesDTO
    {
        [Key]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }

    public class UserRoleDTO
    {
        [Key]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }

    public class RoleDTO
    {
        [Key]
        public string Id { get; set; }
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }

    public class UserAndRolesDTO
    {
        [Key]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public List<UserRoleDTO> colUserRoleDTO { get; set; }
    }


    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Result> Results { get; set; }


        //public DbSet<ApplicationRole> IdentityRoles { get; set; }

        //public DbSet<Phone> Phones { get; set; }
        //public DbSet<Address> Addresses { get; set; }
    }
}