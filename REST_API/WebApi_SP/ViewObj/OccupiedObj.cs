using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_SP.ViewObj
{
    public class OccupiedObj
    {
        private int placeId;
        private DateTime dateBegin;
        private DateTime dateEnd;

        public int PlaceId { get => placeId; set => placeId = value; }
        public DateTime DateBegin { get => dateBegin; set => dateBegin = value; }
        public DateTime DateEnd { get => dateEnd; set => dateEnd = value; }

        public OccupiedObj (int id, DateTime begin, DateTime end)
        {
            PlaceId = id;
            DateBegin = begin;
            DateEnd = end;
        }
    }
}
