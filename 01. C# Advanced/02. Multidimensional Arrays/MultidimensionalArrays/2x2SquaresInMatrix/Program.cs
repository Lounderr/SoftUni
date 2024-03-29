﻿using System;
using System.Linq;

namespace _2x2SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                // string line = String.Join("", Console.ReadLine().Split());
                char[] line = Console.ReadLine().Where(c => !char.IsWhiteSpace(c)).ToArray(); // Cool trick
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            int foundCount = 0;

            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    if (
                        matrix[row, col] == matrix[row, col + 1] &&
                        matrix[row, col + 1] == matrix[row + 1, col] &&
                        matrix[row + 1, col] == matrix[row + 1, col + 1]
                        )
                    {
                        foundCount++;
                    }
                }
            }
            Console.WriteLine(foundCount);
        }
    }
}
