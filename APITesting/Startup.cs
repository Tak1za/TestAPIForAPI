using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(APITesting.Startup))]
namespace APITesting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
