using ConsoleApp1;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class AppDbContext : DbContext
{
    // Tables générées automatiquement par EF Core
    public DbSet<Person> Persons { get; set; }
    public DbSet<Classe> Classes { get; set; }
    public DbSet<Detail> Details { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
    {
    }

    public AppDbContext() { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relation Classe -> Person (1..n)
        modelBuilder.Entity<Person>()
            .HasOne(p => p.Classe)
            .WithMany(c  => c.Persons)
            .HasForeignKey(p => p.ClasseId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Charger la configuration manuellement
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(
                @"C:\\Users\\Landry\\RiderProjects\\ConsoleApp1\\appsettings.json")
            .Build();

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
