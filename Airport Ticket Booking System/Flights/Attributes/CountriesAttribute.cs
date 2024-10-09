﻿using Airport_Ticket_Booking_System.Repositry;

namespace Airport_Ticket_Booking_System.Flights.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CountriesAttribute : ValidationAttribute
    {
        public CountriesAttribute(string property, string type, string constraint)
            : base(property, type, constraint) { }
        public bool IsValid(string? s) => !string.IsNullOrEmpty(s);
    }
}

