using System;

namespace User {

    public class Utilizador {

        private string email;
        private string nome;
        private string genero;
        private string morada;
        private string telemovel;
        private string nif;
        private int altura;
        private string password;
        private DateTime dob;
        private string perfil;

        public Utilizador()
        {
        }

        public Utilizador(string email, string nome, string genero, string morada, string telemovel, string nif, int altura, string password, DateTime dob, string perfil)
        {
            this.Email = email;
            this.Nome = nome;
            this.Genero = genero;
            this.Morada = morada;
            this.Telemovel = telemovel;
            this.Nif = nif;
            this.Altura = altura;
            this.Password = password;
            Dob = dob;
            this.Perfil = perfil;
        }

        public string Email { get => email; set => email = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Morada { get => morada; set => morada = value; }
        public string Telemovel { get => telemovel; set => telemovel = value; }
        public string Nif { get => nif; set => nif = value; }
        public int Altura { get => altura; set => altura = value; }
        public string Password { get => password; set => password = value; }
        public DateTime Dob { get => dob; set => dob = value; }
        public string Perfil { get => perfil; set => perfil = value; }

        public override bool Equals(object obj)
        {
            return obj is Utilizador utilizador &&
                   email == utilizador.email &&
                   nome == utilizador.nome &&
                   genero == utilizador.genero &&
                   morada == utilizador.morada &&
                   telemovel == utilizador.telemovel &&
                   nif == utilizador.nif &&
                   altura == utilizador.altura &&
                   password == utilizador.password &&
                   dob == utilizador.dob &&
                   perfil == utilizador.perfil &&
                   Email == utilizador.Email &&
                   Nome == utilizador.Nome &&
                   Genero == utilizador.Genero &&
                   Morada == utilizador.Morada &&
                   Telemovel == utilizador.Telemovel &&
                   Nif == utilizador.Nif &&
                   Altura == utilizador.Altura &&
                   Password == utilizador.Password &&
                   Dob == utilizador.Dob &&
                   Perfil == utilizador.Perfil;
        }
    }

}