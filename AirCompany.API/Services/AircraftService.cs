using AutoMapper;
using AirCompany.API.DTO;
using AirCompany.Domain.Entities;
using AirCompany.Domain.Repositories;

namespace AirCompany.API.Services;

/// <summary>
/// Сервис для управления данными о самолетах.
/// Реализует интерфейс IService для выполнения операций CRUD с самолетами.
/// </summary>
public class AircraftService(IRepository<Aircraft> aircraftRepository, IMapper mapper) : IService<AircraftDto, Aircraft>
{
    private int _id = 1;

    /// <summary>
    /// Удаляет самолет по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор самолета для удаления.</param>
    /// <returns>True, если удаление прошло успешно; иначе - False.</returns>
    public bool Delete(int id)
    {
        return aircraftRepository.Delete(id);
    }

    /// <summary>
    /// Получает список всех самолетов.
    /// </summary>
    /// <returns>Перечисление всех самолетов.</returns>
    public IEnumerable<Aircraft> GetAll()
    {
        return aircraftRepository.GetAll();
    }

    /// <summary>
    /// Получает самолет по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор самолета.</param>
    /// <returns>Самолет с указанным идентификатором или null, если не найден.</returns>
    public Aircraft? GetById(int id)
    {
        var aircraft = aircraftRepository.GetById(id);
        return aircraft;
    }

    /// <summary>
    /// Добавляет новый самолет.
    /// </summary>
    /// <param name="entity">DTO объекта самолета для добавления.</param>
    /// <returns>Добавленный самолет или null, если добавление не удалось.</returns>
    public Aircraft? Post(AircraftDto entity)
    {
        var aircraft = mapper.Map<Aircraft>(entity);
        aircraft.Id = _id++;
        return aircraftRepository.Post(aircraft);
    }

    /// <summary>
    /// Обновляет данные о самолете по указанному идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор самолета для обновления.</param>
    /// <param name="entity">DTO объекта самолета с новыми данными.</param>
    /// <returns>True, если обновление прошло успешно; иначе - False.</returns>
    public bool Put(int id, AircraftDto entity)
    {
        var aircraft = mapper.Map<Aircraft>(entity);
        return aircraftRepository.Put(id, aircraft);
    }
}
