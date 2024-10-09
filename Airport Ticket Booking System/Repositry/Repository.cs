using Airport_Ticket_Booking_System.Errors;
using Airport_Ticket_Booking_System.Flights;
using Airport_Ticket_Booking_System.Flights.Attributes;
using Airport_Ticket_Booking_System.Tickets;
using Airport_Ticket_Booking_System.Users;
using System.Reflection;

namespace Airport_Ticket_Booking_System.Repositry
{
    public static class Repository
    {
        public static void WriteTicketsData(List<Ticket> tickets)
        {
            string path = @"D:\OneDrive\Desktop\Airport Ticket Booking System\Output\TicketsOutputData.txt";
            using (var writer = new StreamWriter(path))
            {
                foreach (var ticket in tickets)
                {
                    writer.WriteLine(ticket);
                }
            }
        }
        public static List<Ticket> LoadTickets()
        {
            var tickets = new List<Ticket>();
            string path = @"D:\OneDrive\Desktop\Airport Ticket Booking System\Input\TicketsInputData.txt";
            using (var reader = new StreamReader(path))
            {
                string? line = string.Empty;
                while ((line = reader.ReadLine()) is not null)
                {
                    var str = line.Split(',');
                    for (int i = 0; i < str.Length; i++)
                        str[i] = str[i].Trim();
                    var flight = new Flight(str[0], str[1], DateTime.Parse(str[2]), str[3], str[4]);
                    var ticket = new Ticket(flight, (FlightClass)Enum.Parse(typeof(FlightClass), str[5]),
                                 double.Parse(str[6]));
                    tickets.Add(ticket);
                }
            }
            var errors = new List<Error>();
            CheckForErrors(tickets, errors);
            if (errors.Count > 0)
            {
                DisplayErrors(errors);
                return [];
            }
            return tickets;
        }
        private static void DisplayErrors(List<Error> errors)
        {
            Console.WriteLine($"There is {errors.Count} errors in the input data, reinput them based on these conditions: ");
            foreach (var error in errors)
            {
                Console.WriteLine(error);
                Console.WriteLine();
            }
        }
        private static void CheckForErrors(List<Ticket> tickets, List<Error> errors)
        {
            foreach (var ticket in tickets)
            {
                var flight = ticket.Flight;
                var properties = flight.GetType().GetProperties();
                CheckProperties(errors, flight, properties);
            }
        }
        private static void CheckProperties(List<Error> errors, Flight flight, PropertyInfo[] properties)
        {
            foreach (var property in properties)
            {
                var value = property.GetValue(flight);
                var attributes = property.GetCustomAttributes();
                ValidateAttributes(errors, properties, value, attributes);

            }
        }
        private static void ValidateAttributes(List<Error> errors, PropertyInfo[] properties, object? value, IEnumerable<Attribute> attributes)
        {
            foreach (var attribute in attributes)
            {
                if (attribute is CountriesAttribute)
                {
                    var attr = (CountriesAttribute)attribute;
                    if (!attr.IsValid((string?)value))
                    {
                        AddError(errors, attr);
                    }
                }
                else if (attribute is DateTimeAttribute)
                {
                    var attr = (DateTimeAttribute)attribute;
                    if (!attr.IsValid((DateTime?)value))
                    {
                        AddError(errors, attr);
                    }
                }
            }
        }
        private static void AddError(List<Error> errors, ValidationAttribute attr)
        {
            errors.Add(new Error(attr.Property + "\n",
                                        "\t" + attr.Type + "\n" +
                                        "\t" + attr.Constraint + "\n"));
        }
        public static void WritePassengersData(List<Passenger> passengers)
        {
            string path = @$"D:\OneDrive\Desktop\Airport Ticket Booking System\Output\PassengersOutputData.txt";
            using (var writer = new StreamWriter(path))
            {
                foreach (var passenger in passengers)
                {
                    writer.WriteLine(passenger.ToString());
                }
            }
        }
        public static List<Passenger> LoadPassengers()
        {
            List<Passenger> passengers = new List<Passenger>();
            string path = @"D:\OneDrive\Desktop\Airport Ticket Booking System\Input\PassengersInputData.txt";
            using (var reader = new StreamReader(path))
            {
                string? line = string.Empty;
                while ((line = reader.ReadLine()) is not null)
                {
                    var str = line.Split(',');
                    var passenger = new Passenger(str[0].Trim(), str[1].Trim(),
                        DateTime.Parse(str[2].Trim()), str[3]);
                    passengers.Add(passenger);
                }
            }
            return passengers;
        }
        public static List<(string? country, string? airport)> LoadCountriesAirports()
        {
            var countriesAirports = new List<(string? country, string? airport)>();
            string path = @"D:\OneDrive\Desktop\Airport Ticket Booking System\Input\Airports_Countries.txt";
            using (var reader = new StreamReader(path))
            {
                string? line = string.Empty;
                while ((line = reader.ReadLine()) is not null)
                {
                    var splits = line.Split(':');
                    var country = splits[0].Trim();
                    var airport = splits[1].Trim();
                    countriesAirports.Add((country, airport));
                }
            }
            return countriesAirports;
        }
    }

}
