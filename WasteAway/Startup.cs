using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WasteAway.Startup))]
namespace WasteAway
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
