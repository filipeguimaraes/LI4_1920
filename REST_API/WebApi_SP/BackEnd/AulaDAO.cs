using System;
using Classes;
using MySql.Data;
using MySql.Data.MySqlClient;
using Data;
using System.Collections.Generic;

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
                //cmd.CommandText = "Insert INTO AULA(num_bilhetes, preco_bilhete, data_ini, data_fim, modalidade, email, espaco) VALUES(@numBilhetes, @precoBilhete, @dataI, @dataF, @mod, @em, @codEs)";
                cmd.CommandText = "Insert INTO AULA(cod_aula,num_bilhetes, preco_bilhete, data_ini, data_fim, modalidade, email, ESPACOS_cod_espaco) VALUES((select count(*) + 1 from aula a),@numBilhetes, @precoBilhete, @dataI, @dataF, @mod, @em, @codEs)";

                cmd.Prepare();

                //cmd.Parameters.AddWithValue("@codAula", aula.CodAula);
                cmd.Parameters.AddWithValue("@numBilhetes", aula.NumBilhetes);
                cmd.Parameters.AddWithValue("@precoBilhete", aula.PrecoBilhete);
                cmd.Parameters.AddWithValue("@dataI", aula.DataINI);
                cmd.Parameters.AddWithValue("@dataF", aula.DataFIM);
                cmd.Parameters.AddWithValue("@mod", aula.Modalidade);
                cmd.Parameters.AddWithValue("@codEs", aula.CodEspaco);
                cmd.Parameters.AddWithValue("@em", aula.Email);
                
                cmd.ExecuteNonQuery();

                dbCon.Close();
            }
        }


        public List<Aula> getAulasWhere(string param, string eq, string input)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";
            Aula aula = null;
            List<Aula> aulas = new List<Aula>();

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT * FROM AULA WHERE " + param + " "+eq+" @input";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@input", input);

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    aula = new Aula(reader.GetInt32(0), reader.GetInt32(1), reader.GetFloat(2),
                                                reader.GetDateTime(3), reader.GetDateTime(4), reader.GetString(5),
                                                reader.GetString(6), reader.GetInt32(7));
                    aulas.Add(aula);
                }

                dbCon.Close();
            }

            return aulas;

        }

        public int getNumBilhetesVendidos(object codAula)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";
            int r = 0;

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT count(*) FROM AULA a, FREQUENTA f WHERE a.cod_aula = @cod AND a.cod_aula = f.cod_aula";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@cod", codAula);

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    r = reader.GetInt32(0);
                }

                dbCon.Close();
            }

            return r;

        }

        public List<Aula> getAulasByUtilizador(string email)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";
            Aula aula = null;
            List<Aula> aulas = new List<Aula>();

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT DISTINCT a.* FROM AULA a, FREQUENTA f WHERE a.cod_aula = f.cod_aula AND f.email = @email AND a.data_ini > @date";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    aula = new Aula(reader.GetInt32(0), reader.GetInt32(1), reader.GetFloat(2),
                                                reader.GetDateTime(3), reader.GetDateTime(4), reader.GetString(5),
                                                reader.GetString(6), reader.GetInt32(7));
                    aulas.Add(aula);
                }

                dbCon.Close();
            }

            return aulas;
        }


        public List<Aula> getAulasByUtilizadorNotBought(string email)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";
            Aula aula = null;
            List<Aula> aulas = new List<Aula>();

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT a.* FROM AULA a WHERE a.cod_aula not in (SELECT DISTINCT a.cod_aula FROM AULA a, FREQUENTA f WHERE a.cod_aula = f.cod_aula AND f.email = 'conta' AND a.data_ini > now()) AND a.data_ini > now()";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    aula = new Aula(reader.GetInt32(0), reader.GetInt32(1), reader.GetFloat(2),
                                                reader.GetDateTime(3), reader.GetDateTime(4), reader.GetString(5),
                                                reader.GetString(6), reader.GetInt32(7));
                    aulas.Add(aula);
                }

                dbCon.Close();
            }

            return aulas;

        }

        public Aula get(int codigo)
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
                                                reader.GetString(6), reader.GetInt32(7));
                     
                }

                dbCon.Close();
            }

            return aula;

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
                        cmd.CommandText = "UPDATE AULA SET preco_bilhete = CAST(@val AS DECIMAL(10,6)) WHERE cod_aula = @em";
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
                        cmd.CommandText = "UPDATE AULA SET ESPACOS_cod_espaco = @val WHERE cod_aula = @em";
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

        public int bilhetesAula(int codAula)
        {
            int numBilhetes = 0;

            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                
                cmd.CommandText = "SELECT num_bilhetes FROM AULA WHERE cod_aula = @em";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@em", codAula);
                
                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    numBilhetes = reader.GetInt32(0);
                }

                dbCon.Close();
            }
            
            return numBilhetes;
        } 

        public Boolean bilhetesDisponiveis(int codAula)
        {
            Boolean disponivel = false;

            int num = bilhetesAula(codAula);

            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                
                cmd.CommandText = "SELECT COUNT(cod_aula) FROM FREQUENTA WHERE cod_aula = @em";

                cmd.Connection.Open(); 

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@em", codAula);
                
                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    if(reader.GetInt32(0) < num)
                        disponivel = true;
                }

                dbCon.Close();
            }
            Console.WriteLine(disponivel.ToString());
            return disponivel;
        }

        public void deleteTicket(string email, int classId)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if (dbCon.IsConnect())
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;

                cmd.CommandText = "DELETE FROM FREQUENTA WHERE cod_aula = @classId AND email = @email";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@classId", classId);
                cmd.Parameters.AddWithValue("@email", email);

                cmd.ExecuteNonQuery();

                dbCon.Close();
            }
        }

        public void addUserToAula(int codAula, string email)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                
                cmd.CommandText = "INSERT INTO FREQUENTA VALUES(@em, @a)";

                //cmd.Connection.Open(); 

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@em", email);
                cmd.Parameters.AddWithValue("@a", codAula);
                
                cmd.ExecuteNonQuery();

                dbCon.Close();
            }
        }

    }

}