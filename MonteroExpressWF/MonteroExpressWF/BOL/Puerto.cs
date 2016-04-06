using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonteroExpressWF.BOL
{
    public class Puerto
    {
        public int IdPuerto { get; set; }
        public string Nombre { get; set; }

        public string Abrev { get; set; }

        public DateTime FechaIngreso { get; set; }

        public bool Activo { get; set; }

        public int IdUsuario { get; set; }
    }
}