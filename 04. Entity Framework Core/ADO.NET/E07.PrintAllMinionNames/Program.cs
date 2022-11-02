using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace E07.PrintAllMinionNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection($"Server=.;Integrated Security=true;Database=MinionsDB;"))
            {
                connection.Open();

                string getMinionNames =
                    @"
                    SELECT Id FROM Minions;
                    ";

                var cmd = new SqlCommand(getMinionNames, connection);
                var reader = cmd.ExecuteReader();

                List<string> minionNames = new List<string>();

                while (reader.Read())
                {
                    minionNames.Add((string)reader[0].ToString());
                }

                for (int i = 0, j = minionNames.Count - 1; i !<= j; i++, j--)
                {
                    Console.Write($"[{minionNames[i]}] ");
                    if (i != j)
                    {
                        Console.Write($"[{minionNames[j]}] ");
                    }
                }

            }
        }
    }
}
