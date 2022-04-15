using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TemperatureConverter.Startup))]
namespace TemperatureConverter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
