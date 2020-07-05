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
    public partial class GestaoEspacos : Form
    {
        Connector c;
        public GestaoEspacos(Connector c)
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
                cmd.CommandText = "SELECT COUNT(cod_espaco) FROM ESPACOS";

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

                espacosRegistados.Text = result.ToString();
            }

            aulasEspaco();
            lucroMedioEspaco();
            preencherComboEspacos();
            preencherComboEspacos1();
            preencherComboEspacos2();
        }

        public int freqAula(int cod_aula)
        {
            var dbCon = c.Instance();
            dbCon.DataBaseName = "sportsmanager";

            int result = 0;

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT COUNT(cod_aula) FROM FREQUENTA WHERE cod_aula = @em";

                //este Open bugava ao tentar abrir apos o IsConnect (como estava antes)
                //o que dava um erro de tentar abrir um canal que j� est� aberto.
                //n�o vi mais metodos pq so estava mesmo o testar cenas elementares...
                //mas se este d� os outros tamb�m v�o dar...depois temos � de ver o model
                //cmd.Connection.Open();

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@em", cod_aula);

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }

                dbCon.Close();
            }

            return result;
        }
        public float lucroAula(int cod_aula)
        {
            var dbCon = c.Instance();
            dbCon.DataBaseName = "sportsmanager";

            int f = freqAula(cod_aula);

            float preco_bilhete = 0.0f;

            float lucro = 0.0f;

            if (dbCon.IsConnect())
            {
                int result = 0;

                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT preco_bilhete FROM AULA WHERE cod_aula = @em";

                //este Open bugava ao tentar abrir apos o IsConnect (como estava antes)
                //o que dava um erro de tentar abrir um canal que j� est� aberto.
                //n�o vi mais metodos pq so estava mesmo o testar cenas elementares...
                //mas se este d� os outros tamb�m v�o dar...depois temos � de ver o model
                //cmd.Connection.Open();

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@em", cod_aula);

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    preco_bilhete = reader.GetFloat(0);
                }

                dbCon.Close();
            }

            return (float) f * preco_bilhete;
        }

        public float lucroAluguerEspacos()
        {
            var dbCon = c.Instance();
            dbCon.DataBaseName = "sportsmanager";

            float total = 0.0f;

            if (dbCon.IsConnect())
            {

                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT SUM(preco) FROM ALUGA AS A INNER JOIN ESPACOS AS E WHERE A.cod_espaco = E.cod_espaco";

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
                    total = reader.GetFloat(0);
                }

                dbCon.Close();
            }

            return total;
        }

        public void lucroMedioEspaco()
        {
            var dbCon = c.Instance();
            dbCon.DataBaseName = "sportsmanager";

            List<int> aulas = new List<int>();

            float total = 0.0f;

            if (dbCon.IsConnect())
            {
                int result = 0;

                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT cod_aula FROM AULA";

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
                   aulas.Add(reader.GetInt32(0));
                }

                dbCon.Close();
            }

            foreach(int i in aulas) {
                total += lucroAula(i);
            }

            total += lucroAluguerEspacos();

            textBox2.Text = (total / int.Parse(espacosRegistados.Text)).ToString();
        }

        public void preencherComboEspacos()
        {
            List<int> espaçosExistentes = new List<int>();

            var dbCon = c.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if (dbCon.IsConnect())
            {
                int result = 0;

                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT cod_espaco FROM ESPACOS";

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
                    espaçosExistentes.Add(result);
                }

                dbCon.Close();

                foreach (int i in espaçosExistentes)
                {
                    comboBoxEspaços.Items.Add(i);
                }
            }
        }

        public void preencherComboEspacos1()
        {
            List<int> espaçosExistentes = new List<int>();

            var dbCon = c.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if (dbCon.IsConnect())
            {
                int result = 0;

                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT cod_espaco FROM ESPACOS";

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
                    espaçosExistentes.Add(result);
                }

                dbCon.Close();

                foreach (int i in espaçosExistentes)
                {
                    comboBox1.Items.Add(i);
                }
            }
        }

        public void preencherComboEspacos2()
        {
            List<int> espaçosExistentes = new List<int>();

            var dbCon = c.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if (dbCon.IsConnect())
            {
                int result = 0;

                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT cod_espaco FROM ESPACOS";

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
                    espaçosExistentes.Add(result);
                }

                dbCon.Close();

                foreach (int i in espaçosExistentes)
                {
                    comboBox2.Items.Add(i);
                }
            }
        }

        private void ConsultButton_Click(object sender, EventArgs e)
        {
            int i = (int)comboBoxEspaços.SelectedItem;

            var dbCon = c.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if (dbCon.IsConnect())
            {
                int result = 0;

                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT count(cod_espaco) FROM ALUGA WHERE cod_espaco = @c";

                //este Open bugava ao tentar abrir apos o IsConnect (como estava antes)
                //o que dava um erro de tentar abrir um canal que j� est� aberto.
                //n�o vi mais metodos pq so estava mesmo o testar cenas elementares...
                //mas se este d� os outros tamb�m v�o dar...depois temos � de ver o model
                //cmd.Connection.Open();

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@c", i);

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                }

                dbCon.Close();

                nrVezes.Text = result.ToString();
            }
        }

        public void aulasEspaco()
        {

            int espacos = Int32.Parse(espacosRegistados.Text);

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

                textBox3.Text = (((float)result / (float)espacos)).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = (int)comboBox1.SelectedItem;

            int espacos = Int32.Parse(espacosRegistados.Text);

            var dbCon = c.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if (dbCon.IsConnect())
            {
                int result = 0;

                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT count(cod_aula) FROM AULA WHERE ESPACOS_cod_espaco = @em";

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

                textBox1.Text = result.ToString();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this.c);
            this.Hide();
            f2.Show();
        }
    }
}
