using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonteroExpressWF.BOL
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public bool CambiarContrasena { get; set; }
        public Rol Rol { get; set; }
        public bool Habilitado { get; set; }
        public Nullable<DateTime> FechaIngreso { get; set; }
    }
}