using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Risk.Startup))]
namespace Risk
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
