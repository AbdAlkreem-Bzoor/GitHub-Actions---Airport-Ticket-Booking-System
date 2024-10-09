namespace Airport_Ticket_Booking_System.Users
{
    public abstract class Person
    {
        protected Person(string? id, string? name, DateTime? dateOfBirth, string? phoneNumber)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
        }
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            if (obj is null || obj is not Passenger) return false;
            var other = (Passenger)obj;
            var result = true;
            if (other.Id is not null)
            {
                result = result && other.Id.Equals(Id);
            }
            if (other.Name is not null)
            {
                result = result && other.Name.Equals(Name);
            }
            if (other.DateOfBirth is not null)
            {
                result = result && other.DateOfBirth.Equals(DateOfBirth);
            }
            if (other.PhoneNumber is not null)
            {
                result = result && other.PhoneNumber.Equals(PhoneNumber);
            }
            return result;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, DateOfBirth, PhoneNumber);
        }
        public override string ToString()
        {
            return $"Id: {Id} , Name: {Name} , Date of birth: {DateOfBirth} , Phone: {PhoneNumber}\n";
        }
    }
}

