using Airport_Ticket_Booking_System.Repositry;
using Airport_Ticket_Booking_System.Tickets;
using Airport_Ticket_Booking_System.Users;
using AutoFixture;

namespace Airport_Ticket_Booking_System.Tests
{
    public class SearchMethodShould
    {
        private readonly List<Ticket> tickets;
        private readonly Random random;
        private readonly Fixture fixture;
        private readonly Passenger passenger;
        private readonly Manager manager;

        public SearchMethodShould()
        {
            tickets = Repository.LoadTickets();
            random = new();
            fixture = new();
            passenger = new Passenger(fixture.Create<string>(), fixture.Create<string>(),
                                      fixture.Create<DateTime>(), fixture.Create<string>());
            manager = new Manager(fixture.Create<string>(), fixture.Create<string>(),
                                      fixture.Create<DateTime>(), fixture.Create<string>());
        }

        [Theory]
        [InlineData(true, false, false, false, false, false, false)]
        [InlineData(true, true, true, true, true, false, false)]
        [InlineData(true, true, true, true, true, true, true)]
        [InlineData(true, false, false, false, false, false, true)]
        [InlineData(true, false, false, false, false, true, true)]
        [InlineData(true, true, false, false, false, false, false)]
        public void CheckSearchingServiceForPassengers(bool departureCountry, bool destinationCountry,
            bool departureDate, bool departureAirport, bool arrivalAirport, bool flightClass, bool price)
        {
            var ticket = tickets[random.Next(tickets.Count)];

            if (!departureCountry) ticket.Flight.DepartureCountry = null;
            if (!destinationCountry) ticket.Flight.DestinationCountry = null;
            if (!departureDate) ticket.Flight.DepartureDate = null;
            if (!departureAirport) ticket.Flight.DepartureAirport = null;
            if (!arrivalAirport) ticket.Flight.ArrivalAirport = null;
            if (!flightClass) ticket.FlightClass = null;
            if (!price) ticket.Price = null;

            Assert.True(passenger.SearchParametersService(ticket).Any());
        }
        [Theory]
        [InlineData(true, false, false, false, false, false, false)]
        [InlineData(true, true, true, true, true, false, false)]
        [InlineData(true, true, true, true, true, true, true)]
        [InlineData(true, false, false, false, false, false, true)]
        [InlineData(true, false, false, false, false, true, true)]
        [InlineData(true, true, false, false, false, false, false)]
        public void CheckSearchingServiceForManagers(bool departureCountry, bool destinationCountry,
            bool departureDate, bool departureAirport, bool arrivalAirport, bool flightClass, bool price)
        {
            var ticket = tickets[random.Next(tickets.Count)];

            if (!departureCountry) ticket.Flight.DepartureCountry = null;
            if (!destinationCountry) ticket.Flight.DestinationCountry = null;
            if (!departureDate) ticket.Flight.DepartureDate = null;
            if (!departureAirport) ticket.Flight.DepartureAirport = null;
            if (!arrivalAirport) ticket.Flight.ArrivalAirport = null;
            if (!flightClass) ticket.FlightClass = null;
            if (!price) ticket.Price = null;

            Assert.True(manager.SearchParametersService(ticket, passenger).Any());
        }
    }
}
