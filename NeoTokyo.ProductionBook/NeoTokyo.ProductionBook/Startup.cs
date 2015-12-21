using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NeoTokyo.ProductionBook.Startup))]
namespace NeoTokyo.ProductionBook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
