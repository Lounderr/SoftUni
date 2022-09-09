using System;

namespace E03.Telephony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            foreach (var pn in phoneNumbers)
            {
                if (pn.Length == 7)
                {
                    StationaryPhone statPhone = new StationaryPhone();
                    Console.WriteLine(statPhone.Call(pn));
                }
                else if (pn.Length == 10)
                {
                    Smartphone smartPhone = new Smartphone();
                    Console.WriteLine(smartPhone.Call(pn));
                }
                else
                {
                    Console.WriteLine($"Invalid number!");
                }
            }

            foreach (var url in urls)
            {
                Smartphone phone = new Smartphone();
                Console.WriteLine(phone.Browse(url));
            }
        }
    }
}
