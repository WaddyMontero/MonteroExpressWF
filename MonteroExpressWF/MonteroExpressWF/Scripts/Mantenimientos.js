$(document).ready(function () {
    //Se inicializa la tabla de los paquetes
    //alert("Esto es una Tabla");
    $('#tblMantenimiento').jtable({
        title: 'Lista Entidades',
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
            listAction: '../WebServices/MonteroExpressWS.asmx/ListarEntidades'
        },
        fields: {
            IdEntidad: {
                key: true,
                create: false,
                edit: false,
                list: false
            },
            Nombre: {
                title: 'Nombre',
                width: '10%',
                create: true,
                edit: true,
                list: true
            },
            NumDocumento: {
                title: 'Número Documento',
                width: '10%',
                list: true
            },
            FechaIngreso: {
                title: 'FechaIngreso',
                create: true,
                type: "date",
                dateFormat:"dd/MM/yyyy",
                edit: true,
                list: true
            },
            Direcciones: {
                title: '',
                width: '5%',
                sorting: false,
                edit: false,
                create: false,
                display: function (entidadDireccion) {
                    var $mostrar = $('<img src="../Content/img/addressbook.png" title="Mostrar Direcciones" />');
                    //Open child table when user clicks the image
                    $mostrar.click(function () {
                        $('#tblMantenimiento').jtable('openChildTable',
                                $mostrar.closest('tr'),
                                {
                                    title: entidadDireccion.record.Nombre + ' - Direcciones',
                                    actions: {
                                        listAction: '../WebServices/MonteroExpressWS.asmx/ListarEntidades?IdEntidad=' + entidadDireccion.record.IdEntidad
                                        //deleteAction: '/Demo/DeletePhone',
                                        //updateAction: '/Demo/UpdatePhone',
                                        //createAction: '/Demo/CreatePhone'
                                    },
                                    fields: {
                                        IdEntidad: {
                                            type: 'hidden',
                                            defaultValue: entidadDireccion.record.IdEntidad
                                        },
                                        IdEntidadDireccion: {
                                            key: true,
                                            create: false,
                                            edit: false,
                                            list: false
                                        },
                                        Direccion: {
                                            title: 'Direccion',
                                            width: '30%'
                                            //options: { '1': 'Home phone', '2': 'Office phone', '3': 'Cell phone' }
                                        },
                                        Telefono1: {
                                            title: 'Teléfono1',
                                            width: '30%'
                                        },
                                        Telefono2: {
                                            title: 'Teléfono2',
                                            width: '20%',
                                            type: 'date',
                                            create: false,
                                            edit: false
                                        },
                                        IdPais: {
                                            title: 'País',
                                            options:

                                        }
                                    }
                                }, function (data) { //opened handler
                                    data.childTable.jtable('load');
                                });
                    });
                    //Return image to show on the person row
                    return $mostrar;
                }
            }
        }//,
        //toolbar: {
        //    items: [{
        //        //icon: '/images/excel.png',
        //        text: '+ Agregar',
        //        //cssClass: "form-control",
        //        click: function () {
        //            $("#divAgregarPaquete").dialog('open');
        //        }
        //    }, {
        //        //icon: '/images/pdf.png',
        //        text: 'Eliminar',
        //        //cssClass:"form-control",
        //        click: function () {
        //            var $selectedRows = $('#tblPaquetes').jtable('selectedRows');
        //            $selectedRows.each(function () {
        //                var record = $(this).data('record');
        //                //var personId = record.PersonId;
        //                $('#tblPaquetes').jtable('deleteRecord', {
        //                    key: record.IdPaqueteEnvio,
        //                    clientOnly: true
        //                });
        //            });
        //        }
        //    }]
        //}
    });

    $('#tblMantenimiento').jtable('load');
});


