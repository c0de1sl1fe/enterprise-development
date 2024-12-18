using AutoMapper;
using AirCompany.API.DTO;
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
    : IService<RegisteredPassengerDto, RegisteredPassengerFullDto>
{
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
    public IEnumerable<RegisteredPassengerFullDto> GetAll()
    {
        return registeredPassengerRepository.GetAll().Select(mapper.Map<RegisteredPassengerFullDto>);
    }

    /// <summary>
    /// Получает зарегистрированного пассажира по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор зарегистрированного пассажира.</param>
    /// <returns>Full-dto зарегистрированного пассажира с указанным идентификатором или null, если не найден.</returns>
    public RegisteredPassengerFullDto? GetById(int id)
    {
        var registeredPassenger = registeredPassengerRepository.GetById(id);
        if (registeredPassenger == null) return null;

        var registeredPassengerFullDto = mapper.Map<RegisteredPassengerFullDto>(registeredPassenger);
        if (registeredPassenger.Passenger != null)
        {
            registeredPassengerFullDto.Passenger =
                mapper.Map<PassengerFullDto>(passengerRepository.GetById(registeredPassenger.Passenger.Id));
        }

        if (registeredPassenger.Flight != null)
        {
            registeredPassengerFullDto.Flight =
                mapper.Map<FlightFullDto>(flightRepository.GetById(registeredPassenger.Flight.Id));
        }

        return registeredPassengerFullDto;
    }

    /// <summary>
    /// Добавляет нового зарегистрированного пассажира.
    /// </summary>
    /// <param name="entity">DTO объекта зарегистрированного пассажира для добавления.</param>
    /// <returns>Full-dto добавленного зарегистрированного пассажира или null, если добавление не удалось.</returns>
    public RegisteredPassengerFullDto? Post(RegisteredPassengerDto entity)
    {
        var registeredPassenger = mapper.Map<RegisteredPassenger>(entity);
        if (registeredPassenger == null) return null;
        var registeredPassengerFullDto =
            mapper.Map<RegisteredPassengerFullDto>(registeredPassengerRepository.Post(registeredPassenger));
        if (entity.Passenger != null && registeredPassengerFullDto != null)
            registeredPassengerFullDto.Passenger =
                mapper.Map<PassengerFullDto>(passengerRepository.GetById(entity.Passenger.Id));
        if (entity.Flight != null && registeredPassengerFullDto != null)
            registeredPassengerFullDto.Flight = mapper.Map<FlightFullDto>(flightRepository.GetById(entity.Flight.Id));
        return registeredPassengerFullDto;
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