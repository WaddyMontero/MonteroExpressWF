<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MonteroExpressWF.Administracion.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {

            AjaxCall('../WebServices/MonteroExpressWS.asmx/TotalEnviosPorMes', {}, "", TotalEnviosPorMesCallback);
            AjaxCall('../WebServices/MonteroExpressWS.asmx/Top5Envios', {}, "", Top5EnviosCallback);
            AjaxCall('../WebServices/MonteroExpressWS.asmx/Top5Recepciones', {}, "", Top5RecepcionesCallback);
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">            
             <div class="panel panel-primary">
                <div class="panel-heading">
                    <p>5 Comitentes con más envios en el año</p>
                </div>
                <div class="panel-body">
                   <div id="donut-comitente"></div>
                </div>
            </div>
        </div>
        <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <p>5 Destinatarios con más envios recibidos en el año</p>
                </div>
                <div class="panel-body">
                   <div id="donut-destinatario"></div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-sm-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <p>Total de Envios del año actual</p>
                </div>
                <div class="panel-body">
                    <div id="barra"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
