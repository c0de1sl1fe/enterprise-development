using AirCompany.API.Services;
using Microsoft.AspNetCore.Mvc;
using AirCompany.API.DTO;
using AirCompany.Domain.Entities;

namespace AirCompany.API.Controllers;

/// <summary>
/// Контроллер для управления самолетами 
/// </summary>
/// <param name="aircraftService">Репозиторий для работы с самолетами</param>
[Route("api/[controller]")]
[ApiController]
public class AircraftController(IService<AircraftDto, Aircraft> aircraftService) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех самолетов
    /// </summary>
    /// <returns>Список самолетов</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Aircraft>> Get()
    {
        return Ok(aircraftService.GetAll());
    }

    /// <summary>
    /// Возвращает самолет по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор самолета</param>
    /// <returns>Самолет или "Не найдено"</returns>
    [HttpGet("{id}")]
    public ActionResult<Aircraft> Get(int id)
    {
        var result = aircraftService.GetById(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Добавляет новый самолет 
    /// </summary>
    /// <param name="value">Информация о новом самолете</param>
    /// <returns>Добавленный самолет или "Плохой запрос"</returns>
    [HttpPost]
    public ActionResult<Aircraft> Post([FromBody] AircraftDto value)
    {
        var result = aircraftService.Post(value);
        if (result == null)
            return BadRequest();

        return Ok(result);
    }

    /// <summary>
    /// Изменяет самолет по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор самолета</param>
    /// <param name="value">Обновлённая информация о самолете</param>
    /// <returns>Результат операции</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] AircraftDto value)
    {
        var result = aircraftService.Put(id, value);
        if (!result)
            return BadRequest();

        return Ok();
    }

    /// <summary>
    /// Удаляет самолет по идентификатору 
    /// </summary>
    /// <param name="id">Идентификатор самолета</param>
    /// <returns>Результат операции</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = aircraftService.Delete(id);
        if (!result)
            return NotFound();

        return Ok();
    }
}