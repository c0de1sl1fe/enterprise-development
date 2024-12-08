using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain.Entities;

public class Passenger
{
    /// <summary>
    /// Уникальный идентификатор пассажира.
    /// </summary>
    [Key]
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Номер паспорта пассажира.
    /// </summary>
    [Column("passport_number")]
    public string? PassportNumber { get; set; }

    /// <summary>
    /// Полное имя пассажира.
    /// </summary>
    [Column("full_name")]
    public string? FullName { get; set; }

    /// <summary>
    /// Список зарегистрированных пассажиров на рейсы.
    /// </summary>
    public List<RegisteredPassenger>? RegisteredPassengers { get; set; }

    // Конструктор по умолчанию
    public Passenger()
    {
        RegisteredPassengers = new List<RegisteredPassenger>();
    }

    // Конструктор с параметрами
    public Passenger(int id, string? passportNumber = null, string? fullName = null)
    {
        Id = id;
        PassportNumber = passportNumber;
        FullName = fullName;
        RegisteredPassengers = new List<RegisteredPassenger>();
    }
}