namespace AirCompany.Domain.Entities;

/// <summary>
/// Представляет зарегистрированного пассажира на рейсе.
/// </summary>
public class RegisteredPassenger
{
    /// <summary>
    /// Уникальный идентификатор зарегистрированного пассажира.
    /// </summary>
    public required int Id { get; set; }

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
    /// Рейс, на который зарегистрирован пассажир.
    /// </summary>
    public Flight? Flight { get; set; }

    /// <summary>
    /// Пассажир, зарегистрированный на рейс.
    /// </summary>
    public Passenger? Passenger { get; set; }

    // Конструктор по умолчанию
    public RegisteredPassenger()
    {
        Id = -1;    
    }

    // Конструктор с параметрами
    public RegisteredPassenger(int id, string? number = null, string? seatNumber = null, double? luggageWeight = null, Flight? flight = null, Passenger? passenger = null)
    {
        Id = id;
        Number = number;
        SeatNumber = seatNumber;
        LuggageWeight = luggageWeight;
        Flight = flight;
        Passenger = passenger;
    }
}
