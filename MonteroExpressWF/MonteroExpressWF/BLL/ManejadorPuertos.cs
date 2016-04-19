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
        public static List<Puerto> ObtienePuertos(int Activo) 
        {
            return ManejadorMonteroExpress.ObtienePuertos(Activo);
        }

        public static void InsertaPuertos(Puerto Puerto)
        {
            ManejadorMonteroExpress.InsertaPuerto(Puerto);
        }

        public static void ActualizaPuertos(Puerto Puerto)
        {
            ManejadorMonteroExpress.ActualizaPuerto(Puerto);
        }
    }
}