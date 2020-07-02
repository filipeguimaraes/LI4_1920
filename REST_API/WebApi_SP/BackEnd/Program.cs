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

        public void comprarBilhete(int codAula, string userEmail)
        {
            lock (this)
            {
                if (aDAO.bilhetesDisponiveis(codAula) && !uDAO.comprouBilhete(codAula, userEmail))
                {
                    aDAO.addUserToAula(codAula, userEmail);
                }
                else
                {
                    Console.WriteLine("JA COMPROU BILHETE");
                }
            }
        }

        public void newSpace(string tipo, int lotacao, string local, float preco, int area, DateTime ini, DateTime fim)
        {
            Espaco e = new Espaco(tipo, lotacao, local, preco, area, ini, fim,0,0);

            lock(this)
            {
                eDAO.put(e);
            }
        }

        public void newEvent(int numBilhetes, float precoBilhete, DateTime dataIni, DateTime dataFim, string modalidade, int espaco)
        {
            Aula a = new Aula(numBilhetes, precoBilhete, dataIni, dataFim, modalidade, this.user.Email, espaco);

            lock(this)
            {
                if(eDAO.spaceAvailable(espaco, dataIni, dataFim))
                {
                    aDAO.put(a);
                    eDAO.rent(this.user.Email, espaco, dataIni, dataFim);
                }
            }
        }

        public void rentSpace(int espaco, DateTime dataIni, DateTime dataFim)
        {
            lock(this)
            {
                if (eDAO.spaceAvailable(espaco, dataIni, dataFim))
                {
                    eDAO.rent(this.user.Email, espaco, dataIni, dataFim);
                }
            }
        }

        public void mudarLotacao(int espaco, int novaLotacao)
        {
            eDAO.update(espaco, "lotacao", (int)novaLotacao);
        }

        public void alterarReserva(int reserva, int espaco, string tipo, DateTime novaData)
        {
            switch(tipo)
            {
                case "inicio":
                    if (eDAO.canChangeDate(espaco, "data_ini", novaData))
                    {
                        eDAO.updateReserva(reserva, "data_ini", novaData);
                    }
                    break;
                case "fim":
                    if (eDAO.canChangeDate(espaco, "data_fim", novaData))
                    {
                        eDAO.updateReserva(reserva, "data_fim", novaData);
                    }
                    break;
            }
        }

        public void cancelarReserva(int reserva)
        {
            //eDAO.deleteReserva(reserva);
        }

        public void deleteUser()
        {
            uDAO.remove(this.user.Email);
            logout();
        }

        /*
        static void Main(string[] args)
        {

            Program p = new Program();

            p.comprarBilhete(1, "emailNOVOKIKONOVO");
            

        }
        */
    }
}
