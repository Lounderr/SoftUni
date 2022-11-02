using System;

namespace CheckIfPrime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // !
            int n1, primeNo;

            Console.WriteLine("\n\n Recursion : Check a number is prime number or not :");
            Console.WriteLine("--------------------------------------------------------");

            Console.Write(" Input any positive number : ");
            n1 = Convert.ToInt32(Console.ReadLine());

            primeNo = checkForPrime(n1, n1 / 2);//call the function checkForPrime

            if (primeNo == 1)
                Console.Write(" The number {0} is a prime number. \n\n", n1);
            else
                Console.WriteLine(" The number {0} is not a prime number. \n\n", n1);
        }

        static int checkForPrime(int n1, int i)
        {
            if (i == 1)
            {
                return 1;
            }
            else
            {
                if (n1 % i == 0)
                    return 0;
                else
                    return checkForPrime(n1, i - 1);//calling the function checkForPrime itself recursively
            }
        }
    }
}
