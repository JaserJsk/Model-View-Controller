using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AddressBookApp.Startup))]
namespace AddressBookApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
