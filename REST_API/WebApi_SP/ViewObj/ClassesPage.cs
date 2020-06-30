using System;
using System.Collections.Generic;
using Classes;
using ClassesDAO;


namespace ViewObj
{
    public class ClassesPage
    {
        private List<Aula> availableClasses;
        private List<Aula> nextClasses;

        public List<Aula> AvailableClasses { get => availableClasses; set => availableClasses = value; }
        public List<Aula> NextClasses { get => nextClasses; set => nextClasses = value; }

        public ClassesPage(string email)
        {
            AvailableClasses = new AulaDAO().getAulasByUtilizadorNotBought(email);
            NextClasses = new AulaDAO().getAulasByUtilizador(email);
        }

    }
}
