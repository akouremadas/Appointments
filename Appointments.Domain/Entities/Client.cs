using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Entities
{
    public class Client : ModelBase
    {
        public string Name { get; set; }

        public string Prefecture { get; set; }
        public string Municipality { get; set; }
        public string Area { get; set; }
        public string Street { get; set; }

        [Display(Name = "Zip Code")]
        public string Postal { get; set; }
        public string Mobile { get; set; }

        [Display(Name = "Fixed Line")]
        public string Fixed_Line { get; set; }
        public string Email { get; set; }
        
        public virtual ICollection<Appointment> Appointments { get; set; }
        //public Phone Landline { get; set; }
        //public Phone Mobile { get; set; }
        //public Address ClientAddress { get; set; }
        //public virtual ICollection<Phone> Phones { get; set; }
        //public virtual ICollection<Address> Addresses { get; set; }
    }
}