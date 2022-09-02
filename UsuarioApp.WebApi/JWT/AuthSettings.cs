using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioApp.WebApi.JWT
{
    public class AuthSettings
    {
        public string SecretKey { get; set; }
        public int Minutes { get; set; }
    }
}