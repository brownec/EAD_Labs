using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnumCA1.Startup))]
namespace EnumCA1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
