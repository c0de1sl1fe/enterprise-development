namespace AirCompany.Domain.Entities;

/// <summary>
/// Представляет информацию о самолете.
/// </summary>
public class Aircraft
{
    /// <summary>
    /// Уникальный идентификатор самолета.
    /// </summary>
    public required int Id { get; set; }

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

    // Конструктор по умолчанию
    public Aircraft()
    {
        Id = 1;
    }

    // Конструктор с параметрами
    public Aircraft(int id, string? model = null, double? capacity = null, double? performance = null,
        int? maxPassengers = null)
    {
        Id = id;
        Model = model;
        Capacity = capacity;
        Performance = performance;
        MaxPassengers = maxPassengers;
    }
}