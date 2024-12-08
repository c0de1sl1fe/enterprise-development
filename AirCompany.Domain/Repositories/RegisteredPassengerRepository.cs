using AirCompany.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirCompany.Domain.Repositories;

public class RegisteredPassengerRepository(AirCompanyContext context, IRepository<Flight> flightRepository, IRepository<Passenger> passengerRepository) : IRepository<RegisteredPassenger>
{
    public bool Delete(int id)
    {
        var registeredPassenger = GetById(id);
        if (registeredPassenger == null)
            return false;

        context.RegisteredPassengers.Remove(registeredPassenger);
        context.SaveChanges();
        return true;
    }

    public IEnumerable<RegisteredPassenger> GetAll() => context.RegisteredPassengers.ToList();

    public RegisteredPassenger? GetById(int id) => context.RegisteredPassengers.FirstOrDefault(rp => rp.Id == id);

    public RegisteredPassenger? Post(RegisteredPassenger entity)
    {
        var flight = flightRepository.GetById(entity.FlightId);
        var passenger = passengerRepository.GetById(entity.PassengerId);
        
        if (flight == null || passenger == null)
            return null;

        context.RegisteredPassengers.Add(entity);
        context.SaveChanges();
        return entity;
    }

    public bool Put(int id, RegisteredPassenger entity)
    {
        var oldRegisteredPassenger = GetById(id);
        if (oldRegisteredPassenger == null)
            return false;
        
        var flight = flightRepository.GetById(entity.FlightId);
        var passenger = passengerRepository.GetById(entity.PassengerId);
        
        if (flight == null || passenger == null)
            return false;

        oldRegisteredPassenger.Number = entity.Number;
        oldRegisteredPassenger.SeatNumber = entity.SeatNumber;
        oldRegisteredPassenger.LuggageWeight = entity.LuggageWeight;
        oldRegisteredPassenger.Flight = entity.Flight;
        oldRegisteredPassenger.Passenger = entity.Passenger;

        context.SaveChanges();
        return true;
    }
}