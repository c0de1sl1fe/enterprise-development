namespace AirCompany.Domain.Entities;

/// <summary>
/// Представляет информацию о рейсе.
/// </summary>
/// <param name="id">Уникальный идентификатор рейса.</param>
/// <param name="number">Номер рейса.</param>
/// <param name="departurePoint">Место отправления рейса.</param>
/// <param name="arrivalPoint">Место назначения рейса.</param>
/// <param name="departureDate">Дата и время отправления рейса.</param>
/// <param name="arrivalDate">Дата и время прибытия рейса.</param>
/// <param name="aircraftType">Тип самолета, используемого для рейса.</param>
/// <param name="passengers">Список пассажиров, зарегистрированных на рейс.</param>
public class Flight(
    int id,
    string? number,
    string? departurePoint,
    string? arrivalPoint,
    DateTime? departureDate,
    DateTime? arrivalDate,
    Aircraft? aircraftType,
    List<Passenger>? passengers)
{
    /// <summary>
    /// Уникальный идентификатор рейса.
    /// </summary>
    public required int Id { get; set; } = id;

    /// <summary>
    /// Номер рейса.
    /// </summary>
    public string? Number { get; set; } = number;

    /// <summary>
    /// Место отправления рейса.
    /// </summary>
    public string? DeparturePoint { get; set; } = departurePoint;

    /// <summary>
    /// Место назначения рейса.
    /// </summary>
    public string? ArrivalPoint { get; set; } = arrivalPoint;

    /// <summary>
    /// Дата и время отправления рейса.
    /// </summary>
    public DateTime? DepartureDate { get; set; } = departureDate;

    /// <summary>
    /// Дата и время прибытия рейса.
    /// </summary>
    public DateTime? ArrivalDate { get; set; } = arrivalDate;

    /// <summary>
    /// Время отправления рейса.
    /// </summary>
    public TimeOnly? DepartureTime => DepartureDate.HasValue ? TimeOnly.FromDateTime(DepartureDate.Value) : null;

    /// <summary>
    /// Продолжительность рейса.
    /// </summary>
    public TimeSpan? Duration => (DepartureDate.HasValue && ArrivalDate.HasValue) ? ArrivalDate.Value - DepartureDate.Value : null;

    /// <summary>
    /// Тип самолета, используемого для рейса.
    /// </summary>
    public Aircraft? AircraftType { get; set; } = aircraftType;

    /// <summary>
    /// Список пассажиров, зарегистрированных на рейс.
    /// </summary>
    public List<Passenger>? Passengers { get; set; } = passengers;
}
