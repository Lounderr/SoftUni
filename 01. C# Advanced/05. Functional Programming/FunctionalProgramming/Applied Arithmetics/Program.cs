using System;
using System.Linq;

namespace Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Func<double, double> add = (x) => x + 1;
            Func<double, double> multiply = (x) => x * 2;
            Func<double, double> subtract = (x) => x - 1;
            Action<double[]> print = (nums) => Console.WriteLine(String.Join(' ', nums));

            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "end")
                {
                    break;
                }
                else if (cmd == "add")
                {
                    nums = nums.Select(add).ToArray();
                }
                else if (cmd == "multiply")
                {
                    nums = nums.Select(multiply).ToArray();
                }
                else if (cmd == "subtract")
                {
                    nums = nums.Select(subtract).ToArray();
                }
                else if (cmd == "print")
                {
                    print(nums);
                }

            }

        }
    }
}
