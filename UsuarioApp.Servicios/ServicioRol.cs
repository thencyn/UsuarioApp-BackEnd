using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Comun.DTO;
using UsuarioApp.Comun.Mensajes;
using UsuarioApp.Comun.Mensajes.Rol;
using UsuarioApp.IRepositorio;
using UsuarioApp.IServicios;
using UsuarioApp.Modelo;
using UsuarioApp.Repositorio;

namespace UsuarioApp.Servicios
{
    public class ServicioRol : IServicioRol
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicioRol(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<BaseRespuesta> Grabar(RolGrabarRequerimiento requerimiento)
        {
            await this._unitOfWork.RolRepositorio.Grabar(requerimiento);
            await this._unitOfWork.Grabar();
            return new BaseRespuesta()
            {
                Exitosa = true
            };
        }

        public async Task<ObtenerRolListadoRespuesta> ObtenerRolesTodos()
        {
            var listaRoles = await this._unitOfWork.RolRepositorio.ObtenerRolesTodos();
            return new ObtenerRolListadoRespuesta()
            {
                Exitosa = true,
                ListaRoles = listaRoles
            };
        }
    }
}
