using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.VisualBasic;
using MyClasses;

namespace App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] minionInfo = Console.ReadLine().Split();
            string minionName = minionInfo[1];
            string minionAge = minionInfo[2];
            string minionTown = minionInfo[3];

            string villainName = Console.ReadLine().Split()[1];

            using (SqlConnection connection = new SqlConnection($"Server=.;Integrated Security=true;Database=MinionsDB;"))
            {
                connection.Open();

                string getVillainsSql = @"SELECT Name FROM Villains;";
                string getTownsSql = @"SELECT Name FROM Towns;";

                List<string> villains = new List<string>();
                List<string> towns = new List<string>();

                SqlCommand cmd;

                cmd = new SqlCommand(getVillainsSql, connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        villains.Add((string)reader[0]);
                    }
                };

                cmd = new SqlCommand(getTownsSql, connection);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        towns.Add((string)reader[0]);
                    }
                };

                if (!towns.Contains(minionTown))
                {
                    string addTownToDbSql = @"INSERT INTO Towns(Name) VALUES (@TownName);";
                    cmd = new SqlCommand(addTownToDbSql, connection);
                    cmd.Parameters.AddWithValue($"TownName", minionTown);
                    cmd.ExecuteNonQuery();
                    towns.Add(minionTown);
                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }

                if (!villains.Contains(villainName))
                {
                    string addVillainToDbSql = @"INSERT INTO Villains(Name, EvilnessFactor) VALUES (@VillainName, 'Really evil');";
                    cmd = new SqlCommand(addVillainToDbSql, connection);
                    cmd.Parameters.AddWithValue($"VillainName", villainName);
                    cmd.ExecuteNonQuery();
                    villains.Add(villainName);
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                string addMinionToDbSql =
                    @"
                    INSERT INTO Minions(Name, Age, TownId) VALUES 
                    (@MinionName, @MinionAge, (SELECT Id FROM Towns WHERE Name = @MinionTown)); 

                    INSERT INTO MinionsVillains VALUES 
                    ((SELECT TOP(1) Id FROM Minions WHERE Name = @MinionName AND Age = @MinionAge), 
                    (SELECT TOP(1) Id FROM Villains WHERE Name = @VillainName));
                    ";
                cmd = new SqlCommand(addMinionToDbSql, connection);
                cmd.Parameters.AddWithValue($"MinionName", minionName);
                cmd.Parameters.AddWithValue($"MinionAge", minionAge);
                cmd.Parameters.AddWithValue($"MinionTown", minionTown);
                cmd.Parameters.AddWithValue($"VillainName", villainName);
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");




            }
        }
    }
}