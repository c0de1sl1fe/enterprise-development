﻿// <auto-generated />
using System;
using AirCompany.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AirCompany.Domain.Migrations
{
    [DbContext(typeof(AirCompanyContext))]
    partial class AirCompanyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AirCompany.Domain.Entities.Aircraft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double?>("Capacity")
                        .HasColumnType("double precision")
                        .HasColumnName("capacity");

                    b.Property<int?>("MaxPassengers")
                        .HasColumnType("integer")
                        .HasColumnName("max_passengers");

                    b.Property<string>("Model")
                        .HasColumnType("text")
                        .HasColumnName("model");

                    b.Property<double?>("Performance")
                        .HasColumnType("double precision")
                        .HasColumnName("performance");

                    b.HasKey("Id");

                    b.ToTable("aircraft");
                });

            modelBuilder.Entity("AirCompany.Domain.Entities.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AircraftTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ArrivalDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("arrival_date");

                    b.Property<string>("ArrivalPoint")
                        .HasColumnType("text")
                        .HasColumnName("arrival_point");

                    b.Property<DateTime?>("DepartureDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("departure_date");

                    b.Property<string>("DeparturePoint")
                        .HasColumnType("text")
                        .HasColumnName("departure_point");

                    b.Property<string>("Number")
                        .HasColumnType("text")
                        .HasColumnName("number");

                    b.HasKey("Id");

                    b.HasIndex("AircraftTypeId");

                    b.ToTable("flight");
                });

            modelBuilder.Entity("AirCompany.Domain.Entities.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<string>("PassportNumber")
                        .HasColumnType("text")
                        .HasColumnName("passport_number");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("AirCompany.Domain.Entities.RegisteredPassenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("FlightId")
                        .HasColumnType("integer");

                    b.Property<double?>("LuggageWeight")
                        .HasColumnType("double precision")
                        .HasColumnName("luggage_weight");

                    b.Property<string>("Number")
                        .HasColumnType("text")
                        .HasColumnName("number");

                    b.Property<int>("PassengerId")
                        .HasColumnType("integer");

                    b.Property<string>("SeatNumber")
                        .HasColumnType("text")
                        .HasColumnName("seat_number");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("PassengerId");

                    b.ToTable("registered_passenger");
                });

            modelBuilder.Entity("AirCompany.Domain.Entities.Flight", b =>
                {
                    b.HasOne("AirCompany.Domain.Entities.Aircraft", "AircraftType")
                        .WithMany()
                        .HasForeignKey("AircraftTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AircraftType");
                });

            modelBuilder.Entity("AirCompany.Domain.Entities.RegisteredPassenger", b =>
                {
                    b.HasOne("AirCompany.Domain.Entities.Flight", "Flight")
                        .WithMany("Passengers")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AirCompany.Domain.Entities.Passenger", "Passenger")
                        .WithMany("RegisteredPassengers")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("AirCompany.Domain.Entities.Flight", b =>
                {
                    b.Navigation("Passengers");
                });

            modelBuilder.Entity("AirCompany.Domain.Entities.Passenger", b =>
                {
                    b.Navigation("RegisteredPassengers");
                });
#pragma warning restore 612, 618
        }
    }
}