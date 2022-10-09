using System;

namespace _04.FixingVol2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNumber, secondNumber;
            byte result;

            firstNumber = 30;
            secondNumber = 60;
            try
            {
                result = Convert.ToByte(firstNumber * secondNumber);
            }
            catch
            {
                Console.WriteLine("Byte is overflowing!");
                return;
            }
            Console.WriteLine($"{firstNumber} x {secondNumber} = {result}");
            Console.ReadLine();
        }
    }
}
