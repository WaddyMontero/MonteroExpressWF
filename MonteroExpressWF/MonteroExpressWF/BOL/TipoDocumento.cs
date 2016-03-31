using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonteroExpressWF.BOL
{
    public class TipoDocumento
    {
        public int IdTipoDocumento { get; set; }
        public string Descripcion { get; set; }
        public string Mascara { get; set; }
        public Nullable<System.DateTime> FechaIngreso { get; set; }
        public Nullable<bool> Activo { get; set; }
    }
}