using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioApp.IRepositorio
{
    public interface IUnitOfWork
    {
        IUsuarioRepositorio UsuarioRepositorio { get; }
        IRolRepositorio RolRepositorio { get; }
        IPantallaRepositorio PantallaRepositorio { get; }
        Task<bool> Grabar();
        bool PoseeCambios();
    }
}
