using Govt.Agency.DAL.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class Govt_AgencyContext : IdentityDbContext
{
    public Govt_AgencyContext(DbContextOptions<Govt_AgencyContext> options)
        : base(options)
    {
    }

    public DbSet<Govt.Agenct.DAL.Model.AgencyInfo> AgencyInfo { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<City> Citys { get; set; }
    public DbSet<AgencyType> AgencyTypes { get; set; }
}
