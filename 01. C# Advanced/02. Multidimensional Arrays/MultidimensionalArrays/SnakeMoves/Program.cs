using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            string snake = Console.ReadLine();

            char[,] matrix = new char[rows, cols];
            Queue<char> queue = new Queue<char>();

            foreach (char c in snake)
            {
                queue.Enqueue(c);
            }

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        char c = queue.Dequeue();
                        matrix[row, col] = c;
                        queue.Enqueue(c);
                    }
                }
                else
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        char c = queue.Dequeue();
                        matrix[row, col] = c;
                        queue.Enqueue(c);
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }

            /*
            Output

            SoftUn
            UtfoSi
            niSoft
            foSinU
            tUniSo
            */
        }
    }
}
