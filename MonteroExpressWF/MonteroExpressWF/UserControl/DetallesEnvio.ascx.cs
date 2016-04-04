using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MonteroExpressWF.BLL;

namespace MonteroExpressWF.UserControl
{
    public partial class DetallesEnvio : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            rbtnListEnvioSeguro.DataSource = ManejadorSegurosEnvios.ObtenerSegurosEnvios();
            rbtnListEnvioSeguro.DataValueField = "IdSeguroEnvio";
            rbtnListEnvioSeguro.DataTextField = "Descripcion";
            rbtnListEnvioSeguro.DataBind();
        }
        protected void rbtnListEnvioSeguro_DataBound(object sender, EventArgs e) 
        {
            for (int i = 0; i < rbtnListEnvioSeguro.Items.Count; i++)
            {
                rbtnListEnvioSeguro.Items[i].Enabled = false;
                rbtnListEnvioSeguro.Items[i].Attributes.Add("class", "radio-inline");
            }
        }
    }
}