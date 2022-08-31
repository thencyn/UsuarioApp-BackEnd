using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Comun.Mensajes;
using UsuarioApp.Comun.Mensajes.Usuario;
using UsuarioApp.Comun.Vistas;
using UsuarioApp.IRepositorio;
using UsuarioApp.IServicios;
using UsuarioApp.Modelo;

namespace UsuarioApp.Servicios
{
    public class ServicioUsuario : IServicioUsuario
    {
        private readonly IUnitOfWork _unitOfWork;

        public ServicioUsuario(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<BaseRespuesta> Agregar(UsuarioCrearRequerimiento requerimiento)
        {
            await this._unitOfWork.UsuarioRepositorio.Agregar(requerimiento);
            await this._unitOfWork.Grabar();
            return new BaseRespuesta()
            {
                Exitosa = true
            };
        }

        public async Task<ObtenerUsuarioListadoRespuesta> ObtenerUsuariosTodos()
        {
            var listaUsuarios = await this._unitOfWork.UsuarioRepositorio.ObtenerUsuariosTodos();
            return new ObtenerUsuarioListadoRespuesta()
            {
                Exitosa = true,
                ListaUsuarios = listaUsuarios
            };
        }
    }
}
