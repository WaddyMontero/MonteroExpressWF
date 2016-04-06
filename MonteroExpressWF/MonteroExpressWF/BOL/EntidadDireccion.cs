using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonteroExpressWF.BOL
{
    public class EntidadDireccion
    {
        public int IdEntidadDireccion { get; set; }
        public int IdEntidad { get; set; }
        public string Direccion { get; set; }
        public int IdCiudad { get; set; }
        public Ciudad Ciudad { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public bool PorDefecto { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Activo { get; set; }

    }
}