using Microsoft.EntityFrameworkCore;
using Tff.WebApi.Models;

namespace Tff.WebApi.Repositories;


public sealed class BaseDbContext : DbContext
{

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"server= (localdb)\MSSQLLocalDB; Database=Turkiye_ff_db; Trusted_Connection=true");

    }



    public DbSet<Player> Players{ get; set; }
    public DbSet<Referee> Referees { get; set; }
    public DbSet<Team> Teams { get; set; }

}
