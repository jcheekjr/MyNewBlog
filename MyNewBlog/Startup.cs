using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyNewBlog.Startup))]
namespace MyNewBlog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
