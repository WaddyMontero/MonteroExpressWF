using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;
using MonteroExpressWF.DAL;

namespace MonteroExpressWF.BLL
{
    public class ManejadorTiposContenidos
    {
        public static List<TipoContenido> ObtenerTiposContenidos(int Activo) 
        {
            return ManejadorMonteroExpress.ObtenerTiposContenidos(Activo);
        }

        public static void InsertaTipoContenido(TipoContenido TipoContenido)
        {
            ManejadorMonteroExpress.InsertaTipoContenido(TipoContenido);
        }

        public static void ActualizaTipoContenido(TipoContenido TipoContenido)
        {
            ManejadorMonteroExpress.ActualizaTipoContenido(TipoContenido);
        }
    }
}