using MySqlConnector;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace Society
{
    public interface IDatabaseService
    {
        Task<List<string>> GetStringsFromDb();
    }
    public class DatabaseService: IDatabaseService
    {
        private readonly string connectionString = "Server=sql8.freemysqlhosting.net;Database=sql8665264;User Id=sql8665264;Password=cqXXVwnqeV;"; // port 3306

        public async Task<List<string>> GetStringsFromDb()
        {
            var data = new List<string>();

            using MySqlConnection connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            using MySqlCommand command = new MySqlCommand("SELECT MyColumn FROM MyTable", connection);
            using MySqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                // Retrieve data from the column
                string value = reader.GetString(0);

                data.Add(value);
            }
            data.Add("Freezing");

            return data;
        }
    }
}