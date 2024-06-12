using Microsoft.EntityFrameworkCore;
using Przyklad1.Models;

namespace Przyklad1.Context;

public class DataBaseContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<ProductCategory> ProductsCategories { get; set; }

    protected DataBaseContext()
    {
    }
    
    public DataBaseContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ProductCategory>().HasKey(pc => new { pc.ProductID, pc.CategoryID});
        modelBuilder.Entity<ShoppingCart>().HasKey(sc => new { sc.ProductID, sc.AccountID});

        modelBuilder.Entity<Role>().HasData(new List<Role>()
        {
            new Role()
            {
                RoleID = 1,
                RoleName = "Admin"
            },
            new Role()
            {
                RoleID = 2,
                RoleName = "User"
            },
            new Role()
            {
                RoleID = 3,
                RoleName = "Guest"
            }
        });
        
        modelBuilder.Entity<Account>().HasData(new List<Account>()
        {
            new Account()
            {
                AccountID = 1,
                RoleID = 1,
                AccountFirstName = "John",
                AccountLastName = "Doe",
                AccountEmail = "test@gmail.com",
                AccountPhone = "123456789"
            },
            new Account()
            {
                AccountID = 2,
                RoleID = 2,
                AccountFirstName = "Jane",
                AccountLastName = "Doe",
                AccountEmail = "test2@gmail.com",
                AccountPhone = "987654321"
            },
            new Account()
            {
                AccountID = 3,
                RoleID = 3,
                AccountFirstName = "John",
                AccountLastName = "Smith",
                AccountEmail = "test3@gmail.com",
                AccountPhone = "666666789"
            }
        });
        
        
        modelBuilder.Entity<Product>().HasData(new List<Product>()
        {
            new Product()
            {
                ProductID = 1,
                ProductName = "TestProduct",
                ProductWidth = (decimal)0.1,
                ProductHeight = (decimal)0.2,
                ProductDepth = (decimal)0.3,
                ProductWeight = (decimal)0.4
            },
            new Product()
            {
                ProductID = 2,
                ProductName = "TestProduct2",
                ProductWidth = (decimal)0.5,
                ProductHeight = (decimal)0.6,
                ProductDepth = (decimal)0.7,
                ProductWeight = (decimal)0.8
            },
            new Product()
            {
                ProductID = 3,
                ProductName = "TestProduct3",
                ProductWidth = (decimal)0.9,
                ProductHeight = (decimal)1.0,
                ProductDepth = (decimal)1.1,
                ProductWeight = (decimal)1.2
            }
        });
        
        modelBuilder.Entity<Category>().HasData(new List<Category>()
        {
            new Category()
            {
                CategoryID = 1,
                CategoryName = "TestCategory"
            },
            new Category()
            {
                CategoryID = 2,
                CategoryName = "TestCategory2"
            },
            new Category()
            {
                CategoryID = 3,
                CategoryName = "TestCategory3"
            }
        });
        
        modelBuilder.Entity<ShoppingCart>().HasData(new List<ShoppingCart>()
        {
            new ShoppingCart()
            {
                AccountID = 1,
                ProductID = 1,
                ShoppingCartAmount = 1
            },
            new ShoppingCart()
            {
                AccountID = 1,
                ProductID = 2,
                ShoppingCartAmount = 12
            },
            new ShoppingCart()
            {
                AccountID = 2,
                ProductID = 2,
                ShoppingCartAmount = 2
            },
            new ShoppingCart()
            {
                AccountID = 3,
                ProductID = 3,
                ShoppingCartAmount = 3
            }
        });
        
        
        modelBuilder.Entity<ProductCategory>().HasData(new List<ProductCategory>()
        {
            new ProductCategory()
            {
                ProductID = 1,
                CategoryID = 1
            },
            new ProductCategory()
            {
                ProductID = 2,
                CategoryID = 2
            },
            new ProductCategory()
            {
                ProductID = 3,
                CategoryID = 3
            }
        });
    }
    
    
}