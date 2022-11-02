using System;
using System.Data.SqlClient;
using System.Linq;

namespace E09.IncreaseAgeStoredProcedure
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int id = int.Parse(Console.ReadLine());

            using (var connection = new SqlConnection("Server=.;Integrated Security=true;Database=MinionsDb;"))
            {
                connection.Open();

                string ageMinion =
                    @"
                    EXEC usp_GetOlder @Id;
                    ";
                var cmd = new SqlCommand(ageMinion, connection);
                cmd.Parameters.AddWithValue($"Id", id);

                cmd.ExecuteNonQuery();


                cmd = new SqlCommand(@"SELECT Id, Name, Age FROM Minions WHERE Id = @Id", connection);
                cmd.Parameters.AddWithValue($"Id", id);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"[{reader[0]}] {reader[1]} - {reader[2]} years old");
                }
            };
        }
    }
}
