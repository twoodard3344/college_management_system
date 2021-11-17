using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace college_management_system
{
    class CONNECT
    {
        private MySqlConnection connection = new MySqlConnection("Server = 127.0.0.1; Port=3306;Database=college_management_system;Uid=root;Pwd=Laguna_101;");

        public MySqlConnection getConnection()
        {
            return connection;
        }

        public void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }


        }
    }
}

