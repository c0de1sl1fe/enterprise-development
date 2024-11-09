using AutoMapper;
using AirCompany.API.DTO;
using AirCompany.Domain;
using AirCompany.Domain.Entities;
using AirCompany.Domain.Repositories;

namespace AirCompany.API.Services;

public class AircraftService(IRepository<Aircraft> aircraftRepository, IMapper mapper) : IService<AircraftDto, Aircraft>
{
    private int _id = 1;

    public bool Delete(int id)
    {
        return aircraftRepository.Delete(id);
    }

    public IEnumerable<Aircraft> GetAll()
    {
        return aircraftRepository.GetAll();
    }

    public Aircraft? GetById(int id)
    {
        var aircraft = aircraftRepository.GetById(id);
        return aircraft;
    }

    public Aircraft? Post(AircraftDto entity)
    {
        var aircraft = mapper.Map<Aircraft>(entity);
        aircraft.Id = _id++;
        return aircraftRepository.Post(aircraft);
    }

    public bool Put(int id, AircraftDto entity)
    {
        var aircraft = mapper.Map<Aircraft>(entity);
        return aircraftRepository.Put(id, aircraft);
    }
}