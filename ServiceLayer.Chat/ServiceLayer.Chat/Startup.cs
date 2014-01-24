using Microsoft.Owin;
using Owin;
using ServiceLayer.Chat;

[assembly: OwinStartup(typeof(ServiceLayer.Chat.Startup))]
namespace ServiceLayer.Chat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}