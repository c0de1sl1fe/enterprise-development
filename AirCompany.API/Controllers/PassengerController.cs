using AirCompany.API.Services;
using Microsoft.AspNetCore.Mvc;
using AirCompany.API.DTO;
using AirCompany.Domain.Entities;

namespace AirCompany.API.Controllers;

/// <summary>
/// Контроллер для управления пассажирами 
/// </summary>
/// <param name="passengerService">Репозиторий для работы с пассажирами</param>
[Route("api/[controller]")]
[ApiController]
public class PassengerController(IService<PassengerDto, Passenger> passengerService) : ControllerBase
{
    /// <summary>
    /// Возвращает список всех пассажиров
    /// </summary>
    /// <returns>Список пассажиров</returns>
    [HttpGet]
    public ActionResult<IEnumerable<Passenger>> Get()
    {
        return Ok(passengerService.GetAll());
    }

    /// <summary>
    /// Возвращает пассажира по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор пассажира</param>
    /// <returns>Пассажир или "Не найдено"</returns>
    [HttpGet("{id}")]
    public ActionResult<Passenger> Get(int id)
    {
        var result = passengerService.GetById(id);
        if (result == null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Добавляет нового пассажира 
    /// </summary>
    /// <param name="value">Информация о новом пассажире</param>
    /// <returns>Добавленный пассажир или "Плохой запрос"</returns>
    [HttpPost]
    public ActionResult<Passenger> Post([FromBody] PassengerDto value)
    {
        var result = passengerService.Post(value);
        if (result == null)
            return BadRequest();

        return Ok(result);
    }

    /// <summary>
    /// Изменяет пассажира по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор пассажира</param>
    /// <param name="value">Обновлённая информация о пассажире</param>
    /// <returns>Результат операции</returns>
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] PassengerDto value)
    {
        var result = passengerService.Put(id, value);
        if (!result)
            return BadRequest();

        return Ok();
    }

    /// <summary>
    /// Удаляет пассажира по идентификатору 
    /// </summary>
    /// <param name="id">Идентификатор пассажира</param>
    /// <returns>Результат операции</returns>
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var result = passengerService.Delete(id);
        if (!result)
            return NotFound();

        return Ok();
    }
}
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860