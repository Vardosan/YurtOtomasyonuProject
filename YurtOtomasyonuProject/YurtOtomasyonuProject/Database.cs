using Npgsql;
using System;

namespace YurtOtomasyonuProject
{
    public class Database
    {
        private string connectionString;

        public Database(string host, string dbName, string username, string password)
        {
            connectionString = $"Host={host};Database={dbName};Username={username};Password={password}";
        }

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }

        public void ConnectTest()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                Console.WriteLine("Veritabanına başarılı bir şekilde bağlanıldı.");
            }
        }
    }
}
