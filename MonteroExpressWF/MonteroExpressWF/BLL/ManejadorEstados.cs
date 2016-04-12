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
        public static List<Estado> ObtieneEstadosPaquetesActivos()
        {
            //Obtiene los estados de IdTipoPaquete 2 que pertenecen a los paquetes
            return ManejadorMonteroExpress.ObtieneEstadosPaquetes(2).Where(ep => ep.Activo == true).ToList();
        }

        public static List<Estado> ObtieneEstadosEnviosActivos()
        {
            //Obtiene los estados de IdTipoPaquete 2 que pertenecen a los paquetes
            return ManejadorMonteroExpress.ObtieneEstadosPaquetes(1).Where(ee => ee.Activo == true).ToList();
        }
    }
}