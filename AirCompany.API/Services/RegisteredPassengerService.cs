using AutoMapper;
using AirCompany.API.DTO;
using AirCompany.Domain;
using AirCompany.Domain.Entities;
using AirCompany.Domain.Repositories;

namespace AirCompany.API.Services;

public class RegisteredPassengerService(IRepository<RegisteredPassenger> registeredPassengerRepository, IMapper mapper)
    : IService<RegisteredPassengerDto, RegisteredPassenger>
{
    private int _id = 1;

    public bool Delete(int id)
    {
        return registeredPassengerRepository.Delete(id);
    }

    public IEnumerable<RegisteredPassenger> GetAll()
    {
        return registeredPassengerRepository.GetAll();
    }

    public RegisteredPassenger? GetById(int id)
    {
        var registeredPassenger = registeredPassengerRepository.GetById(id);
        return registeredPassenger;
    }

    public RegisteredPassenger? Post(RegisteredPassengerDto entity)
    {
        var registeredPassenger = mapper.Map<RegisteredPassenger>(entity);
        registeredPassenger.Id = _id++;
        return registeredPassengerRepository.Post(registeredPassenger);
    }

    public bool Put(int id, RegisteredPassengerDto entity)
    {
        var registeredPassenger = mapper.Map<RegisteredPassenger>(entity);
        return registeredPassengerRepository.Put(id, registeredPassenger);
    }
}