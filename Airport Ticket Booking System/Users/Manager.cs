using Airport_Ticket_Booking_System.Flights;
using Airport_Ticket_Booking_System.Repositry;
using Airport_Ticket_Booking_System.Tickets;

namespace Airport_Ticket_Booking_System.Users
{
    public class Manager : Person
    {
        private readonly List<Ticket> _ticketList = Repository.LoadTickets();
        private readonly List<Passenger> _passengerList = [];
        public Manager(string? id, string? name,
            DateTime? dateOfBirth, string? phoneNumber) : base(id, name, dateOfBirth, phoneNumber)
        {
        }
        public void SearchParameters(Ticket search, Passenger passenger)
        {
            var tickets = _ticketList.Where(t => t.Equals(search)).ToList();
            var passengers = _passengerList.Where(p => p.Equals(passenger)).ToList();
            var set = new HashSet<Ticket>();
            if (tickets is not null)
            {
                foreach (var ticket in tickets)
                {
                    set.Add(ticket);
                }
            }
            foreach (var p in passengers)
            {
                foreach (var ticket in p._myTicketList)
                {
                    set.Add(ticket);
                }
            }
            foreach (var ticket in set)
            {
                Console.WriteLine(ticket);
            }
        }
        public IEnumerable<Ticket> SearchParametersService(Ticket? search, Passenger? passenger)
        {
            var tickets = _ticketList.Where(t => t.Equals(search)).ToList();
            if (tickets is not null)
            {
                foreach (var ticket in tickets)
                {
                    yield return ticket;
                }
            }
        }
        public void Search()
        {
            Console.WriteLine("Enter Departure Country: ");
            var x = Console.ReadLine()?.Trim();
            var departureCountry = x == "null" ? null : x;
            Console.WriteLine("Enter Destination Country: ");
            x = Console.ReadLine()?.Trim();
            var destinationCountry = x == "null" ? null : x;
            Console.WriteLine("Enter Departure Date: ");
            x = Console.ReadLine()?.Trim();
            DateTime? departureDate = x == "null" ? null : DateTime.Parse(x ?? DateTime.Now.ToString());
            Console.WriteLine("Enter Departure Airport: ");
            x = Console.ReadLine()?.Trim();
            var departureAirport = x == "null" ? null : x;
            Console.WriteLine("Enter Arrival Airport: ");
            x = Console.ReadLine()?.Trim();
            var arrivalAirport = x == "null" ? null : x;
            Console.WriteLine("Enter Flight Class: ");
            x = Console.ReadLine()?.Trim();
            FlightClass? flightClass = x == "null" ? null : (FlightClass)
                Enum.Parse(typeof(FlightClass), x ?? FlightClass.None.ToString());
            Console.WriteLine("Enter Price: ");
            x = Console.ReadLine()?.Trim();
            double? price = x == "null" ? null : double.Parse(x ?? "0");
            var search = new Ticket(new Flight(departureCountry, destinationCountry,
                departureDate, departureAirport, arrivalAirport), flightClass, price);
            Console.WriteLine("Enter Passenger Id: ");
            x = Console.ReadLine()?.Trim();
            var empId = x == "null" ? null : x;
            Console.WriteLine("Enter Passenger Name: ");
            x = Console.ReadLine()?.Trim();
            var empName = x == "null" ? null : x;
            Console.WriteLine("Enter Passenger Date of the birth: ");
            x = Console.ReadLine()?.Trim();
            DateTime? empDateOfBirth = x == "null" ? null : DateTime.Parse(x ?? DateTime.Now.ToString());
            Console.WriteLine("Enter Passenger Phone number: ");
            x = Console.ReadLine()?.Trim();
            var empPhone = x == "null" ? null : x;
            var passenger = new Passenger(empId, empName, empDateOfBirth, empPhone);
            SearchParameters(search, passenger);
        }
        public void WritePassengersDataOnFile()
        {
            Repository.WritePassengersData(_passengerList);
        }
    }
}

