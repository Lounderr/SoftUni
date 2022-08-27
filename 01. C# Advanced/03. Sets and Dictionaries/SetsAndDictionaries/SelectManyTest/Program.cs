using System;
using System.Linq;

namespace SelectManyTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][][] first = new int[3][][];
            for (int i = 0; i < 3; i++)
            {
                first[i] = new int[3][];
                for (int j = 0; j < 3; j++)
                {
                    first[i][j] = new int[3];
                }
            }
            int[] a = first.SelectMany(x => x).SelectMany(x => x).ToArray();
            Console.WriteLine(String.Join(' ', a));



            Console.WriteLine(String.Join(' ', a.Where(x => x == 0).ToList()));
        }
    }
}