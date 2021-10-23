using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADO.NET
{
    public class Program
    {
        const string SqlConnectionString = "Server=.;Database=MinionsDB;Integrated Security=true";
        public static void Main(string[] args)
        {
            using var connection = new SqlConnection(SqlConnectionString);
            connection.Open();

            //1
            //InitialSetup(connection);

            //2
            //GetVillainNames(connection);

            //3
            //SqlCommand command = GetMinionNames(connection);

            //4
            string[] minionInfo = Console.ReadLine().Split();
            string[] villainInfo = Console.ReadLine().Split();

            string minionName = minionInfo[1];
            int age = int.Parse(minionInfo[2]);
            string town = minionInfo[3];

            int townId = GetTownId(connection, town);

            if (townId == 0)
            {
                string createTownQuery = "INSERT INTO Towns (Id, Name, CountryCode) VALUES (6, @name)";
                using var sqlCommand = new SqlCommand(createTownQuery, connection);
                sqlCommand.Parameters.AddWithValue("@name", town);
                sqlCommand.ExecuteNonQuery();
                townId = GetTownId(connection, town);
                Console.WriteLine($"Town {town} was added to the database.");
            }

            string villainName = villainInfo[1];
            int? villainId = GetVillainId(connection, villainName);

            if (villainId == 0)
            {
                string createVillain = "Insert INTO Villains(Name, EvilnessFactorId) VALUES (@villainName, 4)";
                using var sqlCommand = new SqlCommand(createVillain, connection);
                sqlCommand.Parameters.AddWithValue("@villainName", villainName);
                sqlCommand.ExecuteNonQuery();
                villainId = GetVillainId(connection, villainName);
                Console.WriteLine($"Villain {villainName} was added to the database.");
            }

            CreateMinion(connection, minionName, age, townId);
            var minionId = GetMinionId(connection, minionName);
            InsertMinVil(connection, villainId, minionId);

            Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
        }

        private static void InsertMinVil(SqlConnection connection, int? villainId, int? minionId)
        {
            var insertIntoMinVil = "INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
            var sqlCommand = new SqlCommand(insertIntoMinVil, connection);
            sqlCommand.Parameters.AddWithValue("@villainId", villainId);
            sqlCommand.Parameters.AddWithValue("@minionId", minionId);
            sqlCommand.ExecuteNonQuery();
        }

        private static int? GetMinionId(SqlConnection connection, string minionName)
        {
            var minionIdQuery = "SELECT Id FROM Minions WHERE Name = @Name";
            var sqlCommand = new SqlCommand(minionIdQuery, connection);
            sqlCommand.Parameters.AddWithValue("@Name", minionName);
            var minionId = sqlCommand.ExecuteScalar();
            return (int?)minionId;
        }

        private static void CreateMinion(SqlConnection connection, string minionName, int age, int townId)
        {
            string createMinion = "INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";
            using var sqlCommand = new SqlCommand(createMinion, connection);
            sqlCommand.Parameters.AddWithValue("@name", minionName);
            sqlCommand.Parameters.AddWithValue("@age", age);
            sqlCommand.Parameters.AddWithValue("@townId", townId);
            sqlCommand.ExecuteNonQuery();
        }

        private static int? GetVillainId(SqlConnection connection, string villainName)
        {
            string query = "SELECT Id FROM Villains WHERE Name = @Name";
            using var sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@Name", villainName);
            var villainId = sqlCommand.ExecuteScalar();

            return (int?)villainId;
        }

        private static int GetTownId(SqlConnection connection, string town)
        {
            string townIdQuery = "SELECT Id FROM Towns WHERE Name = @townName";
            using var sqlCommand = new SqlCommand(townIdQuery, connection);
            sqlCommand.Parameters.AddWithValue("@townName", town);
            var townId = sqlCommand.ExecuteScalar();

            return (int)townId;
        }

        private static SqlCommand GetMinionNames(SqlConnection connection)
        {
            int id = int.Parse(Console.ReadLine());
            string villainNameQuery = "SELECT Name FROM Villains WHERE Id = @Id";
            var command = new SqlCommand(villainNameQuery, connection);
            command.Parameters.AddWithValue("@Id", id);
            var result = command.ExecuteScalar();

            string minionsQuery = @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) as RowNum,
                                     m.Name,
                                     m.Age
                                  FROM MinionsVillains AS mv
                                  JOIN Minions AS m ON mv.MinionId = m.Id
                                  WHERE mv.VillainId = @Id
                                  ORDER BY m.Name";
            if (result == null)
            {
                Console.WriteLine($"No villain with ID {id} exists in the database.");
            }
            else
            {
                Console.WriteLine($"Villain: {result}");

                using (var minionCommand = new SqlCommand(minionsQuery, connection))
                {
                    minionCommand.Parameters.AddWithValue("@Id", id);

                    using (var reader = minionCommand.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            Console.WriteLine("(no minions)");
                        }
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader[0]}. {reader[1]} {reader[2]}");
                        }
                    }
                }
            }

            return command;
        }

        private static void ExecuteScalar(SqlConnection connection, string query, params KeyValuePair<string, string>[] kvp)
        {
            using (var command = new SqlCommand(query, connection))
            {
                command.ExecuteScalar();
            }
        }

        private static void GetVillainNames(SqlConnection connection)
        {
            string query = @"SELECT Name, COUNT(mv.MinionId)
                FROM Villains AS v
                JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
                GROUP BY v.Id, v.Name";
            using (var command = new SqlCommand(query, connection))
            {
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = reader[0];
                        var count = reader[1];

                        Console.WriteLine($"{name} - {count}");
                    }
                }
            }
        }

        private static void InitialSetup(SqlConnection connection)
        {
            connection.Open();

            string createDatabase = "CREATE DATABASE  MinionsDB";

            var createTableStatements = GetCreateTableStatements();

            foreach (var query in createTableStatements)
            {
                ExecuteNonQuery(connection, query);
            }

            var insertStatements = GetInsertDataStatements();

            foreach (var query in insertStatements)
            {
                ExecuteNonQuery(connection, query);
            }
        }

        private static void ExecuteNonQuery(SqlConnection connection, string query)
        {
            using (var command = new SqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private static string[] GetInsertDataStatements()
        {
            var result = new string[]
                {
                    "INSERT INTO Countries (Id, Name) VALUES (1, 'Bulgaria'), (2, 'Norway'), (3, 'Iceland'), (4, 'England'), (5, 'Greece')",
                    "INSERT INTO Towns(Id, Name, CountryCode) VALUES (1, 'Varna', 1), (2, 'Oslo', 2), (3, 'Hafnarfjordur', 3), (4, 'London', 4), (5, 'Athens', 5)",
                    "INSERT INTO Minions (Id, Name, Age, TownId) VALUES (1, 'Stoyan', 12, 1), (2, 'George', 22, 2), (3, 'Peter', 33, 3), (4, 'Kaloyan', 44, 4), (5, 'Dragan', 55, 5)",
                    "INSERT INTO EvilnessFactors(Id, Name) VALUES (1, 'super good'), (2, 'good'), (3, 'bad'), (4, 'evel'), (5, 'super evel')",
                    "INSERT INTO Villains(Id, Name, EvilnessFactor) VALUES (1, 'Gru', 1), (2, 'Ivo', 2), (3, 'Teo', 3), (4, 'Sto', 4), (5, 'Pro', 5)",
                    "INSERT INTO MinionsVillains(MinionId, VillainId) VALUES (1, 1), (2, 2), (3, 3), (4, 4), (5, 5)"
                };

            return result;
        }

        private static string[] GetCreateTableStatements()
        {
            var result = new string[]
                { 
                    "CREATE TABLE Countries(Id INT PRIMARY KEY, Name VARCHAR(50))",
                    "CREATE TABLE Towns(Id INT PRIMARY KEY, Name VARCHAR(50), CountryCode INT FOREIGN KEY REFERENCES Countries(Id))",
                    "CREATE TABLE Minions(Id INT PRIMARY KEY, Name VARCHAR(50), Age INT, TownId INT FOREIGN KEY REFERENCES Towns(Id))",
                    "CREATE TABLE EvilnessFactors(Id INT PRIMARY KEY, Name VARCHAR(50))",
                    "CREATE TABLE Villains(Id INT PRIMARY KEY, Name VARCHAR(50), EvilnessFactor INT FOREIGN KEY REFERENCES EvilnessFactors(Id))",
                    "CREATE TABLE MinionsVillains(MinionId INT FOREIGN KEY REFERENCES Minions(Id), VillainId INT FOREIGN KEY REFERENCES Villains(Id), CONSTRAINT PK_MinionsVillains PRIMARY KEY(MinionId, VillainId))"
                };

            return result;
        }
    }
}
