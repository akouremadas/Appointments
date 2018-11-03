using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Entities
{
    public class Address : ModelBase
    {
        public string Prefecture { get; set; }
        public string Municipality { get; set; }
        public string Area { get; set; }
        public string Street { get; set; }      
        public string Postal { get; set; }
    }
}
