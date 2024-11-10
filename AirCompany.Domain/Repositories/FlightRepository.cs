using AirCompany.Domain.Entities;

namespace AirCompany.Domain.Repositories;

public class FlightRepository : IRepository<Flight>
{
    private readonly List<Flight> _flights = [];

    public bool Delete(int id)
    {
        var flight = GetById(id);

        if (flight == null)
            return false;

        _flights.Remove(flight);
        return true;
    }

    public IEnumerable<Flight> GetAll() => _flights;

    public Flight? GetById(int id) => _flights.Find(f => f.Id == id);

    public Flight? Post(Flight entity)
    {
        _flights.Add(entity);
        return entity;
    }

    public bool Put(int id, Flight entity)
    {
        var oldFlight = GetById(id);
        if (oldFlight == null)
            return false;

        oldFlight.Number = entity.Number;
        oldFlight.DeparturePoint = entity.DeparturePoint;
        oldFlight.ArrivalPoint = entity.ArrivalPoint;
        oldFlight.DepartureDate = entity.DepartureDate;
        oldFlight.ArrivalDate = entity.ArrivalDate;
        oldFlight.AircraftType = entity.AircraftType;
        oldFlight.Passengers = entity.Passengers;
        return true;
    }
}
