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
    public partial class ModificaTranzactii : Form
    {
        DbContext database = new DbContext();
        public ModificaTranzactii()
        {
            InitializeComponent();
            id_tranzactie = 0;

            database = new DbContext();
            database.Connect();
            database.OpenConnection();
        }
        public int id_tranzactie { get; set; }
        public string data_tranzactie { get; set; }
        public string nume_client { get; set; }
        public string adresa_client { get; set; }
        public string comanda_onorata { get; set; }
        private bool ReadyForDelete()
        {
            if (id_tranzactie == 0)
            {
                return false;
            }

            return true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != null)
                    id_tranzactie = Int32.Parse(textBox1.Text);

                if (ReadyForDelete())
                {
                    button1.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("id_tranzactie showld be number", "Mom and Baby - Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("DELETE FROM tranzactii WHERE id_tranzactie = @id_tranzactie", database.DbConnection);
                command.Prepare();
                command.Parameters.AddWithValue("@id_tranzactie", id_tranzactie);

                int row = command.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("Delete successful.");
                }
                else
                {
                    MessageBox.Show("Delete failed.");
                }

                Tranzactii tranzactiiwindow = new Tranzactii();
                tranzactiiwindow.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

    }

}
