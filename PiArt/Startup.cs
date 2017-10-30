using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PiArt.Startup))]
namespace PiArt
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
