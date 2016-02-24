using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyDailyDairy.UI.Startup))]
namespace MyDailyDairy.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
