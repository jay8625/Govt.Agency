using Govt.Agency.DAL.Model;
using Microsoft.EntityFrameworkCore;

public class Govt_AgencyContext : DbContext
{
    public Govt_AgencyContext(DbContextOptions<Govt_AgencyContext> options)
        : base(options)
    {
    }

    public DbSet<Govt.Agenct.DAL.Model.AgencyInfo> AgencyInfo { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<City> Citys { get; set; }
}
