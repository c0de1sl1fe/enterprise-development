using AirCompany.Domain.Entities;

namespace AirCompany.Domain.Test;

public class TestDataProvider
{
    public List<Aircraft> aircrafts =
    [
        new Aircraft(1, "Boeing 737", 10000.0, 850.0, 180) { Id = 1 },
        new Aircraft(2, "Airbus A320", 12000.0, 900.0, 180) { Id = 2 },
        new Aircraft(3, "Boeing 777", 15000.0, 950.0, 300) { Id = 3 },
        new Aircraft(4, "Airbus A380", 20000.0, 900.0, 500) { Id = 4 },
        new Aircraft(5, "Embraer E195", 8000.0, 800.0, 120) { Id = 5 }
    ];

    public List<Passenger> passengers =
    [
        new(1, "ABC123456", "John Doe") { Id = 1 },
        new(2, "DEF789012", "Jane Smith") { Id = 2 },
        new(3, "GHI345678", "Alice Johnson") { Id = 3 },
        new(4, "JKL901234", "Bob Brown") { Id = 4 },
        new(5, "MNO567890", "Charlie Davis") { Id = 5 }
    ];

    public List<Flight> flights;
    public List<RegisteredPassenger> registeredPassengers;

    public TestDataProvider()
    {
        flights = new List<Flight>
        {
            new(1, "FL123", "New York", "Los Angeles", new DateTime(2023, 10, 15, 14, 0, 0),
                new DateTime(2023, 10, 15, 18, 0, 0), aircrafts[0],
                new List<RegisteredPassenger>
                {
                    new RegisteredPassenger(1, "RP001", "12A", 0.0, null, passengers[0]) { Id = 1 },
                    new RegisteredPassenger(2, "RP002", "12B", 15.0, null, passengers[1]) { Id = 2 },
                    new RegisteredPassenger(3, "RP003", "14A", 25.0, null, passengers[2]) { Id = 3 },
                    new RegisteredPassenger(4, "RP004", "18C", 30.0, null, passengers[3]) { Id = 4 }
                }) { Id = 1 },
            new(2, "FL456", "Chicago", "Miami", new DateTime(2023, 10, 15, 15, 0, 0),
                new DateTime(2023, 10, 15, 19, 0, 0), aircrafts[1],
                new List<RegisteredPassenger>
                {
                    new RegisteredPassenger(5, "RP005", "22D", 10.0, null, passengers[2]) { Id = 5 },
                    new RegisteredPassenger(6, "RP006", "10A", 0.0, null, passengers[2]) { Id = 6 }
                }) { Id = 2 },
            new(3, "FL789", "San Francisco", "Seattle", new DateTime(2023, 10, 15, 16, 0, 0),
                new DateTime(2023, 10, 15, 20, 0, 0), aircrafts[2],
                new List<RegisteredPassenger>
                {
                    new RegisteredPassenger(7, "RP007", "14A", 25.0, null, passengers[2]) { Id = 7 },
                    new RegisteredPassenger(8, "RP008", "18C", 30.0, null, passengers[3]) { Id = 8 },
                    new RegisteredPassenger(9, "RP009", "22D", 10.0, null, passengers[4]) { Id = 9 }
                }) { Id = 3 },
            new(4, "FL101", "Dallas", "Austin", new DateTime(2023, 10, 15, 17, 0, 0),
                new DateTime(2023, 10, 15, 21, 0, 0), aircrafts[3],
                new List<RegisteredPassenger>
                {
                    new RegisteredPassenger(10, "RP010", "12A", 0.0, null, passengers[0]) { Id = 10 },
                    new RegisteredPassenger(11, "RP011", "12B", 15.0, null, passengers[1]) { Id = 11 },
                    new RegisteredPassenger(12, "RP012", "14A", 25.0, null, passengers[2]) { Id = 12 },
                    new RegisteredPassenger(13, "RP013", "18C", 30.0, null, passengers[3]) { Id = 13 },
                    new RegisteredPassenger(14, "RP014", "22D", 10.0, null, passengers[4]) { Id = 14 }
                }) { Id = 4 },
            new(5, "FL202", "Boston", "Newark", new DateTime(2023, 10, 15, 18, 0, 0),
                new DateTime(2023, 10, 15, 22, 0, 0), aircrafts[4], 
                new List<RegisteredPassenger>
                {
                    new RegisteredPassenger(15, "RP015", "10A", 0.0, null, passengers[3]) { Id = 15 }
                }) { Id = 5 },
        };

        registeredPassengers = new List<RegisteredPassenger>
        {
            new(1, "RP001", "12A", 0.0, flights[0], passengers[0]) { Id = 1 },
            new(2, "RP002", "12B", 15.0, flights[0], passengers[1]) { Id = 2 },
            new(3, "RP003", "14A", 25.0, flights[1], passengers[2]) { Id = 3 },
            new(4, "RP004", "18C", 30.0, flights[2], passengers[3]) { Id = 4 },
            new(5, "RP005", "22D", 10.0, flights[3], passengers[4]) { Id = 5 },
            new(6, "RP006", "10A", 0.0, flights[4], passengers[3]) { Id = 6 },
        };
    }
}
