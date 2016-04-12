$(document).ready(function () {
    //Se inicializa la tabla de los paquetes
    //alert("Esto es una Tabla");
    $('#tblMantEnvios').jtable({
        title: 'Listado Envios',
        paging: false, 
        sorting: false,
        defaultSorting: 'Name ASC',
        jqueryuiTheme: true,
        multiselect: true,
        selecting: true,
        selectingCheckboxes: true,
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
                width: '5%',
                create:false,
                edit:false,
                list:true
            },
            NumeroEnvio: {
                title: 'No. Envio',
                width: '7%',
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
                title:'Seguro',
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
            Detalles: {
                title: 'Detalles',
                width: '4%',
                display: function (data) {
                    var $mostrar = $('<img src="../Content/img/addressbook.png" title="Mostrar Direcciones" />');
                    $mostrar.click(function () {
                        $("<div id='divDetalles' title='"+data.record.NumeroEnvio+"'>"+
                            "<div class='row'><div class='col-xs-6'>Dirección Remitente:</div><div class='col-xs-6'>" + data.record.direccionRemitente + "</div></div>" +
                            "<div class='row'><div class='col-xs-6'>Dirección Destinatario:</div><div class='col-xs-6'>" + data.record.direccionDestinatario+ "</div></div>" +
                            "<div class='row'><div class='col-xs-6'>Puerto Origen:</div><div class='col-xs-6'>" + data.record.nombrePuertoOrigen + "</div></div>" +
                            "<div class='row'><div class='col-xs-6'>Puerto Destino:</div><div class='col-xs-6'>" + data.record.nombrePuertoDestino + "</div></div>" +
                            +"</>").dialog({
                                modal: true,
                                width:'400px',
                            buttons: {
                                Cerrar: function () {
                                    $(this).dialog("close");
                                }
                            }
                        });
                    });
                    return $mostrar;
                    //                    $('#tblMantEnvios').

                }
    //                //Open child table when user clicks the image
    //                $mostrar.click(function () {
    //                    $('#tblMantEnvios').

                },
                    //        },
                    //        IdTipoDocumento:{
                    //            title: 'Tipo Documento',
                    //            width: '10%',
                    //            input: function (data) {
                    //                var $ddl = $("<select id='JTddlTipoDocumento' name=''></select>").change(function () {
                    //                    //var idStartWith = $(this).attr("id").split('_')[0] + '_' + $(this).attr("id").split('_')[1] + '_';
                    //                    if ($(this).val() == '') {
                    //                        $('#JTNumDocumento').attr('disabled', 'disabled');
                    //                        $('#JTNumDocumento').val("");
                    //                        $('#hdTipoDoc').val("");
                    //                    } else {
                    //                        $.ajax({
                    //                            type: "POST",
                    //                            url: "../WebServices/MonteroExpressWS.asmx/ObtenerTipoDocumento",
                    //                            data: JSON.stringify({ 'IdTipoDocumento': parseInt($(this).val()) }),
                    //                            contentType: "application/json; charset=utf-8",
                    //                            dataType: "json",
                    //                            success: function (result) {
                    //                                if (data != undefined) {
                    //                                    $('#JTNumDocumento').mask(result.d.Mascara);
                    //                                    $('#JTNumDocumento').removeAttr("disabled");
                    //                                    $('#hdTipoDoc').val(result.d.IdTipoDocumento);
                    //                                }
                    //                            }, error: function (jqXHR, textStatus, errorThrown) {
                    //                                MostrarAlerta("error", textStatus);
                    //                            }
                    //                        });
                    //                    }

                    //                });
                    //                $.ajax({
                    //                    type: "POST",
                    //                    url: "../WebServices/MonteroExpressWS.asmx/ObtenerTiposDocumentos",
                    //                    contentType: "application/json; charset=utf-8",
                    //                    dataType: "json",
                    //                    success: function (data) {
                    //                        if (data != undefined) {
                    //                            $ddl.append('<option value="" selected="selected">Seleccione --></option>');
                    //                            for (i = 0; i < data.d.length;i++)
                    //                            {
                    //                                $ddl.append('<option value="' + data.d[i].IdTipoDocumento + '">' + data.d[i].Descripcion + '</option>');
                    //                            }
                    //                        }
                    //                    }, error: function (jqXHR, textStatus, errorThrown) {
                    //                        MostrarAlerta("error", textStatus);
                    //                    }
                    //                });
                    //                return $ddl;
                    //            },
                    //            list: false,
                    //            edit: false,
                    //            create:true
                    //        },
                    //        NumDocumento: {
                    //            title: 'Número Documento',
                    //            width: '10%',
                    //            input:function(data)
                    //            {
                    //                return $('<input type="text" name="NumDocumento" id="JTNumDocumento" disabled="disabled"/>');
                    //            },
                    //            create: true,
                    //            list: true,
                    //            edit: false
                    //        },
                    //        FechaIngreso: {
                    //            title: 'FechaIngreso',
                    //            create: false,
                    //            type: "date",
                    //            dateFormat:"dd/MM/yyyy",
                    //            edit: false,
                    //            list: true
                    //        },
                    //        Direcciones: {
                    //            title: 'Direcciones',
                    //            width: '5%',
                    //            sorting: false,
                    //            edit: false,
                    //            create: false,
                    //           display: function (entidadDireccion) {
                    //                var $mostrar = $('<img src="../Content/img/addressbook.png" title="Mostrar Direcciones" />');
                    //                //Open child table when user clicks the image
                    //                $mostrar.click(function () {
                    //                    $('#tblMantEnvios').jtable('openChildTable',
                    //                            $mostrar.closest('tr'),
                    //                            {
                    //                                messages: {
                    //                                    serverCommunicationError: 'Error de comunicación con el servidor.',
                    //                                    loadingMessage: 'Cargando registros...',
                    //                                    noDataAvailable: 'No hay datos para mostrar!',
                    //                                    addNewRecord: 'Agregar nuevo registro',
                    //                                    editRecord: 'Editar registro',
                    //                                    areYouSure: '¿Estas seguro?',
                    //                                    deleteConfirmation: '¿Esta seguro que desea eliminar este registro?',
                    //                                    save: 'Guardar',
                    //                                    saving: 'Guardando',
                    //                                    cancel: 'Cancel',
                    //                                    deleteText: 'Eliminar',
                    //                                    deleting: 'Eliminando',
                    //                                    error: 'Error',
                    //                                    close: 'Cerrar',
                    //                                    cannotLoadOptionsFor: 'No se pudo cargar las opciones para {0}',
                    //                                    pagingInfo: 'Mostrando {0}-{1} de {2}',
                    //                                    pageSizeChangeLabel: 'Conteo de fila',
                    //                                    gotoPageLabel: 'Go to page',
                    //                                    canNotDeletedRecords: 'No se eliminaron {0} de {1} registros!',
                    //                                    deleteProggress: 'Eliminando {0} de {1} registros, procesando...'
                    //                                },
                    //                                title: entidadDireccion.record.Nombre + ' - Direcciones',
                    //                                actions: {
                    //                                    listAction: '../WebServices/MonteroExpressWS.asmx/ObtieneDireccionesByEntidad?IdEntidad=' + entidadDireccion.record.IdEntidad,
                    //                                    deleteAction: '../WebServices/MonteroExpressWS.asmx/EliminarEntidadDireccion',
                    //                                    //updateAction: '/Demo/UpdatePhone',
                    //                                    createAction: '../WebServices/MonteroExpressWS.asmx/InsertaEntidadDireccion'
                    //                                },
                    //                                fields: {
                    //                                    IdEntidad: {
                    //                                        type: 'hidden',
                    //                                        defaultValue: entidadDireccion.record.IdEntidad
                    //                                    },
                    //                                    IdEntidadDireccion: {
                    //                                        key: true,
                    //                                        create: false,
                    //                                        edit: false,
                    //                                        list: false
                    //                                    },
                    //                                    Direccion: {
                    //                                        title: 'Direccion',
                    //                                        width: '30%',
                    //                                        list:true
                    //                                        //options: { '1': 'Home phone', '2': 'Office phone', '3': 'Cell phone' }
                    //                                    },
                    //                                    Telefono1: {
                    //                                        title: 'Teléfono1',
                    //                                        width: '30%'
                    //                                    },
                    //                                    Telefono2: {
                    //                                        title: 'Teléfono2',
                    //                                        width: '20%',
                    //                                        create: false,
                    //                                        edit: false
                    //                                    },
                    //                                    IdPais: {
                    //                                        title: 'País',
                    //                                        list: false,
                    //                                        create: true,                                            
                    //                                        options: '../WebServices/MonteroExpressWS.asmx/ObtenerPaises'

                    //                                    },
                    //                                    IdProvincia: {
                    //                                        title: 'Provincia/Estado',
                    //                                        list: false,
                    //                                        create: true,
                    //                                        dependsOn: 'IdPais',
                    //                                        options: function (data) {
                    //                                            return '../WebServices/MonteroExpressWS.asmx/ObtenerProvinciasByPaisJT?IdPais=' + data.dependedValues.IdPais;
                    //                                        },                                           
                    //                                     },
                    //                                    IdCiudad: {
                    //                                        title: 'Ciudad',
                    //                                        list: true,
                    //                                        create: true,
                    //                                        dependsOn: 'IdProvincia',
                    //                                        options: function (data) {
                    //                                            if (data.source == 'list') {

                    //                                                return '../WebServices/MonteroExpressWS.asmx/ObtenerCiudadesByProvinciaJT?IdProvincia=1';
                    //                                            }
                    //                                            return '../WebServices/MonteroExpressWS.asmx/ObtenerCiudadesByProvinciaJT?IdProvincia=' + data.dependedValues.IdProvincia;
                    //                                        },
                    //                                    },
                    //                                    PorDefecto:
                    //                                        {
                    //                                            title: "Por Defecto",
                    //                                            type: "checkbox",
                    //                                            values: {false:'No',true:'Si'}
                    //                                        }
                    //                                },
                    //                                recordAdded: function (event, data)
                    //                                {
                    //                                    //$('#tblMantEnvios').jtable('reload');
                    //                                    //$mostrar.click();
                    //                                }
                    //                            }, function (data) { //opened handler
                    //                                data.childTable.jtable('load');
                    //                            });
                    //                });
                    //                //Return image to show on the person row
                    //                return $mostrar;
                    //            }
                
                    //            }
                    //        }
                    //    }
                    //);
}});
    $('#tblMantEnvios').jtable('load');
});


