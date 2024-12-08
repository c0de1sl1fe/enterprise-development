using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain.Entities;

/// <summary>
/// Представляет зарегистрированного пассажира на рейсе.
/// </summary>
[Table("registered_passenger")]
public class RegisteredPassenger
{
    /// <summary>
    /// Уникальный идентификатор зарегистрированного пассажира.
    /// </summary>
    [Key]
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Номер зарегистрированного пассажира.
    /// </summary>
    [Column("number")]
    public string? Number { get; set; }

    /// <summary>
    /// Номер места, назначенного пассажиру.
    /// </summary>
    [Column("seat_number")]
    public string? SeatNumber { get; set; }

    /// <summary>
    /// Вес багажа пассажира.
    /// </summary>
    [Column("luggage_weight")]
    public double? LuggageWeight { get; set; }

    /// <summary>
    /// Рейс, на который зарегистрирован пассажир.
    /// </summary>
    public Flight? Flight { get; set; }

    /// <summary>
    /// Пассажир, зарегистрированный на рейс.
    /// </summary>
    public Passenger? Passenger { get; set; }

    /// <summary>
    /// Идентификатор рейса.
    /// </summary>
    [ForeignKey("Flight")]
    public int FlightId { get; set; } // Добавлено

    /// <summary>
    /// Идентификатор пассажира.
    /// </summary>
    [ForeignKey("Passenger")]
    public int PassengerId { get; set; } // Добавлено

    public RegisteredPassenger()
    {
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

	public RegisteredPassenger(int id, string? number = null, string? seatNumber = null, double? luggageWeight = null)
	{
		Id = id;
		Number = number;
		SeatNumber = seatNumber;
		LuggageWeight = luggageWeight;
	}
}