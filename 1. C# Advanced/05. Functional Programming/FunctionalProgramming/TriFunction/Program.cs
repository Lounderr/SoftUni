using System;
using System.Linq;

namespace TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            int counter = 0;

            for (int i = 0; i < names.Length;)
            {
                var name = names[i];
                for (int j = 0; j < name.Length; j++)
                {
                    if (counter >= n)
                    {
                        Console.WriteLine(name);
                        return;
                    }
                    counter += names[i][j];
                }

                i++;
                if (!(i < names.Length))
                    i = 0;
            }
        }
    }
}
