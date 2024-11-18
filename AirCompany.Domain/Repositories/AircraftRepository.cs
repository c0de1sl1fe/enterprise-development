using AirCompany.Domain.Entities;

namespace AirCompany.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями Aircraft.
/// Реализует интерфейс IRepository для управления коллекцией самолетов.
/// </summary>
public class AircraftRepository : IRepository<Aircraft>
{
    private readonly List<Aircraft> _aircrafts = [];

    /// <summary>
    /// Удаляет самолет по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор самолета, который нужно удалить.</param>
    /// <returns>Возвращает true, если самолет был успешно удален; иначе false.</returns>
    public bool Delete(int id)
    {
        var value = GetById(id);

        if (value == null)
            return false;

        _aircrafts.Remove(value);
        return true;
    }

    /// <summary>
    /// Получает все самолеты.
    /// </summary>
    /// <returns>Возвращает перечисление всех самолетов.</returns>
    public IEnumerable<Aircraft> GetAll() => _aircrafts;

    /// <summary>
    /// Получает самолет по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор самолета.</param>
    /// <returns>Возвращает самолет с заданным идентификатором или null, если не найден.</returns>
    public Aircraft? GetById(int id) => _aircrafts.Find(a => a.Id == id);

    /// <summary>
    /// Добавляет новый самолет в репозиторий.
    /// </summary>
    /// <param name="entity">Новый самолет, который нужно добавить.</param>
    /// <returns>Возвращает добавленный самолет.</returns>
    public Aircraft? Post(Aircraft entity)
    {
        _aircrafts.Add(entity);
        return entity;
    }

    /// <summary>
    /// Обновляет информацию о самолете по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор самолета, который нужно обновить.</param>
    /// <param name="entity">Объект самолета с новыми данными.</param>
    /// <returns>Возвращает true, если самолет был успешно обновлен; иначе false.</returns>
    public bool Put(int id, Aircraft entity)
    {
        var oldValue = GetById(id);
        if (oldValue == null)
            return false;

        oldValue.Model = entity.Model;
        oldValue.Capacity = entity.Capacity;
        oldValue.Performance = entity.Performance;
        oldValue.MaxPassengers = entity.MaxPassengers;
        return true;
    }
}