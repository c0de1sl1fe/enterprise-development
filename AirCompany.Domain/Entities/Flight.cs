using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain.Entities;

/// <summary>
/// Представляет информацию о рейсе.
/// </summary>
[Table("flight")]
public class Flight
{
    /// <summary>
    /// Уникальный идентификатор рейса.
    /// </summary>
    [Key]
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Номер рейса.
    /// </summary>
    [Column("number")]
    public string? Number { get; set; }

    /// <summary>
    /// Место отправления рейса.
    /// </summary>
    [Column("departure_point")]
    public string? DeparturePoint { get; set; }

    /// <summary>
    /// Место назначения рейса.
    /// </summary>
    [Column("arrival_point")]
    public string? ArrivalPoint { get; set; }

    /// <summary>
    /// Дата и время отправления рейса.
    /// </summary>
    [Column("departure_date")]
    public DateTime? DepartureDate { get; set; }

    /// <summary>
    /// Дата и время прибытия рейса.
    /// </summary>
    [Column("arrival_date")]
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
    [ForeignKey("AircraftType")]
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
        Passengers = passengers ?? new List<RegisteredPassenger>();
    }
}
