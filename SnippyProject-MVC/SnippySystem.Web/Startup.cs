using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SnippySystem.Web.Startup))]
namespace SnippySystem.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
