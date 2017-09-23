

using System.Data;
using MySql.Data.MySqlClient;

namespace MilitaryCommissariat.Utils
{
    public class ConnectionUtils
    {
        private static MySqlConnection _connection;

        private ConnectionUtils()
        {
        }

        public static MySqlConnection GetConnection()
        {
            if (_connection == null)
            {
                string serverName = "localhost";
                string userName = "user";
                string password = "password";
                string dbName = "military_commissariat";
                string port = "3306";
                string connStr = "server=" + serverName +
                                 ";user=" + userName +
                                 ";database=" + dbName +
                                 ";port=" + port +
                                 ";password=" + password + ";";
                _connection = new MySqlConnection(connStr);
            }
            return _connection;
        }
    }
}
