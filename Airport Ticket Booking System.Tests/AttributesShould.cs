using Airport_Ticket_Booking_System.Flights.Attributes;
using AutoFixture;

namespace Airport_Ticket_Booking_System.Tests
{
    public class AttributesShould
    {
        [Theory]
        [InlineData("DepatureCountry", "Text", "Required")]
        public void CheckValidationAttributePropreties(string property, string type, string constraint)
        {
            var attribute = new ValidationAttribute(property, type, constraint);

            Assert.Equal(attribute.Property, property);
            Assert.Equal(attribute.Type, $"Type: {type}");
            Assert.Equal(attribute.Constraint, $"Constraint: {constraint}");
        }
        [Theory]
        [InlineData(null, "DepatureCountry", "Text", "Required", false)]
        [InlineData("", "DepatureCountry", "Text", "Required", false)]
        [InlineData("USA", "DepatureCountry", "Text", "Required", true)]
        public void CheckCountriesAttributeIsValidMethod(string? value, string property, string type,
            string constraint, bool expected)
        {
            var attribute = new CountriesAttribute(property, type, constraint);

            Assert.Equal(attribute.IsValid(value), expected);
        }
        [Theory]
        [InlineData("DepartureDate", "Date Time", "Required, Allowed Range (today → future)", 2003, 7, 24, false)]
        [InlineData("DepartureDate", "Date Time", "Required, Allowed Range (today → future)", 2025, 1, 1, true)]
        public void CheckDateTimeAttributeIsValidMethod(string property, string type, string constraint,
            int year, int month, int day, bool expected)
        {
            var attribute = new DateTimeAttribute(property, type, constraint);
            var date = new DateTime(year, month, day);

            Assert.Equal(attribute.IsValid(date), expected);
        }
    }
}
