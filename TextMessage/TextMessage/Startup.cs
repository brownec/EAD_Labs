using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TextMessage.Startup))]
namespace TextMessage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
