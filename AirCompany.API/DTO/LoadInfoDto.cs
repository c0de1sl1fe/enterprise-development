namespace AirCompany.API.DTO;

/// <summary>
/// DTO для информации о загрузке рейсов
/// </summary>
public class LoadInfoDto
{
    /// <summary>
    /// Средняя загрузка
    /// </summary>
    public double AverageLoad { get; set; }

    /// <summary>
    /// Максимальная загрузка
    /// </summary>
    public int MaxLoad { get; set; }
}