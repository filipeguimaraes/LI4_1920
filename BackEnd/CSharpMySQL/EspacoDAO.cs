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
                cmd.CommandText = "Insert INTO ESPACOS VALUES(@codEspaco, @tipo, @lotacao, @local, @preco, @area, @dispINI, @dispFIM)";
               
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@codEspaco", espaco.CodEspaco);
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
                    espaco = new Espaco(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2),
                                                reader.GetString(3), reader.GetFloat(4), reader.GetInt32(5),
                                                reader.GetDateTime(6), reader.GetDateTime(7));
                     
                }

                

                dbCon.Close();
            }
           Console.WriteLine(espaco.Tipo);

        }

        public void update(int codigo, string atributo, string valor)
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

        public List<Espaco> getAll() {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            List<Espaco> espacos = new ArrayList<Espaco>();

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                
                cmd.CommandText = "SELECT * FROM ESPACO";

                cmd.Connection.Open(); 

                cmd.Prepare();

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Espaco e = new Espaco(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3), reader.GetFloat(4), reader.GetInt32(5), reader.GetDateTime(6), reader.GetDateTime(7));
                    espacos.add(e);
                }

                dbCon.Close();
            }

            return aulas;
        }

    }

}