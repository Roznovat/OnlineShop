using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Database;
using MySqlConnector;

namespace OnlineShop
{
    public partial class LoginForm : Form
    {
        DbContext database;  
        private string username;
        private string password;

        public LoginForm()
        {
            username = "";
            password = "";
            InitializeComponent();
            database = new DbContext();
            database.Connect();
            database.OpenConnection();
        }

        private void ResetFields()
        {
            text_password.Text = "";
            text_username.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("The username or password is missing!", "Mom And Baby - Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetFields();
                    return;
                }

                string encrypted = EncrpytPassword(password);
                MySqlCommand command = new MySqlCommand("SELECT * FROM admin WHERE admin_nume = @username AND admin_parola = @password",database.DbConnection);
                command.Prepare();
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", encrypted);

                MySqlDataReader reader = command.ExecuteReader();
                int count = 0;

                while (reader.Read())
                {
                    count++;
                }

                reader.Close();

                if(count >= 1)
                {
                    MessageBox.Show("Welcome back, " + username, "Mom And Baby - Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Menu mainMenu = new Menu();
                    mainMenu.Show();
                    this.Hide();
                    
                }
                else
                {
                    MessageBox.Show("Cannot sign you in because the credentials you have provided does not describe any of our existing users!", "Mom And Baby - Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetFields();
                    return;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private string EncrpytPassword(string password)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(password));
            byte[] result = md5.Hash;

            StringBuilder sb = new StringBuilder();
            for(int i=0; i<result.Length; i++)
            {
                sb.Append(result[i].ToString("x2"));
            }

            return sb.ToString();
        }

        private void text_username_TextChanged(object sender, EventArgs e)
        {
            username = text_username.Text;
        }

        private void text_password_TextChanged(object sender, EventArgs e)
        {
           password  = text_password.Text;
        }
    }

 }

