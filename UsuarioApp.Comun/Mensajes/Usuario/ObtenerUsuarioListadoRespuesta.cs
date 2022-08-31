using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Comun.DTO;
using UsuarioApp.Comun.Vistas;

namespace UsuarioApp.Comun.Mensajes.Usuario
{
    public class ObtenerUsuarioListadoRespuesta : BaseRespuesta
    {
        public IEnumerable<UsuarioListado> ListaUsuarios { get; set; }
    }
}
