<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarEnvio.aspx.cs" Inherits="MonteroExpressWF.Administracion.RegistrarEnvio" %>
<%@ Register Src="~/UserControl/DatosGenerales.ascx" TagName="DatosGenerales" TagPrefix="DG" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="accordion">
        <h3>Remitente</h3>
        <div>
                <p>
            <DG:DatosGenerales ID="usrControlDatosGenerales" runat="server"/>
                    </p>
        </div>
        <h3>Destinatario</h3>
        <div>
            <p>

                Esto es una prueba 2
            </p>

        </div>

    </div>



</asp:Content>


