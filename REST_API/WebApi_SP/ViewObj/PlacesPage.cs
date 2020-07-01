using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spaces;
using SpacesDAO;

namespace WebApi_SP.ViewObj
{
    public class PlacesPage
    {
        private List<Espaco> availableClasses;
        private List<Espaco> nextClasses;

        public List<Espaco> AvailableClasses { get => availableClasses; set => availableClasses = value; }
        public List<Espaco> NextClasses { get => nextClasses; set => nextClasses = value; }

        public PlacesPage(string email)
        {
            //AvailableClasses = new SpacesDAO().getAulasByUtilizadorNotBought(email);
            //NextClasses = new SpacesDAO().getAulasByUtilizador(email);
        }

    }
}
