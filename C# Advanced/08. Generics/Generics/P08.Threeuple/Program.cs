using System;
using System.Linq;

namespace P08.Threeuple
{
    public class Threeuple<T, U, V>
    {
        public T Item1 { get; set; }

        public U Item2 { get; set; }

        public V Item3 { get; set; }

        public Threeuple() { }

        public Threeuple(T item1, U item2, V item3)
        {
            Item1 = item1;
            Item2 = item2;
            Item3 = item3;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Threeuple<string, string, string> nameAddressTown = new Threeuple<string, string, string>();
            Threeuple<string, double, bool> nameLitersDrunk = new Threeuple<string, double, bool>();
            Threeuple<string, double, string> nameBalBank = new Threeuple<string, double, string>();

            for (int i = 0; i < 3; i++)
            {
                string[] line = Console.ReadLine().Split();

                if (i == 0)
                {
                    nameAddressTown = new Threeuple<string, string, string>
                    {
                        Item1 = $"{line[0]} {line[1]}",
                        Item2 = line[2],
                        Item3 = line[3],
                    };
                }

                else if (i == 1)
                {
                    nameLitersDrunk = new Threeuple<string, double, bool>
                    {
                        Item1 = line[0],
                        Item2 = double.Parse(line[1]),
                        Item3 = line[2] == "drunk" ? true : false,
                    };
                }

                else if (i == 2)
                {
                    nameBalBank = new Threeuple<string, double, string>
                    {
                        Item1 = line[0],
                        Item2 = double.Parse(line[1]),
                        Item3 = line[2],
                    };
                }
            }
            Console.WriteLine($"{nameAddressTown.Item1} -> {nameAddressTown.Item2} -> {nameAddressTown.Item3}");
            Console.WriteLine($"{nameLitersDrunk.Item1} -> {nameLitersDrunk.Item2} -> {nameLitersDrunk.Item3}");
            Console.WriteLine($"{nameBalBank.Item1} -> {nameBalBank.Item2} -> {nameBalBank.Item3}");


        }
    }
}
