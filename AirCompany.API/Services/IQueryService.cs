using AirCompany.Domain.Entities;
using AirCompany.API.DTO;

namespace AirCompany.API.Services
{
    /// <summary>
    /// Интерфейс для сервиса запросов к данным об авиарейсах и пассажирах
    /// </summary>
    public interface IQueryService
    {
        /// <summary>
        /// Выводит сведения о всех авиарейсах, вылетевших из указанного пункта отправления в указанный пункт прибытия
        /// </summary>
        /// <param name="departure">Пункт отправления</param>
        /// <param name="arrival">Пункт прибытия</param>
        /// <returns>Список авиарейсов</returns>
        List<FlightFullDto> GetFlightsByDepartureAndArrival(string departure, string arrival);

        /// <summary>
        /// Выводит сведения обо всех пассажирах, летящих данным рейсом, вес багажа которых равен нулю, упорядочить по ФИО
        /// </summary>
        /// <param name="flightId">Идентификатор рейса</param>
        /// <returns>Список пассажиров</returns>
        List<RegisteredPassenger> GetPassengersWithNoBaggage(int flightId);

        /// <summary>
        /// Выводит сводную информацию обо всех полетах самолетов данного типа в указанный период времени
        /// </summary>
        /// <param name="aircraftTypeId">Тип самолета</param>
        /// <param name="startDate">Начальная дата</param>
        /// <param name="endDate">Конечная дата</param>
        /// <returns>Список полетов</returns>
        List<FlightInfoDto> GetFlightSummaryByAircraftType(int aircraftTypeId, DateTime startDate, DateTime endDate);

        /// <summary>
        /// Выводит топ 5 авиарейсов по количеству перевезённых пассажиров
        /// </summary>
        /// <returns>Топ 5 авиарейсов</returns>
        List<TopFlightsDto> GetTopFlightsByPassengerCount();

        /// <summary>
        /// Выводит список рейсов с минимальным временем в пути
        /// </summary>
        /// <returns>Список рейсов с минимальным временем в пути</returns>
        List<FlightFullDto> GetFlightsWithMinimumDuration();

        /// <summary>
        /// Выводит информацию о средней и максимальной загрузке авиарейсов из заданного пункта отправления
        /// </summary>
        /// <param name="departure">Пункт отправления</param>
        /// <returns>Средняя и максимальная загрузка</returns>
        LoadInfoDto GetLoadInfoByDeparture(string departure);
    }
}
