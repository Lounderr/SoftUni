using System;

namespace _07.CustomException
{
    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException() 
            : base()
        {
        }
        public InvalidPersonNameException(string message)
          : base(message)
        {
        }

        public InvalidPersonNameException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create InvalidPersonNameException class in the previous problem, which does not allow any special character or numeric value in a name of any of the students. To do that create a student class with Name and Email properties. When trying to create a student with the name "P3t3r", throw your custom Exception class.

            try
            {
                throw new InvalidPersonNameException("Invalid Person Name!");
            }
            catch (InvalidPersonNameException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
