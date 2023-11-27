using MySqlConnector;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace SocietyApi
{
    public interface IDatabaseService
    {
        Task<List<string>> GetStringsFromDb();
        Task AddStringToDb(string value);
        Task ClearDb();
    }
    public class DatabaseService: IDatabaseService
    {
        private readonly string connectionString = "Server=sql8.freemysqlhosting.net;Database=sql8665264;User Id=sql8665264;Password=cqXXVwnqeV;"; // port 3306

        public async Task<List<string>> GetStringsFromDb()
        {
            var data = new List<string>();

            using MySqlConnection connection = new MySqlConnection(connectionString); // prepare connection
            await connection.OpenAsync();

            using MySqlCommand command = new MySqlCommand("SELECT MyColumn FROM MyTable", connection); // prepare command
            using MySqlDataReader reader = await command.ExecuteReaderAsync(); // execute command

            while (await reader.ReadAsync())
            {
                string value = reader.GetString(0); // Retrieve data from the column

                data.Add(value);
            }
            await connection.CloseAsync();

            return data;
        }
        public async Task AddStringToDb(string value)
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new MySqlCommand("INSERT INTO MyTable (MyColumn) VALUES (" + value + ")", connection);
            using MySqlDataReader reader = await command.ExecuteReaderAsync();
            await connection.CloseAsync();
        }
        public async Task ClearDb()
        {
            using MySqlConnection connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new MySqlCommand("TRUNCATE MyTable", connection);
            using MySqlDataReader reader = await command.ExecuteReaderAsync();
            await connection.CloseAsync();
        }
    }
}