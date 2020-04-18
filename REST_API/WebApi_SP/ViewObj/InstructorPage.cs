using System;

using User;
using UserDAO;


namespace ViewObj
{
    public class InstructorPage
    {
        public Boolean log { get; set; }

        public Utilizador infoPage { get; set;}

        public InstructorPage() { infoPage = new UtilizadorDAO().get("ola@adeus.com"); }

    }
}
