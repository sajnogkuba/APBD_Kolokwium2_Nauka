using Microsoft.EntityFrameworkCore;

namespace Przykład4.Contexts;

public class DatabaseContext : DbContext
{
    // public DbSet<Album> Albumy { get; set; }
    // public DbSet<Utwor> Utwory { get; set; }
    // public DbSet<Muzyk> Muzycy { get; set; }
    // public DbSet<Wytwornia> Wytwornie { get; set; }
    // public DbSet<WykonawcaUtwor> WykonawcyUtwory { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}