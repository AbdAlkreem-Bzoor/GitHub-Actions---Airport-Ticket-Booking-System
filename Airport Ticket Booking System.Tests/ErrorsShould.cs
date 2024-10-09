using Airport_Ticket_Booking_System.Errors;

namespace Airport_Ticket_Booking_System.Tests
{
    public class ErrorsShould
    {
        private readonly Error _error = new Error("DepartureCountry", "Text\tRequired");
        [Fact]
        public void CheckToString()
        {
            Assert.Equal("DepartureCountry\nText\tRequired", _error.ToString());
        }
        [Fact]
        public void CheckPropertyValue()
        {
            Assert.Equal("DepartureCountry", _error.Property);
        }
        [Fact]
        public void CheckMessageValue()
        {
            Assert.Equal("Text\tRequired", _error.Message);
        }
    }
}
