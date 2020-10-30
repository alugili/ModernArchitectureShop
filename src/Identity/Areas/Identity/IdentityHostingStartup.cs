using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(IdentityServer.Areas.Identity.IdentityHostingStartup))]
namespace IdentityServer.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}
