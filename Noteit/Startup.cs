using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Noteit.Startup))]
namespace Noteit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
