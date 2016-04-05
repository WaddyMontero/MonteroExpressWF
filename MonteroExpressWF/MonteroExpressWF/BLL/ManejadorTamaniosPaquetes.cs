using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;
using MonteroExpressWF.DAL;

namespace MonteroExpressWF.BLL
{
    public class ManejadorTamaniosPaquetes
    {
        public static List<TamanioPaquete> ObtieneTamaniosPaquetes() 
        {
            return ManejadorMonteroExpress.ObtieneTamaniosPaquetes();
        }
    }
}