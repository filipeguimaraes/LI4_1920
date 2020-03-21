using System;
using Classes;
using MySql.Data;
using MySql.Data.MySqlClient;
using Data;

namespace ClassesDAO {

    public class AulaDAO {

        private Connector db;
        public AulaDAO()
        {
            this.db = new Connector();
        }

        public void put(Aula aula) 
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "Insert INTO AULA VALUES(@codAula, @numBilhetes, @precoBilhete, @dataI, @dataF, @mod, @codEs, @em)";
               
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@codAula", aula.CodAula);
                cmd.Parameters.AddWithValue("@numBilhetes", aula.NumBilhetes);
                cmd.Parameters.AddWithValue("@precoBilhete", aula.PrecoBilhete);
                cmd.Parameters.AddWithValue("@dataI", aula.DataINI.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@dataF", aula.DataFIM.ToString("yyyy-MM-dd HH:mm"));
                cmd.Parameters.AddWithValue("@mod", aula.Modalidade);
                cmd.Parameters.AddWithValue("@codEs", aula.CodEspaco);
                cmd.Parameters.AddWithValue("@em", aula.Email);
                
                cmd.ExecuteNonQuery();

                dbCon.Close();
            }
        }

        public void get(int codigo)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";
            Aula aula = null;

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT * FROM AULA WHERE cod_aula = @c";
               
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@c", codigo);
                
                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    aula = new Aula(reader.GetInt32(0), reader.GetInt32(1), reader.GetFloat(2),
                                                reader.GetDateTime(3), reader.GetDateTime(4), reader.GetString(5),
                                                reader.GetInt32(6), reader.GetString(7));
                     
                }

                dbCon.Close();
            }
           Console.WriteLine(aula.Modalidade);

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
                    case "cod_aula":
                        cmd.CommandText = "UPDATE AULA SET cod_aula = @val WHERE cod_aula = @em";
                        break;
                    case "num_bilhetes":
                        cmd.CommandText = "UPDATE AULA SET num_bilhetes = @val WHERE cod_aula = @em";
                        break;
                    case "preco_bilhete":
                        cmd.CommandText = "UPDATE AULA SET preco_bilhete = @val WHERE cod_aula = @em";
                        break;
                    case "data_ini":
                        cmd.CommandText = "UPDATE AULA SET data_ini = @val WHERE cod_aula = @em";
                        break;
                    case "data_fim":
                        cmd.CommandText = "UPDATE AULA SET data_fim = @val WHERE cod_aula = @em";
                        break;
                    case "modalidade":
                        cmd.CommandText = "UPDATE AULA SET modalidade = @val WHERE cod_aula = @em";
                        break;
                    case "espaco":
                        cmd.CommandText = "UPDATE AULA SET espaco = @val WHERE cod_aula = @em";
                        break;
                    case "email":
                        cmd.CommandText = "UPDATE AULA SET email = @val WHERE cod_aula = @em";
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
                
                cmd.CommandText = "DELETE FROM AULA WHERE cod_aula = @val";

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
                
                cmd.CommandText = "SELECT COUNT(cod_aula) FROM AULA WHERE cod_aula = @em";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@em", codigo);
                
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

    }

}