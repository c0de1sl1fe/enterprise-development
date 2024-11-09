namespace AirCompany.API.DTO;


/// <summary>
/// Представляет зарегистрированного пассажира на рейсе для передачи данных.
/// </summary>
public class RegisteredPassengerDto
{
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
    public int? FlightId { get; set; }

    /// <summary>
    /// Идентификатор пассажира, зарегистрированного на рейс.
    /// </summary>
    public int? PassengerId { get; set; }
}
