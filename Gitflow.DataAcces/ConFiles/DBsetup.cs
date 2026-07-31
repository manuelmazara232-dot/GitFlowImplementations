using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Gitflow.DataAcces.ConFiles
{
    internal class DBsetup
    {
        string serverConn = ConfigurationManager.ConnectionStrings["ServerConnString"]?.ConnectionString;
        string appConn = ConfigurationManager.ConnectionStrings["appConn"]?.ConnectionString;
        

        private void DBExists(string ServerConnection, string DatabaseName)
        {
            using(new SqlConnection(ServerConnection))
            {

            }
        }
    }
}
