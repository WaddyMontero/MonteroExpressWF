using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MonteroExpressWF.BOL;
using MonteroExpressWF.DAL;

namespace MonteroExpressWF.BLL
{
    public class ManejadorGeografico
    {
        public static List<Pais> ObtenerPaises()
        {
            return ManejadorMonteroExpress.ObtenerPaises();
        }

        public static List<Provincia> ObtenerProvincias(int IdPais)
        {
            return ManejadorMonteroExpress.ObtenerProvincias(IdPais);
        }

        public static List<Ciudad> ObtenerCiudades(int IdProvincia)
        {
            return ManejadorMonteroExpress.ObtenerCiudades(IdProvincia);
        }
    }
}