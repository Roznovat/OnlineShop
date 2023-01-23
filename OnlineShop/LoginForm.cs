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
    public partial class LoginForm : Form
    {
        private MySqlConnection con = new MySqlConnection();
        MySql Command = new MySqlCommand();
        public LoginForm()
        {
            InitializeComponent();
            con.ConnectionString = @"server=localhost;database=bebe2"
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
