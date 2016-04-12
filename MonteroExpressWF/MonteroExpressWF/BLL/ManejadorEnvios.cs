using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;
using MonteroExpressWF.DAL;

namespace MonteroExpressWF.BLL
{
    public class ManejadorEnvios
    {
        public static List<Envio> ListarEnvios()
        {
            return ManejadorMonteroExpress.ListarEnvios();
        }
        public static object RegistrarEnvio(Envio Envio) 
        {
            return ManejadorMonteroExpress.RegistrarEnvio(Envio);
        }
    }
}