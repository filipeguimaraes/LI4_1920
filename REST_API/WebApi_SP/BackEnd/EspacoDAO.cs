using System;
using Spaces;
using MySql.Data;
using MySql.Data.MySqlClient;
using Data;
using System.Collections.Generic;
using WebApi_SP.ViewObj;

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

        internal List<Espaco> getEspacosByUtilizador(string email)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";
            Espaco espaco = null;
            List<Espaco> espacos = new List<Espaco>();

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT * FROM ESPACOS e, ALUGA a WHERE e.cod_espaco = a.cod_espaco AND a.email = @email AND a.data_ini > @date";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    espaco = new Espaco(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
                                                reader.GetString(3), reader.GetFloat(4), reader.GetInt32(5),
                                                reader.GetDateTime(11), reader.GetDateTime(12),
                                                reader.GetFloat(8), reader.GetFloat(9));
                    espacos.Add(espaco);
                }

                dbCon.Close();
            }

            return espacos;
        }

        internal List<Espaco> getEspacosToRent(string email)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";
            Espaco espaco = null;
            List<Espaco> espacos = new List<Espaco>();

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT DISTINCT e.* FROM ESPACOS e";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    espaco = new Espaco(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
                                                reader.GetString(3), reader.GetFloat(4), reader.GetInt32(5),
                                                reader.GetDateTime(6), reader.GetDateTime(7),
                                                reader.GetFloat(8), reader.GetFloat(9));
                    espacos.Add(espaco);
                }

                dbCon.Close();
            }

            return espacos;
        }

        internal List<OccupiedObj> getOccupations(int cod, DateTime date)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";
            OccupiedObj ocupacao = null;
            List<OccupiedObj> ocupacoes = new List<OccupiedObj>();

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT a.cod_espaco, a.data_ini, a.data_fim FROM ALUGA a WHERE @val = a.cod_espaco AND ((@dateBegin >= data_ini OR data_ini <= @dateEnd) AND (@dateBegin <= data_fim OR data_fim >= @dateEnd))";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@val", cod);
                cmd.Parameters.AddWithValue("@dateBegin", date.ToString("yyyy-MM-dd 00:00:00"));
                cmd.Parameters.AddWithValue("@dateEnd", date.ToString("yyyy-MM-dd 23:59:59"));

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ocupacao = new OccupiedObj(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2));
                    ocupacoes.Add(ocupacao);
                }

                dbCon.Close();
            }

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT a.ESPACOS_cod_espaco, a.data_ini, a.data_fim FROM AULA a WHERE @val = a.ESPACOS_cod_espaco AND ((@dateBegin >= data_ini OR data_ini <= @dateEnd) AND (@dateBegin <= data_fim OR data_fim >= @dateEnd))";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@val", cod);
                cmd.Parameters.AddWithValue("@dateBegin", date.ToString("yyyy-MM-dd 00:00:00"));
                cmd.Parameters.AddWithValue("@dateEnd", date.ToString("yyyy-MM-dd 23:59:59"));

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ocupacao = new OccupiedObj(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2));
                    ocupacoes.Add(ocupacao);
                }

                dbCon.Close();
            }

            return ocupacoes;
        }

        public Espaco get(int codigo)
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
                    espaco = new Espaco(reader.GetInt32(2), reader.GetString(1), reader.GetInt32(2),
                                                reader.GetString(3), reader.GetFloat(4), reader.GetInt32(5),
                                                reader.GetDateTime(6), reader.GetDateTime(7),
                                                reader.GetFloat(8), reader.GetFloat(9));
                    espaco.CodEspaco = reader.GetInt32(0);
                     
                }

                

                dbCon.Close();
            }

            return espaco;

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

        public int available(int codigo, string begin, string end)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            int res = 0;

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;

                cmd.CommandText = "SELECT count(*)+(SELECT count(*) FROM AULA a WHERE @val = a.ESPACOS_cod_espaco AND data_ini > now() AND ((@dateBegin >= data_ini OR data_ini <= @dateEnd) AND (@dateBegin <= data_fim OR data_fim >= @dateEnd))) as count FROM ALUGA a WHERE @val = a.cod_espaco AND data_ini > now() AND ((@dateBegin >= data_ini OR data_ini <= @dateEnd) AND (@dateBegin <= data_fim OR data_fim >= @dateEnd))";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@val", codigo);
                cmd.Parameters.AddWithValue("@dateEnd", end);
                cmd.Parameters.AddWithValue("@dateBegin", begin);

                cmd.ExecuteNonQuery();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    res = reader.GetInt32(0);
                }

                dbCon.Close();
            }

            return res;
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

        public void deleteReserva(string email, int codEspaco, DateTime inicio, DateTime fim)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;

                cmd.CommandText = "DELETE FROM ALUGA WHERE cod_espaco = @c AND data_ini = @datai AND data_fim = @datae AND email = @e";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@c", codEspaco);
                cmd.Parameters.AddWithValue("@datai", inicio);
                cmd.Parameters.AddWithValue("@datae", fim);
                cmd.Parameters.AddWithValue("@e", email);

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                dbCon.Close();
            }
        }

    }

}