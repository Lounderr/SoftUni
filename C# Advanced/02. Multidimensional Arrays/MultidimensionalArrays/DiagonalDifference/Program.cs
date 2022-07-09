using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            int primDiagSum = 0;
            for (int row = 0, col = 0; row < n; row++, col++)
            {
                primDiagSum += matrix[row, col];
            }

            int secDiagSum = 0;
            for (int row = 0, col = n - 1; row < n && col >= 0; row++, col--)
            {
                secDiagSum += matrix[row, col];
            }

            Console.WriteLine(Math.Abs(primDiagSum - secDiagSum));
        }
    }
}