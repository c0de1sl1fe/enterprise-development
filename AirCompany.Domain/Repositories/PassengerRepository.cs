using AirCompany.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirCompany.Domain.Repositories;

public class PassengerRepository(AirCompanyContext context) : IRepository<Passenger>
{
    public bool Delete(int id)
    {
        var passenger = GetById(id);
        if (passenger == null)
            return false;

        context.Passengers.Remove(passenger);
        context.SaveChanges();
        return true;
    }

    public IEnumerable<Passenger> GetAll() => context.Passengers.ToList();

    public Passenger? GetById(int id) => context.Passengers.FirstOrDefault(p => p.Id == id);

    public Passenger? Post(Passenger entity)
    {
        context.Passengers.Add(entity);
        context.SaveChanges();
        return entity;
    }

    public bool Put(int id, Passenger entity)
    {
        var oldPassenger = GetById(id);
        if (oldPassenger == null)
            return false;

        oldPassenger.PassportNumber = entity.PassportNumber;
        oldPassenger.FullName = entity.FullName;

        context.SaveChanges();
        return true;
    }
}