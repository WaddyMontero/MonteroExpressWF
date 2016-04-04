using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MonteroExpressWF.BLL;

namespace MonteroExpressWF.Administracion
{
    public partial class RegistrarEnvio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            chkListTiposContenidos.DataSource = ManejadorTiposContenidos.ObtenerTiposContenidos();
            chkListTiposContenidos.DataTextField = "Descripcion";
            chkListTiposContenidos.DataValueField = "IdTipoContenido";
            chkListTiposContenidos.DataBind();
        }

        protected void chkListTiposContenidos_DataBound(object sender, EventArgs e)
        {
            for (int i = 0; i < chkListTiposContenidos.Items.Count; i++)
            {
                chkListTiposContenidos.Items[i].Attributes.Add("class", "checkbox-inline");
            }
        }
    }
}