using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioApp.Comun.DTO;

namespace UsuarioApp.WebApi.JWT
{
    public class LoginRespuesta
    {
        public string Token { get; set; }
        public IEnumerable<PantallaDTO> MenuUsuario { get; set; }
    }
}