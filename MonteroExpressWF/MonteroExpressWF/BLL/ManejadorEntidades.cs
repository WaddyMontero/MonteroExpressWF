using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;
using MonteroExpressWF.DAL;

namespace MonteroExpressWF.BLL
{
    public class ManejadorEntidades
    {
        public static Entidad BuscarEntidad(string NumDocumento) 
        {
            return ManejadorMonteroExpress.BuscarEntidad(NumDocumento);
        }

        public static List<Entidad> ListarEntidades()
        {
            return ManejadorMonteroExpress.ListarEntidades();
        }

    }
}