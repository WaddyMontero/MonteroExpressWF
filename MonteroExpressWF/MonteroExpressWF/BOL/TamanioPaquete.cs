﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonteroExpressWF.BOL
{
    public class TamanioPaquete
    {
        public int IdTamanioPaquete { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool Activo { get; set; }
    
    }
}