using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Buoi_3_Bai_1.Startup))]
namespace Buoi_3_Bai_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
