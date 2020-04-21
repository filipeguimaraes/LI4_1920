using System;
using Spaces;
using MySql.Data;
using MySql.Data.MySqlClient;
using Data;

namespace SpacesDAO {

    public class EspacoDAO {

        private Connector db;

        public EspacoDAO()
        {
            this.db = new Connector();
        }

        public void put(Espaco espaco) 
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "Insert INTO ESPACOS(tipo, lotacao, local, preco, area, disponivel_ini, disponivel_fim) VALUES(@tipo, @lotacao, @local, @preco, @area, @dispINI, @dispFIM)";
               
                cmd.Prepare();

                
                cmd.Parameters.AddWithValue("@tipo", espaco.Tipo);
                cmd.Parameters.AddWithValue("@lotacao", espaco.Lotacao);
                cmd.Parameters.AddWithValue("@local", espaco.Local);
                cmd.Parameters.AddWithValue("@preco", espaco.PrecoHora);
                cmd.Parameters.AddWithValue("@area", espaco.Area);
                cmd.Parameters.AddWithValue("@dispINI", espaco.DisponivelIni.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@dispFIM", espaco.DisponivelFim.ToString("yyyy-MM-dd HH:mm"));
                
                cmd.ExecuteNonQuery();

                dbCon.Close();
            }
        }

        public void get(int codigo)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";
            Espaco espaco = null;

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT * FROM ESPACOS WHERE cod_espaco = @cod";
               
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@cod", codigo);
                
                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    espaco = new Espaco(reader.GetString(1), reader.GetInt32(2),
                                                reader.GetString(3), reader.GetFloat(4), reader.GetInt32(5),
                                                reader.GetDateTime(6), reader.GetDateTime(7));
                    espaco.CodEspaco = reader.GetInt32(0);
                     
                }

                

                dbCon.Close();
            }
           Console.WriteLine(espaco.Tipo);

        }

        public void update(int codigo, string atributo, object valor)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;

                switch (atributo)
                {
                    case "cod_espaco":
                        cmd.CommandText = "UPDATE ESPACOS SET cod_espaco = @val WHERE cod_espaco = @em";
                        break;
                    case "tipo":
                        cmd.CommandText = "UPDATE ESPACOS SET tipo = @val WHERE cod_espaco = @em";
                        break;
                    case "lotacao":
                        cmd.CommandText = "UPDATE ESPACOS SET lotacao = @val WHERE cod_espaco = @em";
                        break;
                    case "local":
                        cmd.CommandText = "UPDATE ESPACOS SET local = @val WHERE cod_espaco = @em";
                        break;
                    case "preco":
                        cmd.CommandText = "UPDATE ESPACOS SET preco = @val WHERE cod_espaco = @em";
                        break;
                    case "area":
                        cmd.CommandText = "UPDATE ESPACOS SET area = @val WHERE cod_espaco = @em";
                        break;
                    case "disponivel_ini":
                        cmd.CommandText = "UPDATE ESPACOS SET disponivel_ini = @val WHERE cod_espaco = @em";
                        break;
                    case "disponivel_fim":
                        cmd.CommandText = "UPDATE ESPACOS SET disponivel_fim = @val WHERE cod_espaco = @em";
                        break;
                    default:
                        break;
                }
                
               
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@val", valor);
                cmd.Parameters.AddWithValue("@em", codigo);
                
                cmd.ExecuteNonQuery();

                dbCon.Close();
            }
        }

        public void remove(int codigo)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                
                cmd.CommandText = "DELETE FROM ESPACOS WHERE cod_espaco = @val";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@val", codigo);
                
                cmd.ExecuteNonQuery();

                dbCon.Close();
            }
        }

        public Boolean containsKey(int codigo)
        {
            Boolean existe = false;

            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                
                cmd.CommandText = "SELECT COUNT(cod_espaco) FROM ESPACOS WHERE cod_espaco = @em";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@em",codigo);
                
                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    int res = 0;
                    res = reader.GetInt32(0);
                    if(res > 0)
                        existe = true;
                }

                dbCon.Close();
            }
            Console.WriteLine(existe.ToString());
            return existe;
        }

        public Boolean spaceAvailable(int codigo, DateTime inicio, DateTime fim)
        {
            Boolean disponivel = true;

            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;

                cmd.CommandText = "SELECT COUNT(cod_espaco) FROM ESPACOS WHERE cod_espaco = @em AND data_ini = @di";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@em", codigo);
                cmd.Parameters.AddWithValue("@di", inicio.ToString("yyyy-MM-dd HH:mm"));

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int res = 0;
                    res = reader.GetInt32(0);
                    if (res > 0)
                        disponivel = false;
                }

                dbCon.Close();
            }
            Console.WriteLine(disponivel.ToString());
            return disponivel;
        }

        public void rent(string email, int codEspaco, DateTime inicio, DateTime fim)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;

                cmd.CommandText = "INSERT INTO ALUGA(cod_espaco, data_ini, data_fim, email) VALUES(@es, @di, @df, @em)";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@es", codEspaco);
                cmd.Parameters.AddWithValue("@di", inicio.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@df", fim.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@em", email);

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                dbCon.Close();
            }
        }

        public Boolean canChangeDate(int codigo, string tipo, DateTime novaData)
        {
            Boolean disponivel = true;

            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;

                switch(tipo)
                {
                    case "inicio":
                        cmd.CommandText = "SELECT COUNT(cod_espaco) FROM ALUGA WHERE cod_espaco = @em AND data_ini = @di"; //REVER ESTA LÓGICA PARA FUNCIONAR

                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@em", codigo);
                        cmd.Parameters.AddWithValue("@di", novaData.ToString("yyyy-MM-dd HH:mm"));

                        cmd.ExecuteNonQuery();
                        break;
                    case "fim":
                        cmd.CommandText = "SELECT COUNT(cod_espaco) FROM ALUGA WHERE cod_espaco = @em AND data_ini <= @di";

                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@em", codigo);
                        cmd.Parameters.AddWithValue("@di", novaData.ToString("yyyy-MM-dd HH:mm"));

                        cmd.ExecuteNonQuery();
                        break;
                }

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int res = 0;
                    res = reader.GetInt32(0);
                    if (res > 0)
                        disponivel = false;
                }

                dbCon.Close();
            }
            Console.WriteLine(disponivel.ToString());
            return disponivel;
        }

        public void updateReserva(int reserva, string tipo, DateTime novaData)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;

                switch (tipo)
                {
                    case "inicio":
                        cmd.CommandText = "UPDATE ALUGA SET data_ini = @di WHERE cod_reserva = @c";

                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@c", reserva);
                        cmd.Parameters.AddWithValue("@di", novaData.ToString("yyyy-MM-dd HH:mm"));

                        cmd.ExecuteNonQuery();
                        break;
                    case "fim":
                        cmd.CommandText = "UPDATE ALUGA SET data_fim = @di WHERE cod_reserva = @c";

                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@c", reserva);
                        cmd.Parameters.AddWithValue("@di", novaData.ToString("yyyy-MM-dd HH:mm"));

                        cmd.ExecuteNonQuery();
                        break;
                }

                var reader = cmd.ExecuteReader();

                dbCon.Close();
            }
        }

        public void deleteReserva(int reserva)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;

                cmd.CommandText = "DELETE FROM ALUGA WHERE cod_reserva = @c";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@c", reserva);

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                dbCon.Close();
            }
        }

    }

}