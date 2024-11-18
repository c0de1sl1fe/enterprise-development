using AirCompany.Domain.Entities;

namespace AirCompany.Domain.Repositories;

/// <summary>
/// Репозиторий для работы с сущностями Passenger.
/// Реализует интерфейс IRepository для управления коллекцией пассажиров.
/// </summary>
public class PassengerRepository : IRepository<Passenger>
{
    private readonly List<Passenger> _passengers = [];

    /// <summary>
    /// Удаляет пассажира по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пассажира, который нужно удалить.</param>
    /// <returns>Возвращает true, если пассажир был успешно удален; иначе false.</returns>
    public bool Delete(int id)
    {
        var passenger = GetById(id);

        if (passenger == null)
            return false;

        _passengers.Remove(passenger);
        return true;
    }

    /// <summary>
    /// Получает всех пассажиров.
    /// </summary>
    /// <returns>Возвращает перечисление всех пассажиров.</returns>
    public IEnumerable<Passenger> GetAll() => _passengers;

    /// <summary>
    /// Получает пассажира по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пассажира.</param>
    /// <returns>Возвращает пассажира с заданным идентификатором или null, если не найден.</returns>
    public Passenger? GetById(int id) => _passengers.Find(p => p.Id == id);

    /// <summary>
    /// Добавляет нового пассажира в репозиторий.
    /// </summary>
    /// <param name="entity">Новый пассажир, который нужно добавить.</param>
    /// <returns>Возвращает добавленного пассажира.</returns>
    public Passenger? Post(Passenger entity)
    {
        // Добавляем пассажира в список
        _passengers.Add(entity);
        return entity;
    }

    /// <summary>
    /// Обновляет информацию о пассажире по заданному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пассажира, который нужно обновить.</param>
    /// <param name="entity">Объект пассажира с новыми данными.</param>
    /// <returns>Возвращает true, если пассажир был успешно обновлен; иначе false.</returns>
    public bool Put(int id, Passenger entity)
    {
        var oldPassenger = GetById(id);
        if (oldPassenger == null)
            return false;

        oldPassenger.PassportNumber = entity.PassportNumber;
        oldPassenger.FullName = entity.FullName;
        return true;
    }
}