using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MonteroExpressWF.BOL;
using MonteroExpressWF.BLL;

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
                        Envio envio = ManejadorEnvios.ObtenerEnvio(int.Parse(IdEnvio));
                        //Datos del Remitente
                        lblNombreRem.Text = envio.Remitente.Nombre;
                        lblNumDocumentoRem.Text = envio.Remitente.NumDocumento;
                        lblDireccionRem.Text = envio.Remitente.EntidadDirecciones[0].Direccion + 
                            ", " + envio.Remitente.EntidadDirecciones[0].Ciudad.Nombre + ", " + 
                            envio.Remitente.EntidadDirecciones[0].Ciudad.Provincia.Nombre;
                        lblTelefonoRem.Text = envio.Remitente.EntidadDirecciones[0].Telefono1 + ((envio.Remitente.EntidadDirecciones[0].Telefono2 != "")?" | " + envio.Remitente.EntidadDirecciones[0].Telefono2:"");
                        lblSuscribe.Text = envio.Remitente.Nombre;
                        lblDni.Text = envio.Remitente.NumDocumento;
                        //Datos del Destinatario
                        lblNombreDest.Text = envio.Destinatario.Nombre;
                        lblNumDocumentoDest.Text = envio.Destinatario.NumDocumento;
                        lblDireccionDest.Text = envio.Destinatario.EntidadDirecciones[0].Direccion +
                            ", " + envio.Destinatario.EntidadDirecciones[0].Ciudad.Nombre + ", " +
                            envio.Destinatario.EntidadDirecciones[0].Ciudad.Provincia.Nombre;
                        lblTelefonoDest.Text = envio.Destinatario.EntidadDirecciones[0].Telefono1 + ((envio.Destinatario.EntidadDirecciones[0].Telefono2 != "")?" | " + envio.Destinatario.EntidadDirecciones[0].Telefono2:"");
                        foreach (TipoContenido tCont in envio.TiposContenidos)
                        {
                            lblContenidoEnvio.Text += tCont.Descripcion + "; ";
                        }
                        lblContenidoEnvio.Text.Remove(lblContenidoEnvio.Text.Length - 2);
                        decimal pesoTotal = 0;
                        foreach (PaqueteEnvio paq in envio.PaquetesEnvios)
                        {
                            var fila = "<tr><td>"+paq.Cantidad+"</td><td colspan='2'>"+paq.Descripcion+"</td><td>"+paq.Peso+"</td><td>"+paq.TamanioPaquete.Descripcion+"</td><td>"+paq.Estado.Descripcion+"</td></tr>";
                            tblBodyPaquetes.InnerHtml += fila;
                            pesoTotal += paq.Peso;
                        }
                        lblPesoTotal.Text = pesoTotal.ToString();
                        
                    }
                }
            }
        }
    }
}