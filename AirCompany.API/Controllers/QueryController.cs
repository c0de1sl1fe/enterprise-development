using AirCompany.API.DTO;
using AirCompany.API.Services;
using AirCompany.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AirCompany.API.Controllers;

/// <summary>
/// Контроллер для запросов к данным о авиарейсах и пассажирах
/// </summary>
/// <param name="queryService">Сервис для запросов</param>
[Route("api/[controller]")]
[ApiController]
public class QueryController(IQueryService queryService) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех авиарейсов, вылетевших из указанного пункта отправления в указанный пункт прибытия
    /// </summary>
    /// <param name="departure">Пункт отправления</param>
    /// <param name="arrival">Пункт прибытия</param>
    /// <returns>Список авиарейсов</returns>
    [HttpGet("flights")]
    public ActionResult<List<FlightFullDto>> GetFlights(string departure, string arrival)
    {
        var flights = queryService.GetFlightsByDepartureAndArrival(departure, arrival);
        return Ok(flights);
    }

    /// <summary>
    /// Возвращает список пассажиров, летящих данным рейсом, вес багажа которых равен нулю
    /// </summary>
    /// <param name="flightId">Идентификатор рейса</param>
    /// <returns>Список пассажиров</returns>
    [HttpGet("passengers/no-baggage")]
    public ActionResult<List<RegisteredPassengerFullDto>> GetPassengersWithNoBaggage(int flightId)
    {
        var passengers = queryService.GetPassengersWithNoBaggage(flightId);
        return Ok(passengers);
    }

    /// <summary>
    /// Возвращает сводную информацию обо всех полетах самолетов данного типа в указанный период времени
    /// </summary>
    /// <param name="aircraftTypeId">Тип самолета</param>
    /// <param name="startDate">Начальная дата</param>
    /// <param name="endDate">Конечная дата</param>
    /// <returns>Список полетов</returns>
    [HttpGet("flights-summary")]
    public ActionResult<List<FlightInfoDto>> GetFlightSummaryByAircraftType(int aircraftTypeId, DateTime startDate,
        DateTime endDate)
    {
        var flightSummary = queryService.GetFlightSummaryByAircraftType(aircraftTypeId, startDate, endDate);
        return Ok(flightSummary);
    }

    /// <summary>
    /// Возвращает топ 5 авиарейсов по количеству перевезённых пассажиров
    /// </summary>
    /// <returns>Топ 5 авиарейсов</returns>
    [HttpGet("top-flights")]
    public ActionResult<List<TopFlightsDto>> GetTopFlightsByPassengerCount()
    {
        var topFlights = queryService.GetTopFlightsByPassengerCount();
        return Ok(topFlights);
    }

    /// <summary>
    /// Возвращает список рейсов с минимальным временем в пути
    /// </summary>
    /// <returns>Список рейсов с минимальным временем в пути</returns>
    [HttpGet("flights/min-duration")]
    public ActionResult<List<FlightFullDto>> GetFlightsWithMinimumDuration()
    {
        var flights = queryService.GetFlightsWithMinimumDuration();
        return Ok(flights);
    }

    /// <summary>
    /// Возвращает информацию о средней и максимальной загрузке авиарейсов из заданного пункта отправления
    /// </summary>
    /// <param name="departure">Пункт отправления</param>
    /// <returns>Средняя и максимальная загрузка</returns>
    [HttpGet("load-info")]
    public ActionResult<LoadInfoDto> GetLoadInfoByDeparture(string departure)
    {
        var loadInfo = queryService.GetLoadInfoByDeparture(departure);
        return Ok(loadInfo);
    }
}