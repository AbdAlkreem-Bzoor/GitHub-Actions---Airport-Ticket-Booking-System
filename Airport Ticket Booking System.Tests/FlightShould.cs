using Airport_Ticket_Booking_System.Flights;
using AutoFixture;

namespace Airport_Ticket_Booking_System.Tests
{
    public class FlightShould
    {
        [Fact]
        public void CheckPropretiesValues()
        {
            var fixture = new Fixture();

            var departureCountry = fixture.Create<string>();
            var destinationCountry = fixture.Create<string>();
            var departureDate = fixture.Create<DateTime>();
            var departureAirport = fixture.Create<string>();
            var arrivalAirport = fixture.Create<string>();

            var flight = new Flight(departureCountry, destinationCountry, departureDate, 
                                    departureAirport, arrivalAirport);

            Assert.Equal(flight.DepartureCountry, departureCountry);
            Assert.Equal(flight.DestinationCountry, destinationCountry);
            Assert.Equal(flight.DepartureDate, departureDate);
            Assert.Equal(flight.DepartureAirport, departureAirport);
            Assert.Equal(flight.ArrivalAirport, arrivalAirport);
        }
    }
}
