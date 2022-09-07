using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Comun.DTO;
using UsuarioApp.Comun.Mensajes;
using UsuarioApp.Comun.Mensajes.Rol;
using UsuarioApp.Comun.Mensajes.Shared;
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
           var validacion = string.Empty;
            if (await this._unitOfWork.RolRepositorio.VerificarNombre(new RolVerificarNombreRequerimiento() { IdRol = requerimiento.Rol.IdRol, Nombre = requerimiento.Rol.Nombre }))
            {
                validacion = "El nombre del rol ya existe en el sistema.";
            }
            else
            {
                await this._unitOfWork.RolRepositorio.Grabar(requerimiento);
                await this._unitOfWork.Grabar();
            }
            return new BaseRespuesta() 
            { 
                Exitosa = string.IsNullOrEmpty(validacion),
                Mensaje = validacion
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

        public async Task<BaseRespuesta> CambiarEstado(RolCambiarEstadoRequerimiento requerimiento)
        {
            await this._unitOfWork.RolRepositorio.CambiarEstado(requerimiento);
            await this._unitOfWork.Grabar();
            return new BaseRespuesta()
            {
                Exitosa = true
            };
        }

        public async Task<ObtenerRolPorIdRespuesta> ObtenerRolPorId(ObtenerPorIdRequerimiento requerimiento)
        {
            var rol = await this._unitOfWork.RolRepositorio.ObtenerRolPorId(requerimiento);
            return new ObtenerRolPorIdRespuesta()
            {
                Exitosa = true,
                Rol = rol
            };
        }
    }
}
