﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;
using MonteroExpressWF.DAL;

namespace MonteroExpressWF.BLL
{
    public class ManejadorSegurosEnvios
    {
        public static List<SeguroEnvio> ObtenerSegurosEnvios() 
        {
            return ManejadorMonteroExpress.ObtenerSegurosEnvios();
        }
    }
}