namespace AirCompany.API.DTO;

/// <summary>
/// DTO для информации о рейсе
/// </summary>
public class FlightInfoDto
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
    /// Дата и время отправления
    /// </summary>
    public DateTime? DepartureDate { get; set; }

    /// <summary>
    /// Количество пассажиров
    /// </summary>
    public int PassengersCount { get; set; }
}
