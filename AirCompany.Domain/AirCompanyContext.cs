using AirCompany.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
namespace AirCompany.Domain;

public class AirCompanyContext(DbContextOptions<AirCompanyContext> options) : DbContext(options)
{
    public DbSet<Flight> Flights { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<RegisteredPassenger> RegisteredPassengers { get; set; }
    public DbSet<Aircraft> Aircrafts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
            modelBuilder.Entity<RegisteredPassenger>()
                .HasOne(rp => rp.Flight)
                .WithMany(f => f.Passengers)
                .HasForeignKey(rp => rp.FlightId) 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RegisteredPassenger>()
                .HasOne(rp => rp.Passenger)
                .WithMany(p => p.RegisteredPassengers)
                .HasForeignKey(rp => rp.PassengerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.AircraftType)
                .WithMany()
                .HasForeignKey(f => f.AircraftTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
    }
}