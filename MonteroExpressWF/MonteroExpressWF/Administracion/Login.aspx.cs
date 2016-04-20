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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this.formLogin.DefaultButton = btnLogin.ClientID;
        }
        protected void btnLogin_Click(object sender, EventArgs e) 
        {
            if (txtUsuario.Text != "" && txtContrasena.Text != "")
            {
                Usuario usuario = ManejadorUsuarios.AutenticarUsuario(txtUsuario.Text, txtContrasena.Text);
                if (usuario != null)
                {
                    if (usuario.Habilitado)
                    {
                        Usuario.UsuarioActual = usuario;
                        Response.Redirect("Dashboard.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(Page, typeof(Page), "ImprimirMensaje", "alert('Este usuario no esta habilitado. Favor contacte su administrador.')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, typeof(Page), "ImprimirMensaje", "alert('Usuario y/o Contraseña incorrecta. Verifique y trate de nuevo.')", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page,typeof(Page), "ImprimirMensaje", "alert('Complete el nombre de usuario y/o contraseña.')",true);
            }
        }
    }
}