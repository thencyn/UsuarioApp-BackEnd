using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using UsuarioApp.Comun.DTO;
using UsuarioApp.Comun.Mensajes.Shared;
using UsuarioApp.IRepositorio;

namespace UsuarioApp.Repositorio
{
    public class PantallaRepositorio : IPantallaRepositorio
    {
        private readonly Modelo.UsuariosAppContext _context;
        private readonly IMapper _mapper;
        public PantallaRepositorio(Modelo.UsuariosAppContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<PantallaDTO>> ObtenerPantallasPorIdRol(ObtenerPorIdRequerimiento requerimiento)
        {
            return await _context.RolPantalla
                .Where(x => x.IdRol == requerimiento.Id)
                .Select(x => x.IdPantallaNavigation)
                .ProjectTo<PantallaDTO>(_mapper.ConfigurationProvider)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}