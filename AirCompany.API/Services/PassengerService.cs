using AutoMapper;
using AirCompany.API.DTO;
using AirCompany.Domain;
using AirCompany.Domain.Entities;
using AirCompany.Domain.Repositories;

namespace AirCompany.API.Services;

public class PassengerService(IRepository<Passenger> passengerRepository, IMapper mapper)
    : IService<PassengerDto, Passenger>
{
    private int _id = 1;

    public bool Delete(int id)
    {
        return passengerRepository.Delete(id);
    }

    public IEnumerable<Passenger> GetAll()
    {
        return passengerRepository.GetAll();
    }

    public Passenger? GetById(int id)
    {
        var passenger = passengerRepository.GetById(id);
        return passenger;
    }

    public Passenger? Post(PassengerDto entity)
    {
        var passenger = mapper.Map<Passenger>(entity);
        passenger.Id = _id++;
        return passengerRepository.Post(passenger);
    }

    public bool Put(int id, PassengerDto entity)
    {
        var passenger = mapper.Map<Passenger>(entity);
        return passengerRepository.Put(id, passenger);
    }
}