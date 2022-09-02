using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsuarioApp.Comun.DTO;
using UsuarioApp.Comun.Mensajes.Shared;
using UsuarioApp.IRepositorio;
using UsuarioApp.IServicios;

namespace UsuarioApp.Servicios
{
    public class ServicioPantalla : IServicioPantalla
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicioPantalla(IUnitOfWork UnitOfWork)
        {
            this._unitOfWork = UnitOfWork;
        }

        public async Task<IEnumerable<PantallaDTO>> ObtenerPantallasPorIdRol(ObtenerPorIdRequerimiento requerimiento)
        {
            return await _unitOfWork.PantallaRepositorio.ObtenerPantallasPorIdRol(requerimiento);
        }
    }
}