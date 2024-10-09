using Airport_Ticket_Booking_System.Flights;
using Airport_Ticket_Booking_System.Tickets;
using AutoFixture;

namespace Airport_Ticket_Booking_System.Tests
{
    public class TicketShould
    {
        [Fact]
        public void CheckPropertiesValues()
        {
            var fixture = new Fixture();

            var departureCountry = fixture.Create<string>();
            var destinationCountry = fixture.Create<string>();
            var departureDate = fixture.Create<DateTime>();
            var departureAirport = fixture.Create<string>();
            var arrivalAirport = fixture.Create<string>();

            var flight = new Flight(departureCountry, destinationCountry, departureDate,
                                    departureAirport, arrivalAirport);

            var flightClass = fixture.Create<FlightClass>();

            var price = fixture.Create<double>();

            var ticket = new Ticket(flight, flightClass, price);

            Assert.Equal(ticket.Price, price);
            Assert.Equal(ticket.FlightClass, flightClass);
        }
    }
}
