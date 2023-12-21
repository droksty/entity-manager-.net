using Microsoft.Data.SqlClient;

namespace PlayerWebApp.DAO
{
    public class DBLUtil
    {
        private static SqlConnection? connection;


        // Enfore noninstatiability
        private DBLUtil() { }


        public static SqlConnection? GetConnection()
        {
            try
            {
                ConfigurationManager cm = new();
                cm.AddJsonFile("appsettings.json");
                string url = cm.GetConnectionString("DefaultConnection");
                connection = new SqlConnection(url);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return connection;
        }


        public static void CloseConnection()
        {
            connection?.Close();
        }
    }
}
