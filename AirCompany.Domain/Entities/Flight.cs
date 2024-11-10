namespace AirCompany.Domain.Entities;

/// <summary>
/// Представляет информацию о рейсе.
/// </summary>
public class Flight
{
    /// <summary>
    /// Уникальный идентификатор рейса.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Номер рейса.
    /// </summary>
    public string? Number { get; set; }

    /// <summary>
    /// Место отправления рейса.
    /// </summary>
    public string? DeparturePoint { get; set; }

    /// <summary>
    /// Место назначения рейса.
    /// </summary>
    public string? ArrivalPoint { get; set; }

    /// <summary>
    /// Дата и время отправления рейса.
    /// </summary>
    public DateTime? DepartureDate { get; set; }

    /// <summary>
    /// Дата и время прибытия рейса.
    /// </summary>
    public DateTime? ArrivalDate { get; set; }

    /// <summary>
    /// Время отправления рейса.
    /// </summary>
    public TimeOnly? DepartureTime => DepartureDate.HasValue ? TimeOnly.FromDateTime(DepartureDate.Value) : null;

    /// <summary>
    /// Продолжительность рейса.
    /// </summary>
    public TimeSpan? Duration => (DepartureDate.HasValue && ArrivalDate.HasValue)
        ? ArrivalDate.Value - DepartureDate.Value
        : null;

    /// <summary>
    /// Тип самолета, используемого для рейса.
    /// </summary>
    public Aircraft? AircraftType { get; set; }

    /// <summary>
    /// Список зарегистрированных пассажиров на рейс.
    /// </summary>
    public List<RegisteredPassenger>? Passengers { get; set; }

    // Конструктор по умолчанию
    public Flight()
    {
        Id = -1;
        Passengers = new List<RegisteredPassenger>();
    }

    // Конструктор с параметрами
    public Flight(int id, string? number = null, string? departurePoint = null, string? arrivalPoint = null,
        DateTime? departureDate = null, DateTime? arrivalDate = null,
        Aircraft? aircraftType = null, List<RegisteredPassenger>? passengers = null)
    {
        Id = id;
        Number = number;
        DeparturePoint = departurePoint;
        ArrivalPoint = arrivalPoint;
        DepartureDate = departureDate;
        ArrivalDate = arrivalDate;
        AircraftType = aircraftType;
        Passengers = passengers;
    }
}