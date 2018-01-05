using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPNETIdentityDemo.Startup))]
namespace ASPNETIdentityDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
