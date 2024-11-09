using AirCompany.Domain.Entities;

namespace AirCompany.Domain.Repositories;

public class RegisteredPassengerRepository : IRepository<RegisteredPassenger>
{
    private readonly List<RegisteredPassenger> _registeredPassengers = [];

    public bool Delete(int id)
    {
        var registeredPassenger = GetById(id);

        if (registeredPassenger == null)
            return false;

        _registeredPassengers.Remove(registeredPassenger);
        return true;
    }

    public IEnumerable<RegisteredPassenger> GetAll() => _registeredPassengers;

    public RegisteredPassenger? GetById(int id) => _registeredPassengers.Find(rp => rp.Id == id);

    public RegisteredPassenger? Post(RegisteredPassenger entity)
    {
        _registeredPassengers.Add(entity);
        return entity;
    }

    public bool Put(int id, RegisteredPassenger entity)
    {
        var oldRegisteredPassenger = GetById(id);
        if (oldRegisteredPassenger == null)
            return false;

        oldRegisteredPassenger.Number = entity.Number;
        oldRegisteredPassenger.SeatNumber = entity.SeatNumber;
        oldRegisteredPassenger.LuggageWeight = entity.LuggageWeight;
        oldRegisteredPassenger.Flight = entity.Flight;
        oldRegisteredPassenger.Passenger = entity.Passenger;
        return true;
    }
}