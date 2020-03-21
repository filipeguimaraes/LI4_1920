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
        static void Main(string[] args)
        {
            // APENAS PARA TESTE
            UtilizadorDAO dao = new UtilizadorDAO();
            
            dao.containsKey("emailMEU");

        }
    }
}
