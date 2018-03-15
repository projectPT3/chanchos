using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(projectPT3.Startup))]
namespace projectPT3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
