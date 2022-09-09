using System.Linq;

namespace E03.Telephony
{
    public class StationaryPhone : IPhone
    {
        public string Call(string number)
        {
            if (number.Any(n => !char.IsDigit(n)))
            {
                return $"Invalid number!";
            }
            return $"Dialing... {number}";
        }
    }
}
