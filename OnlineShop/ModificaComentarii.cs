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
    public partial class ModificaComentarii : Form
    {
        DbContext database = new DbContext();
        public ModificaComentarii()
        {
            InitializeComponent();
            id_comentariu = 0;
            id_produs = 0;

            database = new DbContext();
            database.Connect();
            database.OpenConnection();
        }
        public int id_comentariu { get; set; }//primary key
        public int id_produs { get; set; }
        public string nume_client { get; set;  }
        public string adresa_email { get; set; }
        public string comentariu { get; set; }

        private bool ReadyForDelete()
        {
            if (id_comentariu == 0)
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
                    id_comentariu = Int32.Parse(textBox1.Text);
               
                if (ReadyForDelete())
                {
                    button2.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("id_comentariu showld be number", "Mom and Baby - Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("DELETE FROM comentarii WHERE id_comentariu = @id_comentariu", database.DbConnection);
                command.Prepare();
                command.Parameters.AddWithValue("@id_comentariu", id_comentariu);

                int row = command.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("Delete successful.");
                }
                else
                {
                    MessageBox.Show("Delete failed.");
                }

                Comentarii comentariiwindow = new Comentarii();
                comentariiwindow.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

    }

}