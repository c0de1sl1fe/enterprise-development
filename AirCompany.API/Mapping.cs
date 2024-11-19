// using AirCompany.API.DTO;
// using AirCompany.Domain.Entities;
// using AutoMapper;
//
// namespace AirCompany.API;
//
// /// <summary>
// /// Класс для маппинга
// /// </summary>
// public class Mapping : Profile
// {
//     /// <summary>
//     /// Маппинг сущностей
//     /// </summary>
//     public Mapping()
//     {
//         
//         // CreateMap<Aircraft, AircraftDto>().ReverseMap().ConstructUsing(src => new Aircraft(
//         //     0,
//         //     src.Model,
//         //     src.Capacity,
//         //     src.Performance,
//         //     src.MaxPassengers) { Id = 0 });
//         // CreateMap<Flight, FlightDto>().ReverseMap()
//         //     .ConstructUsing(src => new Flight(
//         //         0,
//         //         src.Number,
//         //         src.DeparturePoint,
//         //         src.ArrivalPoint,
//         //         src.DepartureDate,
//         //         src.ArrivalDate,
//         //         null,
//         //         null) { Id = 0 });
//         //     
//         //
//         // CreateMap<Passenger, PassengerDto>().ReverseMap()
//         //     .ConstructUsing(src => new Passenger(
//         //         0,
//         //         src.PassportNumber,
//         //         src.FullName) { Id = 0 });
//         //
//         // CreateMap<RegisteredPassenger, RegisteredPassengerDto>().ReverseMap()
//         //     .ConstructUsing(src => new RegisteredPassenger(
//         //         0,
//         //         src.Number,
//         //         src.SeatNumber,
//         //         src.LuggageWeight,
//         //         null,
//         //         null) { Id = 0 });
//     }
// }
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
        // Маппинг для Aircraft
        CreateMap<Aircraft, AircraftDto>();
        CreateMap<AircraftDto, Aircraft>();
        CreateMap<Aircraft, AircraftFullDto>();
        CreateMap<AircraftFullDto, Aircraft>();

        // Маппинг для Flight
        CreateMap<Flight, FlightDto>();
        CreateMap<FlightDto, Flight>();
        CreateMap<Flight, FlightFullDto>();
        CreateMap<FlightFullDto, Flight>();

        // Маппинг для Passenger
        CreateMap<Passenger, PassengerDto>();
        CreateMap<PassengerDto, Passenger>();
        CreateMap<Passenger, PassengerFullDto>();
        CreateMap<PassengerFullDto, Passenger>();

        // Маппинг для RegisteredPassenger
        CreateMap<RegisteredPassenger, RegisteredPassengerDto>();
        CreateMap<RegisteredPassengerDto, RegisteredPassenger>();
        CreateMap<RegisteredPassenger, RegisteredPassengerFullDto>();
        CreateMap<RegisteredPassengerFullDto, RegisteredPassenger>();
    }
}
