using Appointments.Domain.Abstract;
using Appointments.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointments.Domain.Concrete
{
    public class ClientRepository : IClientRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
    }
}
