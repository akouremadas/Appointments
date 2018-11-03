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
        public DateTime StartDateTime { get; set; }
        public Result Result { get; set; }
        public Client Client { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comments { get; set; }

    }
}
