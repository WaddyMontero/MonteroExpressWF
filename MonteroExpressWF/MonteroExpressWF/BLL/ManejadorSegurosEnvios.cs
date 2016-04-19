using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;
using MonteroExpressWF.DAL;

namespace MonteroExpressWF.BLL
{
    public class ManejadorSegurosEnvios
    {
        public static List<SeguroEnvio> ObtenerSegurosEnvios(int Activo) 
        {
            return ManejadorMonteroExpress.ObtenerSegurosEnvios(Activo);
        }

        public static void InsertaSeguroEnvio(SeguroEnvio SeguroEnvio)
        {
            ManejadorMonteroExpress.InsertaSeguroEnvio(SeguroEnvio);
        }

        public static void ActualizaSeguroEnvio(SeguroEnvio SeguroEnvio)
        {
            ManejadorMonteroExpress.ActualizaSeguroEnvio(SeguroEnvio);
        }
    }
}