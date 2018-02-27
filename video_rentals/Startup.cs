using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(video_rentals.Startup))]
namespace video_rentals
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
