using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;

namespace Data
{

    public class Connector
    {

        public Connector()
        {

        }

        private string databaseName = string.Empty;
        public string DataBaseName
        {

            get { return databaseName; }
            set { databaseName = value; }

        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static Connector _instance = null;
        public Connector Instance()
        {
            if (_instance == null)
                _instance = new Connector();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (string.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server=sportsmanager.mysql.database.azure.com; database={0}; UID=SMAdmin@sportsmanager; password=SportsManager2020", databaseName);
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

            //faltava verificar isto assim esta class � completamente responsavel pela conex�o fica um pouco mais modelar.
            if (Connection.State == System.Data.ConnectionState.Closed)
                Connection.Open();

            return true;
        }

        public void Close()
        {
            connection.Close();
        }

    }

}



