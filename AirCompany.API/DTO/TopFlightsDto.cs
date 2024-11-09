namespace AirCompany.API.DTO;

/// <summary>
/// DTO для топ рейсов
/// </summary>
public class TopFlightsDto
{
    /// <summary>
    /// Идентификатор рейса
    /// </summary>
    public int FlightId { get; set; }

    /// <summary>
    /// Пункт отправления
    /// </summary>
    public string? DeparturePoint { get; set; }

    /// <summary>
    /// Пункт прибытия
    /// </summary>
    public string? ArrivalPoint { get; set; }

    /// <summary>
    /// Количество перевезённых пассажиров
    /// </summary>
    public int PassengersCount { get; set; }
}