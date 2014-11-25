using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EADCA2.Startup))]
namespace EADCA2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
