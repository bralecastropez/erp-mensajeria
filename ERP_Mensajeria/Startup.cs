using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ERP_Mensajeria.Startup))]
namespace ERP_Mensajeria
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
