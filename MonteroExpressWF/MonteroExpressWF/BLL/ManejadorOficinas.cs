using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;
using MonteroExpressWF.DAL;

namespace MonteroExpressWF.BLL
{
    public class ManejadorOficinas
    {
        public static List<Oficina> ObtenerOficinasActivas() 
        {
            return ManejadorMonteroExpress.ObtenerOficinas().Where(o => o.Activo == true).ToList();            
        }
        public static List<Oficina> ObtenerOficinas()
        {
            return ManejadorMonteroExpress.ObtenerOficinas();
        }
    }
}