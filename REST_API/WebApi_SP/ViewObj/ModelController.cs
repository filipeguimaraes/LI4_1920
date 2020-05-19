using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Collections.Specialized;
using ViewObj;
using User;
using UserDAO;

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

                auth.Info = this.sessionsCache.GetCount();
                auth.Result = u.Perfil;
                auth.SsKey = ssKey;
                auth.SsValue = ssValue;
                auth.Email = email;
                DateTimeOffset d = DateTimeOffset.Now.AddSeconds(30);
                auth.Expire = d.ToUnixTimeMilliseconds().ToString();

                while (this.sessionsCache.AddOrGetExisting(auth.GetKey(), auth, d) != null)
                {
                    auth.SsKey = Guid.NewGuid().ToString();
                    auth.SsValue = Guid.NewGuid().ToString();
                    d = DateTimeOffset.Now.AddSeconds(30);
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
            Object l = sessionsCache.Remove(ssKey + ssValue);
            if (l != null) {
                AuthenticationObj<Object> authObj = (AuthenticationObj<Object>) l;
                DateTimeOffset d = DateTimeOffset.Now.AddSeconds(30);
                authObj.Expire = d.ToUnixTimeMilliseconds().ToString();
                sessionsCache.Set(ssKey + ssValue,l,d);
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
                authObj.Result = "user";
            }

            return authObj;
        }

    }
}
