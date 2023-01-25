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
    public partial class ModificaProducatori : Form
    {
        DbContext database = new DbContext();
        public ModificaProducatori()
        {
            InitializeComponent();
            id_producator = 0;

            database = new DbContext();
            database.Connect();
            database.OpenConnection();
        }
        public int id_producator { get; set; } //primary key
        public string producator { get; set; }
        private bool ReadyForInsert()
        {
            if (id_producator ==0 || string.IsNullOrEmpty(producator))
            {
                return false;
            }
            return true;
        }
        private bool ReadyForUpdate()
        {
            if (id_producator == 0 || string.IsNullOrEmpty(producator))
            {
                return false;
            }
            return true;
        }
        private bool ReadyForDelete()
        {
            if (id_producator == 0)
            {
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO producatori (id_producator, producator) VALUES (@id_producator, @producator)", database.DbConnection);
                command.Prepare();
                command.Parameters.AddWithValue("@producator", producator);
                command.Parameters.AddWithValue("@id_producator", id_producator);

                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {

                    MessageBox.Show("Insert successful");
                }
                else
                {

                    MessageBox.Show("Insert failed");
                }


                Producatori producatoriwindow = new Producatori();
                producatoriwindow.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            return;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                id_producator = Int32.Parse(textBox1.Text);
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
                MessageBox.Show("id_producator showld be number", "Mom and Baby - Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            producator = textBox2.Text;
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
                MySqlCommand command = new MySqlCommand("UPDATE producatori set producator=@producator WHERE id_producator=@id_producator", database.DbConnection);
                command.Prepare();
                command.Parameters.AddWithValue("@producator", producator);
                command.Parameters.AddWithValue("@id_producator", id_producator);



                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {

                    MessageBox.Show("Update successful");
                }
                else
                {

                    MessageBox.Show("Update failed");
                }


                Producatori producatoriwindow = new Producatori();
                producatoriwindow.Show();
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
                MySqlCommand command = new MySqlCommand("DELETE FROM producatori WHERE id_producator = @id_producator", database.DbConnection);
                command.Prepare();
                command.Parameters.AddWithValue("@id_producator", id_producator);

                int row = command.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("Delete successful.");
                }
                else
                {
                    MessageBox.Show("Delete failed.");
                }

                Producatori producatoriwindow = new Producatori();
                producatoriwindow.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

    }

}