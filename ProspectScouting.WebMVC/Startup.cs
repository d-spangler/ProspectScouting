using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProspectScouting.WebMVC.Startup))]
namespace ProspectScouting.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
