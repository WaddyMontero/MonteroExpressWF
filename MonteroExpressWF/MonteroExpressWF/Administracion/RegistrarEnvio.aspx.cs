using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MonteroExpressWF.BLL;
using MonteroExpressWF.BOL;

namespace MonteroExpressWF.Administracion
{
    public partial class RegistrarEnvio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Usuario.UsuarioActual == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                //ddlEstado.DataSource = ManejadorEstados.ObtieneEstadosPaquetesActivos();
                //ddlEstado.DataTextField = "Descripcion";
                //ddlEstado.DataValueField = "IdEstado";
                //ddlEstado.DataBind();
                ddlTamanioPaquete.DataSource = ManejadorTamaniosPaquetes.ObtieneTamaniosPaquetes();
                ddlTamanioPaquete.DataTextField = "Descripcion";
                ddlTamanioPaquete.DataValueField = "IdTamanioPaquete";
                ddlTamanioPaquete.DataBind();
                chkListTiposContenidos.DataSource = ManejadorTiposContenidos.ObtenerTiposContenidos(1);
                chkListTiposContenidos.DataTextField = "Descripcion";
                chkListTiposContenidos.DataValueField = "IdTipoContenido";
                chkListTiposContenidos.DataBind();
                ddlProvincia.DataSource = ManejadorGeografico.ObtenerProvincias(205);
                ddlProvincia.DataTextField = "Nombre";
                ddlProvincia.DataValueField = "IdProvincia";
                ddlProvincia.DataBind();
                //ddlOficina.DataSource = ManejadorOficinas.ObtenerOficinas(1);
                //ddlOficina.DataTextField = "Nombre";
                //ddlOficina.DataValueField = "IdOficina";                
                //ddlOficina.DataBind();
                ddlEstadoEnvio.DataSource = ManejadorEstados.ObtieneEstadosEnviosActivos();
                ddlEstadoEnvio.DataTextField = "Descripcion";
                ddlEstadoEnvio.DataValueField = "IdEstado";
                ddlEstadoEnvio.DataBind();
            }

            chkListTiposContenidos.DataSource = ManejadorTiposContenidos.ObtenerTiposContenidos(1);
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