using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AzureCS.Startup))]
namespace AzureCS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
