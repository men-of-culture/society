using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
namespace BlazorApp1
{
    public interface IDatabaseService
    {
        Task<List<string>> GetStringsFromDb();
    }
    public class DatabaseService: IDatabaseService
    {
        private readonly string connectionString = "Server=myServerAddress;Database=myDatabase;User Id=myUsername;Password=myPassword;";

        public async Task<List<string>> GetStringsFromDb()
        {
            var data = new List<string>();

            /*using SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            // Replace "MyTable" with your actual table name and "MyColumn" with the column you want to retrieve.
            using SqlCommand command = new SqlCommand("SELECT MyColumn FROM MyTable", connection);
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                // Retrieve data from the column
                string value = reader.GetString(0); // Adjust the index if necessary

                data.Add(value);
            }*/
            data.Add("Freezing");

            return data;
        }
    }
}