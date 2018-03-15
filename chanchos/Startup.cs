using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(chanchos.Startup))]
namespace chanchos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
