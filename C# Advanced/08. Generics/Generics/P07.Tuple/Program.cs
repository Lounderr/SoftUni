using System;
using System.Linq;

namespace P07.Tuple
{
    public class MyTuple<T, U>
    {
        public T Item1 { get; set; }
        public U Item2 { get; set; }

        public MyTuple() { }
        public MyTuple(T item1, U item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyTuple<string, string> nameAndAddress = new MyTuple<string, string>();
            MyTuple<string, double> nameAndLiters = new MyTuple<string, double>();
            MyTuple<int, double> intAndDouble = new MyTuple<int, double>();

            for (int i = 0; i < 3; i++)
            {
                string[] line = Console.ReadLine().Split();

                if (i == 0)
                {
                    nameAndAddress = new MyTuple<string, string>
                    {
                        Item1 = $"{line[0]} {line[1]}",
                        Item2 = line[2],
                    };
                }

                else if (i == 1)
                {
                    nameAndLiters = new MyTuple<string, double>
                    {
                        Item1 = line[0],
                        Item2 = double.Parse(line[1]),
                    };
                }

                else if (i == 2)
                {
                    intAndDouble = new MyTuple<int, double>
                    {
                        Item1 = int.Parse(line[0]),
                        Item2 = double.Parse(line[1]),
                    };
                }
            }
            Console.WriteLine($"{nameAndAddress.Item1} -> {nameAndAddress.Item2}");
            Console.WriteLine($"{nameAndLiters.Item1} -> {nameAndLiters.Item2}");
            Console.WriteLine($"{intAndDouble.Item1} -> {intAndDouble.Item2}");


        }
    }
}
