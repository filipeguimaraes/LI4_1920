using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SportsManagerAdmin
{
    public partial class Form2 : Form
    {

        Connector c;

        public Form2(Connector c)
        {
            InitializeComponent();

            this.c = c;
        }

        private void gestaoUsers_Click(object sender, EventArgs e)
        {
            GestaoUsers g = new GestaoUsers(c);
            this.Hide();
            g.Show();
        }

        private void gestaoEspacos_Click(object sender, EventArgs e)
        {
            GestaoEspacos g = new GestaoEspacos(c);
            this.Hide();
            g.Show();
        }

        private void gestaoAulas_Click(object sender, EventArgs e)
        {
            GestaoAulas g = new GestaoAulas(c);
            this.Hide();
            g.Show();
        }
    }
}
