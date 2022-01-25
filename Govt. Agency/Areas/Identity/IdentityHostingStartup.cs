using Govt._Agency.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Govt._Agency.Areas.Identity.IdentityHostingStartup))]
namespace Govt._Agency.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Govt_AgencyContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Govt_AgencyContext")));

                services.AddDefaultIdentity<Govt_AgencyUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Govt_AgencyContext>();
            });
        }
    }
}