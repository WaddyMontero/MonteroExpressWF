using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MonteroExpressWF.BLL;
using MonteroExpressWF.BOL;

namespace MonteroExpressWF.WebServices
{
    /// <summary>
    /// Summary description for MonteroExpressWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class MonteroExpressWS : System.Web.Services.WebService
    {

        #region TiposDocumentos
        [WebMethod]
        public TipoDocumento ObtenerTipoDocumento(int IdTipoDocumento)
        {
            //return JsonConvert.SerializeObject(ManejadorMonteroExpress.ObtenerTipoDocumento(int.Parse(IdTipoDocumento)));
            return ManejadorTipoDocumento.ObtenerTipoDocumentoById(IdTipoDocumento);
        }
        #endregion

        #region DireccionesEntidad
        [WebMethod]
        public List<EntidadDireccion> ObtenerEntidadDirecciones(string NumDocumento)
        {
            //return JsonConvert.SerializeObject(ManejadorMonteroExpress.ObtenerTipoDocumento(int.Parse(IdTipoDocumento)));
            return ManejadorTipoDocumento.ObtenerTipoDocumentoById(IdTipoDocumento);
        }

        #endregion
    }
}
