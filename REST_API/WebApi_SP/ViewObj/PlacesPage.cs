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
        private string flag;
        private List<OccupiedObj> occupied;

        public List<Espaco> ToRent { get => toRent; set => toRent = value; }
        public List<Espaco> Rented { get => rented; set => rented = value; }
        public string Flag { get => flag; set => flag = value; }
        public List<OccupiedObj> Occupied { get => occupied; set => occupied = value; }

        public PlacesPage(string email, string flag)
        {
            ToRent = new EspacoDAO().getEspacosToRent(email);
            Rented = new EspacoDAO().getEspacosByUtilizador(email);
            Flag = flag;
        }

    }
}
