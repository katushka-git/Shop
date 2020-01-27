using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyReklama.Startup))]
namespace MyReklama
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
