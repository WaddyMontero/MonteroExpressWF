<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Site1.Master" AutoEventWireup="true" CodeBehind="Mant_Envios.aspx.cs" Inherits="MonteroExpressWF.Mantenimientos.Mant_Envios" %>
<asp:Content ContentPlaceHolderID="head" runat="server">

<script type="text/javascript">
    $(document).ready(function () {
        $('#txtFiltroFecha').datepicker({
            dateFormat: 'd/m/y'
        });
    });


    function Buscar() {

        
        $('#tblMantEnvios').jtable('load', { Nombre: $('#txtFiltroNombre').val(), Fecha: $('#txtFiltroFecha').val(), Albaran: $('#txtFiltroAlbaran').val() });
    }

</script>




</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">

            <h1 class="page-header">Mantenimiento Envios</h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div id="tblMantEnvios"></div>

        <div class="row">
            <div class="col-xs-2">
                Nombre:
            </div>
            <div class="col-xs-4">
                <input id="txtFiltroNombre" type="text" />
            </div>
            <div class="col-xs-2">
                Fecha:
            </div>
            <div class="col-xs-4">
                <input id="txtFiltroFecha" type="text"/>
            </div>
        </div>

        <div class="row">
            <div class="col-xs-2">
                # Albaran:
            </div>
            <div class="col-xs-4">
                <input id="txtFiltroAlbaran" type="text" />
            </div>

            <div class="col-xs-4">
                <button id="btnBuscar" onclick="Buscar()">Buscar</button>
            </div>
        </div>
    </div>



</asp:Content>
