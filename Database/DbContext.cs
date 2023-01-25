using MySqlConnector;
using System;
using System.Windows.Forms;

namespace Database
{
    public class DbContext
    {
        private readonly string connection;

        private bool Open { get; set; }

        public MySqlConnection DbConnection { get; set; }


        public DbContext()
        {
            Open = false;
            connection = @"server=localhost;userid=root;database=bebe2;";
        }

        public void Connect()
        {
            try
            {
                DbConnection = new MySqlConnection(connection);

            }
            catch(MySqlException ex)
            {
                MessageBox.Show("Unable to establish connection\n"+ex);
            }
        }

        public void OpenConnection()
        {
            if (!Open)
            {
                try
                {
                    DbConnection.Open();
                    Open = true;
                }
                catch(MySqlException ex)
                {
                    MessageBox.Show("Connection failed!\n"+ex);
                }
            }
        }

        public void CloseConnection()
        {
            if (Open)
            {
                DbConnection.Close();
                Open = false;
            }
        }
    }
}
