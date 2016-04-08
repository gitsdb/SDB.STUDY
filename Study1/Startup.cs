using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Study1.Startup))]
namespace Study1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
