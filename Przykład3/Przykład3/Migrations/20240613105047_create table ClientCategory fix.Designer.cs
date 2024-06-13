﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Przykład3.Contexts;

#nullable disable

namespace Przykład3.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240613105047_create table ClientCategory fix")]
    partial class createtableClientCategoryfix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Przykład3.Models.ClientCategory", b =>
                {
                    b.Property<int>("ClientCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdClientCategory");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientCategoryId"));

                    b.Property<int>("ClientCategoryDiscountPercentage")
                        .HasColumnType("int")
                        .HasColumnName("DiscountPerc");

                    b.Property<string>("ClientCategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("ClientCategoryId");

                    b.ToTable("ClientCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
