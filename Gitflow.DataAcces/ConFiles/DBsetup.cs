using Microsoft.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace Gitflow.DataAcces.ConFiles
{
    public class DBsetup
    {
        string QRP = ConfigurationManager.AppSettings["QueryPath"];
        string serverConn = ConfigurationManager.ConnectionStrings["ServerConnString"]?.ConnectionString;
        string appConn = ConfigurationManager.ConnectionStrings["appConn"]?.ConnectionString;
        string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        

        public void setup()
        {
            string fullPath = Path.GetFullPath(Path.Combine(baseDirectory, QRP));
            bool IsNewDB = AssureDBExistence(serverConn, "GitFlow");

            if (IsNewDB) { ExecQuery(appConn, fullPath); };

        }


        private bool AssureDBExistence(string ServerConnection, string DatabaseName)
        {
            using(var conn = new SqlConnection(ServerConnection))
            {
                conn.Open();
                string query = $@"
IF NOT EXISTS (SELECT NAME FROM sys.databases WHERE name = '{DatabaseName}')
BEGIN
    CREATE DATABASE {DatabaseName}
    SELECT 1;
END
ELSE 
BEGIN
SELECT 0;
END;";
                using (var command = new SqlCommand(query, conn))
                {
                    object resultObj = command.ExecuteScalar();
                    int result = resultObj != null ? Convert.ToInt32(resultObj) : 0;

                    return result == 1;
                }
            }
        }
        private void ExecQuery(string ConnectionString, string QueryPath)
        {
            using (var conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = conn;
                    string query = File.ReadAllText(QueryPath);
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
