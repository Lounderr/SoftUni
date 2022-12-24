using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace E05.ChangeTownNamesCasing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string country = Console.ReadLine();
            using (SqlConnection connection = new SqlConnection($"Server=.;Integrated Security=true;Database=MinionsDB;"))
            {
                connection.Open();


                
                string updateTowns = 
                    @$"
                    UPDATE Towns 
                    SET Name = UPPER(t.Name)
                    FROM Towns t
                    JOIN Countries c 
                    ON t.CountryCode = c.Id
                    WHERE c.Name = @Country;
                    ";

                SqlCommand cmd;

                cmd = new SqlCommand(updateTowns, connection);
                cmd.Parameters.AddWithValue("Country", country);
                int affected = cmd.ExecuteNonQuery();

                if (affected > 0)
                {
                    Console.WriteLine(affected + " town names were affected.");
                }
                else
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }

                string getTowns = 
                    @$"
                    SELECT t.Name
                    FROM Towns t 
                    JOIN Countries c 
                    ON t.CountryCode = c.Id 
                    WHERE c.Name = @Country;
                    ";
                cmd = new SqlCommand(getTowns, connection);
                cmd.Parameters.AddWithValue("Country", country);

                var townsReader = cmd.ExecuteReader();

                List<string> towns = new List<string>();
                                
                while (townsReader.Read())
                {
                    towns.Add((string)townsReader[0]);
                }
                
                Console.WriteLine($"[{String.Join(", ", towns)}]");
            };
        }
    }
}
