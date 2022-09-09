using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Comun.DTO;
using UsuarioApp.Comun.Mensajes;
using UsuarioApp.Comun.Mensajes.Shared;
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
            var usuario = await this._unitOfWork.UsuarioRepositorio.ObtenerUsuarioPorCorreo(new ObtenerUsuarioPorCorreoRequerimiento(){ Correo = requerimiento.Correo });
            if (usuario == null)
            {
                await this._unitOfWork.UsuarioRepositorio.Agregar(requerimiento);
                await this._unitOfWork.Grabar();
                return new BaseRespuesta()
                {
                    Exitosa = true,
                };
            }
            else
            {
                return new BaseRespuesta()
                {
                    Exitosa = false,
                    Mensaje = "El correo ingresado ya existe en el sistema."
                };
            }
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
    
        public async Task<UsuarioDTO> Login(string usuario, string password)
        {
            return await this._unitOfWork.UsuarioRepositorio.Login(usuario, password);
        }

        public async Task<BaseRespuesta> Modificar(UsuarioModificarRequerimiento requerimiento)
        {
            var usuarioPorCorreo = await this._unitOfWork.UsuarioRepositorio.VerificarCorreo(new UsuarioVerificarCorreoRequerimiento(){ Correo = requerimiento.Correo, IdUsuario = requerimiento.IdUsuario });
            var usuario = await this._unitOfWork.UsuarioRepositorio.ObtenerUsuarioPorId(new ObtenerPorIdRequerimiento(){ Id = requerimiento.IdUsuario });

            if (usuarioPorCorreo)
            {
                return new BaseRespuesta()
                {
                    Exitosa = false,
                    Mensaje = "El correo ya existe en otro usuario."
                };
            }
            else if (usuario == null)
            {
                return new BaseRespuesta()
                {
                    Exitosa = false,
                    Mensaje = "El IdUsuario no existe."
                };
            }
            else
            {
                await this._unitOfWork.UsuarioRepositorio.Modificar(requerimiento);
                await this._unitOfWork.Grabar();
                return new BaseRespuesta()
                {
                    Exitosa = true
                };
            }
        }

        public async Task<BaseRespuesta> CambiarEstado(UsuarioCambiarEstadoRequerimiento requerimiento)
        {
            var usuario = await this._unitOfWork.UsuarioRepositorio.ObtenerUsuarioPorId(new ObtenerPorIdRequerimiento(){ Id = requerimiento.IdUsuario });
            if (usuario != null)
            {
                await this._unitOfWork.UsuarioRepositorio.CambiarEstado(requerimiento);
                await this._unitOfWork.Grabar();
                return new BaseRespuesta()
                {
                    Exitosa = true
                };
            }
            else
            {
                return new BaseRespuesta()
                {
                    Exitosa = false,
                    Mensaje = "El IdUsuario no existe."
                };
            }
        }

        public async Task<BaseRespuesta> CambiarPassword(UsuarioCambiarPasswordRequerimiento requerimiento)
        {
            var usuario = await this._unitOfWork.UsuarioRepositorio.ObtenerUsuarioPorId(new ObtenerPorIdRequerimiento(){ Id = requerimiento.IdUsuario });
            if (usuario != null)
            {
                await this._unitOfWork.UsuarioRepositorio.CambiarPassword(requerimiento);
                await this._unitOfWork.Grabar();
                return new BaseRespuesta()
                {
                    Exitosa = true
                };
            }
            else
            {
                return new BaseRespuesta()
                {
                    Exitosa = false,
                    Mensaje = "El IdUsuario no existe."
                };
            }
        }

        public async Task<UsuarioVerificarCorreoRespuesta> VerificarCorreo(UsuarioVerificarCorreoRequerimiento requerimiento)
        {
            var verificacion = await this._unitOfWork.UsuarioRepositorio.VerificarCorreo(requerimiento);                
            return new UsuarioVerificarCorreoRespuesta()
            {
                Exitosa = true,
                ExisteCorreo = verificacion
            };
        }

        public async Task<ObtenerUsuarioRespuesta> ObtenerUsuarioPorId(ObtenerPorIdRequerimiento requerimiento)
        {
            var usuario = await this._unitOfWork.UsuarioRepositorio.ObtenerUsuarioPorId(requerimiento);
            if (usuario != null)
            {
                return new ObtenerUsuarioRespuesta()
                {
                    Exitosa = true,
                    Usuario = usuario
                };
            }
            else
            {
                return new ObtenerUsuarioRespuesta()
                {
                    Exitosa = false,
                    Mensaje = "El usuario no existe."
                };
            }
        }
    }
}
