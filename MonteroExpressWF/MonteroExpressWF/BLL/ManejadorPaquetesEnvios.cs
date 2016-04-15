using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;
using MonteroExpressWF.DAL;

namespace MonteroExpressWF.BLL
{
    public class ManejadorPaquetesEnvios
    {
        public static List<PaqueteEnvio> ObtenerPaquetesPorEnvio(int IdEnvio)
        {
            return ManejadorMonteroExpress.ObtenerPaquetesPorEnvio(IdEnvio);
        }
    }
}