using Airport_Ticket_Booking_System.Flights;
using Airport_Ticket_Booking_System.Repositry;
using Airport_Ticket_Booking_System.Tickets;

namespace Airport_Ticket_Booking_System.Users
{
    public class Passenger : Person
    {
        private readonly List<Ticket> _ticketList = [];
        internal readonly List<Ticket> _myTicketList = [];
        public Passenger(string? id, string? name,
            DateTime? dateOfBirth, string? phoneNumber) : base(id, name, dateOfBirth, phoneNumber)
        {
            _ticketList = Repository.LoadTickets().ToList();
        }
        public void SearchParameters(Ticket search)
        {
            var tickets = _ticketList.Where(t => t.Equals(search)).ToList();
            if (tickets is not null)
            {
                Console.WriteLine("List of available tickets:\n");
                foreach (var ticket in tickets)
                {
                    Console.WriteLine(ticket);
                }
            }
            else
            {
                Console.WriteLine("No available tickets!\n");
            }
        }
        public IEnumerable<Ticket> SearchParametersService(Ticket search)
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
        public void Add(Ticket ticket)
        {
            _myTicketList.Add(ticket);
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
            SearchParameters(search);

        }
        public void Add()
        {
            Console.WriteLine("Enter Flight Id: ");
            var id = int.Parse(Console.ReadLine() ?? "0");
            var x = _ticketList.FirstOrDefault(x => x.Id == id);
            if (x is not null)
                _myTicketList.Add(x);
        }
        public void AddTicket(int id)
        {
            var x = _ticketList.Where(t => t.Id == id);
            if (x is null || !x.Any())
            {
                Console.WriteLine("The is no Flight with the provided 'id'");
                return;
            }
            _myTicketList.Add(x.First());
        }
        public void Cancel()
        {
            Console.WriteLine("Enter Flight Id: ");
            var id = int.Parse(Console.ReadLine() ?? "0");
            CancelTicket(id);
        }
        public void CancelTicket(int id)
        {
            _myTicketList.RemoveAll(t => t.Id == id);
        }
        public void Modify()
        {
            Console.WriteLine("Enter Flight Id: ");
            var id = int.Parse(Console.ReadLine() ?? "0");
            ModifyTicket(id);
        }
        public void ModifyTicket(int id)
        {
            int index = 0;
            foreach (var ticket in _myTicketList)
            {
                if (ticket.Id == id)
                {
                    Console.Write($"Enter the Ticket id that you want to replace it with: ");
                    var x = Console.ReadLine() ?? "1";
                    var l = _ticketList.Any(item => item.Id == int.Parse(x));
                    if (!l)
                    {
                        Console.WriteLine("There is no Ticket with the provided id!");
                        break;
                    }
                    _myTicketList[index] = _ticketList.Where(t => t.Id == int.Parse(x)).First();
                    break;
                }
                index++;
            }
        }
        public void Veiw()
        {
            ViewBookings();
        }
        public void ViewBookings()
        {
            foreach (var ticket in _myTicketList)
            {
                Console.WriteLine(ticket);
            }
        }
        public override string ToString()
        {
            if (_myTicketList.Count == 0)
                return $"Passenger {Name} has no tickets.";

            string toString = $"Passenger: {Name} (ID: {Id})\n" +
                              $"Date of Birth: {DateOfBirth?.ToString("yyyy-MM-dd")}\n" +
                              $"Phone Number: {PhoneNumber}\n" +
                              "|\n|\n|_______";

            foreach (var ticket in _myTicketList)
            {
                toString += $"\n|       |_ Ticket {ticket.Id}\n" +
                            $"|              | - Class: {ticket.FlightClass}\n" +
                            $"|              | - Price: {ticket.Price:C2}\n" +
                            $"|              |_______ Flight:\n" +
                            $"|                          |_ From: {ticket.Flight.DepartureCountry} ({ticket.Flight.DepartureAirport})\n" +
                            $"|                          |_ To: {ticket.Flight.DestinationCountry} ({ticket.Flight.ArrivalAirport})\n" +
                            $"|                          |_ Departure: {ticket.Flight.DepartureDate:yyyy-MM-dd HH:mm}\n";
            }

            return toString;
        }
    }
}


