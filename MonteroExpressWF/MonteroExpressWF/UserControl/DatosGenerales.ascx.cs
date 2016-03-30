using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MonteroExpressWF.DAL;

namespace MonteroExpressWF.UserControl
{
    public partial class DatosGenerales : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ddlTipoDocumento.DataSource = ManejadorMonteroExpress.ObtenerTiposDocumentos();
            ddlTipoDocumento.DataTextField = "Descripcion";
            ddlTipoDocumento.DataValueField = "IdTipoDocumento";
            ddlTipoDocumento.DataBind();
        }
    }
}