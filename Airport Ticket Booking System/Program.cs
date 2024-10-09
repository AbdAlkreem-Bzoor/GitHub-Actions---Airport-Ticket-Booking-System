using Airport_Ticket_Booking_System.Users;

namespace Airport_Ticket_Booking_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose Mode: ");
                Console.WriteLine("1. Passenger");
                Console.WriteLine("2. Manager");
                Console.WriteLine("0. Exit");
                int input = int.Parse(Console.ReadLine() ?? "0");
                switch (input)
                {
                    case 1: PassengerMenu(); break;
                    case 2: ManaegersUtilitis(); break;
                    case 0: break;
                    default: break;
                }
            }
        }
        public static void PassengerMenu()
        {
            Passenger p = new Passenger("202499", "Abdalkreem", DateTime.Parse("2003-07-24"), "0599929122");
            Console.WriteLine("Choose one of these options:");
            Console.WriteLine("1. Search for Tickets");
            Console.WriteLine("2. Add Ticket");
            Console.WriteLine("3. Modify Ticket");
            Console.WriteLine("4. Cancel Ticket");
            Console.WriteLine("5. Veiw Bookings");
            Console.WriteLine("0. Exit");
            int input = int.Parse(Console.ReadLine() ?? "0");
            switch (input)
            {
                case 1: p?.Search(); break;
                case 2: p?.Add(); break;
                case 3: p?.Modify(); break;
                case 4: p?.Cancel(); break;
                case 5: p?.Veiw(); break;
                case 0: break;
            }
        }
        public static void ManaegersUtilitis()
        {
            var manager = new Manager("202111", "Abdalkreem", DateTime.Parse("2003-07-24"), "0594451321");
            Console.WriteLine("Choose one of these options:");
            Console.WriteLine("1. Search for Tickets, Flights, Passengers");
            Console.WriteLine("2. Add a Ticket");
            Console.WriteLine("3. Add a Passenger");
            Console.WriteLine("4. Delete a Ticket");
            Console.WriteLine("5. Delete a Passenger");
            Console.WriteLine("6. Modify a Ticket");
            Console.WriteLine("7. Modify a Passenger");
            Console.WriteLine("0. Exit");
            int input = int.Parse(Console.ReadLine() ?? "0");
            switch (input)
            {
                case 1: manager?.Search(); break;
                case 0: break;
            }
        }
    }
}
