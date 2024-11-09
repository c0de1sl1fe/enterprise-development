using Microsoft.AspNetCore.Mvc;
using AirCompany.API.DTO;
using AirCompany.API.Services;
using AirCompany.Domain.Entities;

namespace AirCompany.API.Controllers;

/// <summary>
/// Контроллер для управления зарегистрированными пассажирами 
/// </summary>
/// <param name="registeredPassengerService">Репозиторий для работы с зарегистрированными пассажирами</param>
[Route("api/[controller]")]
[ApiController]
public class RegisteredPassengerController(
    IService<RegisteredPassengerDto, RegisteredPassenger> registeredPassengerService) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех зарегистрированных пассажиров
    /// </summary>
    /// <returns>Список зарегистрированных пассажиров</returns>
    [HttpGet]
    public ActionResult<IEnumerable<RegisteredPassenger>> Get()
    {
        return Ok(registeredPassengerService.GetAll());
    }

    /// <summary>
    /// Возвращает зарегистрированного пассажира по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор зарегистрированного пассажира</param>
    /// <returns>Зарегистрированный пассажир или "Не найдено"</returns>
    [HttpGet("{id}")]
    public ActionResult<RegisteredPassenger> Get(int id)
    {
        var result = registeredPassengerService.GetById(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Добавляет нового зарегистрированного пассажира 
    /// </summary>
    /// <param name="value">Информация о новом зарегистрированном пассажире</param>
    /// <returns>Добавленный зарегистрированный пассажир или "Плохой запрос"</returns>
    [HttpPost]
    public ActionResult<RegisteredPassenger> Post([FromBody] RegisteredPassengerDto value)
    {
        var result = registeredPassengerService.Post(value);
        if (result == null)
            return BadRequest();

        return Ok(result);
    }

    /// <summary>
    /// Изменяет зарегистрированного пассажира по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор зарегистрированного пассажира</param>
    /// <param name="value">Обновлённая информация о зарегистрированном пассажире</param>
    /// <returns>Результат операции</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] RegisteredPassengerDto value)
    {
        var result = registeredPassengerService.Put(id, value);
        if (!result)
            return BadRequest();

        return Ok();
    }

    /// <summary>
    /// Удаляет зарегистрированного пассажира по идентификатору 
    /// </summary>
    /// <param name="id">Идентификатор зарегистрированного пассажира</param>
    /// <returns>Результат операции</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = registeredPassengerService.Delete(id);
        if (!result)
            return NotFound();

        return Ok();
    }
}