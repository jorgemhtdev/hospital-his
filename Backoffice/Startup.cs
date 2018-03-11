using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Backoffice.Startup))]
namespace Backoffice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
