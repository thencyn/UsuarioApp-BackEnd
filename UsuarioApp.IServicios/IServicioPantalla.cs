using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioApp.Comun.DTO;
using UsuarioApp.Comun.Mensajes.Shared;

namespace UsuarioApp.IServicios
{
    public interface IServicioPantalla
    {
        Task<IEnumerable<PantallaDTO>> ObtenerPantallasPorIdRol(ObtenerPorIdRequerimiento requerimiento);
    }
}