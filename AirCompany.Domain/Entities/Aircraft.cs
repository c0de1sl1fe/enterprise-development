using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirCompany.Domain.Entities;

/// <summary>
/// Представляет информацию о самолете.
/// </summary>
[Table("aircraft")]
public class Aircraft
{
    /// <summary>
    /// Уникальный идентификатор самолета.
    /// </summary>
    [Key]
    [Column("id")]
    public required int Id { get; set; }

    /// <summary>
    /// Модель самолета.
    /// </summary>
    [Column("model")]
    public string? Model { get; set; } 
    
    /// <summary>
    /// Вместимость самолета.
    /// </summary>
    [Column("capacity")]
    public double? Capacity { get; set; }

    /// <summary>
    /// Производительность самолета.
    /// </summary>
    [Column("performance")]
    public double? Performance { get; set; }

    /// <summary>
    /// Максимальное количество пассажиров.
    /// </summary>
    [Column("max_passengers")]
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