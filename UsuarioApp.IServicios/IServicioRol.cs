﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Comun.Mensajes;
using UsuarioApp.Comun.Mensajes.Rol;
using UsuarioApp.Comun.Mensajes.Shared;

namespace UsuarioApp.IServicios
{
    public interface IServicioRol
    {
        Task<BaseRespuesta> Grabar(RolGrabarRequerimiento requerimiento);
        Task<ObtenerRolListadoRespuesta> ObtenerRolesTodos();
        Task<BaseRespuesta> CambiarEstado(RolCambiarEstadoRequerimiento requerimiento);
        Task<ObtenerRolPorIdRespuesta> ObtenerRolPorId(Comun.Mensajes.Shared.ObtenerPorIdRequerimiento requerimiento);
        Task<RolVerificarNombreRespuesta> VerificarNombre(RolVerificarNombreRequerimiento requerimiento);
        Task<ObtenerPantallasSeleccionadasPorIdRolRespuesta> ObtenerPantallasSeleccionadasPorIdRol(ObtenerPorIdRequerimiento requerimiento);
        Task<BaseRespuesta> RolPantallasGrabar(RolPantallasGrabarRequerimiento requerimiento);
    }
}
