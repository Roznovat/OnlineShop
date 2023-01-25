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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //navigarea din meniu spre cele 6 tabele
            Produse productsWindow= new Produse();
            productsWindow.Show();
            this.Hide();
        }
        private void afiseaza_domenii_Click(object sender, EventArgs e)
        {
            Domenii domeniiWindow = new Domenii();
            domeniiWindow.Show();
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Producatori producatoriWindow = new Producatori();
            producatoriWindow.Show();
            this.Hide();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Comentarii comentariiWindow = new Comentarii();
            comentariiWindow.Show();
            this.Hide();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            Vanzari vanzariWindow = new Vanzari();
            vanzariWindow.Show();
            this.Hide();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            Tranzactii tranzactiiWindow = new Tranzactii();
            tranzactiiWindow.Show();
            this.Hide();
        }
        //logout din meniu spre pagina de login
        private void button4_Click(object sender, EventArgs e)
        {
            LoginForm LoginWindow = new LoginForm();
            LoginWindow.Show();
            this.Hide();
        }

        
    }
}
