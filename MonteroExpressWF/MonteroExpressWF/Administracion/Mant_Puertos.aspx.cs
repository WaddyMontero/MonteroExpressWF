﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MonteroExpressWF.BOL;

namespace MonteroExpressWF.Mantenimientos
{
    public partial class Mant_Puertos: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Usuario.UsuarioActual == null)
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}