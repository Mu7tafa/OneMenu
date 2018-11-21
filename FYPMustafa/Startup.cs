using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FYPMustafa.Startup))]
namespace FYPMustafa
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
