using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Appointments.WebUI.Startup))]
namespace Appointments.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
