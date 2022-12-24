using System;
using System.Data.SqlClient;

namespace E01.InitialSetup
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // . or 127.0.0.1 or DESKTOP-NAME
            string connectionString = "Server=.;Integrated Security=true;Database=master;"; // User Id=MyName;Password=1234;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmdCreate = new SqlCommand(@"USE master; CREATE DATABASE MinionsDB;", connection);

                cmdCreate.ExecuteNonQuery();

                string query =
                   @"
                USE master;
                CREATE DATABASE MinionsDB;
                USE MinionsDB; 
                CREATE TABLE Countries(Id INT PRIMARY KEY IDENTITY, [Name] NVARCHAR(80)  NOT NULL);
                INSERT INTO Countries VALUES 
                ('Bulgaria'),
                ('Macedonia')
                CREATE TABLE Towns(Id INT PRIMARY KEY IDENTITY, [Name] NVARCHAR(80) NOT NULL, CountryCode INT REFERENCES Countries(Id));
                INSERT INTO Towns VALUES 
                ('Sofia', 1),
                ('Plovdiv', 1),
                ('MacedonianCity', 2)
                CREATE TABLE Minions(Id INT PRIMARY KEY IDENTITY, [Name] NVARCHAR(80), Age INT, TownId INT REFERENCES Towns(Id));
                INSERT INTO Minions VALUES 
                ('Kesten', 12, 1),
                ('Kartof', 11, 1),
                ('Tekila', 14, 1),
                ('Mezdra', 16, 2),
                ('Muncho', 22, 2),
                ('Gosho', 13, 2),
                ('Stracimir', 11, 2)
                CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY IDENTITY, [Name] NVARCHAR(80))
                INSERT INTO EvilnessFactors VALUES
                ('Kinda evil'),
                ('Really evil')
                CREATE TABLE Villains(Id INT PRIMARY KEY IDENTITY, [Name] NVARCHAR(80), EvilnessFactorId INT REFERENCES EvilnessFactors(Id));
                INSERT INTO Villains VALUES 
                ('Gru', 1),
                ('Vru', 1),
                ('Bru', 2)
                CREATE TABLE MinionsVillains(MinionId INT REFERENCES Minions(Id), VillainId INT REFERENCES Villains(Id), PRIMARY KEY(MinionId, VillainId));
                INSERT INTO MinionsVillains VALUES
                (1),
                (1),
                (1),
                (1),
                (2),
                (2),
                (2);            
                ";

                SqlCommand cmd = new SqlCommand(query, connection);

                Console.WriteLine(cmd.ExecuteNonQuery());
            }
        }
    }
}
