using System.Data.SQLite;
using System.IO;
using System.Data;
using System.Reflection;

namespace Presentation
{
    public class Database
    {
        public SQLiteConnection myConnection;

        public Database()
        {
            string Text = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\GSH_database.sqlite3";
            myConnection = new SQLiteConnection("Data Source="+Text);

            if (!File.Exists("./GSH_database.sqlite3"))
            {
                SQLiteConnection.CreateFile("GSH_database.sqlite3");
            }
        }

        public void ConnectDB()
        {
            if (myConnection.State != ConnectionState.Open)
            {
                myConnection.Open();
            }
        }

        public void DisconnectDB()
        {
            if (myConnection.State != ConnectionState.Closed)
            {
                myConnection.Close();
            }
        }
    }
}
