using Data;
using MySql.Data.MySqlClient;
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
    public partial class GestaoUsers : Form
    {
        Connector c;
        public GestaoUsers(Connector c)
        {
            InitializeComponent();

            this.c = c;

            var dbCon = c.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if (dbCon.IsConnect())
            {
                int result = 0;

                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT count(email) FROM UTILIZADOR";

                //este Open bugava ao tentar abrir apos o IsConnect (como estava antes)
                //o que dava um erro de tentar abrir um canal que j� est� aberto.
                //n�o vi mais metodos pq so estava mesmo o testar cenas elementares...
                //mas se este d� os outros tamb�m v�o dar...depois temos � de ver o model
                //cmd.Connection.Open();

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }

                dbCon.Close();

                usersRegistados.Text = result.ToString();
            }
            preencherComboUsers1();
            aulasPorUser();
        }

        public void preencherComboUsers1()
        {
            List<string> usersExistentes = new List<string>();

            var dbCon = c.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if (dbCon.IsConnect())
            {
                string result;

                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT email FROM UTILIZADOR";

                //este Open bugava ao tentar abrir apos o IsConnect (como estava antes)
                //o que dava um erro de tentar abrir um canal que j� est� aberto.
                //n�o vi mais metodos pq so estava mesmo o testar cenas elementares...
                //mas se este d� os outros tamb�m v�o dar...depois temos � de ver o model
                //cmd.Connection.Open();

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = reader.GetString(0);
                    usersExistentes.Add(result);
                }

                dbCon.Close();

                foreach (string i in usersExistentes)
                {
                    comboBox1.Items.Add(i);
                }
            }
        }

        public void aulasPorUser()
        {
            var dbCon = c.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if (dbCon.IsConnect())
            {
                int result = 0;

                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT count(cod_aula) FROM AULA";

                //este Open bugava ao tentar abrir apos o IsConnect (como estava antes)
                //o que dava um erro de tentar abrir um canal que j� est� aberto.
                //n�o vi mais metodos pq so estava mesmo o testar cenas elementares...
                //mas se este d� os outros tamb�m v�o dar...depois temos � de ver o model
                //cmd.Connection.Open();

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }

                dbCon.Close();

                textBox1.Text = ((float) result / (float) int.Parse(usersRegistados.Text)).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string i = (string)comboBox1.SelectedItem;

            var dbCon = c.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if (dbCon.IsConnect())
            {
                int result = 0;

                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT count(email) FROM FREQUENTA WHERE email = @em";

                //este Open bugava ao tentar abrir apos o IsConnect (como estava antes)
                //o que dava um erro de tentar abrir um canal que j� est� aberto.
                //n�o vi mais metodos pq so estava mesmo o testar cenas elementares...
                //mas se este d� os outros tamb�m v�o dar...depois temos � de ver o model
                //cmd.Connection.Open();

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@em", i);

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }

                dbCon.Close();

                textBox2.Text = result.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this.c);
            this.Hide();
            f2.Show();
        }
    }
}
