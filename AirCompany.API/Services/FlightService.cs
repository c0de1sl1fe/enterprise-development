using AutoMapper;
using AirCompany.API.DTO;
using AirCompany.Domain.Entities;
using AirCompany.Domain.Repositories;

namespace AirCompany.API.Services;

/// <summary>
/// Сервис для управления данными о рейсах.
/// Реализует интерфейс IService для выполнения операций CRUD с рейсами.
/// </summary>
public class FlightService(
    IRepository<Flight> flightRepository,
    IRepository<Aircraft> aircraftRepository,
    IRepository<RegisteredPassenger> registeredPassengerRepository,
    IMapper mapper) : IService<FlightDto, FlightFullDto>
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
    public IEnumerable<FlightFullDto> GetAll()
    {
        return flightRepository.GetAll().Select(mapper.Map<FlightFullDto>);
    }

    /// <summary>
    /// Получает full-dto рейса по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор рейса.</param>
    /// <returns>Full-dto рейса с указанным идентификатором или null, если не найден.</returns>
    public FlightFullDto? GetById(int id)
    {
        var flight = flightRepository.GetById(id);
        if (flight == null) return null;
        var flightFullDto = mapper.Map<FlightFullDto>(flight);
        var test = registeredPassengerRepository.GetAll().ToList();
        flightFullDto.Passengers = registeredPassengerRepository.GetAll()
            .Where(p => p.Flight?.Id == flight.Id)
            .ToList()
            .Select(mapper.Map<RegisteredPassengerFullDto>)
            .ToList();
        if (flight.AircraftType != null) flightFullDto.AircraftTypeId = flight.AircraftType.Id;
        return flightFullDto;
    }

    /// <summary>
    /// Добавляет новый рейс.
    /// </summary>
    /// <param name="entity">DTO объекта рейса для добавления.</param>
    /// <returns>Full-dto добавленного рейса или null, если добавление не удалось.</returns>
    public FlightFullDto? Post(FlightDto entity)
    {
        var flight = mapper.Map<Flight>(entity);
        flight.Id = _id++;
        return mapper.Map<FlightFullDto>(flightRepository.Post(flight));
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