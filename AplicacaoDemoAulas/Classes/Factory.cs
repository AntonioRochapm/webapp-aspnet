using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace AplicacaoDemoAulas.Classes
{
    public class Factory
    {
        public class Security
        {
            public static string EncodePassword(string pass_original)
            {
                var plainTextBytes = Encoding.UTF8.GetBytes(pass_original);
                return Convert.ToBase64String(plainTextBytes);
            }
            public static string DecodePassword(string pass_codificada)
            {
                var base64EncodedBytes = Convert.FromBase64String(pass_codificada);
                return Encoding.UTF8.GetString(base64EncodedBytes);
            }
        }
    }
}