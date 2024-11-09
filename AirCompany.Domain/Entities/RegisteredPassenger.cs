namespace AirCompany.Domain.Entities;

/// <summary>
/// Представляет зарегистрированного пассажира на рейсе.
/// </summary>
/// <param name="id">Уникальный идентификатор зарегистрированного пассажира.</param>
/// <param name="number">Номер зарегистрированного пассажира.</param>
/// <param name="seatNumber">Номер места, назначенного пассажиру.</param>
/// <param name="luggageWeight">Вес багажа пассажира.</param>
/// <param name="flight">Рейс, на который зарегистрирован пассажир.</param>
/// <param name="passenger">Пассажир, зарегистрированный на рейс.</param>
public class RegisteredPassenger(
    int id,
    string? number,
    string? seatNumber,
    double? luggageWeight,
    Flight? flight,
    Passenger? passenger)
{
    /// <summary>
    /// Уникальный идентификатор зарегистрированного пассажира.
    /// </summary>
    public required int Id { get; set; } = id;

    /// <summary>
    /// Номер зарегистрированного пассажира.
    /// </summary>
    public string? Number { get; set; } = number;

    /// <summary>
    /// Номер места, назначенного пассажиру.
    /// </summary>
    public string? SeatNumber { get; set; } = seatNumber;

    /// <summary>
    /// Вес багажа пассажира.
    /// </summary>
    public double? LuggageWeight { get; set; } = luggageWeight;

    /// <summary>
    /// Рейс, на который зарегистрирован пассажир.
    /// </summary>
    public Flight? Flight { get; set; } = flight;

    /// <summary>
    /// Пассажир, зарегистрированный на рейс.
    /// </summary>
    public Passenger? Passenger { get; set; } = passenger;
}