using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Appointments.Domain.Abstract;
using Appointments.Domain.Entities;
using Appointments.Domain.Concrete;
using System.Web.Mvc;

namespace Team3Store.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IAppointmentRepository>().To<AppointmentRepository>();
            kernel.Bind<IClientRepository>().To<ClientRepository>();
            kernel.Bind<IResultRepository>().To<ResultRepository>();
            kernel.Bind<IAddressRepository>().To<AddressRepository>();
            kernel.Bind<IPhoneRepository>().To<PhoneRepository>();
        }
    }
}