using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataLayer
{
    public class EFDBContext : DbContext
    {
        public DbSet<Team> Team { get; set; }
        public DbSet<Footballer> Footballer { get; set; }

        public EFDBContext(DbContextOptions<EFDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }

    // <summary>
    // For Migrations
    // </summary>
    public class EFDBContextFactory : IDesignTimeDbContextFactory<EFDBContext>
    {
        public EFDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EFDBContext>();
            optionsBuilder.UseNpgsql("Host=postgres;Port=5432;Database=66bitFootballer;Username=postgres;Password=Kot_Kuzma1", b => b.MigrationsAssembly("DataLayer"));
            //optionsBuilder.UseNpgsql("Host=postgres;Port=5432;Database=66bitFootballer;Username=postgres;Password=Kot_Kuzma1", b => b.MigrationsAssembly("DataLayer"));

            return new EFDBContext(optionsBuilder.Options);
        }
    }
}
