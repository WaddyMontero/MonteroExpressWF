<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarEnvio.aspx.cs" Inherits="MonteroExpressWF.Administracion.RegistrarEnvio" %>

<%@ Register Src="~/UserControl/DatosGenerales.ascx" TagName="DatosGenerales" TagPrefix="DG" %>
<%@ Register Src="~/UserControl/DetallesEnvio.ascx" TagName="DetallesEnvio" TagPrefix="DE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="accordion">
                <h3>Datos Generales</h3>
                <div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="row">
                                <h3>Remitente</h3>
                            <DG:DatosGenerales ID="usrControlRemitente" runat="server" />
                                </div>
                            <div class="row">
                                <h3>Destinatario</h3>
                                <DG:DatosGenerales ID="usrControlDestinatario" runat="server" />
                            
                                </div>
                        </div>
                        <div class="col-lg-6">
                            <DE:DetallesEnvio ID="usrControlDetallesEnvio" runat="server" />
                        </div>
                    </div>

                </div>
                <h3>Prueba</h3>
                <div>asgag</div>


            </div>

        </div>
    </div>


</asp:Content>


