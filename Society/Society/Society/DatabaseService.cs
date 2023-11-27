using MySqlConnector;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace Society
{
    public interface IMSSQLDatabaseService
    {
        Task<List<string>> GetStringsFromDb();
        Task AddStringToDb(string value);
        Task ClearDb();
    }
    public class MSSQLDatabaseService : IMSSQLDatabaseService
    {
        private readonly string connectionString = "Server=sql.bsite.net\\MSSQL2016;Database=joozibob_society;User Id=joozibob_society;Password=society;"; // port 3306

        public async Task<List<string>> GetStringsFromDb()
        {
            var data = new List<string>();

            using SqlConnection connection = new SqlConnection(connectionString); // prepare connection
            await connection.OpenAsync();

            using SqlCommand command = new SqlCommand("SELECT MyColumn FROM MyTable", connection); // prepare command
            using SqlDataReader reader = await command.ExecuteReaderAsync(); // execute command

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
            using SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            using SqlCommand command = new SqlCommand("INSERT INTO MyTable (MyColumn) VALUES (" + value + ")", connection);
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            await connection.CloseAsync();
        }
        public async Task ClearDb()
        {
            using SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            using SqlCommand command = new SqlCommand("TRUNCATE TABLE MyTable", connection);
            using SqlDataReader reader = await command.ExecuteReaderAsync();
            await connection.CloseAsync();
        }
    }
}