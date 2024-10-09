using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Ticket_Booking_System.Errors
{
    /// <summary>
    /// The Validation of a specific Error
    /// </summary>
    public class Error
    {
        /// <summary>
        /// The name of Property that has an error
        /// </summary>
        public string Property { get; init; }
        public string Message { get; init; }
        public Error(string property, string message)
        {
            Property = property;
            Message = message;
        }
        public override string ToString()
        {
            return $"{Property}\n{Message}";
        }
    }
}
