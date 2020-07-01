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
        private List<Espaco> toRent;
        private List<Espaco> rented;

        public List<Espaco> ToRent { get => toRent; set => toRent = value; }
        public List<Espaco> Rented { get => rented; set => rented = value; }

        public PlacesPage(string email)
        {
            ToRent = new EspacoDAO().getEspacosToRent(email);
            Rented = new EspacoDAO().getEspacosByUtilizador(email);
        }

    }
}
