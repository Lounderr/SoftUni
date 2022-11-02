using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;

namespace E08.IncreaseMinionAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ids = Console.ReadLine().Split().Select(int.Parse).ToArray();

            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDb;"))
            {
                connection.Open();

                string updateMinionNamesAndAges =
                    @$"
                    UPDATE Minions
                    SET Age = Age + 1,
                    Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)) 
                    FROM Minions 
                    WHERE Id IN (@Id{String.Join(", @Id", ids)});
                    ";
                var cmd = new SqlCommand(updateMinionNamesAndAges, connection);
                foreach (var id in ids)
                {
                    cmd.Parameters.AddWithValue($"Id{id}", id);
                }

                cmd.ExecuteNonQuery();

                string getMinionsByIdsSql =
                    @$"
                    SELECT Name, Age FROM Minions;
                    ";

                cmd = new SqlCommand(getMinionsByIdsSql, connection);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(((string)reader[0], (int)reader[1]));
                }
            };
        }
    }
}
