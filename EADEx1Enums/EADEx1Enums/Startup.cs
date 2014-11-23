using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EADEx1Enums.Startup))]
namespace EADEx1Enums
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
