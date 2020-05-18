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
    public partial class GestaoAulas : Form
    {
        Connector c;
        public GestaoAulas(Connector c)
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

                aulas.Text = result.ToString();
            }

            alunosPorAula();

        
        }

        public int aulasCriadas()
        {
            var dbCon = c.Instance();
            dbCon.DataBaseName = "sportsmanager";
            int result = 0;

            if (dbCon.IsConnect())
            {
                

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

                aulas.Text = result.ToString();
            }

            return result;
        }

        public void alunosPorAula()
        {
            int aulas = aulasCriadas();

            var dbCon = c.Instance();
            dbCon.DataBaseName = "sportsmanager";
            int result = 0;

            if (dbCon.IsConnect())
            {


                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT count(email) FROM FREQUENTA";

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

                mediaAlunos.Text = ((double)result / aulas).ToString();
            }
        }


    }
}
