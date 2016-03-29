<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarEnvio.aspx.cs" Inherits="MonteroExpressWF.Administracion.RegistrarEnvio" %>
<%@ Register Src="~/UserControl/DatosGenerales.ascx" TagName="DatosGenerales" TagPrefix="DG" %>
<%@ Register Src="~/UserControl/DetallesEnvio.ascx" TagName="DetallesEnvio" TagPrefix="DE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="accordion">
        <h3>Remitente</h3>
        <div>
                <p>
            <DG:DatosGenerales ID="usrControlDatosGenerales" runat="server"/>
                    </p>
        </div>
        <h3>Detalles Envio</h3>
        <div>
            <p>

                <DE:DetallesEnvio ID="usrControlDetallesEnvio" runat="server" />
            </p>

        </div>

    </div>



</asp:Content>


