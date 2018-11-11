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
        [DataType(DataType.Date)]
        public DateTime StartDateTime { get; set; }
        public int ResultId { get; set; }
        public int ClientId { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

        public virtual Result Result { get; set; }
        public virtual Client Client { get; set; }

    }
}
