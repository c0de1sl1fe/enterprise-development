using AirCompany.Domain.Entities;

namespace AirCompany.Domain.Repositories;

public class PassengerRepository : IRepository<Passenger>
{
    private readonly List<Passenger> _passengers = [];

    public bool Delete(int id)
    {
        var passenger = GetById(id);

        if (passenger == null)
            return false;

        _passengers.Remove(passenger);
        return true;
    }

    public IEnumerable<Passenger> GetAll() => _passengers;

    public Passenger? GetById(int id) => _passengers.Find(p => p.Id == id);

    public Passenger? Post(Passenger entity)
    {
        _passengers.Add(entity);
        return entity;
    }

    public bool Put(int id, Passenger entity)
    {
        var oldPassenger = GetById(id);
        if (oldPassenger == null)
            return false;

        oldPassenger.PassportNumber = entity.PassportNumber;
        oldPassenger.FullName = entity.FullName;
        return true;
    }
}