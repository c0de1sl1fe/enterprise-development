using AutoMapper;
using AirCompany.API.DTO;
using AirCompany.Domain.Entities;
using AirCompany.Domain.Repositories;

namespace AirCompany.API.Services;

/// <summary>
/// Сервис для управления данными о пассажирах.
/// Реализует интерфейс IService для выполнения операций CRUD с пассажирами.
/// </summary>
public class PassengerService(IRepository<Passenger> passengerRepository, IMapper mapper)
    : IService<PassengerDto, Passenger>
{
    private int _id = 1;

    /// <summary>
    /// Удаляет пассажира по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пассажира для удаления.</param>
    /// <returns>True, если удаление прошло успешно; иначе - False.</returns>
    public bool Delete(int id)
    {
        return passengerRepository.Delete(id);
    }

    /// <summary>
    /// Получает список всех пассажиров.
    /// </summary>
    /// <returns>Перечисление всех пассажиров.</returns>
    public IEnumerable<Passenger> GetAll()
    {
        return passengerRepository.GetAll();
    }

    /// <summary>
    /// Получает пассажира по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пассажира.</param>
    /// <returns>Пассажир с указанным идентификатором или null, если не найден.</returns>
    public Passenger? GetById(int id)
    {
        var passenger = passengerRepository.GetById(id);
        return passenger;
    }

    /// <summary>
    /// Добавляет нового пассажира.
    /// </summary>
    /// <param name="entity">DTO объекта пассажира для добавления.</param>
    /// <returns>Добавленный пассажир или null, если добавление не удалось.</returns>
    public Passenger? Post(PassengerDto entity)
    {
        var passenger = mapper.Map<Passenger>(entity);
        passenger.Id = _id++;
        return passengerRepository.Post(passenger);
    }

    /// <summary>
    /// Обновляет данные о пассажире по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор пассажира для обновления.</param>
    /// <param name="entity">DTO объекта пассажира с новыми данными.</param>
    /// <returns>True, если обновление прошло успешно; иначе - False.</returns>
    public bool Put(int id, PassengerDto entity)
    {
        var passenger = mapper.Map<Passenger>(entity);
        return passengerRepository.Put(id, passenger);
    }
}
