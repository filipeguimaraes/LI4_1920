using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using Data;
using UserDAO;
using User;
using Spaces;
using SpacesDAO;
using Classes;
using ClassesDAO;

namespace CSharpMySQL
{
    class Program
    {
        
        private UtilizadorDAO uDAO = new UtilizadorDAO();
        private AulaDAO aDAO = new AulaDAO();
        private EspacoDAO eDAO = new EspacoDAO();

        private Utilizador user = null;

        public Boolean login(string email, string password)
        {
            Boolean sucesso = false;

            if(uDAO.containsKey(email))
            {
                if(uDAO.passwordMatch(email, password)){
                    sucesso = true;
                    this.user = uDAO.get(email);
                }
            }

            Console.WriteLine(sucesso.ToString());
            return sucesso;

        }

        public void signup(string email, string nome, string genero, string morada, string telemovel, string nif, int altura, string password, DateTime dob, string perfil)
        {
            Utilizador u = new Utilizador(email, nome, genero, morada, telemovel, nif, altura, password, dob, perfil);

            if(uDAO.containsKey(email))
            {
                Console.WriteLine("JA EXISTE ESSE EMAIL REGISTADO");
            }
            else
            {
                uDAO.put(u);
                uDAO.updatePassword(u.Email);
            }
        }

        public void logout()
        {
            this.user = null;
        }
        static void Main(string[] args)
        {

            /*Program p = new Program();

            p.signup("emailFIFIFIFIFI", "fracn", "f", "rua das ruas", "91002339", "555666888", 178, "aaaa", new DateTime(2019, 10, 02), "admin");
            */

        }
    }
}
