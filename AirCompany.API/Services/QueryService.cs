using AirCompany.Domain.Entities;
using AirCompany.Domain.Repositories;
using AirCompany.API.DTO;
using AirCompany.Domain.Entities;
using AirCompany.Domain.Repositories;

namespace AirCompany.API.Services;

/// <summary>
/// Сервис для запросов к данным о авиарейсах и пассажирах
/// </summary>
/// <param name="flightsRepository">Репозиторий авиарейсов</param>
/// <param name="passengerRepository">Репозиторий пассажиров</param>
/// <param name="registeredPassengerRepository">Репозиторий зарегистрированных пассажиров</param>
public class QueryService(
    IRepository<Flight> flightsRepository,
    IRepository<Passenger> passengerRepository,
    IRepository<RegisteredPassenger> registeredPassengerRepository)
{
    /// <summary>
    /// Выводит сведения о всех авиарейсах, вылетевших из указанного пункта отправления в указанный пункт прибытия
    /// </summary>
    /// <param name="departure">Пункт отправления</param>
    /// <param name="arrival">Пункт прибытия</param>
    /// <returns>Список авиарейсов</returns>
    public List<Flight> GetFlightsByDepartureAndArrival(string departure, string arrival)
    {
        var flights = flightsRepository.GetAll()
            .Where(f => f.DeparturePoint == departure && f.ArrivalPoint == arrival)
            .ToList();

        return flights;
    }

    /// <summary>
    /// Выводит сведения обо всех пассажирах, летящих данным рейсом, вес багажа которых равен нулю, упорядочить по ФИО
    /// </summary>
    /// <param name="flightId">Идентификатор рейса</param>
    /// <returns>Список пассажиров</returns>
    public List<RegisteredPassenger> GetPassengersWithNoBaggage(int flightId)
    {
        var passengers = registeredPassengerRepository.GetAll()
            .Where(rp => rp.Flight != null && rp.Flight.Id == flightId && rp.LuggageWeight == 0)
            .OrderBy(rp => rp.Passenger?.FullName)
            .ToList();

        return passengers;
    }

    /// <summary>
    /// Выводит сводную информацию обо всех полетах самолетов данного типа в указанный период времени
    /// </summary>
    /// <param name="aircraftTypeId">Тип самолета</param>
    /// <param name="startDate">Начальная дата</param>
    /// <param name="endDate">Конечная дата</param>
    /// <returns>Список полетов</returns>
    public List<FlightInfoDto> GetFlightSummaryByAircraftType(int aircraftTypeId, DateTime startDate, DateTime endDate)
    {
        var flightSummary = flightsRepository.GetAll()
            .Where(f => f.AircraftType != null && f.AircraftType.Id == aircraftTypeId && f.DepartureDate >= startDate &&
                        f.DepartureDate <= endDate)
            .Select(f => new FlightInfoDto
            {
                FlightId = f.Id,
                DeparturePoint = f.DeparturePoint,
                ArrivalPoint = f.ArrivalPoint,
                DepartureDate = f.DepartureDate,
                PassengersCount = registeredPassengerRepository
                    .GetAll()
                    .Count(rp => rp.Flight?.Id == f.Id)
            })
            .ToList();

        return flightSummary;
    }

    /// <summary>
    /// Выводит топ 5 авиарейсов по количеству перевезённых пассажиров
    /// </summary>
    /// <returns>Топ 5 авиарейсов</returns>
    public List<TopFlightsDto> GetTopFlightsByPassengerCount()
    {
        var topFlights = flightsRepository.GetAll()
            .Select(f => new TopFlightsDto
            {
                FlightId = f.Id,
                DeparturePoint = f.DeparturePoint,
                ArrivalPoint = f.ArrivalPoint,
                PassengersCount = registeredPassengerRepository
                    .GetAll()
                    .Count(rp => rp.Flight?.Id == f.Id)
            })
            .OrderByDescending(f => f.PassengersCount)
            .Take(5)
            .ToList();

        return topFlights;
    }

    /// <summary>
    /// Выводит список рейсов с минимальным временем в пути
    /// </summary>
    /// <returns>Список рейсов с минимальным временем в пути</returns>
    public List<Flight> GetFlightsWithMinimumDuration()
    {
        var minDuration = flightsRepository.GetAll()
            .Min(f => f.ArrivalDate - f.DepartureDate);

        var flights = flightsRepository.GetAll()
            .Where(f => (f.ArrivalDate - f.DepartureDate) == minDuration)
            .ToList();

        return flights;
    }

    /// <summary>
    /// Выводит информацию о средней и максимальной загрузке авиарейсов из заданного пункта отправления
    /// </summary>
    /// <param name="departure">Пункт отправления</param>
    /// <returns>Средняя и максимальная загрузка</returns>
    public LoadInfoDto GetLoadInfoByDeparture(string departure)
    {
        var flights = flightsRepository.GetAll()
            .Where(f => f.DeparturePoint == departure)
            .ToList();

        var averageLoad = flights.Average(f => registeredPassengerRepository.GetAll().Count(rp => rp.Flight?.Id == f.Id));
        var maxLoad = flights.Max(f => registeredPassengerRepository.GetAll().Count(rp => rp.Flight?.Id == f.Id));

        return new LoadInfoDto
        {
            AverageLoad = averageLoad,
            MaxLoad = maxLoad
        };
    }
}