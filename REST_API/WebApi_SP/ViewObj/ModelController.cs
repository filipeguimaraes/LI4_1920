using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Caching;
using System.Collections.Specialized;
using ViewObj;

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
            string ssKey = Guid.NewGuid().ToString();
            string ssValue = Guid.NewGuid().ToString();

            AuthenticationObj<Object> auth = new AuthenticationObj<Object>(this.sessionsCache.GetCount());
            auth.Result = email;
            auth.SsKey = ssKey;
            auth.SsValue = ssValue;
            auth.Email = password;
            DateTimeOffset d = DateTimeOffset.Now.AddSeconds(15);
            auth.Expire = d.ToUnixTimeMilliseconds().ToString();

            while (this.sessionsCache.AddOrGetExisting(auth.GetKey(), auth, d) != null) {
                auth.SsKey = Guid.NewGuid().ToString();
                auth.SsValue = Guid.NewGuid().ToString();
                d = DateTimeOffset.Now.AddSeconds(15);
                auth.Expire = d.ToUnixTimeMilliseconds().ToString();
            }

            return auth;
        }

        public Object Authentication(string ssKey, string ssValue)
        {
            Object l = sessionsCache.Remove(ssKey + ssValue);
            if (l != null) {
                AuthenticationObj<Object> authObj = (AuthenticationObj<Object>) l;
                DateTimeOffset d = DateTimeOffset.Now.AddSeconds(15);
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
    }
}
