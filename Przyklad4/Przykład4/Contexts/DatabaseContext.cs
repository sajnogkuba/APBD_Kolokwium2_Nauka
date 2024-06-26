using Microsoft.EntityFrameworkCore;
using Przykład4.Models;

namespace Przykład4.Contexts;

public class DatabaseContext : DbContext
{
    public DbSet<Character> Characters { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Title> Titles { get; set; }
    public DbSet<CharacterTitle> CharacterTitles { get; set; }
    
    protected DatabaseContext()
    {
    }

    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CharacterTitle>().HasKey(ct => new
        {
            ct.CharacterId,
            ct.TitleId
        });

        modelBuilder.Entity<Backpack>().HasKey(b => new
        {
            b.BackpackCharacterId,
            b.BackpackItemId
        });
        
        modelBuilder.Entity<Backpack>()
            .HasOne(b => b.Character)
            .WithMany(c => c.Backpacks)
            .HasForeignKey(b => b.BackpackCharacterId)
            .OnDelete(DeleteBehavior.NoAction);
        
        modelBuilder.Entity<Backpack>()
            .HasOne(b => b.Item)
            .WithMany(c => c.Backpacks)
            .HasForeignKey(b => b.BackpackItemId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Item>().HasData(new List<Item>()
        {
            new Item()
            {
                ItemId = 1,
                ItemName = "TestItem",
                ItemWeight = 10
            },
            new Item()
            {
                ItemId = 2,
                ItemName = "TestItem2",
                ItemWeight = 20
            },
            new Item()
            {
                ItemId = 3,
                ItemName = "TestItem3",
                ItemWeight = 30
            }
        });
        
        modelBuilder.Entity<Character>().HasData(new List<Character>()
        {
            new Character()
            {
                CharacterId = 1,
                CharacterFirstName = "TestCharacterFirstName",
                CharacterLastName = "TestCharacterLastName",
                CharacterCurrentWeight = 0,
                CharacterMaxWeight = 100
            },
            new Character()
            {
                CharacterId = 2,
                CharacterFirstName = "TestCharacterFirstName2",
                CharacterLastName = "TestCharacterLastName2",
                CharacterCurrentWeight = 20,
                CharacterMaxWeight = 120
            },
            new Character()
            {
                CharacterId = 3,
                CharacterFirstName = "TestCharacterFirstName3",
                CharacterLastName = "TestCharacterLastName3",
                CharacterCurrentWeight = 30,
                CharacterMaxWeight = 130
            }
        });
        
        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>()
        {
            new Backpack()
            {
                BackpackCharacterId = 1,
                BackpackItemId = 1,
                BackpackAmount = 1
            },
            new Backpack()
            {
                BackpackCharacterId = 2,
                BackpackItemId = 2,
                BackpackAmount = 2
            },
            new Backpack()
            {
                BackpackCharacterId = 3,
                BackpackItemId = 3,
                BackpackAmount = 3
            }
        });
        
        modelBuilder.Entity<Title>().HasData(new List<Title>()
        {
            new Title()
            {
                TitleId = 1,
                TitleName = "TestTitle"
            },
            new Title()
            {
                TitleId = 2,
                TitleName = "TestTitle2"
            },
            new Title()
            {
                TitleId = 3,
                TitleName = "TestTitle3"
            }
        });
        
        modelBuilder.Entity<CharacterTitle>().HasData(new List<CharacterTitle>()
        {
            new CharacterTitle()
            {
                CharacterId = 1,
                TitleId = 1,
                AcquiredAt = DateTime.Now
            },
            new CharacterTitle()
            {
                CharacterId = 2,
                TitleId = 2,
                AcquiredAt = DateTime.Now
            },
            new CharacterTitle()
            {
                CharacterId = 3,
                TitleId = 3,
                AcquiredAt = DateTime.Now
            }
        });
    }
}