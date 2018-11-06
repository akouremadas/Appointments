using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Entities
{
    public class Client : ModelBase
    {
        public string Name { get; set; }
        public Phone Landline { get; set; }
        public Phone Mobile { get; set; }
        public Address ClientAddress { get; set; }
    }
}