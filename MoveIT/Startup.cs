using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoveIT.Startup))]
namespace MoveIT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
