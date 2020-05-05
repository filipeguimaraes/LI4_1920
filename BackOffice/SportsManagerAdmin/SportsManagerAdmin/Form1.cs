using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;

namespace SportsManagerAdmin
{
    public partial class Form1 : Form
    {

        Connector c = new Connector();

        string username = "SportsManager";
        string password = "SportsManager2020";

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (usernameText.Text.Equals(username) && passwordText.Text.Equals(password)) {
                Form2 form = new Form2(c);

                this.Hide();

                form.Show();
            } 

        }
    }
}
