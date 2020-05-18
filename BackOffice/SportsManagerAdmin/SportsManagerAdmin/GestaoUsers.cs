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
        }
    }
}
