using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShopWebApp2.Startup))]
namespace ShopWebApp2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
