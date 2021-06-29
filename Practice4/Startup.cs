using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Practice4.Startup))]
namespace Practice4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
