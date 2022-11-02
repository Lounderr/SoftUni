using System;
using System.Data.SqlClient;

namespace E02.VillainNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection($"Server=.;Integrated Security=true;Database=MinionsDB;"))
            {
                connection.Open();

                string query =
                    @"
                    SELECT v.Name AS VillainName, COUNT(m.Id) AS [Count]
                    FROM MinionsVillains AS ms 
                     JOIN Minions AS m 
                     ON MinionId = m.Id
                     JOIN Villains AS v 
                     ON VillainId = v.Id
                    GROUP BY v.Name
                    HAVING COUNT(m.Id) > 3
                    ORDER BY [Count] DESC;
                    ";

                var reader = new SqlCommand(query, connection).ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader["VillainName"] + "  -  " + reader["Count"]);
                }
            };
        }
    }
}
