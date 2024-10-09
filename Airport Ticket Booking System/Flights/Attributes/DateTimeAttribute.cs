namespace Airport_Ticket_Booking_System.Flights.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class DateTimeAttribute : ValidationAttribute
    {
        public DateTimeAttribute(string property, string type, string constraint)
            : base(property, type, constraint) { }
        public bool IsValid(DateTime? dt) => dt >= DateTime.Today;
    }
}

