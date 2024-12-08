using AirCompany.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirCompany.Domain.Repositories;

public class AircraftRepository(AirCompanyContext context) : IRepository<Aircraft>
{
    public bool Delete(int id)
    {
        var value = GetById(id);
        if (value == null)
            return false;

        context.Aircrafts.Remove(value);
        context.SaveChanges();
        return true;
    }

    public IEnumerable<Aircraft> GetAll() => context.Aircrafts.ToList();

    public Aircraft? GetById(int id) => context.Aircrafts.FirstOrDefault(a => a.Id == id);

    public Aircraft? Post(Aircraft entity)
    {
        context.Aircrafts.Add(entity);
        context.SaveChanges();
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

        context.SaveChanges();
        return true;
    }
}