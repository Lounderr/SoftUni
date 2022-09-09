using System.Linq;

namespace E03.Telephony
{
    public class Smartphone : ISmartphone
    {
        public string Call(string number)
        {
            if (number.Any(n => !char.IsDigit(n)))
            {
                return $"Invalid number!";
            }

            return $"Calling... {number}";
        }

        public string Browse(string url)
        {
            if (url.Any(l => char.IsDigit(l)))
            {
                return $"Invalid URL!";
            }

            return $"Browsing: {url}!";
        }
    }
}
