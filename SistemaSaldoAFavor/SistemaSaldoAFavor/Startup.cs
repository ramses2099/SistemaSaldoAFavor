using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SistemaSaldoAFavor.Startup))]
namespace SistemaSaldoAFavor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
