using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Collections.Specialized;
using ViewObj;
using User;
using UserDAO;
using Classes;
using ClassesDAO;
using Spaces;
using SpacesDAO;

namespace WebApi_SP.ViewObj
{
    public class ModelController
    {
        public ModelController()
        {
            var _cacheConfig = new NameValueCollection();
            this.sessionsCache = new MemoryCache("Sessions",_cacheConfig);
        }

        private MemoryCache sessionsCache;
        public MemoryCache SessionsCache { get => sessionsCache; set => sessionsCache = value; }

        

        private static ModelController _instance = null;


        public ModelController Instance()
        {
            if (_instance == null)
                _instance = new ModelController();
            return _instance;
        }


        public AuthenticationObj<Object> Login(string email, string password)
        {
            Utilizador u = new UtilizadorDAO().get(email);
            AuthenticationObj<Object> auth = new AuthenticationObj<object>();

            if (u != null && password != null && password.Equals(u.Password))
            {
                string ssKey = Guid.NewGuid().ToString();
                string ssValue = Guid.NewGuid().ToString();

                auth.Info = null;
                auth.Result = u.Perfil;
                auth.SsKey = ssKey;
                auth.SsValue = ssValue;
                auth.Email = email;
                auth.Name = u.Nome;
                DateTimeOffset d = DateTimeOffset.Now.AddMinutes(5);
                auth.Expire = d.ToUnixTimeMilliseconds().ToString();

                while (this.sessionsCache.AddOrGetExisting(auth.GetKey(), auth, d) != null)
                {
                    auth.SsKey = Guid.NewGuid().ToString();
                    auth.SsValue = Guid.NewGuid().ToString();
                    d = DateTimeOffset.Now.AddMinutes(5);
                    auth.Expire = d.ToUnixTimeMilliseconds().ToString();
                }
            }
            else
            {
                auth.Result = "invalid";
            }
            

            return auth;
        }


        public Object Authentication(string ssKey, string ssValue)
        {
            Object l = sessionsCache.Get(ssKey + ssValue);

            if (l != null)
            {
                AuthenticationObj<Object> authObj = (AuthenticationObj<Object>)l;
                DateTimeOffset d = DateTimeOffset.Now.AddMinutes(5);
                authObj.Expire = d.ToUnixTimeMilliseconds().ToString();
                sessionsCache.Set(ssKey + ssValue, l, d);

                authObj.Info = new UtilizadorDAO().get(authObj.Email);
            }

            return l;
        }


        public Object Logout(string ssKey, string ssValue)
        {
            sessionsCache.Remove(ssKey + ssValue);

            return null;
        }


        public AuthenticationObj<Object> Register(string email, string password)
        {
            UtilizadorDAO uDAO = new UtilizadorDAO();
            Utilizador u = uDAO.get(email);
            AuthenticationObj<Object> r = new AuthenticationObj<object>();

            if (u == null)
            {
                u = new Utilizador();
                u.Email = email;
                u.Nome = "Username";
                u.Password = password;
                u.Perfil = "settings";
                u.Dob = DateTime.Now;
                u.Altura = 0;
                u.Genero = "I";
                u.Telemovel = "";
                u.Morada = "";
                u.Nif = "";
                u.Creditos = 0;

                uDAO.put(u);

                r.Info = u;
                r.Email = email;
                r.Result = "login";
            }
            else
            {
                r.Result = "invalid";
            }


            return r;
        }


        public Object ChangeSettings(string ssKey, string ssValue,
            string emailSett, string passSett, string nameSett, string genderSett,
            string addrSett, string contactSett, string daySett, string monthSett,
            string yearSett, string heightSett, string weightSett)
        {
            Object l = sessionsCache.Get(ssKey + ssValue);
            AuthenticationObj<Object> authObj = (AuthenticationObj<Object>)l;


            if (authObj != null)
            {
                if (emailSett != null)
                {

                    new UtilizadorDAO().update(authObj.Email, "email", emailSett);
                    authObj.Email = emailSett;
                }
                if (passSett != null) new UtilizadorDAO().update(authObj.Email, "password", passSett);

                if (nameSett != null)
                {
                    new UtilizadorDAO().update(authObj.Email, "nome", nameSett);
                    authObj.Name = nameSett;
                }

                if (!genderSett.Equals("I")) new UtilizadorDAO().update(authObj.Email, "genero", genderSett);

                if (addrSett != null) new UtilizadorDAO().update(authObj.Email, "morada", addrSett);

                if (contactSett != null) new UtilizadorDAO().update(authObj.Email, "telemovel", contactSett);

                if (heightSett != null) new UtilizadorDAO().update(authObj.Email, "altura", heightSett);

                //if (weightSett == null) new UtilizadorDAO().update(authObj.Email, "peso", weightSett);

                if (daySett != null && monthSett != null && yearSett != null &&
                    !daySett.Equals("Day") && !monthSett.Equals("Month")  && !yearSett.Equals("Year")) 
                {
                    new UtilizadorDAO().update(authObj.Email, "DOB", yearSett + "-" + monthSett + "-" + daySett);
                }

                if (authObj.Result.Equals("settings"))
                {
                    new UtilizadorDAO().update(authObj.Email, "perfil", "user");
                    authObj.Result = "user";
                }
            }

            return authObj;
        }

        
        public Object getInstructorPage(string ssKey, string ssValue)
        {
            Object l = sessionsCache.Get(ssKey + ssValue);
            AuthenticationObj<Object> authObj = (AuthenticationObj<Object>)l;

            if (authObj != null && authObj.Result.Equals("instructor"))
            {
                DateTimeOffset d = DateTimeOffset.Now.AddMinutes(5);
                authObj.Expire = d.ToUnixTimeMilliseconds().ToString();
                sessionsCache.Set(ssKey + ssValue, l, d);


                authObj.Info = new AulaDAO().getAulasWhere("email", "=", authObj.Email);
            }
            else return null;

            return authObj;
        }


        public Object instructorAddClass(string ssKey, string ssValue, int numTicket, float priceTicket, string dateBegin,
            string dateEnd, string adress, string instructorEmail, int placeId)
        {
            Object l = sessionsCache.Get(ssKey + ssValue);
            AuthenticationObj<Object> authObj = (AuthenticationObj<Object>)l;

            if (authObj != null && authObj.Result.Equals("instructor"))
            {
                DateTimeOffset d = DateTimeOffset.Now.AddMinutes(5);
                authObj.Expire = d.ToUnixTimeMilliseconds().ToString();
                sessionsCache.Set(ssKey + ssValue, l, d);


                Aula aula = new Aula(numTicket,priceTicket,DateTime.Parse(dateBegin),DateTime.Parse(dateEnd),
                    adress,instructorEmail,placeId);
                
                if (new EspacoDAO().available(placeId, dateBegin, dateEnd) == 0)
                    new AulaDAO().put(aula);

                authObj.Info = new AulaDAO().getAulasWhere("email", "=", authObj.Email);
            }
            else return null;

            return authObj;
        }


        public object instructorDeleteClass(string ssKey, string ssValue, int classId)
        {
            Object l = sessionsCache.Get(ssKey + ssValue);
            AuthenticationObj<Object> authObj = (AuthenticationObj<Object>)l;

            if (authObj != null && authObj.Result.Equals("instructor"))
            {
                DateTimeOffset d = DateTimeOffset.Now.AddMinutes(5);
                authObj.Expire = d.ToUnixTimeMilliseconds().ToString();
                sessionsCache.Set(ssKey + ssValue, l, d);


                new AulaDAO().remove(classId);

                authObj.Info = new AulaDAO().getAulasWhere("email", "=", authObj.Email);
            }
            else return null;

            return authObj;
        }

        public Object instructorUpdateClass(string ssKey, string ssValue, int classId, int numTicket, string priceTicket, string dateBegin, string dateEnd, string modality, int placeId)
        {
            Object l = sessionsCache.Get(ssKey + ssValue);
            AuthenticationObj<Object> authObj = (AuthenticationObj<Object>)l;

            if (authObj != null && authObj.Result.Equals("instructor"))
            {
                DateTimeOffset d = DateTimeOffset.Now.AddMinutes(5);
                authObj.Expire = d.ToUnixTimeMilliseconds().ToString();
                sessionsCache.Set(ssKey + ssValue, l, d);

                new AulaDAO().update(classId, "num_bilhetes", numTicket.ToString());
                new AulaDAO().update(classId, "preco_bilhete", priceTicket);
                new AulaDAO().update(classId, "data_ini", DateTime.Parse(dateBegin).ToString("yyyy-MM-dd HH:mm:ss"));
                new AulaDAO().update(classId, "data_fim", DateTime.Parse(dateEnd).ToString("yyyy-MM-dd HH:mm:ss"));
                new AulaDAO().update(classId, "modalidade", modality);
                new AulaDAO().update(classId, "espaco", placeId.ToString());

                authObj.Info = new AulaDAO().getAulasWhere("email", "=", authObj.Email);
            }
            else return null;

            return authObj;
        }

        public Object buyClasse(string ssKey, string ssValue, int classId)
        {
            Object l = sessionsCache.Get(ssKey + ssValue);
            AuthenticationObj<Object> authObj = (AuthenticationObj<Object>)l;

            if (authObj != null && authObj.Result.Equals("user"))
            {
                DateTimeOffset d = DateTimeOffset.Now.AddMinutes(5);
                authObj.Expire = d.ToUnixTimeMilliseconds().ToString();
                sessionsCache.Set(ssKey + ssValue, l, d);

                Aula aula = new AulaDAO().get(classId);
                Utilizador utilizador = new UtilizadorDAO().get(authObj.Email);

                if (utilizador.Creditos >= aula.PrecoBilhete && aula.NumBilhetes > new AulaDAO().getNumBilhetesVendidos(aula.CodAula))
                {
                    new AulaDAO().addUserToAula(classId, authObj.Email);
                    new UtilizadorDAO().update(authObj.Email, "creditos", utilizador.Creditos-aula.PrecoBilhete);
                }

                authObj.Info = new ClassesPage(authObj.Email);
            }
            else return null;

            return authObj;
        }

        public Object getClassesPage(string ssKey, string ssValue)
        {
            Object l = sessionsCache.Get(ssKey + ssValue);
            AuthenticationObj<Object> authObj = (AuthenticationObj<Object>)l;

            if (authObj != null && authObj.Result.Equals("user"))
            {
                DateTimeOffset d = DateTimeOffset.Now.AddMinutes(5);
                authObj.Expire = d.ToUnixTimeMilliseconds().ToString();
                sessionsCache.Set(ssKey + ssValue, l, d);

                authObj.Info = new ClassesPage(authObj.Email);
            }
            else return null;

            return authObj;
        }

        public Object refundTicketClasse(string ssKey, string ssValue, int classId)
        {
            Object l = sessionsCache.Get(ssKey + ssValue);
            AuthenticationObj<Object> authObj = (AuthenticationObj<Object>)l;

            if (authObj != null && authObj.Result.Equals("user"))
            {
                DateTimeOffset d = DateTimeOffset.Now.AddMinutes(5);
                authObj.Expire = d.ToUnixTimeMilliseconds().ToString();
                sessionsCache.Set(ssKey + ssValue, l, d);

                Aula aula = new AulaDAO().get(classId);
                Utilizador utilizador = new UtilizadorDAO().get(authObj.Email);

                new AulaDAO().deleteTicket(authObj.Email,classId);

                new UtilizadorDAO().update(authObj.Email, "creditos", utilizador.Creditos + aula.PrecoBilhete);

                authObj.Info = new ClassesPage(authObj.Email);
            }
            else return null;

            return authObj;
        }


        public Object getPlacesPage(string ssKey, string ssValue)
        {
            Object l = sessionsCache.Get(ssKey + ssValue);
            AuthenticationObj<Object> authObj = (AuthenticationObj<Object>)l;

            if (authObj != null && authObj.Result.Equals("user"))
            {
                DateTimeOffset d = DateTimeOffset.Now.AddMinutes(5);
                authObj.Expire = d.ToUnixTimeMilliseconds().ToString();
                sessionsCache.Set(ssKey + ssValue, l, d);

                authObj.Info = new PlacesPage(authObj.Email,null);
            }
            else return null;

            return authObj;
        }

        public Object RentSpace(string ssKey, string ssValue, int placeId, string dateBegin, string dateEnd)
        {
            Object l = sessionsCache.Get(ssKey + ssValue);
            AuthenticationObj<Object> authObj = (AuthenticationObj<Object>)l;

            if (authObj != null && authObj.Result.Equals("user"))
            {
                DateTimeOffset d = DateTimeOffset.Now.AddMinutes(5);
                authObj.Expire = d.ToUnixTimeMilliseconds().ToString();
                sessionsCache.Set(ssKey + ssValue, l, d);

                string f = null;
                DateTime begin = DateTime.Parse(dateBegin);
                DateTime end = DateTime.Parse(dateEnd);
                Utilizador utilizador = new UtilizadorDAO().get(authObj.Email);
                Espaco espaco = new EspacoDAO().get(placeId);

                try
                {
                    double hours_rent = end.Subtract(begin).TotalHours;

                    if (new EspacoDAO().available(placeId, dateBegin, dateEnd) == 0 && utilizador.Creditos >= hours_rent * espaco.PrecoHora)
                    {
                        new EspacoDAO().rent(authObj.Email, placeId, begin, end);

                        new UtilizadorDAO().update(authObj.Email, "creditos", utilizador.Creditos - (hours_rent * espaco.PrecoHora));
                    }
                    else f = "Already rented in those dates.";
                }
                catch (Exception e) 
                { 

                }

                authObj.Info = new PlacesPage(authObj.Email,f);
                }
            else return null;

            return authObj;
        }


        public Object refundRentSpace(string ssKey, string ssValue, int placeId, string dateBegin, string dateEnd)
        {
            Object l = sessionsCache.Get(ssKey + ssValue);
            AuthenticationObj<Object> authObj = (AuthenticationObj<Object>)l;

            if (authObj != null && authObj.Result.Equals("user"))
            {
                DateTimeOffset d = DateTimeOffset.Now.AddMinutes(5);
                authObj.Expire = d.ToUnixTimeMilliseconds().ToString();
                sessionsCache.Set(ssKey + ssValue, l, d);

                DateTime begin = DateTime.Parse(dateBegin);
                DateTime end = DateTime.Parse(dateEnd);
                double hours_rent = end.Subtract(begin).TotalHours;

                new EspacoDAO().deleteReserva(authObj.Email, placeId, begin, end);

                Utilizador utilizador = new UtilizadorDAO().get(authObj.Email);
                Espaco espaco = new EspacoDAO().get(placeId);

                new UtilizadorDAO().update(authObj.Email, "creditos", utilizador.Creditos + (hours_rent * espaco.PrecoHora));

                authObj.Info = new PlacesPage(authObj.Email,null);
            }
            else return null;

            return authObj;
        }

        public Object ListOfOccupiedDates(string ssKey, string ssValue, int placeId, string date)
        {
            Object l = sessionsCache.Get(ssKey + ssValue);
            AuthenticationObj<Object> authObj = (AuthenticationObj<Object>)l;

            if (authObj != null && authObj.Result.Equals("user"))
            {
                DateTimeOffset d = DateTimeOffset.Now.AddMinutes(5);
                authObj.Expire = d.ToUnixTimeMilliseconds().ToString();
                sessionsCache.Set(ssKey + ssValue, l, d);

                DateTime day = DateTime.Parse(date);

                List<OccupiedObj> occup = new EspacoDAO().getOccupations(placeId,day);

                PlacesPage pp = new PlacesPage(authObj.Email, null);
                pp.Occupied = occup;

                authObj.Info = pp;

            }
            else return null;

            return authObj;
        }

    }
}
