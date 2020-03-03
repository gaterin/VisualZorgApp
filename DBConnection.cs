
using MySql.Data.MySqlClient;

namespace VisualZorgApp
{
    class DBConnection
    {
        public MySqlConnection con { get; private set; }
        private string server = "localhost";
        private string database = "zorgapp";
        private string uid = "root";
        private string password = "";

        public DBConnection()
        {
            Initialize();
        }

        private void Initialize()
        {
          
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            con = new MySqlConnection(connectionString);
            

        }
    }
}
