using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Comun.DTO;
using UsuarioApp.Comun.Mensajes.Shared;
using UsuarioApp.Comun.Mensajes.Usuario;
using UsuarioApp.Comun.Vistas;
using UsuarioApp.IRepositorio;
using UsuarioApp.Modelo;

namespace UsuarioApp.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly UsuariosAppContext _context;
        private readonly IMapper _mapper;

        public UsuarioRepositorio(Modelo.UsuariosAppContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task Agregar(UsuarioCrearRequerimiento requerimiento)
        {
            var hmac = new HMACSHA512();
            var usuario = new Modelo.Usuario()
            {
                IdRol = requerimiento.IdRol,
                Correo = requerimiento.Correo,
                Nombre = requerimiento.Nombre,
                FechaCreacion = DateTime.Now,
                RegistroVigente = true,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(requerimiento.Password)),
                PasswordSalt = hmac.Key
            };
            await this._context.Usuario.AddAsync(usuario);
        }

        public async Task<IEnumerable<UsuarioListado>> ObtenerUsuariosTodos()
        {
            var listaUsuarios = await this._context.Usuario
                                          .ProjectTo<UsuarioListado>(this._mapper.ConfigurationProvider)
                                          .ToListAsync();
            return listaUsuarios;
        }

        public async Task<UsuarioDTO> Login(string usuario, string password)
        {
            var usuarioDto = await _context.Usuario
                .Where(x => x.Correo == usuario && x.RegistroVigente)
                .ProjectTo<UsuarioDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            if (usuarioDto != null)
            {
                var hmac = new HMACSHA512(usuarioDto.PasswordSalt);
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                if (!usuarioDto.PasswordHash.SequenceEqual(passwordHash))
                {
                    return null;
                }                
            }
            return usuarioDto;
        }

        public async Task Modificar(UsuarioModificarRequerimiento requerimiento)
        {
            var usuario = await this._context.Usuario.FirstOrDefaultAsync(x => x.IdUsuario == requerimiento.IdUsuario);
            if (usuario != null)
            {
                usuario.Nombre = requerimiento.Nombre;
                usuario.Correo = requerimiento.Correo;
                usuario.IdRol = requerimiento.IdRol;
            }
        }

        public async Task CambiarEstado(UsuarioCambiarEstadoRequerimiento requerimiento)
        {
            var usuario = await this._context.Usuario.FirstOrDefaultAsync(x => x.IdUsuario == requerimiento.IdUsuario);
            if (usuario != null)
            {                
                usuario.RegistroVigente = !usuario.RegistroVigente;
            }
        }

        public async Task CambiarPassword(UsuarioCambiarPasswordRequerimiento requerimiento)
        {
            var usuario = await this._context.Usuario.FirstOrDefaultAsync(x => x.IdUsuario == requerimiento.IdUsuario);
            if (usuario != null)
            {
                var hmac = new HMACSHA512();
                usuario.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(requerimiento.Password));
                usuario.PasswordSalt = hmac.Key;
            }
        }

        public async Task<bool> VerificarPassword(UsuarioCambiarPasswordRequerimiento requerimiento)
        {
            var passwordVerificada = false;
            var usuario = await this._context.Usuario.FirstOrDefaultAsync(x => x.IdUsuario == requerimiento.IdUsuario);
            if (usuario != null)
            {
                var hmac = new HMACSHA512(usuario.PasswordSalt);
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(requerimiento.Password));
                return usuario.PasswordHash.SequenceEqual(passwordHash);
            }
            return passwordVerificada;
        }

        public async Task<bool> VerificarCorreo(UsuarioVerificarCorreoRequerimiento requerimiento)
        {
            return await this._context.Usuario.AnyAsync(x => x.Correo == requerimiento.Correo && (!requerimiento.IdUsuario.HasValue || x.IdUsuario != requerimiento.IdUsuario));
        }

        public async Task<UsuarioDTO> ObtenerUsuarioPorId(ObtenerPorIdRequerimiento requerimiento)
        {
            return await _context.Usuario
                .Where(x => x.IdUsuario == requerimiento.Id)
                .ProjectTo<UsuarioDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task<UsuarioDTO> ObtenerUsuarioPorCorreo(ObtenerUsuarioPorCorreoRequerimiento requerimiento)
        {
             return await _context.Usuario
                .ProjectTo<UsuarioDTO>(_mapper.ConfigurationProvider)
                .Where(x => x.Correo == requerimiento.Correo)
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
