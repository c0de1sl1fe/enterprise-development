using AutoMapper;
using AirCompany.API.DTO;
using AirCompany.Domain.Entities;
using AirCompany.Domain.Repositories;

namespace AirCompany.API.Services;

/// <summary>
/// Сервис для управления данными о рейсах.
/// Реализует интерфейс IService для выполнения операций CRUD с рейсами.
/// </summary>
public class FlightService(IRepository<Flight> flightRepository, IMapper mapper) : IService<FlightDto, Flight>
{
    private int _id = 1;

    /// <summary>
    /// Удаляет рейс по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор рейса для удаления.</param>
    /// <returns>True, если удаление прошло успешно; иначе - False.</returns>
    public bool Delete(int id)
    {
        return flightRepository.Delete(id);
    }

    /// <summary>
    /// Получает список всех рейсов.
    /// </summary>
    /// <returns>Перечисление всех рейсов.</returns>
    public IEnumerable<Flight> GetAll()
    {
        return flightRepository.GetAll();
    }

    /// <summary>
    /// Получает рейс по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор рейса.</param>
    /// <returns>Рейс с указанным идентификатором или null, если не найден.</returns>
    public Flight? GetById(int id)
    {
        var flight = flightRepository.GetById(id);
        return flight;
    }

    /// <summary>
    /// Добавляет новый рейс.
    /// </summary>
    /// <param name="entity">DTO объекта рейса для добавления.</param>
    /// <returns>Добавленный рейс или null, если добавление не удалось.</returns>
    public Flight? Post(FlightDto entity)
    {
        var flight = mapper.Map<Flight>(entity);
        flight.Id = _id++;
        return flightRepository.Post(flight);
    }

    /// <summary>
    /// Обновляет данные о рейсе по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор рейса для обновления.</param>
    /// <param name="entity">DTO объекта рейса с новыми данными.</param>
    /// <returns>True, если обновление прошло успешно; иначе - False.</returns>
    public bool Put(int id, FlightDto entity)
    {
        var flight = mapper.Map<Flight>(entity);
        return flightRepository.Put(id, flight);
    }
}
