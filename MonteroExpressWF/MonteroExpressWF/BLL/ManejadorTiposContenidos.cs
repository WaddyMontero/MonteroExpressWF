using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;
using MonteroExpressWF.DAL;

namespace MonteroExpressWF.BLL
{
    public class ManejadorTiposContenidos
    {
        public static List<TipoContenido> ObtenerTiposContenidos() 
        {
            return ManejadorMonteroExpress.ObtenerTiposContenidos();
        }
    }
}