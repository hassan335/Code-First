using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Khuari.Startup))]
namespace Khuari
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
