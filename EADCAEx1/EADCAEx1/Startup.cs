using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EADCAEx1.Startup))]
namespace EADCAEx1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
