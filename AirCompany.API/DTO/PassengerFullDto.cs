namespace AirCompany.API.DTO;

/// <summary>
/// Представляет полную информацию о пассажире для передачи данных.
/// </summary>
public class PassengerFullDto
{
    /// <summary>
    /// Идентификатор пассажира.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Номер паспорта пассажира.
    /// </summary>
    public string? PassportNumber { get; set; }

    /// <summary>
    /// Полное имя пассажира.
    /// </summary>
    public string? FullName { get; set; }
}