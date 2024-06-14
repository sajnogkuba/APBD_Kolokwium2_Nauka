using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<BackpackSlot> BackpackSlots { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new Item
            {
                ItemPK = 1,
                ItemName = "Miecz na potwory",
                ItemWeight = 50
            },
            new Item
            {
                ItemPK = 2,
                ItemName = "TestItem2",
                ItemWeight = 20
            },
            new Item
            {
                ItemPK = 3,
                ItemName = "TestItem3",
                ItemWeight = 30
            }
        });

        modelBuilder.Entity<Character>().HasData(new List<Character>()
        {
            new Character()
            {
                CharacterPK = 1,
                CharacterFirstName = "Siwy",
                CharacterLastName = "Geralt",
                CharacterCurrentWeight = 100,
                CharacterMaxWeight = 300,
                CharacterMoney = 100
            },
            new Character()
            {
                CharacterPK = 2,
                CharacterFirstName = "TestFirstName",
                CharacterLastName = "TestLastName",
                CharacterCurrentWeight = 0,
                CharacterMaxWeight = 300,
                CharacterMoney = 150
            },
            new Character()
            {
                CharacterPK = 3,
                CharacterFirstName = "TestFirstName2",
                CharacterLastName = "TestLastName2",
                CharacterCurrentWeight = 0,
                CharacterMaxWeight = 400,
                CharacterMoney = 200
            }
        });
        
        modelBuilder.Entity<Title>().HasData(new List<Title>()
        {
            new Title()
            {
                TitlePK = 1,
                TitleName = "Biały Wilk"
            },
            new Title()
            {
                TitlePK = 2,
                TitleName = "Gwynbleidd"
            },
            new Title()
            {
                TitlePK = 3,
                TitleName = "TestTitle3"
            },
        });
        
        modelBuilder.Entity<BackpackSlot>()
            .HasOne(b => b.Character)
            .WithMany(c => c.BackpackSlots)
            .HasForeignKey(b => b.CharacterFK)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<BackpackSlot>()
            .HasOne(b => b.Item)
            .WithMany(c => c.BackpackSlots)
            .HasForeignKey(b => b.ItemFK)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<CharacterTitle>()
            .HasOne(b => b.Character)
            .WithMany(c => c.CharacterTitles)
            .HasForeignKey(b => b.CharacterFK)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<CharacterTitle>()
            .HasOne(b => b.Title)
            .WithMany(c => c.CharacterTitles)
            .HasForeignKey(b => b.TitleFK)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<BackpackSlot>().HasData(new List<BackpackSlot>()
        {
            new BackpackSlot()
            {
                BackpackSlotPK = 1,
                CharacterFK = 1,
                ItemFK = 1,
            },
            new BackpackSlot()
            {
                BackpackSlotPK = 2,
                CharacterFK = 1,
                ItemFK = 2,
            }
        });
        
        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>()
        {
            new CharacterTitle()
            {
                TitleFK = 1,
                CharacterFK = 1,
                CharacterTitleAquireAt = DateTime.Now
            },
            new CharacterTitle()
            {
                TitleFK = 2,
                CharacterFK = 1,
                CharacterTitleAquireAt = DateTime.Now
            }
        });
    }
}