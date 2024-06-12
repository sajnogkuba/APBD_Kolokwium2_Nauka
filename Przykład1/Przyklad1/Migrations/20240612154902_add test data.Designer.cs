﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Przyklad1.Context;

#nullable disable

namespace Przyklad1.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20240612154902_add test data")]
    partial class addtestdata
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Przyklad1.Models.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_account");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountID"));

                    b.Property<string>("AccountEmail")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("email");

                    b.Property<string>("AccountFirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("first_name");

                    b.Property<string>("AccountLastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("AccountPhone")
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)")
                        .HasColumnName("phone");

                    b.Property<int>("RoleID")
                        .HasColumnType("int")
                        .HasColumnName("FK_role");

                    b.HasKey("AccountID");

                    b.HasIndex("RoleID");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountID = 1,
                            AccountEmail = "test@gmail.com",
                            AccountFirstName = "John",
                            AccountLastName = "Doe",
                            AccountPhone = "123456789",
                            RoleID = 1
                        },
                        new
                        {
                            AccountID = 2,
                            AccountEmail = "test2@gmail.com",
                            AccountFirstName = "Jane",
                            AccountLastName = "Doe",
                            AccountPhone = "987654321",
                            RoleID = 2
                        },
                        new
                        {
                            AccountID = 3,
                            AccountEmail = "test3@gmail.com",
                            AccountFirstName = "John",
                            AccountLastName = "Smith",
                            AccountPhone = "666666789",
                            RoleID = 3
                        });
                });

            modelBuilder.Entity("Przyklad1.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_category");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "TestCategory"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "TestCategory2"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "TestCategory3"
                        });
                });

            modelBuilder.Entity("Przyklad1.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_product");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductID"));

                    b.Property<decimal>("ProductDepth")
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("depth");

                    b.Property<decimal>("ProductHeight")
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("height");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("ProductWeight")
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("weight");

                    b.Property<decimal>("ProductWidth")
                        .HasColumnType("decimal(5, 2)")
                        .HasColumnName("width");

                    b.HasKey("ProductID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            ProductDepth = 0.3m,
                            ProductHeight = 0.2m,
                            ProductName = "TestProduct",
                            ProductWeight = 0.4m,
                            ProductWidth = 0.1m
                        },
                        new
                        {
                            ProductID = 2,
                            ProductDepth = 0.7m,
                            ProductHeight = 0.6m,
                            ProductName = "TestProduct2",
                            ProductWeight = 0.8m,
                            ProductWidth = 0.5m
                        },
                        new
                        {
                            ProductID = 3,
                            ProductDepth = 1.1m,
                            ProductHeight = 1m,
                            ProductName = "TestProduct3",
                            ProductWeight = 1.2m,
                            ProductWidth = 0.9m
                        });
                });

            modelBuilder.Entity("Przyklad1.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int")
                        .HasColumnName("FK_product");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int")
                        .HasColumnName("FK_category");

                    b.HasKey("ProductID", "CategoryID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products_Categories");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CategoryID = 1
                        },
                        new
                        {
                            ProductID = 2,
                            CategoryID = 2
                        },
                        new
                        {
                            ProductID = 3,
                            CategoryID = 3
                        });
                });

            modelBuilder.Entity("Przyklad1.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PK_role");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("name");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleID = 2,
                            RoleName = "User"
                        },
                        new
                        {
                            RoleID = 3,
                            RoleName = "Guest"
                        });
                });

            modelBuilder.Entity("Przyklad1.Models.ShoppingCart", b =>
                {
                    b.Property<int>("ProductID")
                        .HasColumnType("int")
                        .HasColumnName("FK_product");

                    b.Property<int>("AccountID")
                        .HasColumnType("int")
                        .HasColumnName("FK_account");

                    b.Property<int>("ShoppingCartAmount")
                        .HasColumnType("int")
                        .HasColumnName("amount");

                    b.HasKey("ProductID", "AccountID");

                    b.HasIndex("AccountID");

                    b.ToTable("Shopping_Carts");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            AccountID = 1,
                            ShoppingCartAmount = 1
                        },
                        new
                        {
                            ProductID = 2,
                            AccountID = 2,
                            ShoppingCartAmount = 2
                        },
                        new
                        {
                            ProductID = 3,
                            AccountID = 3,
                            ShoppingCartAmount = 3
                        });
                });

            modelBuilder.Entity("Przyklad1.Models.Account", b =>
                {
                    b.HasOne("Przyklad1.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Przyklad1.Models.ProductCategory", b =>
                {
                    b.HasOne("Przyklad1.Models.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Przyklad1.Models.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Przyklad1.Models.ShoppingCart", b =>
                {
                    b.HasOne("Przyklad1.Models.Account", "Account")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Przyklad1.Models.Product", "Product")
                        .WithMany("ShoppingCarts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Przyklad1.Models.Account", b =>
                {
                    b.Navigation("ShoppingCarts");
                });

            modelBuilder.Entity("Przyklad1.Models.Category", b =>
                {
                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("Przyklad1.Models.Product", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("ShoppingCarts");
                });

            modelBuilder.Entity("Przyklad1.Models.Role", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
