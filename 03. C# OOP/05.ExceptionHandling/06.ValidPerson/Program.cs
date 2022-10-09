using System;

namespace _06.ValidPerson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Peter", "Johnson", 24);

            try
            {
                Person negativeAge = new Person(string.Empty, "Carter", 31);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
