using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonteroExpressWF.BOL
{
    public class Ciudad
    {
        public int IdCiudad { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Activo { get; set; }

        public  Provincia Provincia { get; set; }

    }
}