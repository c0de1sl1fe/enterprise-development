using AutoMapper;
using AirCompany.API.DTO;
using AirCompany.Domain;
using AirCompany.Domain.Entities;
using AirCompany.Domain.Repositories;

namespace AirCompany.API.Services;

/// <summary>
/// Сервис для управления данными о зарегистрированных пассажирах.
/// Реализует интерфейс IService для выполнения операций CRUD с зарегистрированными пассажирами.
/// </summary>
public class RegisteredPassengerService(
    IRepository<RegisteredPassenger> registeredPassengerRepository,
    IRepository<Flight> flightRepository,
    IRepository<Passenger> passengerRepository,
    IMapper mapper)
    : IService<RegisteredPassengerDto, RegisteredPassenger>
{
    private int _id = 1;

    /// <summary>
    /// Удаляет зарегистрированного пассажира по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор зарегистрированного пассажира для удаления.</param>
    /// <returns>True, если удаление прошло успешно; иначе - False.</returns>
    public bool Delete(int id)
    {
        return registeredPassengerRepository.Delete(id);
    }

    /// <summary>
    /// Получает список всех зарегистрированных пассажиров.
    /// </summary>
    /// <returns>Перечисление всех зарегистрированных пассажиров.</returns>
    public IEnumerable<RegisteredPassenger> GetAll()
    {
        return registeredPassengerRepository.GetAll();
    }

    /// <summary>
    /// Получает зарегистрированного пассажира по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор зарегистрированного пассажира.</param>
    /// <returns>Зарегистрированный пассажир с указанным идентификатором или null, если не найден.</returns>
    public RegisteredPassenger? GetById(int id)
    {
        var registeredPassenger = registeredPassengerRepository.GetById(id);
        return registeredPassenger;
    }

    /// <summary>
    /// Добавляет нового зарегистрированного пассажира.
    /// </summary>
    /// <param name="entity">DTO объекта зарегистрированного пассажира для добавления.</param>
    /// <returns>Добавленный зарегистрированный пассажир или null, если добавление не удалось.</returns>
    public RegisteredPassenger? Post(RegisteredPassengerDto entity)
    {
        var registeredPassenger = mapper.Map<RegisteredPassenger>(entity);
        registeredPassenger.Id = _id++;
        registeredPassenger.Passenger = passengerRepository.GetById(entity.PassengerId);
        registeredPassenger.Flight = flightRepository.GetById(entity.FlightId);
        return registeredPassengerRepository.Post(registeredPassenger);
    }

    /// <summary>
    /// Обновляет данные о зарегистрированном пассажире по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор зарегистрированного пассажира для обновления.</param>
    /// <param name="entity">DTO объекта зарегистрированного пассажира с новыми данными.</param>
    /// <returns>True, если обновление прошло успешно; иначе - False.</returns>
    public bool Put(int id, RegisteredPassengerDto entity)
    {
        var registeredPassenger = mapper.Map<RegisteredPassenger>(entity);
        return registeredPassengerRepository.Put(id, registeredPassenger);
    }
}