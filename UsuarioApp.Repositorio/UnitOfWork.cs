using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.IRepositorio;
using UsuarioApp.Modelo;

namespace UsuarioApp.Repositorio
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UsuariosAppContext _context;
        private readonly IMapper _mapper;

        public UnitOfWork(Modelo.UsuariosAppContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public IUsuarioRepositorio UsuarioRepositorio => new UsuarioRepositorio(this._context, this._mapper);

        public IRolRepositorio RolRepositorio => new RolRepositorio(this._context, this._mapper);
        public IPantallaRepositorio PantallaRepositorio  => new PantallaRepositorio (this._context, this._mapper);

        public async Task<bool> Grabar()
        {
            return await this._context.SaveChangesAsync() > 1;
        }

        public bool PoseeCambios()
        {
            return this._context.ChangeTracker.HasChanges();
        }
    }
}
