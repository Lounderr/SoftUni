using System;
using System.Linq;

namespace P02.WallDestroyer
{
    public class Point
    {
        public int Row;
        public int Col;
        public char Value;

        public Point(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Class Point(row, col, value)

            INPUT: int n
            new matrix = n * n

            feed each row into matrix 
            if (matrix[row, col] == 'V') => Vanko = new Point(row, col)

            string cmd = RL;
            while (cmd != End) => cmd = RL; if(cmd == "up") => nextpos(row, col) = Vanko(row [- 1], col); TakeTurn(nextpos)
            
            TakeTurn(nextPos) 
                - if (nextpos != 'R') => oldpos = '*' AND newpos = 'V' AND holes++
                - else Print(Vanko hit a rod!) => don't move
                - if (nextpos != 'C') => oldpos = '*' AND newpos = 'E' AND holes++
                - else Print(Vanko got electrocuted, but he managed to make {countOfHoles} hole(s).) => exit
                - if (nextpos == '*') => Print(The wall is already destroyed at position [row, col]!) AND dont move
                - if (OutOfBounds(nextpos)) => do nothing
            */

            Point vanko = null;

            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                char[] inputRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputRow[col];

                    if (matrix[row, col] == 'V')
                    {
                        vanko = new Point(row, col);
                    }
                }
            }

            int holes = 1;
            int rods = 0;

            string cmd = Console.ReadLine();
            while (cmd != "End")
            {
                if (cmd == "up")
                {
                    Point nextPos = new Point(vanko.Row - 1, vanko.Col);
                    if (TakeTurn(nextPos))
                        break;
                }
                else if (cmd == "down")
                {
                    Point nextPos = new Point(vanko.Row + 1, vanko.Col);
                    if (TakeTurn(nextPos))
                        break;
                }
                else if (cmd == "left")
                {
                    Point nextPos = new Point(vanko.Row, vanko.Col - 1);
                    if (TakeTurn(nextPos))
                        break;
                }
                else if (cmd == "right")
                {
                    Point nextPos = new Point(vanko.Row, vanko.Col + 1);
                    if (TakeTurn(nextPos))
                        break;
                }

                cmd = Console.ReadLine();
            }

            End();

            void End(bool electrocuted = false)
            {
                if (electrocuted)
                {
                    Console.WriteLine($"Vanko hit a rod! Vanko managed to make {holes} hole(s) and he hit only {rods} rod(s).");
                }

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }

                Environment.Exit(0);
            }

            bool TakeTurn(Point nextPos)
            {
                if (nextPos.Row >= matrix.GetLength(0) || nextPos.Col >= matrix.GetLength(1) || nextPos.Row < 0 || nextPos.Col < 0)
                {
                    return false;
                }
                if (matrix[nextPos.Row, nextPos.Col] == '-')
                {
                    matrix[vanko.Row, vanko.Col] = '*';
                    matrix[nextPos.Row, nextPos.Col] = 'V';

                    vanko.Row = nextPos.Row;
                    vanko.Col = nextPos.Col;

                    holes++;
                }
                else if (matrix[nextPos.Row, nextPos.Col] == 'R')
                {
                    rods++;
                    Console.WriteLine("Vanko hit a rod!");
                }
                else if (matrix[nextPos.Row, nextPos.Col] == 'C')
                {
                    matrix[vanko.Row, vanko.Col] = '*';
                    matrix[nextPos.Row, nextPos.Col] = 'E';

                    vanko.Row = nextPos.Row;
                    vanko.Col = nextPos.Col;

                    holes++;

                    Console.WriteLine($"Vanko got electrocuted, but he managed to make {holes} hole(s).");

                    End(true);
                    return true;
                }
                else if (matrix[nextPos.Row, nextPos.Col] == '*')
                {
                    matrix[vanko.Row, vanko.Col] = '*';

                    vanko.Row = nextPos.Row;
                    vanko.Col = nextPos.Col;

                    Console.WriteLine($"The wall is already destroyed at position [{vanko.Row}, {vanko.Row}]!");
                }

                return false;
            }


        }
    }
}
