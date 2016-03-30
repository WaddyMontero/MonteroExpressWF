using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonteroExpressWF.DAL
{
    public class ManejadorMonteroExpress
    {
        
        public static List<TiposDocumento> ObtenerTiposDocumentos() 
        {
            MonteroExpressEntities conexion = new MonteroExpressEntities();
            return conexion.Obtener_TiposDocumentos().ToList();
        }
        public static TiposDocumento ObtenerTipoDocumento(int IdTipoDocumento)
        {
            MonteroExpressEntities conexion = new MonteroExpressEntities();
            return conexion.Obtener_TiposDocumentos().Single(td => td.IdTipoDocumento == IdTipoDocumento);
        }
    }
}