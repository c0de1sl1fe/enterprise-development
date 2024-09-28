namespace AirCompany.Domain;

/// <summary>
/// Представляет информацию о самолете.
/// </summary>
/// <param name="id">Уникальный идентификатор самолета.</param>
/// <param name="model">Модель самолета.</param>
/// <param name="capacity">Вместимость самолета.</param>
/// <param name="performance">Производительность самолета.</param>
/// <param name="maxPassengers">Максимальное количество пассажиров.</param>
public class Aircraft(int id, string model, decimal capacity, decimal performance, int maxPassengers)
{
    /// <summary>
    /// Уникальный идентификатор самолета.
    /// </summary>
    public int Id { get; set; } = id;

    /// <summary>
    /// Модель самолета.
    /// </summary>
    public string Model { get; set; } = model;

    /// <summary>
    /// Вместимость самолета.
    /// </summary>
    public decimal Capacity { get; set; } = capacity;

    /// <summary>
    /// Производительность самолета.
    /// </summary>
    public decimal Performance { get; set; } = performance;

    /// <summary>
    /// Максимальное количество пассажиров.
    /// </summary>
    public int MaxPassengers { get; set; } = maxPassengers;
}