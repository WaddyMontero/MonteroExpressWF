using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MonteroExpressWF.BLL;

namespace MonteroExpressWF.UserControl
{
    public partial class DatosGenerales : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlTipoDocumento.DataSource = ManejadorTipoDocumento.ObtenerTiposDocumentos(1);
                ddlTipoDocumento.DataTextField = "Descripcion";
                ddlTipoDocumento.DataValueField = "IdTipoDocumento";
                ddlTipoDocumento.DataBind();
                ddlPais.DataSource = ManejadorGeografico.ObtenerPaises();
                ddlPais.DataTextField = "Nombre";
                ddlPais.DataValueField = "IdPais";
                ddlPais.DataBind();
            }
            
        }
    }
}