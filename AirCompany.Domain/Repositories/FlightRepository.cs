using AirCompany.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirCompany.Domain.Repositories;

public class FlightRepository(AirCompanyContext context, IRepository<Aircraft> aircraftRepository) : IRepository<Flight>
{
    public bool Delete(int id)
    {
        var flight = GetById(id);
        if (flight == null)
            return false;

        context.Flights.Remove(flight);
        context.SaveChanges();
        return true;
    }

    public IEnumerable<Flight> GetAll() => context.Flights.ToList();

    public Flight? GetById(int id) => context.Flights.FirstOrDefault(f => f.Id == id);

    public Flight? Post(Flight entity)
    {
        var aircraft = aircraftRepository.GetById(entity.AircraftType?.Id ?? -1);
        if (aircraft == null)
            return null;

        context.Flights.Add(entity);
        context.SaveChanges();
        return entity;
    }

    public bool Put(int id, Flight entity)
    {
        var oldFlight = GetById(id);
        if (oldFlight == null)
            return false;

        var aircraft = aircraftRepository.GetById(entity.AircraftType?.Id ?? -1);
        if (aircraft == null)
            return false;

        oldFlight.Number = entity.Number;
        oldFlight.DeparturePoint = entity.DeparturePoint;
        oldFlight.ArrivalPoint = entity.ArrivalPoint;
        oldFlight.DepartureDate = entity.DepartureDate;
        oldFlight.ArrivalDate = entity.ArrivalDate;
        oldFlight.AircraftType = entity.AircraftType;

        context.SaveChanges();
        return true;
    }
}