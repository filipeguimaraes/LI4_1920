using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_SP.ViewObj
{
    public class AuthenticationObj<T>
    {
        private string result;
        private string ssKey;
        private string ssValue;
        private string email;
        private string name;
        private T info;

        public AuthenticationObj()
        {
            this.result = null;
            this.ssKey = null;
            this.ssValue = null;
            this.email = null;
            this.Expire = null;
        }

        public AuthenticationObj(T t){
            this.result = null;
            this.ssKey = null;
            this.ssValue = null;
            this.email = null;
            this.Expire = null;
            this.info = t;
        }

        public string GetKey ()
        {
            return ssKey + ssValue;
        }

        public string Result { get => result; set => result = value; }
        public string SsKey { get => ssKey; set => ssKey = value; }
        public string SsValue { get => ssValue; set => ssValue = value; }
        public string Email { get => email; set => email = value; }
        public string Expire { get; set; }
        public T Info { get => info; set => info = value; }
        public string Name { get => name; set => name = value; }
    }
}
