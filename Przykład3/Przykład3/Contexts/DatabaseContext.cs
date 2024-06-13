using Microsoft.EntityFrameworkCore;
using Przykład3.Models;

namespace Przykład3.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<ClientCategory> ClientCategories { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<BoatStandard> BoatStandards { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Sailboat> Sailboats { get; set; }
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<SailboatReservation>().HasKey(sr => new {sr.SailboatReservationSailboatId, sr.SailboatReservationReservationId});
        
        modelBuilder.Entity<SailboatReservation>()
            .HasOne(sr => sr.Sailboat)
            .WithMany(s => s.SailboatReservations)
            .HasForeignKey(sr => sr.SailboatReservationSailboatId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<SailboatReservation>()
            .HasOne(sr => sr.Reservation)
            .WithMany(r => r.SailboatReservations)
            .HasForeignKey(sr => sr.SailboatReservationReservationId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ClientCategory>().HasData(new List<ClientCategory>()
        {
            new ClientCategory()
            {
                ClientCategoryId = 1,
                ClientCategoryName = "Test",
                ClientCategoryDiscountPercentage = 10
            },
            new ClientCategory()
            {
                ClientCategoryId = 2,
                ClientCategoryName = "Test2",
                ClientCategoryDiscountPercentage = 20
            },
            new ClientCategory()
            {
                ClientCategoryId = 3,
                ClientCategoryName = "Test3",
                ClientCategoryDiscountPercentage = 30
            }
        });
        
        modelBuilder.Entity<Client>().HasData(new List<Client>()
        {
            new Client()
            {
                ClientId = 1,
                ClientName = "Test",
                ClientLastName = "Test",
                ClientBirthday = new DateTime(2000, 1, 1),
                ClientPesel = "54345678901",
                ClientEmail = "test@gmail.com",
                ClientCategoryId = 1
            },
            new Client()
            {
                ClientId = 2,
                ClientName = "Test2",
                ClientLastName = "Test2",
                ClientBirthday = new DateTime(2002, 2, 2),
                ClientPesel = "12345678901",
                ClientEmail = "test2@gmail.com",
                ClientCategoryId = 2
            },
            new Client()
            {
                ClientId = 3,
                ClientName = "Test3",
                ClientLastName = "Test3",
                ClientBirthday = new DateTime(2003, 3, 3),
                ClientPesel = "69345678901",
                ClientEmail = "tes3@gmail.com",
                ClientCategoryId = 3
            }
        });
        
        modelBuilder.Entity<BoatStandard>().HasData(new List<BoatStandard>()
        {
            new BoatStandard()
            {
                BoatStandardId = 1,
                BoatStandardName = "Test",
                BoatStandardLevel = 1
            },
            new BoatStandard()
            {
                BoatStandardId = 2,
                BoatStandardName = "Test2",
                BoatStandardLevel = 2
            },
            new BoatStandard()
            {
                BoatStandardId = 3,
                BoatStandardName = "Test3",
                BoatStandardLevel = 3
            }
        });
        
        modelBuilder.Entity<Reservation>().HasData(new List<Reservation>()
        {
            new Reservation()
            {
                ReservationId = 1,
                ReservationClientId = 1,
                ReservationDateFrom = new DateTime(2024, 5,3),
                ReservationDateTo = new DateTime(2024, 5, 5),
                ReservationBoatStandardId = 1,
                ReservationCapacity = 1,
                ReservationNumOfBoats = 3,
                ReservationFulfilled = false,
                ReservationPrice = 100,
                ReservationCancelReason = null
            },
            new Reservation()
            {
                ReservationId = 2,
                ReservationClientId = 2,
                ReservationDateFrom = new DateTime(2024, 7,3),
                ReservationDateTo = new DateTime(2024, 7, 5),
                ReservationBoatStandardId = 2,
                ReservationCapacity = 3,
                ReservationNumOfBoats = 2,
                ReservationFulfilled = true,
                ReservationPrice = 300,
                ReservationCancelReason = null
            },
            new Reservation()
            {
                ReservationId = 3,
                ReservationClientId = 1,
                ReservationDateFrom = new DateTime(2024, 7,3),
                ReservationDateTo = new DateTime(2024, 7, 5),
                ReservationBoatStandardId = 3,
                ReservationCapacity = 13,
                ReservationNumOfBoats = 5,
                ReservationFulfilled = true,
                ReservationPrice = 1300,
                ReservationCancelReason = "TEST"
            }
        });
        
        modelBuilder.Entity<Sailboat>().HasData(new List<Sailboat>()
        {
            new Sailboat()
            {
                SailboatId = 1,
                SailboatName = "Test",
                SailboatCapacity = 1,
                SailboatDescription = "Test",
                SailboatBoatStandardId = 1,
                SailboatPrice = 100
            },
            new Sailboat()
            {
                SailboatId = 2,
                SailboatName = "Test2",
                SailboatCapacity = 2,
                SailboatDescription = "Test2",
                SailboatBoatStandardId = 2,
                SailboatPrice = 200
            },
            new Sailboat()
            {
                SailboatId = 3,
                SailboatName = "Test3",
                SailboatCapacity = 3,
                SailboatDescription = "Test3",
                SailboatBoatStandardId = 3,
                SailboatPrice = 300
            }
        });
        
        modelBuilder.Entity<SailboatReservation>().HasData(new List<SailboatReservation>()
        {
            new SailboatReservation()
            {
                SailboatReservationReservationId = 1,
                SailboatReservationSailboatId = 1
            },
            new SailboatReservation()
            {
                SailboatReservationReservationId = 2,
                SailboatReservationSailboatId = 2
            },
            new SailboatReservation()
            {
                SailboatReservationReservationId = 2,
                SailboatReservationSailboatId = 3
            },
            new SailboatReservation()
            {
                SailboatReservationReservationId = 2,
                SailboatReservationSailboatId = 1
            },
            new SailboatReservation()
            {
                SailboatReservationReservationId = 3,
                SailboatReservationSailboatId = 1
            },
            new SailboatReservation()
            {
                SailboatReservationReservationId = 3,
                SailboatReservationSailboatId = 2
            }
        });

    }
}