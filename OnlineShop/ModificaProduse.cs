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
    public partial class ModificaProduse : Form
    {
        DbContext database = new DbContext();
        public ModificaProduse()
        {
            InitializeComponent();
            id_producator = 0;
            id_produs = 0;
            pret = 0;
            id_domeniu = 0;

            database = new DbContext();
            database.Connect();
            database.OpenConnection();
        }
        public int id_producator { get; set; }

        public int id_produs { get; set; } //primary key

        public string oferta_produs { get; set; }

        public string descriere_produs { get; set; }
        public int pret { get; set; }
        public string datai { get; set; }
        public int id_domeniu { get; set; }

        private bool ReadyForInsert()
        {
            if (id_producator == 0 || string.IsNullOrEmpty(oferta_produs) || string.IsNullOrEmpty(descriere_produs) || pret == 0 || string.IsNullOrEmpty(datai) || id_domeniu == 0)
            {
                return false;
            }
            return true;
        }

        private bool ReadyForUpdate()
        {
            if (id_producator == 0 || id_produs == 0 || string.IsNullOrEmpty(oferta_produs) || string.IsNullOrEmpty(descriere_produs) || pret == 0 || string.IsNullOrEmpty(datai) || id_domeniu == 0)
            {
                return false;
            }
            return true;
        }

        private bool ReadyForDelete()
        {
            if (id_produs == 0)
            {
                return false;
            }

            return true;
        }


        private void button1_Click(object sender, EventArgs e) //insert
        {
            try
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO produse (id_producator, oferta_produs, descriere_produs, pret, datai, id_domeniu) VALUES (@id_producator, @oferta_produs, @descriere_produs, @pret, @datai, @id_domeniu)", database.DbConnection);
                command.Prepare();
                command.Parameters.AddWithValue("@id_producator", id_producator);
                command.Parameters.AddWithValue("@oferta_produs", oferta_produs);
                command.Parameters.AddWithValue("@descriere_produs", descriere_produs);
                command.Parameters.AddWithValue("@pret", pret);
                command.Parameters.AddWithValue("@datai", datai);
                command.Parameters.AddWithValue("@id_domeniu", id_domeniu);



                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {

                    MessageBox.Show("Insert successful");
                }
                else
                {

                    MessageBox.Show("Insert failed");
                }


                Produse produsewindow = new Produse();
                produsewindow.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            return;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)  //id_producator
        {
            try
            {
                if(textBox1.Text!=null)
                    id_producator = Int32.Parse(textBox1.Text);
                if(ReadyForInsert())
                {
                    button1.Enabled = true;
                }
                if(ReadyForUpdate())
                {
                    button2.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("id_producator showld be number", "Mom and Baby - Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            oferta_produs = textBox3.Text; //la toate
            if (ReadyForInsert())
            {
                button1.Enabled = true;
            }
            if (ReadyForUpdate())
            {
                button2.Enabled = true;
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            descriere_produs = textBox4.Text; 
            if (ReadyForInsert())
            {
                button1.Enabled = true;
            }
            if (ReadyForUpdate())
            {
                button2.Enabled = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox5.Text != null) {
                    pret = Int32.Parse(textBox5.Text);
                }
                if (ReadyForInsert())
                {
                    button1.Enabled = true;
                }
                if (ReadyForUpdate())
                {
                    button2.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("pretul showld be number", "Mom and Baby - Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            datai = textBox6.Text; 
            if (ReadyForInsert())
            {
                button1.Enabled = true;
            }
            if (ReadyForUpdate())
            {
                button2.Enabled = true;
            }
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox7.Text != null)
                    id_domeniu = Int32.Parse(textBox7.Text);
                if (ReadyForInsert())
                {
                    button1.Enabled = true;
                }
                if (ReadyForUpdate())
                {
                    button2.Enabled = true;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("domeniul showld be number", "Mom and Baby - Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e) //id_produs
        {
            try
            {
                if(textBox2.Text!=null)
                    id_produs = Int32.Parse(textBox2.Text);
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
                MessageBox.Show("id_produs showld be number", "Mom and Baby - Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand command = new MySqlCommand("UPDATE produse set id_producator=@id_producator, oferta_produs=@oferta_produs, descriere_produs=@descriere_produs, pret=@pret, datai=@datai, id_domeniu=@id_domeniu WHERE id_produs=@id_produs", database.DbConnection);
                command.Prepare();
                command.Parameters.AddWithValue("@id_producator", id_producator);
                command.Parameters.AddWithValue("@id_produs", id_produs);
                command.Parameters.AddWithValue("@oferta_produs", oferta_produs);
                command.Parameters.AddWithValue("@descriere_produs", descriere_produs);
                command.Parameters.AddWithValue("@pret", pret);
                command.Parameters.AddWithValue("@datai", datai);
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


                Produse produsewindow = new Produse();
                produsewindow.Show();
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
                MySqlCommand command = new MySqlCommand("DELETE FROM produse WHERE id_produs = @id_produs", database.DbConnection);
                command.Prepare();
                command.Parameters.AddWithValue("@id_produs", id_produs);

                int row = command.ExecuteNonQuery();

                if (row > 0)
                {
                    MessageBox.Show("Delete successful.");
                }
                else
                {
                    MessageBox.Show("Delete failed.");
                }

                Produse produsewindow = new Produse();
                produsewindow.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error "+ex);
            }
        }
        
    }
    
}
