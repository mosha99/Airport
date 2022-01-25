﻿// <auto-generated />
using System;
using Airport.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Airport.Migrations
{
    [DbContext(typeof(AirplantContext))]
    partial class AirplantContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Airport.Models.Airplans", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Airplans");
                });

            modelBuilder.Entity("Airport.Models.AirPort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("X")
                        .HasColumnType("float");

                    b.Property<double>("Y")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("AirPorts");
                });

            modelBuilder.Entity("Airport.Models.Flighpass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FlightId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("PasengerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("PasengerId");

                    b.ToTable("Flighpasses");
                });

            modelBuilder.Entity("Airport.Models.Flights", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AirplanId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EndLocationId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<int?>("StartLocationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AirplanId");

                    b.HasIndex("EndLocationId");

                    b.HasIndex("StartLocationId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("Airport.Models.FlightsInfo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<bool>("ArrivedOnPlane")
                        .HasColumnType("bit");

                    b.Property<int?>("FlightId")
                        .HasColumnType("int");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("pasengerId")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("FlightId");

                    b.HasIndex("pasengerId");

                    b.ToTable("FlightsInfo");
                });

            modelBuilder.Entity("Airport.Models.Pasenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Pasengers");
                });

            modelBuilder.Entity("Airport.Models.Flighpass", b =>
                {
                    b.HasOne("Airport.Models.Flights", "Flight")
                        .WithMany("PasengerList")
                        .HasForeignKey("FlightId");

                    b.HasOne("Airport.Models.Pasenger", "Pasenger")
                        .WithMany("Flights")
                        .HasForeignKey("PasengerId");

                    b.Navigation("Flight");

                    b.Navigation("Pasenger");
                });

            modelBuilder.Entity("Airport.Models.Flights", b =>
                {
                    b.HasOne("Airport.Models.Airplans", "Airplan")
                        .WithMany("Flights")
                        .HasForeignKey("AirplanId");

                    b.HasOne("Airport.Models.AirPort", "EndLocation")
                        .WithMany("InputFlights")
                        .HasForeignKey("EndLocationId");

                    b.HasOne("Airport.Models.AirPort", "StartLocation")
                        .WithMany("OutputFlights")
                        .HasForeignKey("StartLocationId");

                    b.Navigation("Airplan");

                    b.Navigation("EndLocation");

                    b.Navigation("StartLocation");
                });

            modelBuilder.Entity("Airport.Models.FlightsInfo", b =>
                {
                    b.HasOne("Airport.Models.Flights", "Flight")
                        .WithMany()
                        .HasForeignKey("FlightId");

                    b.HasOne("Airport.Models.Pasenger", "pasenger")
                        .WithMany()
                        .HasForeignKey("pasengerId");

                    b.Navigation("Flight");

                    b.Navigation("pasenger");
                });

            modelBuilder.Entity("Airport.Models.Airplans", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("Airport.Models.AirPort", b =>
                {
                    b.Navigation("InputFlights");

                    b.Navigation("OutputFlights");
                });

            modelBuilder.Entity("Airport.Models.Flights", b =>
                {
                    b.Navigation("PasengerList");
                });

            modelBuilder.Entity("Airport.Models.Pasenger", b =>
                {
                    b.Navigation("Flights");
                });
#pragma warning restore 612, 618
        }
    }
}
