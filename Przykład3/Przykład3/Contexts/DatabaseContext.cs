using Microsoft.EntityFrameworkCore;

namespace Przykład3.Contexts;

public class DatabaseContext : DbContext
{
    // public DbSet<Album> Albumy { get; set; }
    // ...
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}