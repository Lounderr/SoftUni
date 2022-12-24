using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace E06.RemoveVillain
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int villainId = int.Parse(Console.ReadLine());

            using (SqlConnection connection = new SqlConnection($"Server=.;Integrated Security=true;Database=MinionsDB;"))
            {
                connection.Open();

                SqlTransaction transaction = connection.BeginTransaction();

                string getVillain =
                    @"
                    SELECT Id FROM Villains WHERE Id = @VillainId;
                    ";

                SqlCommand cmd;

                cmd = new SqlCommand(getVillain, connection, transaction);
                cmd.Parameters.AddWithValue("VillainId", villainId);
                if (cmd.ExecuteScalar() is null)
                {
                    Console.WriteLine("No such villain was found.");
                    transaction.Rollback();
                    return;
                };

                string releaseMinions =
                    @$"
                    DELETE FROM MinionsVillains WHERE VillainId = @VillainId;
                    ";

                cmd = new SqlCommand(releaseMinions, connection, transaction);
                cmd.Parameters.AddWithValue("VillainId", villainId);
                string outputReleasedMinions = $"{cmd.ExecuteNonQuery()} minions were released.";

                string deleteVillain =
                    @$"
                    SELECT Name FROM Villains WHERE Id = @VillainId;
                    DELETE FROM Villains WHERE Id = @VillainId;
                    ";

                cmd = new SqlCommand(deleteVillain, connection, transaction);
                cmd.Parameters.AddWithValue("VillainId", villainId);
                string outputDeletedVillain = $"{(string)cmd.ExecuteScalar()} was deleted.";

                Console.WriteLine(outputDeletedVillain);
                Console.WriteLine(outputReleasedMinions);

                transaction.Commit();
            };
        }
    }
}
