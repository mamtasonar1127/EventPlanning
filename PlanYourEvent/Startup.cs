using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PlanYourEvent.Startup))]
namespace PlanYourEvent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
