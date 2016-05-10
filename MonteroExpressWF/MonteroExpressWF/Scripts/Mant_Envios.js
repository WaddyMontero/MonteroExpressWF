$(document).ready(function () {
    //Se inicializa la tabla de los paquetes
    //alert("Esto es una Tabla");
    $('#tblMantEnvios').jtable({
        title: 'Listado Envios',
        paging: true, 
        sorting: false,
        defaultSorting: 'Name ASC',
        jqueryuiTheme: true,
        pageSize:10,
        //multiselect: true,
        //selecting: true,
        //selectingCheckboxes: true,
        messages: {
            serverCommunicationError: 'Error de comunicación con el servidor.',
            loadingMessage: 'Cargando registros...',
            noDataAvailable: 'No hay datos para mostrar!',
            addNewRecord: 'Agregar nuevo envíos',
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
            listAction: '../WebServices/MonteroExpressWS.asmx/ListarEnvios'},
            //updateAction: '../WebServices/MonteroExpressWS.asmx/ActualizarNombreEntidad'},
        fields: {
            IdEnvio: {
                key: true,
                create: false,
                edit: false,
                list: false
            },
            Fecha: {
                title: 'Fecha Envio',
                width: '6%',
                create: false,
                type: "date",
                dateFormat:"dd/MM/yyyy",
                edit: false,
                list: true
            },
            AlbaranNum:{
                title: 'Albarán',
                width: '3%',
                create:false,
                edit:false,
                list:true
            },
            NumeroEnvio: {
                title: 'No. Envio',
                width: '5%',
                create: false,
                edit: false,
                list: true
            },
            IdOficina:{
                list:false
            },
            IdDireccionRemitente:{
                list:false,
                edit:false
            },
            nombreRemitente:{
                title:'Remitente',
                list: true,
                edit: false
            },
            direccionRemitente:{
                title:'Dirección Origen',
                list: false,
                edit: false
            },
            nombreDestinatario:{
                title:'Destinatario',
                list: true,
                edit: false
            },
            direccionDestinatario:{
                title:'Dirección Destino',
                list: false,
                edit: false

            },
            descripcionSeguro:{
                title: 'Seguro',
                width: '7.2%',
                list: true,
                edit: false
            },
            nombrePuertoOrigen:{
                title:'Puerto Origen',
                list: false,
                edit: false
            },
            nombrePuertoDestino:{
                title:'Puerto Destino',
                list: false,
                edit: false
            },
            Imprimir: {
                width:'1%',
                display: function (data) {
                    var $print = $('<img src="../Content/img/print.png" title="Imprimir" class="img" />');
                    $print.click(function () {
                        window.open('http://monteroexpress.azurewebsites.net/Administracion/ImprimirEnvio.aspx?IdEnvio=' + data.record.IdEnvio);
                    });
                    return $print;
                }
            },
            Detalles: {
                    width: '1%',
                    display: function (data) {
                        var $mostrar = $('<img src="../Content/img/information_hdpi.png" title="Mostrar Direcciones" class="img" />');
                        $mostrar.click(function () {
                            
                            $("<div id='divDetalles' title='Detalles Envio "+data.record.NumeroEnvio+"'>"+
                                "<div class='row'><div class='col-xs-6'>Dirección Remitente:</div><div class='col-xs-6'>" + data.record.direccionRemitente + "</div></div>" +
                                "<div class='row'><div class='col-xs-6'>Dirección Destinatario:</div><div class='col-xs-6'>" + data.record.direccionDestinatario+ "</div></div>" +
                                "<div class='row'><div class='col-xs-6'>Puerto Origen:</div><div class='col-xs-6'>" + data.record.nombrePuertoOrigen + "</div></div>" +
                                "<div class='row'><div class='col-xs-6'>Puerto Destino:</div><div class='col-xs-6'>" + data.record.nombrePuertoDestino + "</div></div>" +
                                "<div class='row'><div id='tblListaPaquetes'></div></div>"
                                +"</div>").dialog({
                                    modal: true,
                                    width:'600px',
                                buttons: {
                                    Cerrar: function () {
                                        $(this).dialog('close');
                                    }
                                }, close: function (event, ui) {
                                    $(this).dialog('destroy').remove();
                                }, open: function () {
                                    
                                    $('#tblListaPaquetes').jtable({
                                        title: 'Listado Paquetes',
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
                                            TamanoPaquete: {
                                                title: 'Tamaño',
                                                create: false,
                                                edit: false,
                                                list: true,
                                                width: '2.5%'
                                            },
                                            EstadoPaquete: {
                                                title: 'Estado',
                                                list: true,
                                                edit: false,
                                                width: '2.5%'
                                            },
                                            ValorEnvio: {
                                                title: 'Valor',
                                                list: false,
                                                edit: false
                                            }
                                        }
                                    });
                                    $('#tblListaPaquetes').jtable('load', { "idEnvio": data.record.IdEnvio });
                                }
                                });
                            
                        });
                        return $mostrar;
                        }
                    },
            }   
    });

    $('#tblMantEnvios').jtable('load', { Nombre: '', Fecha:'', Albaran: ''});

    


});


