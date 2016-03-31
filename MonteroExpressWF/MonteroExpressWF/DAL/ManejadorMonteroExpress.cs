using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;

namespace MonteroExpressWF.DAL
{
    public class ManejadorMonteroExpress
    {
        
        public static List<TipoDocumento> ObtenerTiposDocumentos() 
        {
           
            //return conexion.Obtener_TiposDocumentos().ToList();
            return new List<TipoDocumento>();
        }
        public static TipoDocumento ObtenerTipoDocumento(int IdTipoDocumento)
        {
            
            //return conexion.Obtener_TiposDocumentos().Single(td => td.IdTipoDocumento == IdTipoDocumento);
            return new TipoDocumento();
        }
    }
}