using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyOneSignalDemo.Startup))]
namespace MyOneSignalDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
