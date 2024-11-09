namespace AirCompany.API.Services;

/// <summary>
/// Интерфейс для сервисов сущностей
/// </summary>
/// <typeparam name="Dt">Тип сущности Dto</typeparam>
/// <typeparam name="T">Тип сущности</typeparam>
public interface IService<Dt, T> 
{
    /// <summary>
    /// Получение всех сущностей
    /// </summary>
    /// <returns>Список сущностей</returns>
    public IEnumerable<T> GetAll();

    /// <summary>
    /// Получение сущности по идентификатору 
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <returns>Сущность с выбранным идентификатором</returns>
    public T? GetById(int id);

    /// <summary>
    /// Добавление сущности
    /// </summary>
    /// <param name="entity">Новая сущность</param>
    /// <returns>Добавленная сущность</returns>
    public T? Post(Dt entity);

    /// <summary>
    /// Обновляет сущность по идентификатору 
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <param name="entity">Новая сущность</param>
    /// <returns>Результат операции</returns>
    public bool Put(int id, Dt entity);

    /// <summary>
    /// Удаляет сущность по идентификатору 
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <returns>Результат операции</returns>
    public bool Delete(int id);
}