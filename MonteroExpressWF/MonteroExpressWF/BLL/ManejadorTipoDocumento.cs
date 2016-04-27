using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;
using MonteroExpressWF.DAL;

namespace MonteroExpressWF.BLL
{
    public class ManejadorTipoDocumento
    {
        public static List<TipoDocumento> ObtenerTiposDocumentos(int Activo)
        {
            return ManejadorMonteroExpress.ObtenerTiposDocumentos(Activo);
        }
        public static TipoDocumento ObtenerTipoDocumentoById(int IdTipoDocumento) 
        {
            return ManejadorMonteroExpress.ObtenerTipoDocumentoById(IdTipoDocumento);
        }

        public static void InsertaTipoDocumento(TipoDocumento TipoDocumento)
        {
            ManejadorMonteroExpress.InsertaTipoDocumento(TipoDocumento);
        }

        public static void ActualizaTipoDocumento(TipoDocumento TipoDocumento)
        {
            ManejadorMonteroExpress.ActualizaTipoDocumento(TipoDocumento);
        }


    }
}