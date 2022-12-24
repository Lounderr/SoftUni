using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace E03.MinionNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection($"Server=.;Integrated Security=true;Database=MinionsDB;"))
            {
                connection.Open();

                string query =
                    @"
                    SELECT v.Name, m.Name, m.Age
                    FROM Villains AS v 
                        JOIN MinionsVillains mv ON mv.VillainId = v.Id
                            JOIN Minions m ON m.Id = mv.MinionId
                    WHERE v.Id = 1;
                    ";

                var cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("VillainId", id);

                try
                {
                    Console.WriteLine("Villain: " + cmd.ExecuteScalar().ToString());
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine($"No villain with ID {id} exists in the database.");
                }

                List<(string, int)> minionsNamesAges = new List<(string, int)>();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    minionsNamesAges.Add(((string)reader[1], (int)reader[2]));
                }

                if (minionsNamesAges.Count == 0)
                {
                    Console.WriteLine($"(no minions)");
                }

                for (int i = 0; i < minionsNamesAges.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {minionsNamesAges[i].Item1} {minionsNamesAges[i].Item2}");
                }
            };
        }
    }
}