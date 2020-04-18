using System;
using User;
using MySql.Data;
using MySql.Data.MySqlClient;
using Data;
using System.Text;
using System.Security.Cryptography;

namespace UserDAO {

    public class UtilizadorDAO {

        private Connector db;
        public UtilizadorDAO()
        {
            this.db = new Connector();
        }

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

        // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }


        public string Hash(string password)
        {
            string hash = null;
            using (SHA1 sha1Hash = SHA1.Create())
            {
                hash = GetHash(sha1Hash, password);
            }
            return hash;
        }

        public void put(Utilizador utilizador) 
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "Insert INTO UTILIZADOR VALUES(@email, @nif, @nome, @genero, @telemovel, @dob, @altura, @password, @morada, @perfil)";
               
                cmd.Connection.Open();

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@email", utilizador.Email);
                cmd.Parameters.AddWithValue("@nif", utilizador.Nif);
                cmd.Parameters.AddWithValue("@nome", utilizador.Nome);
                cmd.Parameters.AddWithValue("@genero", utilizador.Genero);
                cmd.Parameters.AddWithValue("@telemovel", utilizador.Telemovel);
                cmd.Parameters.AddWithValue("@dob", utilizador.Dob.Date.ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("@altura", utilizador.Altura.ToString());
                //string hashada = Hash(utilizador.Password);
                cmd.Parameters.AddWithValue("@password", utilizador.Password);
                cmd.Parameters.AddWithValue("@morada", utilizador.Morada);
                cmd.Parameters.AddWithValue("@perfil", utilizador.Perfil);
                
                cmd.ExecuteNonQuery();

                dbCon.Close();
            }
        }

        public Utilizador get(string email)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";
            Utilizador utilizador = null;

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                cmd.CommandText = "SELECT * FROM UTILIZADOR WHERE email = @email";
               
                //este Open bugava ao tentar abrir apos o IsConnect (como estava antes)
                //o que dava um erro de tentar abrir um canal que já está aberto.
                //não vi mais metodos pq so estava mesmo o testar cenas elementares...
                //mas se este dá os outros também vão dar 
                //cmd.Connection.Open();

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@email", email);
                
                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    utilizador = new Utilizador(reader.GetString(0), reader.GetString(2), reader.GetString(3),
                                                reader.GetString(8), reader.GetString(4), reader.GetString(1),
                                                reader.GetInt32(6), reader.GetString(7), reader.GetDateTime(5),
                                                reader.GetString(9));
                     
                }

                

                dbCon.Close();
            }
            Console.WriteLine(utilizador.Nome);
            return utilizador;
        }

        public void updatePassword(string email)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                
                cmd.CommandText = "CALL UpdatePASS(@val)";

                cmd.Connection.Open();

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@val", email);
                
                cmd.ExecuteNonQuery();

                dbCon.Close();
            }
        }
        public void update(string email, string atributo, string valor)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;

                switch (atributo)
                {
                    case "email":
                        cmd.CommandText = "UPDATE UTILIZADOR SET email = @val WHERE email = @em";
                        break;
                    case "nif":
                        cmd.CommandText = "UPDATE UTILIZADOR SET nif = @val WHERE email = @em";
                        break;
                    case "nome":
                        cmd.CommandText = "UPDATE UTILIZADOR SET nome = @val WHERE email = @em";
                        break;
                    case "genero":
                        cmd.CommandText = "UPDATE UTILIZADOR SET genero = @val WHERE email = @em";
                        break;
                    case "telemovel":
                        cmd.CommandText = "UPDATE UTILIZADOR SET telemovel = @val WHERE email = @em";
                        break;
                    case "DOB":
                        cmd.CommandText = "UPDATE UTILIZADOR SET DOB = @val WHERE email = @em";
                        break;
                    case "altura":
                        cmd.CommandText = "UPDATE UTILIZADOR SET altura = @val WHERE email = @em";
                        break;
                    case "password":
                        cmd.CommandText = "UPDATE UTILIZADOR SET password = @val WHERE email = @em";
                        break;
                    case "morada":
                        cmd.CommandText = "UPDATE UTILIZADOR SET morada = @val WHERE email = @em";
                        break;
                    case "perfil":
                        cmd.CommandText = "UPDATE UTILIZADOR SET perfil = @val WHERE email = @em";
                        break;
                    default:
                        break;
                }
                
                //cmd.Connection.Open();

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@val", valor);
                cmd.Parameters.AddWithValue("@em", email);
                
                cmd.ExecuteNonQuery();

                dbCon.Close();
            }
        }

        public void remove(string email)
        {
            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                
                cmd.CommandText = "DELETE FROM UTILIZADOR WHERE email = @val";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@val", email);
                
                cmd.ExecuteNonQuery();

                dbCon.Close();
            }
        }

        public Boolean containsKey(string email)
        {
            Boolean existe = false;

            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                
                cmd.CommandText = "SELECT COUNT(email) FROM UTILIZADOR WHERE email = @em";

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@em", email);
                
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

        public Boolean passwordMatch(string email, string passwordInput)
        {
            Boolean match = false;

            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                
                cmd.CommandText = "SELECT password FROM UTILIZADOR WHERE email = @em";

                cmd.Connection.Open();

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@em", email);
                
                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    if(reader.GetString(0).Equals(Hash(passwordInput)));
                        match = true;
                }

                dbCon.Close();
            }
            else
            {
                Console.WriteLine("NAO HA LIGACAO");
            }
            Console.WriteLine(match.ToString());
            return match;
        }

        public Boolean comprouBilhete(int codAula, string email)
        {
           Boolean comprou = false;

            var dbCon = db.Instance();
            dbCon.DataBaseName = "sportsmanager";

            if(dbCon.IsConnect()) 
            {
                var cmd = new MySqlCommand();
                cmd.Connection = dbCon.Connection;
                
                cmd.CommandText = "SELECT COUNT(email) FROM FREQUENTA WHERE email = @em AND cod_aula = @a";

                cmd.Connection.Open();

                cmd.Prepare();

                cmd.Parameters.AddWithValue("@em", email);
                cmd.Parameters.AddWithValue("@a", codAula);
                
                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    if(reader.GetInt32(0) > 1);
                        comprou = true;
                }

                dbCon.Close();
            }
            Console.WriteLine(comprou.ToString());
            return comprou;
        }
    }

}