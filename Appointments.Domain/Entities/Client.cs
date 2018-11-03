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
        public virtual Phone Landline { get; set; }
        public virtual Phone Mobile { get; set; }
        public virtual Address ClientAddress { get; set; }
    }
}
