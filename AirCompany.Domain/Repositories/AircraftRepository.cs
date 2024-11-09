using AirCompany.Domain.Entities;

namespace AirCompany.Domain.Repositories;

public class AircraftRepository : IRepository<Aircraft>
{
    private readonly List<Aircraft> _aircrafts = [];

    public bool Delete(int id)
    {
        var value = GetById(id);

        if (value == null)
            return false;

        _aircrafts.Remove(value);
        return true;
    }

    public IEnumerable<Aircraft> GetAll() => _aircrafts;

    public Aircraft? GetById(int id) => _aircrafts.Find(a => a.Id == id);

    public Aircraft? Post(Aircraft entity)
    {
        _aircrafts.Add(entity);
        return entity;
    }

    public bool Put(int id, Aircraft entity)
    {
        var oldValue = GetById(id);
        if (oldValue == null)
            return false;

        oldValue.Model = entity.Model;
        oldValue.Capacity = entity.Capacity;
        oldValue.Performance = entity.Performance;
        oldValue.MaxPassengers = entity.MaxPassengers;
        return true;
    }
}