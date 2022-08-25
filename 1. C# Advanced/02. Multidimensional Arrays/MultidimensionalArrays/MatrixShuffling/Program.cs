using System;
using System.Linq;

namespace MatrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Init

            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] line = Console.ReadLine().Split();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            // Swap

            while (true)
            {
                string[] cmd = Console.ReadLine().Split();

                if (cmd[0] == "END")
                {
                    break;
                }

                if (!(cmd.All(s => s.All(Char.IsDigit))))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int[] cmdArgs = cmd.Skip(1).Select(int.Parse).ToArray();

                if (
                    cmd[0] != "swap" ||
                    cmd.Length != 5 ||
                    cmdArgs[0] > rows - 1 ||
                    cmdArgs[1] > cols - 1 ||
                    cmdArgs[2] > rows - 1 ||
                    cmdArgs[3] > cols - 1 ||
                    cmdArgs.Any(i => i < 0)
                    )
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int fRow = cmdArgs[0];
                int fCol = cmdArgs[1];

                int sRow = cmdArgs[2];
                int sCol = cmdArgs[3];

                string swapTempHolder;
                swapTempHolder = matrix[fRow, fCol];
                matrix[fRow, fCol] = matrix[sRow, sCol];
                matrix[sRow, sCol] = swapTempHolder;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
