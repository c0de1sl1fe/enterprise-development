namespace AirCompany.API.DTO;

/// <summary>
/// Представляет информацию о самолете для передачи данных.
/// </summary>
public class AircraftDto
{
    /// <summary>
    /// Модель самолета.
    /// </summary>
    public string? Model { get; set; }

    /// <summary>
    /// Вместимость самолета.
    /// </summary>
    public double? Capacity { get; set; }

    /// <summary>
    /// Производительность самолета.
    /// </summary>
    public double? Performance { get; set; }

    /// <summary>
    /// Максимальное количество пассажиров.
    /// </summary>
    public int? MaxPassengers { get; set; }
}