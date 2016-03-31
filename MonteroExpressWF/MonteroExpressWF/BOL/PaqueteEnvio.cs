﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonteroExpressWF.BOL
{
    public class PaqueteEnvio
    {
        public int IdPaqueteEnvio { get; set; }
        public Nullable<int> IdEnvio { get; set; }
        public int Cantidad { get; set; }
        public Nullable<int> IdTipoPaquete { get; set; }
        public string Descripcion { get; set; }
        public Nullable<decimal> PrecioUnitario { get; set; }
        public Nullable<decimal> PrecioTotal { get; set; }
        public EstadoPaquete EstadoPaquete { get; set; }
        public TipoPaquete TiposPaquete { get; set; }
    }
}