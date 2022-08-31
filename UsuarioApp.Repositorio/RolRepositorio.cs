﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Comun.DTO;
using UsuarioApp.Comun.Mensajes.Rol;
using UsuarioApp.IRepositorio;
using UsuarioApp.Modelo;

namespace UsuarioApp.Repositorio
{
    public class RolRepositorio : IRolRepositorio
    {
        private readonly UsuariosAppContext _context;
        private readonly IMapper _mapper;

        public RolRepositorio(Modelo.UsuariosAppContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task Grabar(RolGrabarRequerimiento requerimiento)
        {
            if (!requerimiento.Rol.IdRol.HasValue)
            {
                var rol = new Modelo.Rol()
                {
                    Nombre = requerimiento.Rol.Nombre,
                    RegistroVigente = true
                };
                await this._context.Rol.AddAsync(rol);
            }
            else
            {
                var rolBD = await this._context.Rol.FirstOrDefaultAsync(x => x.IdRol == requerimiento.Rol.IdRol);
                if (rolBD != null)
                {
                    rolBD.Nombre = requerimiento.Rol.Nombre;
                }
            }
        }

        public async Task<IEnumerable<RolDTO>> ObtenerRolesTodos()
        {
            //var listaRoles = (await this._context.Rol
            //                    .ToListAsync())
            //                 .ConvertAll(x => new RolDTO()
            //                 {
            //                     IdRol = x.IdRol,
            //                     Nombre = x.Nombre,
            //                     RegistroVigente = x.RegistroVigente
            //                 });
            var listaRoles = await this._context.Rol
                                    .ProjectTo<RolDTO>(this._mapper.ConfigurationProvider)
                                    .ToListAsync();
                        
            return listaRoles;
        }
    }
}