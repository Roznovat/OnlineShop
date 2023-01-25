using Database;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShop
{
    public partial class Tranzactii : Form
    {
        DbContext database = new DbContext();
        public Tranzactii()
        {
            InitializeComponent();
            database.Connect();
            database.OpenConnection();
            FillTable();
        }

        public void FillTable()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM tranzactii", database.DbConnection);
            command.Prepare();

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            using (DataTable dt = new DataTable())
            {
                adapter.Fill(dt);
                dataGrid.DataSource = dt;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Menu menuWindow = new Menu();
            menuWindow.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModificaTranzactii modificatranzactiiWindow = new ModificaTranzactii();
            modificatranzactiiWindow.Show();
            this.Hide();
        }
    }


}
