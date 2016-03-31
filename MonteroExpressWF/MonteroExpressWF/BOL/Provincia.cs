using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonteroExpressWF.BOL
{
    public class Provincia
    {
        public int IdProvincia { get; set; }
        public Nullable<int> IdPais { get; set; }
        public string Nombre { get; set; }
        public string Abrev { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<bool> Activo { get; set; }

        public Pais Pais { get; set; }
    
    }
}