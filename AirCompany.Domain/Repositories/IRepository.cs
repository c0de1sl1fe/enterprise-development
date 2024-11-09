namespace AirCompany.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями
/// </summary>
/// <typeparam name="T">Тип сущности</typeparam>
public interface IRepository<T>
{
    /// <summary>
    /// Получить все сущности
    /// </summary>
    /// <returns>Список сущностей</returns>
    public IEnumerable<T> GetAll();

    /// <summary>
    /// Получить сущность по идентификатору 
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <returns>Сущность с заданным идентификатором</returns>
    public T? GetById(int id);

    /// <summary>
    /// Добавить новую сущность
    /// </summary>
    /// <param name="entity">Новая сущность</param>
    /// <returns>Добавленная сущность</returns>
    public T? Post(T entity);

    /// <summary>
    /// Обновить сущность по идентификатору 
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <param name="entity">Новая сущность</param>
    /// <returns>Результат операции</returns>
    public bool Put(int id, T entity);

    /// <summary>
    /// Удалить сущность по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор сущности</param>
    /// <returns>Результат операции</returns>
    public bool Delete(int id);
}