using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AlgebraSeminar.Startup))]
namespace AlgebraSeminar
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
