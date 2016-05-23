<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RecepcionEnvios.ascx.cs" Inherits="MonteroExpressWF.UserControl.RecepcionEnvios" %>

<script type="text/javascript">

    $(document).ready(function(){
    
    $('#tblListaPaquetes').jtable({
        title: 'Paquetes asociados',
        paging: false,
        sorting: false,
        defaultSorting: 'Name ASC',
        jqueryuiTheme: true,
        messages: {
            serverCommunicationError: 'Error de comunicación con el servidor.',
            loadingMessage: 'Cargando registros...',
            noDataAvailable: 'No hay datos para mostrar!',
            addNewRecord: 'Agregar nuevo registro',
            editRecord: 'Editar registro',
            areYouSure: '¿Estas seguro?',
            deleteConfirmation: '¿Esta seguro que desea eliminar este registro?',
            save: 'Guardar',
            saving: 'Guardando',
            cancel: 'Cancel',
            deleteText: 'Eliminar',
            deleting: 'Eliminando',
            error: 'Error',
            close: 'Cerrar',
            cannotLoadOptionsFor: 'No se pudo cargar las opciones para {0}',
            pagingInfo: 'Mostrando {0}-{1} de {2}',
            pageSizeChangeLabel: 'Conteo de fila',
            gotoPageLabel: 'Go to page',
            canNotDeletedRecords: 'No se eliminaron {0} de {1} registros!',
            deleteProggress: 'Eliminando {0} de {1} registros, procesando...'
        },
        actions: {
            listAction: '../WebServices/MonteroExpressWS.asmx/ObtenerPaquetesPorEnvio'
        },
        fields: {
            IdPaqueteEnvio: {
                key: true,
                create: false,
                edit: false,
                list: false
            },
            Descripcion: {
                title: 'Contenido',
                width: '20%',
                create: false,
                edit: false,
                list: true
            },
            Cantidad: {
                title: 'Cant.',
                width: '3%',
                create: false,
                edit: false,
                list: true
            },
            TamanioPaquete: {
                title: 'Tamaño',
                create: false,
                edit: false,
                list: true,
                width: '4.5%'
            },
            EstadoPaquete: {
                title: 'Estado',
                list: true,
                edit: false,
                width: '2.5%'
            },
            Peso: {
                title: 'Peso',
                list: true,
                edit: false,
                width:'1.5%'
            }
        }
    });
    //$('#tblListaPaquetes').jtable('load', { "idEnvio": data.record.IdEnvio });
    
});

    function BuscarEnvio()
    {
        if ($('#txtAlbaran').val() != '') {
            AjaxCall('../WebServices/MonteroExpressWS.asmx/ObtenerEnvioByAlbaran', {'AlbaranNum': $('#txtAlbaran').val()}, "", BuscarEnvioByAlbaranCallBack);
        } else {
            MostrarDialogo('buscarEnvioRecepcionEnvioModal','Buscar envio', "Debe digitar el número de albaran del envio que desea recibir.", true, null);
        }
    }

</script>
<div class="hidden" id="pnlRecepcion">
    <div class="row">
        <div class="col-xs-2">Albaran #:</div>
        <div class="col-xs-6"> 
            <input type="text" id="txtAlbaran" class="form-control"/>
        </div>
        <div class="col-xs-4">
            <input type="button" id="btnBuscarEnvio" class="btn btn-info" onclick="BuscarEnvio()" value="Buscar">
        </div>

    </div>
    <hr /><br />
    <%--<div class="panel-heading">Detalles de Envio</div>
    <div class="panel-body">        --%>
        <div id='divDetalles' title="Detalles Envio" class="hidden">
            <div class='row'>
                <input type="hidden" id="hdfIdEnvio" />
                <div class='col-xs-6'>
                    <label class="bold">Remitente:</label>
                </div>
                <div class="col-xs-6">
                    <label id="lblRemitente"></label>
                </div>
            </div>
            <div class='row'>
                <div class='col-xs-6'>
                    <label class="bold">Dirección Remitente:</label>
                </div>
                <div class="col-xs-6">
                    <label id="lblDirRemitente"></label>
                </div>
            </div>
            <div class='row'>
                <div class='col-xs-6'>
                    <label class="bold">Destinatario:</label>
                </div>
                <div class="col-xs-6">
                    <label id="lblDestinatario"></label>

                </div>
            </div>
            <div class='row'>
                <div class='col-xs-6'>
                     <label class="bold">Dirección Destinatario:</label>
                </div>
                <div class="col-xs-6">
                    <label id="lblDirDestinatario"></label>

                </div>
            </div>
            <div class='row'>
                <div class='col-xs-6'>
                    <label class="bold">Puerto Origen:</label>
                </div>
                <div class="col-xs-6">
                    <label id="lblPuertoOrigen"></label>
                </div>
            </div>
            <div class='row'>
                <div class='col-xs-6'>
                    <label class="bold">Puerto Destino:</label>
                </div>
                <div class="col-xs-6">
                    <label id="lblPuertoDestino"></label>
                </div>
            </div>
            <div class='row'>
                <div class='col-xs-6'>
                    <label class="bold">Fecha Envio:</label>
                </div>
                <div class="col-xs-6">
                    <label id="lblFechaEnvio"></label>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-xs-12">
                    <div id="tblListaPaquetes"></div>
                </div>

            </div>
        </div>

    <%--</div>--%>
</div>
