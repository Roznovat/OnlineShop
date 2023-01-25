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
    public partial class ModificaDomenii : Form
    {
        DbContext database = new DbContext();
        public ModificaDomenii()
        {
            InitializeComponent();
            id_domeniu = 0;

            database = new DbContext();
            database.Connect();
            database.OpenConnection();
        }
        public int id_domeniu { get; set; } //primary key
        public string domeniu { get; set; }

        private bool ReadyForInsert()
        {
            if (string.IsNullOrEmpty(domeniu))
            {
                return false;
            }
            return true;
        }
        private bool ReadyForUpdate()
        {
            if (id_domeniu == 0 || string.IsNullOrEmpty(domeniu))
            {
                return false;
            }
            return true;
        }
        private bool ReadyForDelete()
        {
            if (id_domeniu == 0)
            {
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO domenii (domeniu) VALUES (@domeniu)", database.DbConnection);
                command.Prepare();
                command.Parameters.AddWithValue("@domeniu", domeniu);

                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {

                    MessageBox.Show("Insert successful");
                }
                else
                {

                    MessageBox.Show("Insert failed");
                }


                Domenii domeniuwindow = new Domenii();
                domeniuwindow.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            return;
        }

            private void textBox1_TextChanged(object sender, EventArgs e) //id_domeniu
        {
            try
            {
                if (textBox1.Text != null)
                    id_domeniu = Int32.Parse(textBox1.Text);
                if (ReadyForInsert())
                {
                    button1.Enabled = true;
                }
                if (ReadyForUpdate())
                {
                    button2.Enabled = true;
                }
                if (ReadyForDelete())
                {
                    button3.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("id_domeniu showld be number", "Mom and Baby - Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            domeniu = textBox2.Text; 
            if (ReadyForInsert())
            {
                button1.Enabled = true;
            }
            if (ReadyForUpdate())
            {
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("UPDATE domenii set domeniu=@domeniu WHERE id_domeniu=@id_domeniu", database.DbConnection);
                command.Prepare();
                command.Parameters.AddWithValue("@domeniu", domeniu);
                command.Parameters.AddWithValue("@id_domeniu", id_domeniu);



                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {

                    MessageBox.Show("Update successful");
                }
                else
                {

                    MessageBox.Show("Update failed");
                }


                Domenii domeniiwindow = new Domenii();
                domeniiwindow.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            return;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("DELETE FROM domenii WHERE id_domeniu = @id_domeniu", database.DbConnection);
                command.Prepare();
                command.Parameters.AddWithValue("@id_domeniu", id_domeniu);

                int row = command.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("Delete successful.");
                }
                else
                {
                    MessageBox.Show("Delete failed.");
                }

                Domenii domeniiwindow = new Domenii();
                domeniiwindow.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

    }

}

