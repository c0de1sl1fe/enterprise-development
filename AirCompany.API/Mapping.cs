using AirCompany.API.DTO;
using AirCompany.Domain.Entities;
using AutoMapper;

namespace AirCompany.API;

/// <summary>
/// Класс для маппинга
/// </summary>
public class Mapping : Profile
{
    /// <summary>
    /// Маппинг сущностей
    /// </summary>
    public Mapping()
    {
        CreateMap<Aircraft, AircraftDto>().ReverseMap().ConstructUsing(src => new Aircraft(
            0,
            src.Model,
            src.Capacity,
            src.Performance,
            src.MaxPassengers) { Id = 0 });
        CreateMap<Flight, FlightDto>().ReverseMap()
            .ConstructUsing(src => new Flight(
                0,
                src.Number,
                src.DeparturePoint,
                src.ArrivalPoint,
                src.DepartureDate,
                src.ArrivalDate,
                null,
               null) { Id = 0 })
            .ForMember(dest => dest.Passengers, opt => opt.MapFrom(src => src.Passengers!.Select(id => new RegisteredPassenger { Id = id }))); // Преобразуем идентификаторы в объекты RegisteredPassenger
            

        CreateMap<Passenger, PassengerDto>().ReverseMap()
            .ConstructUsing(src => new Passenger(
                0,
                src.PassportNumber,
                src.FullName) { Id = 0 });

        CreateMap<RegisteredPassenger, RegisteredPassengerDto>().ReverseMap()
            .ConstructUsing(src => new RegisteredPassenger(
                0,
                src.Number,
                src.SeatNumber,
                src.LuggageWeight,
                null,
                null) { Id = 0 });
    }
}