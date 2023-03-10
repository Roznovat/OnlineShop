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
    public partial class Domenii : Form
    {
        DbContext database = new DbContext();
        public Domenii()
        {
            InitializeComponent();
            database.Connect();
            database.OpenConnection();
            FillTable();
        }
        public void FillTable()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM domenii", database.DbConnection);
            command.Prepare();

            MySqlDataAdapter adapter = new MySqlDataAdapter(command);

            using (DataTable dt = new DataTable())
            {
                adapter.Fill(dt);
                dataGrid.DataSource = dt;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu menuWindow = new Menu();
            menuWindow.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ModificaDomenii modificadomeniiWindow = new ModificaDomenii();
            modificadomeniiWindow.Show();
            this.Hide();
        }
    }


}