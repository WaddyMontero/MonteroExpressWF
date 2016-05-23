<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Site1.Master" AutoEventWireup="true" CodeBehind="Mant_Envios.aspx.cs" Inherits="MonteroExpressWF.Mantenimientos.Mant_Envios" %>

<asp:Content ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtFiltroFecha').datepicker({
                dateFormat: 'dd/mm/yy'
            });
        });


        function Buscar() {
            $('#tblMantEnvios').jtable('load', { Nombre: $('#txtFiltroNombre').val(), Fecha: $('#txtFiltroFecha').val(), Albaran: $('#txtFiltroAlbaran').val(), Estado: $('#txtFiltroEstado').val() });
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
        <div class="col-xs-4">
            <div class="form-group">
                <label for="txtFiltroNombre">Remitente:</label>
                <input id="txtFiltroNombre" type="text" class="form-control" />
            </div>
        </div>

        <div class="col-xs-4">
            <div class="form-group">
                <label for="txtFiltroFecha">Fecha:</label>
                <input id="txtFiltroFecha" type="text" class="form-control" />
            </div>
        </div>
        <div class="col-xs-2">
            <div class="form-group">
                <label for="btnBuscar"></label>
                <button id="btnBuscar" class="form-control btn btn-primary" onclick="Buscar()">Buscar</button>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-xs-4">
            <div class="form-group">
                <label for="txtFiltroAlbaran">#Albaran:</label>
                <input id="txtFiltroAlbaran" type="text" class="form-control" />
            </div>
        </div>

                <div class="col-xs-4">
            <div class="form-group">
                <label for="txtFiltroEstado">Estado:</label>
                <input id="txtFiltroEstado" type="text" class="form-control" />
            </div>
        </div>
    </div>


    <div class="row">
        <div id="tblMantEnvios"></div>

    </div>



</asp:Content>
