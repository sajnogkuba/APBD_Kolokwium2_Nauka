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
            
    }
}