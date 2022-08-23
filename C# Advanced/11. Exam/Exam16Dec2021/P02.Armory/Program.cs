using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace P02.Armory
{
    internal class Program
    {
        class Point
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

        static void Main(string[] args)
        {
            Point officer = null;
            Point mirrorOne = null;
            Point mirrorTwo = null;

            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                string inputRow = Console.ReadLine();
                for (int col = 0; col < inputRow.Length; col++)
                {
                    matrix[row, col] = inputRow[col];

                    if (matrix[row, col] == 'A')
                    {
                        officer = new Point(row, col);
                    }
                    else if (matrix[row, col] == 'M')
                    {
                        if (mirrorOne == null)
                        {
                            mirrorOne = new Point(row, col);
                        }
                        else if (mirrorTwo == null)
                        {
                            mirrorTwo = new Point(row, col);
                        }
                    }
                }
            }

            List<int> goldCoins = new List<int>();

            while (true)
            {
                string cmd = Console.ReadLine();

                if (cmd == "up")
                {
                    Point nextMove = new Point(officer.Row - 1, officer.Col);

                    if (nextMove.Row >= 0)
                        TakeTurn(nextMove);
                    else
                    {
                        LeaveArea();
                        break;
                    }
                }
                else if (cmd == "down")
                {
                    Point nextMove = new Point(officer.Row + 1, officer.Col);
                    if (nextMove.Row < matrix.GetLength(0))
                        TakeTurn(nextMove);
                    else
                    {
                        LeaveArea();
                        break;
                    }
                }
                else if (cmd == "left")
                {
                    Point nextMove = new Point(officer.Row, officer.Col - 1);
                    if (nextMove.Col >= 0)
                        TakeTurn(nextMove);
                    else
                    {
                        LeaveArea();
                        break;
                    }
                }
                else if (cmd == "right")
                {
                    Point nextMove = new Point(officer.Row, officer.Col + 1);
                    if (nextMove.Col < matrix.GetLength(1))
                        TakeTurn(nextMove);
                    else
                    {
                        LeaveArea();
                        break;
                    }
                }

                if (goldCoins.Sum() >= 65)
                {
                    Console.WriteLine("Very nice swords, I will come back for more!");
                    break;
                }


                //for (int i = 0; i < n; i++)
                //{
                //    for (int j = 0; j < n; j++)
                //    {
                //        Console.Write(matrix[i, j]);
                //    }
                //    Console.WriteLine();
                //}
                //Console.WriteLine(goldCoins.Sum());

            }

            Console.WriteLine($"The king paid {goldCoins.Sum()} gold coins.");
               
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }


            void MoveOfficer(Point next)
            {
                matrix[officer.Row, officer.Col] = '-';

                officer.Row = next.Row;
                officer.Col = next.Col;

                matrix[officer.Row, officer.Col] = 'A';
            }

            void TakeTurn(Point nextMove)
            {
                nextMove.Value = matrix[nextMove.Row, nextMove.Col];

                if (char.IsDigit(nextMove.Value))
                {
                    goldCoins.Add(nextMove.Value - '0');
                    MoveOfficer(nextMove);
                }
                else if (nextMove.Value == 'M')
                {
                    if (mirrorOne.Row == nextMove.Row && mirrorOne.Col == nextMove.Col)
                    {
                        MoveOfficer(mirrorTwo);
                        matrix[mirrorOne.Row, mirrorOne.Col] = '-';
                    }
                    else
                    {
                        MoveOfficer(mirrorOne);
                        matrix[mirrorTwo.Row, mirrorTwo.Col] = '-';
                    }
                }
                else
                {
                    MoveOfficer(nextMove);
                }
            }

            void LeaveArea()
            {
                Console.WriteLine("I do not need more swords!");
                matrix[officer.Row, officer.Col] = '-';
            }

        }

    }
}

