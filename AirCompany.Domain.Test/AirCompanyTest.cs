namespace AirCompany.Domain.Test;

public class AirCompanyTest(TestDataProvider testDataProvider) : IClassFixture<TestDataProvider>
{
    private readonly TestDataProvider _testDataProvider = testDataProvider;

    [Fact]
    public void TestSeeAllFlights()
    {
        var allFlights = _testDataProvider.flights.ToList();
        Assert.Equal(5, allFlights.Count);
    }

    /// <summary>
    /// Вывести сведения обо всех пассажирах, летящих данным рейсом, вес багажа которых равен нулю, упорядочить по ФИО.
    /// </summary>
    [Fact]
    public void TestPassengersWithNoBaggageOnFlight()
    {
        var flightId = 1; // ID рейса для поиска
        var passengers = _testDataProvider.registeredPassengers
            .Where(p => p.Flight!.Id == flightId && p.LuggageWeight == 0)
            .OrderBy(p => p.Passenger!.FullName)
            .ToList();

        Assert.NotEmpty(passengers);
        Assert.All(passengers, p => Assert.Equal(0, p.LuggageWeight));
    }

    /// <summary>
    /// Вывести сводную информацию обо всех полетах самолетов данного типа в указанный период времени.
    /// </summary>
    [Fact]
    public void TestSummaryOfFlightsByAircraftTypeInTimePeriod()
    {
        int aircraftTypeId = 1;
        DateTime startDate = new DateTime(2023, 10, 15, 14, 0, 0);
        DateTime endDate = new DateTime(2023, 10, 15, 18, 0, 0);

        var flights = _testDataProvider.flights
            .Where(f => f.AircraftType!.Id == aircraftTypeId && f.DepartureDate >= startDate && f.ArrivalDate <= endDate)
            .ToList();

        Assert.NotEmpty(flights);
        Assert.All(flights, f => Assert.Equal(aircraftTypeId, f.AircraftType!.Id));
        Assert.All(flights, f => Assert.True(f.DepartureDate >= startDate && f.DepartureDate <= endDate));
    }
    
    /// <summary>
    /// Вывести топ 5 авиарейсов по количеству перевезённых пассажиров.
    /// </summary>
    [Fact]
    public void TestTop5FlightsByPassengerCount()
    {
        var top5Flights = _testDataProvider.flights
            .OrderByDescending(f => f.Passengers.Count)
            .Take(5)
            .ToList();

        Assert.Equal(5, top5Flights.Count);
        Assert.Equal(_testDataProvider.flights[3], top5Flights[0]);
        Assert.Equal(_testDataProvider.flights[0], top5Flights[1]);
        Assert.Equal(_testDataProvider.flights[2], top5Flights[2]);
        Assert.Equal(_testDataProvider.flights[1], top5Flights[3]);
        Assert.Equal(_testDataProvider.flights[4], top5Flights[4]);
    }
    
    /// <summary>
    /// Вывести список рейсов с минимальным временем в пути.
    /// </summary>
    [Fact]
    public void TestFlightsWithMinimumFlightDuration()
    {
        var minDuration = _testDataProvider.flights.Min(f => f.Duration);
        var flightsWithMinDuration = _testDataProvider.flights
            .Where(f => f.Duration == minDuration)
            .ToList();

        Assert.NotEmpty(flightsWithMinDuration);
        Assert.All(flightsWithMinDuration, f => Assert.Equal(minDuration, f.Duration));
    }
    
    /// <summary>
    /// Проверка вывода средней и максимальной загрузки рейсов из указанного пункта отправления.
    /// </summary>
    [Fact]
    public void TestAverageAndMaxLoadFromDeparturePoint()
    {
        string departurePoint = "New York";

        var flightsFromPoint = _testDataProvider.flights
            .Where(f => f.DeparturePoint == departurePoint)
            .ToList();

        var averageLoad = flightsFromPoint.Average(f => f.Passengers.Count);
        var maxLoad = flightsFromPoint.Max(f => f.Passengers.Count);
        
        Assert.Equal(4, averageLoad);
        Assert.Equal(4, maxLoad);
    }
}