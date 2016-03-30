using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MonteroExpressWF.DAL;
using Newtonsoft.Json;
using System.Xml.Serialization;

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

        [WebMethod]
        
        public TiposDocumento ObtenerTipoDocumento(string IdTipoDocumento)
        {
            //return JsonConvert.SerializeObject(ManejadorMonteroExpress.ObtenerTipoDocumento(int.Parse(IdTipoDocumento)));
            return ManejadorMonteroExpress.ObtenerTipoDocumento(int.Parse(IdTipoDocumento));
        }
    }
}
