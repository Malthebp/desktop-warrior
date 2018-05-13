using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DesktopWarrior.Startup))]
namespace DesktopWarrior
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
