namespace AirCompany.API.DTO;

/// <summary>
/// Представляет информацию о пассажире для передачи данных.
/// </summary>
public class PassengerDto
{
    /// <summary>
    /// Номер паспорта пассажира.
    /// </summary>
    public string? PassportNumber { get; set; }

    /// <summary>
    /// Полное имя пассажира.
    /// </summary>
    public string? FullName { get; set; }
}
