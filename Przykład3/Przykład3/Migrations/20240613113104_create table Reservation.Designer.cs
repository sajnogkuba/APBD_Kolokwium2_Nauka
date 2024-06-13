﻿// <auto-generated />
using System;
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
    [Migration("20240613113104_create table Reservation")]
    partial class createtableReservation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Przykład3.Models.BoatStandard", b =>
                {
                    b.Property<int>("BoatStandardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdBoatStandard");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BoatStandardId"));

                    b.Property<int>("BoatStandardLevel")
                        .HasColumnType("int")
                        .HasColumnName("Level");

                    b.Property<string>("BoatStandardName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.HasKey("BoatStandardId");

                    b.ToTable("BoatStandard");
                });

            modelBuilder.Entity("Przykład3.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdClient");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<DateTime>("ClientBirthday")
                        .HasColumnType("datetime2")
                        .HasColumnName("Birthday");

                    b.Property<int>("ClientCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("IdClientCategory");

                    b.Property<string>("ClientEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("ClientLastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("LastName");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Name");

                    b.Property<string>("ClientPesel")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Pesel");

                    b.HasKey("ClientId");

                    b.HasIndex("ClientCategoryId");

                    b.ToTable("Client");
                });

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

            modelBuilder.Entity("Przykład3.Models.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdReservation");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<int>("ReservationBoatStandardId")
                        .HasColumnType("int")
                        .HasColumnName("IdBoatStandard");

                    b.Property<string>("ReservationCancelReason")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("CancelReason");

                    b.Property<int>("ReservationCapacity")
                        .HasColumnType("int")
                        .HasColumnName("Capacity");

                    b.Property<int>("ReservationClientId")
                        .HasColumnType("int")
                        .HasColumnName("IdClient");

                    b.Property<DateTime>("ReservationDateFrom")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateFrom");

                    b.Property<DateTime>("ReservationDateTo")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateTo");

                    b.Property<bool>("ReservationFulfilled")
                        .HasColumnType("bit")
                        .HasColumnName("Fulfilled");

                    b.Property<int>("ReservationNumOfBoats")
                        .HasColumnType("int")
                        .HasColumnName("NumOfBoats");

                    b.Property<decimal>("ReservationPrice")
                        .HasColumnType("money")
                        .HasColumnName("Price");

                    b.HasKey("ReservationId");

                    b.HasIndex("ReservationBoatStandardId");

                    b.HasIndex("ReservationClientId");

                    b.ToTable("Reservation");
                });

            modelBuilder.Entity("Przykład3.Models.Client", b =>
                {
                    b.HasOne("Przykład3.Models.ClientCategory", "ClientCategory")
                        .WithMany("Clients")
                        .HasForeignKey("ClientCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientCategory");
                });

            modelBuilder.Entity("Przykład3.Models.Reservation", b =>
                {
                    b.HasOne("Przykład3.Models.BoatStandard", "BoatStandard")
                        .WithMany("Reservations")
                        .HasForeignKey("ReservationBoatStandardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Przykład3.Models.Client", "Client")
                        .WithMany("Reservations")
                        .HasForeignKey("ReservationClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BoatStandard");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Przykład3.Models.BoatStandard", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Przykład3.Models.Client", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("Przykład3.Models.ClientCategory", b =>
                {
                    b.Navigation("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
