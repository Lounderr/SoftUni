using System;
using System.Linq;

namespace P02.PawnWars
{
    internal class Program
    {
        public class Point
        {
            public int Row;
            public int Col;

            public Point(int row, int col)
            {
                Row = row;
                Col = col;
            }
        }

        static void Main(string[] args)
        {
            // read input -> init matrix AND b/w positions
            // w makes the first move
            // both pawns move until:
            // a) they are diagonal to each other -> next wins 
            // b) one reaches the end -> current wins

            // Fill matrix and get pawn positions
            Point wPawn = new Point(-1, -1);
            Point bPawn = new Point(-1, -1);

            char[,] matrix = new char[8, 8];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] inputRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    char squareValue = inputRow[col];
                    matrix[row, col] = squareValue;

                    if (squareValue == 'w')
                    {
                        wPawn = new Point(row, col);
                    }
                    else if (squareValue == 'b')
                    {
                        bPawn = new Point(row, col);
                    }
                }
            }

            bool isWhiteTurn = true;
            while (true)
            {
                if (isWhiteTurn)
                {
                    if (IsDiagonal(wPawn, bPawn))
                    {
                        Console.WriteLine($"Game over! White capture on {(char)(bPawn.Col + 97)}{8 - bPawn.Row}.");
                        return;
                    }

                    if (wPawn.Row == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(wPawn.Col + 97)}{8 - wPawn.Row}.");
                        return;
                    }

                    matrix[wPawn.Row, wPawn.Col] = '-';
                    matrix[wPawn.Row - 1, wPawn.Col] = 'w';
                    wPawn.Row--;

                    isWhiteTurn = false;
                }
                else
                {
                    if (IsDiagonal(wPawn, bPawn))
                    {
                        Console.WriteLine($"Game over! Black capture on {(char)(wPawn.Col + 97)}{8 - wPawn.Row}.");
                        return;
                    }

                    if (bPawn.Row == matrix.GetLength(0) - 1)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(bPawn.Col + 97)}{8 - bPawn.Row}.");
                        return;
                    }

                    matrix[bPawn.Row, bPawn.Col] = '-';
                    matrix[bPawn.Row + 1, bPawn.Col] = 'b';
                    bPawn.Row++;

                    isWhiteTurn = true;
                }

                //Print(matrix);
            }
        }

        private static bool IsDiagonal(Point wPawn, Point bPawn)
        {
            return bPawn.Row == wPawn.Row - 1 && (bPawn.Col == wPawn.Col - 1 || bPawn.Col == wPawn.Col + 1);
        }

        //private static void Print(char[,] matrix)
        //{
        //    Console.WriteLine("\n\n");
        //    for (int row = 0; row < matrix.GetLength(0); row++)
        //    {
        //        for (int col = 0; col < matrix.GetLength(1); col++)
        //        {
        //            Console.Write(matrix[row, col]);
        //        }
        //        Console.WriteLine();
        //    }
        //}
    }
}
