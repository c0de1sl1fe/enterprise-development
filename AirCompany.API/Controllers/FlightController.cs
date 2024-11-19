using AirCompany.API.Services;
using Microsoft.AspNetCore.Mvc;
using AirCompany.API.DTO;
using AirCompany.Domain.Entities;

namespace AirCompany.API.Controllers;

/// <summary>
/// Контроллер для управления рейсами 
/// </summary>
/// <param name="flightService">Репозиторий для работы с рейсами</param>
[Route("api/[controller]")]
[ApiController]
public class FlightController(IService<FlightDto, FlightFullDto> flightService) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех рейсов
    /// </summary>
    /// <returns>Список рейсов</returns>
    [HttpGet]
    public ActionResult<IEnumerable<FlightFullDto>> Get()
    {
        return Ok(flightService.GetAll());
    }

    /// <summary>
    /// Возвращает рейс по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор рейса</param>
    /// <returns>Рейс или "Не найдено"</returns>
    [HttpGet("{id}")]
    public ActionResult<FlightFullDto> Get(int id)
    {
        var result = flightService.GetById(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Добавляет новый рейс 
    /// </summary>
    /// <param name="value">Информация о новом рейсе</param>
    /// <returns>Добавленный рейс или "Плохой запрос"</returns>
    [HttpPost]
    public ActionResult<FlightFullDto> Post([FromBody] FlightDto value)
    {
        var result = flightService.Post(value);
        if (result == null)
            return BadRequest();

        return Ok(result);
    }

    /// <summary>
    /// Изменяет рейс по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор рейса</param>
    /// <param name="value">Обновлённая информация о рейсе</param>
    /// <returns>Результат операции</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] FlightDto value)
    {
        var result = flightService.Put(id, value);
        if (!result)
            return BadRequest();

        return Ok();
    }

    /// <summary>
    /// Удаляет рейс по идентификатору 
    /// </summary>
    /// <param name="id">Идентификатор рейса</param>
    /// <returns>Результат операции</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = flightService.Delete(id);
        if (!result)
            return NotFound();

        return Ok();
    }
}