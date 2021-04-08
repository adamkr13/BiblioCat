using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BiblioCat.WebMVC.Startup))]
namespace BiblioCat.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
