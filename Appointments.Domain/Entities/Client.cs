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
        
        [Display(Name ="Street Number")]
        public string StrNum { get; set; }

        [Display(Name = "Zip Code")]
        public string Postal { get; set; }
        public string Profession { get; set; }
        public string Mobile { get; set; }

        [Display(Name = "Fixed Line")]
        public string Fixed_Line { get; set; }
        public string Email { get; set; }

        [Display(Name = "Address")]
        public string Address
        {
            get
            {
                return Street + " " + StrNum+", " + Postal + ", " + Area + ", " + Municipality + ", " + Prefecture  ;
            }
        }

        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}