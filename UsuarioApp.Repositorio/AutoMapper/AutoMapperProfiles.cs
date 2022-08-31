using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuarioApp.Repositorio.AutoMapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Modelo.Rol, Comun.DTO.RolDTO>();
            CreateMap<Modelo.Pantalla, Comun.DTO.PantallaDTO>();
            CreateMap<Modelo.Usuario, Comun.DTO.UsuarioDTO>();

            CreateMap<Modelo.Usuario, Comun.Vistas.UsuarioListado>()
                    .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => src.IdRolNavigation.Nombre));
        }
    }
}
