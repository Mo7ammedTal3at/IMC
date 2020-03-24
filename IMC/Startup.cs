using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IMC.Startup))]
namespace IMC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
