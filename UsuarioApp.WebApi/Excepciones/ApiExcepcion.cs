using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsuarioApp.WebApi.Excepciones
{
    public class ApiExcepcion
    {
        public ApiExcepcion(int statusCode, string mensaje, string detalles)
        {
            StatusCode = statusCode;
            Mensaje = mensaje;
            Detalles = detalles;
        }

        public int StatusCode { get; set; }
        public string Mensaje { get; set; }
        public string Detalles { get; set; }
    }
}