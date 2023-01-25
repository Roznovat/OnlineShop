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
    public partial class ModificaVanzari : Form
    {
        DbContext database = new DbContext();
        public ModificaVanzari()
        {
            InitializeComponent();
            id_tranzactie = 0;
            id_produs = 0;
            nr_bucati = 0;

            database = new DbContext();//+
            database.Connect();//+
            database.OpenConnection();//+
        }
        public int id_tranzactie { get; set; }
        public int id_produs { get; set; }
        public int nr_bucati { get; set; }
        public string data_vanzare { get; set; }
        private bool ReadyForDelete()
        {
            if (nr_bucati == 0)
            {
                return false;
            }

            return true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text != null)
                    nr_bucati = Int32.Parse(textBox3.Text);

                if (ReadyForDelete())
                {
                    button1.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("nr_bucati showld be number", "Mom and Baby - Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("DELETE FROM vanzari WHERE nr_bucati = @nr_bucati", database.DbConnection);
                command.Prepare();
                command.Parameters.AddWithValue("@nr_bucati", nr_bucati);

                int row = command.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("Delete successful.");
                }
                else
                {
                    MessageBox.Show("Delete failed.");
                }

                Vanzari vanzariwindow = new Vanzari();
                vanzariwindow.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

    }

}
