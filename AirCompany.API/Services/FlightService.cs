using AutoMapper;
using AirCompany.API.DTO;
using AirCompany.Domain.Entities;
using AirCompany.Domain.Repositories;

namespace AirCompany.API.Services;

public class FlightService(IRepository<Flight> flightRepository, IMapper mapper) : IService<FlightDto, Flight>
{
    private int _id = 1;

    public bool Delete(int id)
    {
        return flightRepository.Delete(id);
    }

    public IEnumerable<Flight> GetAll()
    {
        return flightRepository.GetAll();
    }

    public Flight? GetById(int id)
    {
        var flight = flightRepository.GetById(id);
        return flight;
    }

    public Flight? Post(FlightDto entity)
    {
        var flight = mapper.Map<Flight>(entity);
        flight.Id = _id++;
        return flightRepository.Post(flight);
    }

    public bool Put(int id, FlightDto entity)
    {
        var flight = mapper.Map<Flight>(entity);
        return flightRepository.Put(id, flight);
    }
}