using Airport_Ticket_Booking_System.Flights;

namespace Airport_Ticket_Booking_System.Tickets
{
    public class Ticket
    {
        private static int sequence;
        public Ticket(Flight flight, FlightClass? flightClass, double? price)
        {
            Id = sequence++;
            Flight = flight;
            FlightClass = flightClass;
            Price = price;
        }
        public int Id { get; init; }
        public Flight Flight { get; set; }
        public FlightClass? FlightClass { get; set; }
        public double? Price { get; set; }

        /// <summary>
        /// This Method will check the equality between two tickets ignoring the null fileds of the two objects
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>True or False</returns>
        public override bool Equals(object? obj)
        {
            if (obj is null || obj is not Ticket)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            var other = (Ticket)obj;
            bool result = true;
            if (other.Flight.DepartureCountry is not null)
            {
                result = result && Flight.DepartureCountry == other.Flight.DepartureCountry;
            }
            if (other.Flight.DestinationCountry is not null)
            {
                result = result && Flight.DestinationCountry == other.Flight.DestinationCountry;
            }
            if (other.Flight.DepartureDate is not null)
            {
                result = result && Flight.DepartureDate == other.Flight.DepartureDate;
            }
            if (other.Flight.DepartureAirport is not null)
            {
                result = result && Flight.DepartureAirport == other.Flight.DepartureAirport;
            }
            if (other.Flight.ArrivalAirport is not null)
            {
                result = result && Flight.ArrivalAirport == other.Flight.ArrivalAirport;
            }
            if (other.FlightClass is not null)
            {
                result = result && FlightClass == other.FlightClass;
            }
            if (other.Price is not null)
            {
                result = result && Price == other.Price;
            }
            return result;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Flight.DepartureCountry, Flight.DestinationCountry,
                Flight.DepartureDate, Flight.DepartureAirport,
                Flight.ArrivalAirport, FlightClass, Price);
        }
        public override string ToString()
        {
            return
                "Ticket Information\n" +
                "----------------------------------------------\n" +
                $"Ticket Number: {Id}\n" +
                $"Class: {FlightClass}\n" +
                $"Price: {Price:C2}\n" +
                $"{Flight}\n";
        }

    }
}

