using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Entities
{
    public class Result : ModelBase
    {
        [Display(Name = "Result")]
        public string ResultName { get; set; }
    }
}
