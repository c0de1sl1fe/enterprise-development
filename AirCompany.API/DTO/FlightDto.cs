namespace AirCompany.API.DTO;

/// <summary>
/// Представляет информацию о рейсе для передачи данных.
/// </summary>
public class FlightDto
{
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
    /// Идентификатор типа самолета, используемого для рейса.
    /// </summary>
    public int AircraftTypeId { get; set; }
}