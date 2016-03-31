using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonteroExpressWF.BOL;

namespace MonteroExpressWF.DAL
{
    public class ManejadorMonteroExpress
    {

        #region TipoDocumento
        public static List<TipoDocumento> ObtenerTiposDocumentos()
        {

            
            return new List<TipoDocumento>();
        }
        public static TipoDocumento ObtenerTipoDocumento(int IdTipoDocumento)
        {

            //return conexion.Obtener_TiposDocumentos().Single(td => td.IdTipoDocumento == IdTipoDocumento);
            return new TipoDocumento();
        }

        #endregion
        
    }
}