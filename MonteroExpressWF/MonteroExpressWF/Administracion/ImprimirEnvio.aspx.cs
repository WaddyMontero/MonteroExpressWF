using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MonteroExpressWF.Administracion
{
    public partial class ImprimirEnvio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["IdEnvio"] != null)
                {
                    string IdEnvio = Request.QueryString["IdEnvio"].ToString();
                    if (IdEnvio != "")
                    {
                        //lblPrueba.Text = IdEnvio;
                    }
                }
                
            }

        }
    }
}