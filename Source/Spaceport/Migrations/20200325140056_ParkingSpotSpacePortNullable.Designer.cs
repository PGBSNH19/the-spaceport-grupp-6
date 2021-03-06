﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spaceport;

namespace Spaceport.Migrations
{
    [DbContext(typeof(SpacePortDBContext))]
    [Migration("20200325140056_ParkingSpotSpacePortNullable")]
    partial class ParkingSpotSpacePortNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Spaceport.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AmountPaid")
                        .HasColumnType("int");

                    b.Property<bool>("Paid")
                        .HasColumnType("bit");

                    b.HasKey("InvoiceID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Spaceport.ParkingSession", b =>
                {
                    b.Property<int>("ParkingSessionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("InvoiceID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ParkingSpotID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<bool>("ParkingToken")
                        .HasColumnType("bit");

                    b.Property<DateTime>("RegistrationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("SpaceShipID")
                        .HasColumnType("int");

                    b.HasKey("ParkingSessionID");

                    b.HasIndex("InvoiceID");

                    b.HasIndex("ParkingSpotID");

                    b.HasIndex("SpaceShipID");

                    b.ToTable("ParkingSessions");
                });

            modelBuilder.Entity("Spaceport.ParkingSpot", b =>
                {
                    b.Property<int>("ParkingSpotID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaxLength")
                        .HasColumnType("int");

                    b.Property<bool>("Occupied")
                        .HasColumnType("bit");

                    b.Property<int?>("SpacePortID")
                        .HasColumnType("int");

                    b.HasKey("ParkingSpotID");

                    b.HasIndex("SpacePortID");

                    b.ToTable("ParkingSpots");
                });

            modelBuilder.Entity("Spaceport.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("PersonID");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Spaceport.SpacePort", b =>
                {
                    b.Property<int>("SpacePortID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpacePortID");

                    b.ToTable("SpacePorts");
                });

            modelBuilder.Entity("Spaceport.SpaceShip", b =>
                {
                    b.Property<int>("SpaceShipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DriverPersonID")
                        .HasColumnType("int");

                    b.Property<int>("Length")
                        .HasColumnType("int");

                    b.HasKey("SpaceShipID");

                    b.HasIndex("DriverPersonID");

                    b.ToTable("SpaceShips");
                });

            modelBuilder.Entity("Spaceport.ParkingSession", b =>
                {
                    b.HasOne("Spaceport.Models.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Spaceport.ParkingSpot", "ParkingSpot")
                        .WithMany()
                        .HasForeignKey("ParkingSpotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Spaceport.SpaceShip", "SpaceShip")
                        .WithMany()
                        .HasForeignKey("SpaceShipID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Spaceport.ParkingSpot", b =>
                {
                    b.HasOne("Spaceport.SpacePort", "SpacePort")
                        .WithMany()
                        .HasForeignKey("SpacePortID");
                });

            modelBuilder.Entity("Spaceport.SpaceShip", b =>
                {
                    b.HasOne("Spaceport.Person", "Driver")
                        .WithMany()
                        .HasForeignKey("DriverPersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
