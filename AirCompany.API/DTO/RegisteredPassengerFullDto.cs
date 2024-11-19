namespace AirCompany.API.DTO;

/// <summary>
/// Представляет полную информацию о зарегистрированном пассажире на рейсе для передачи данных.
/// </summary>
public class RegisteredPassengerFullDto
{
    /// <summary>
    /// Идентификатор зарегистрированного пассажира.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Номер зарегистрированного пассажира.
    /// </summary>
    public string? Number { get; set; }

    /// <summary>
    /// Номер места, назначенного пассажиру.
    /// </summary>
    public string? SeatNumber { get; set; }

    /// <summary>
    /// Вес багажа пассажира.
    /// </summary>
    public double? LuggageWeight { get; set; }

    /// <summary>
    /// Идентификатор рейса, на который зарегистрирован пассажир.
    /// </summary>
    public FlightFullDto? Flight { get; set; }

    /// <summary>
    /// Идентификатор пассажира, зарегистрированного на рейс.
    /// </summary>
    public PassengerFullDto? Passenger { get; set; }
}