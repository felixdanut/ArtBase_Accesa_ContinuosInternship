using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(ArtBase.WebAPI.Startup))]

namespace ArtBase.WebAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
