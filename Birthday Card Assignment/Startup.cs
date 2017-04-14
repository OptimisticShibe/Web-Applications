using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Birthday_Card_Assignment.Startup))]
namespace Birthday_Card_Assignment
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
