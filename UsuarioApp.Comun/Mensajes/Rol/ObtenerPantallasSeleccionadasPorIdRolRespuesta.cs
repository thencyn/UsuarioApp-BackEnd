using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioApp.Comun.DTO;

namespace UsuarioApp.Comun.Mensajes.Rol
{
    public class ObtenerPantallasSeleccionadasPorIdRolRespuesta : BaseRespuesta
    {
         public IEnumerable<PantallaDTO> ListaPantallas { get; set; }
        public IEnumerable<int> ListaPantallasSeleccionadas { get; set; }
    }
}