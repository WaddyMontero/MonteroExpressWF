using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;
using MonteroExpressWF.DAL;

namespace MonteroExpressWF.BLL
{
    public class ManejadorEstados
    {
        public static List<Estado> ObtieneEstadosPaquetes()
        {
            //Obtiene los estados de IdTipoPaquete 2 que pertenecen a los paquetes
            return ManejadorMonteroExpress.ObtieneEstadosPaquetes(2);
        }
    }
}