using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace Appointments.Domain.Entities
{
    public class Appointment : ModelBase
    {
        [Display(Name ="ΗΜΕΡΟΜΗΝΙΑ/ΩΡΑ")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime StartDateTime { get; set; }

        [Display(Name = "ΚΑΤΑΣΤΑΣΗ ΡΑΝΤΕΒΟΥ")]
        [Required]
        public int ResultId { get; set; }

        [Display(Name = "ΟΝΟΜΑ ΠΕΛΑΤΗ")]
        [Required]
        public int ClientId { get; set; }

        [Display(Name = "ΣΧΟΛΙΑ ΡΑΝΤΕΒΟΥ")]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Comments { get; set; }

        [Display(Name = "ΠΩΛΗΤΗΣ")]
        [Required]
        
        public string UserId { get; set; }

        public virtual IEnumerable<User> User { get; set; }


        public virtual Result Result { get; set; }
        public virtual Client Client { get; set; }


    }
}
