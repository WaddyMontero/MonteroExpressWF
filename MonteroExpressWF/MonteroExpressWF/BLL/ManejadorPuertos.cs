using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;
using MonteroExpressWF.DAL;

namespace MonteroExpressWF.BLL
{
    public class ManejadorPuertos
    {
        public static List<Puerto> ObtienePuertos(bool SoloActivos) 
        {
            if (SoloActivos)
            {
                return ManejadorMonteroExpress.ObtienePuertos().Where(p => p.Activo = SoloActivos).ToList();
            }
            else
            {
                return ManejadorMonteroExpress.ObtienePuertos();
            }
        }
    }
}