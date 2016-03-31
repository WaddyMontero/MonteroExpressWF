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
        public static List<TipoDocumento> ObtenerTiposDocumentos()
        {
            return ManejadorMonteroExpress.ObtenerTiposDocumentos();
        }
        public static TipoDocumento ObtenerTipoDocumentoById(int IdTipoDocumento) 
        {
            return ManejadorMonteroExpress.ObtenerTipoDocumentoById(IdTipoDocumento);
        }
    }
}