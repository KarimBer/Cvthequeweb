using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cvthequeweb.Startup))]
namespace Cvthequeweb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
