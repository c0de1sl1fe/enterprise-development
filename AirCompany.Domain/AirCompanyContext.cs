using AirCompany.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirCompany.Domain;

public class AirCompanyContext : DbContext
{
    public AirCompanyContext(DbContextOptions<AirCompanyContext> options) : base(options)
    {
    }

    public DbSet<Flight> Flights { get; set; }
    public DbSet<Passenger> Passengers { get; set; }
    public DbSet<RegisteredPassenger> RegisteredPassengers { get; set; }
    public DbSet<Aircraft> Aircrafts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegisteredPassenger>()
            .HasOne(rp => rp.Flight)
            .WithMany(f => f.Passengers)
            .HasForeignKey(rp => rp.Flight)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<RegisteredPassenger>()
            .HasOne(rp => rp.Passenger)
            .WithMany()
            .HasForeignKey(rp => rp.Passenger)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Flight>()
            .HasOne(f => f.AircraftType)
            .WithMany()
            .HasForeignKey(f => f.AircraftType)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Passenger>()
            .HasMany(p => p.RegisteredPassengers)
            .WithOne(rp => rp.Passenger)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
}