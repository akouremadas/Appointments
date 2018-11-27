using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Entities
{
    public class Appointment : ModelBase
    {
        [Display(Name ="Appointment Date & Time")]
        [DataType(DataType.Date)]
        public DateTime StartDateTime { get; set; }

        [Display(Name = "Appointment Result")]
        public int ResultId { get; set; }

        [Display(Name = "Client Name")]
        public int ClientId { get; set; }

        [Display(Name = "Appointment Comments")]
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        public virtual Result Result { get; set; }
        public virtual Client Client { get; set; }

    }
}
