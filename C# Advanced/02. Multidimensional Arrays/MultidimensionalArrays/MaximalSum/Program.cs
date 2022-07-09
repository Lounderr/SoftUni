using System;
using System.Linq;

namespace MaximalSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Init
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }


            // Logic
            int maxSum = 0;
            int[,] largest3x3 = new int[3, 3];
            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int sum = 0;

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            sum += matrix[row + i, col + j];
                        }
                    }
                    if (maxSum < sum)
                    {
                        maxSum = sum;

                        for (int i = 0; i < 3; i++)
                        {
                            for (int j = 0; j < 3; j++)
                            {
                                largest3x3[i, j] = matrix[row + i, col + j];
                            }
                        }
                        
                    }
                }
            }

            Console.WriteLine("Sum = " + maxSum);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{largest3x3[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
