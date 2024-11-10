namespace AirCompany.Domain.Entities;

/// <summary>
/// Представляет информацию о пассажире.
/// </summary>
public class Passenger
{
    /// <summary>
    /// Уникальный идентификатор пассажира.
    /// </summary>
    public required int Id { get; set; }

    /// <summary>
    /// Номер паспорта пассажира.
    /// </summary>
    public string? PassportNumber { get; set; }

    /// <summary>
    /// Полное имя пассажира.
    /// </summary>
    public string? FullName { get; set; }

    // Конструктор по умолчанию
    public Passenger()
    {
        Id = -1;
    }

    // Конструктор с параметрами
    public Passenger(int id, string? passportNumber = null, string? fullName = null)
    {
        Id = id;
        PassportNumber = passportNumber;
        FullName = fullName;
    }
}