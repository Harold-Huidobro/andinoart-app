using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Andinoart_app.Backend.Startup))]
namespace Andinoart_app.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
