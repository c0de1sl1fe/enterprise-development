namespace AirCompany.Domain.Entities;

/// <summary>
/// Представляет информацию о пассажире.
/// </summary>
/// <param name="id">Уникальный идентификатор пассажира.</param>
/// <param name="passportNumber">Номер паспорта пассажира.</param>
/// <param name="fullName">Полное имя пассажира.</param>
public class Passenger(
    int id,
    string? passportNumber,
    string? fullName)
{
    /// <summary>
    /// Уникальный идентификатор пассажира.
    /// </summary>
    public required int Id { get; set; } = id;

    /// <summary>
    /// Номер паспорта пассажира.
    /// </summary>
    public string? PassportNumber { get; set; } = passportNumber;

    /// <summary>
    /// Полное имя пассажира.
    /// </summary>
    public string? FullName { get; set; } = fullName;
}