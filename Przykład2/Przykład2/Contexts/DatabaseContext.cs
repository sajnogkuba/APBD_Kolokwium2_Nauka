using Microsoft.EntityFrameworkCore;
using Przykład2.Models;

namespace Przykład2.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Album> Albumy { get; set; }
    public DbSet<Utwor> Utwory { get; set; }
    public DbSet<Muzyk> Muzycy { get; set; }
    public DbSet<Wytwornia> Wytwornie { get; set; }
    public DbSet<WykonawcaUtwor> WykonawcyUtwory { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<WykonawcaUtwor>()
            .HasKey(wu => new { wu.IdWMuzyk, wu.IdUtwor });

        modelBuilder.Entity<Muzyk>()
            .HasData(new List<Muzyk>()
            {
                new Muzyk()
                {
                    IdMuzyk = 1,
                    Imie = "Jan",
                    Nazwisko = "Kowalski",
                    Pseudonim = "Kowal"
                },
                new Muzyk()
                {
                    IdMuzyk = 2,
                    Imie = "Anna",
                    Nazwisko = "Nowak",
                    Pseudonim = "Nowak"
                },
                new Muzyk()
                {
                    IdMuzyk = 3,
                    Imie = "Piotr",
                    Nazwisko = "Wiśniewski",
                    Pseudonim = "Wiśnia"
                }
            });
        
        modelBuilder.Entity<Utwor>()
            .HasData(new List<Utwor>()
            {
                new Utwor()
                {
                    IdUtwor = 1,
                    NazwaUtworu = "Piosenka1",
                    CzasTrwania = 3.5f,
                    IdAlbum = 2
                },
                new Utwor()
                {
                    IdUtwor = 2,
                    NazwaUtworu = "Piosenka2",
                    CzasTrwania = 4.2f,
                    IdAlbum = 1
                },
                new Utwor()
                {
                    IdUtwor = 3,
                    NazwaUtworu = "Piosenka3",
                    CzasTrwania = 2.8f,
                    IdAlbum = 1
                }
            });
        
        modelBuilder.Entity<Wytwornia>()
            .HasData(new List<Wytwornia>()
            {
                new Wytwornia()
                {
                    IdWytwornia = 1,
                    Nazwa = "Sony Music"
                },
                new Wytwornia()
                {
                    IdWytwornia = 2,
                    Nazwa = "Universal Music"
                },
                new Wytwornia()
                {
                    IdWytwornia = 3,
                    Nazwa = "Warner Music"
                }
            });
        
        modelBuilder.Entity<Album>()
            .HasData(new List<Album>()
            {
                new Album()
                {
                    IdAlbum = 1,
                    NazwaAlbumu = "Album1",
                    DataWydania = new DateTime(2021, 1, 1),
                    IdWytwornia = 1
                },
                new Album()
                {
                    IdAlbum = 2,
                    NazwaAlbumu = "Album2",
                    DataWydania = new DateTime(2021, 2, 1),
                    IdWytwornia = 2
                },
                new Album()
                {
                    IdAlbum = 3,
                    NazwaAlbumu = "Album3",
                    DataWydania = new DateTime(2021, 3, 1),
                    IdWytwornia = 3
                }
            });
        
        modelBuilder.Entity<WykonawcaUtwor>()
            .HasData(new List<WykonawcaUtwor>()
            {
                new WykonawcaUtwor()
                {
                    IdWMuzyk = 1,
                    IdUtwor = 2
                },
                new WykonawcaUtwor()
                {
                    IdWMuzyk = 2,
                    IdUtwor = 1
                },
                new WykonawcaUtwor()
                {
                    IdWMuzyk = 3,
                    IdUtwor = 3
                }
            });
    }
}