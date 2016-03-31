﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonteroExpressWF.BOL
{
    public class Entidad
    {
        public int IdEntidad { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> IdTipoDocumento { get; set; }
        public string NumDocumento { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public Nullable<bool> Activo { get; set; }

        public List<EntidadDireccion> EntidadDirecciones { get; set; }
        public TipoDocumento TiposDocumento { get; set; }
    }
}