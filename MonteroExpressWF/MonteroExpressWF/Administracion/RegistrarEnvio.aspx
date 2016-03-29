<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarEnvio.aspx.cs" Inherits="MonteroExpressWF.Administracion.RegistrarEnvio" %>

<%@ Register Src="~/UserControl/DatosGenerales.ascx" TagName="DatosGenerales" TagPrefix="DG" %>
<%@ Register Src="~/UserControl/DetallesEnvio.ascx" TagName="DetallesEnvio" TagPrefix="DE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="accordion">
                <h3>Remitente</h3>
                <div>
                    <div class="row">
                        <div class="col-lg-6">
                            <DG:DatosGenerales ID="usrControlRemitente" runat="server" />
                        </div>
                        <div class="col-lg-6">
                             <DE:DetallesEnvio ID="usrControlDetallesEnvio" runat="server" />
                        </div>
                    </div>
                    
                </div>
                <h3>Destinatario</h3>
                <div>
                    <DG:DatosGenerales ID="usrControlDestinatario" runat="server" />
                </div>


            </div>

        </div>
    </div>


</asp:Content>


