using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab26.Startup))]
namespace Lab26
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
