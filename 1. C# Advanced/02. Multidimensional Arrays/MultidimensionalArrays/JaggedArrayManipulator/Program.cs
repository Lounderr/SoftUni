using System;
using System.Linq;

namespace JaggedArrayManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Init
            int rows = int.Parse(Console.ReadLine());
            int[][] jArr = new int[rows][];

            int oldSequenceLength = 0;
            for (int row = 0; row < rows; row++)
            {
                int[] sequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jArr[row] = new int[sequence.Length];
                for (int col = 0; col < sequence.Length; col++)
                {
                    jArr[row][col] = sequence[col];
                }
                if (row > 0)
                {
                    if (jArr[row - 1].Length == jArr[row].Length)
                    {
                        for (int col = 0; col < sequence.Length; col++)
                        {
                            jArr[row][col] *= 2;
                            jArr[row - 1][col] *= 2;
                        }
                    }
                    else // edge case - 3 equal lengths
                    {
                        for (int col = 0; col < sequence.Length; col++)
                        {
                            jArr[row][col] /= 2;
                        }
                        for (int col = 0; col < oldSequenceLength; col++)
                        {
                            jArr[row - 1][col] /= 2;

                        }
                    }
                }
                oldSequenceLength = sequence.Length;
            }

            // Commands

            while (true)
            {
                string[] cmd = Console.ReadLine().Split(); // Дума 0 0 0 0 

                if (cmd[0] == "End")
                {
                    for (int i = 0; i < rows; i++)
                    {
                        Console.WriteLine(String.Join(' ', jArr[i]));
                    }
                    break;
                }

                int parsedArg = -1;
                if (!(cmd.Skip(1).All(arg => int.TryParse(arg, out parsedArg)))) // if arg not parsed
                {
                    if (parsedArg < 0)
                    {
                        continue;
                    }
                }

                int[] cmdArgs = cmd.Skip(1).Select(int.Parse).ToArray();
                int row = cmdArgs[0];
                int col = cmdArgs[1];
                int value = cmdArgs[2];

                if (row < 0 || col < 0)
                {
                    continue;
                }

                if (row >= rows || col >= jArr[row].Length)
                {
                    continue;
                }

                if (cmd[0] == "Add")
                {
                    jArr[row][col] += value;
                }
                else if (cmd[0] == "Subtract")
                {
                    jArr[row][col] -= value;
                }
            }
        }
    }
}
