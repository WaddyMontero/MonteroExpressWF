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
                                    title: entidadDireccion.record.Nombre + ' - Direcciones',
                                    actions: {
                                        listAction: '../WebServices/MonteroExpressWS.asmx/ObtieneDireccionesByEntidad?IdEntidad=' + entidadDireccion.record.IdEntidad,
                                        //deleteAction: '/Demo/DeletePhone',
                                        //updateAction: '/Demo/UpdatePhone',
                                        createAction: '../WebServices/MonteroExpressWS.asmx/InsertaEntidadDireccion'
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
                                            width: '30%',
                                            list:true
                                            //options: { '1': 'Home phone', '2': 'Office phone', '3': 'Cell phone' }
                                        },
                                        Telefono1: {
                                            title: 'Teléfono1',
                                            width: '30%'
                                        },
                                        Telefono2: {
                                            title: 'Teléfono2',
                                            width: '20%',
                                            create: false,
                                            edit: false
                                        },
                                        IdPais: {
                                            title: 'País',
                                            list: false,
                                            create: true,                                            
                                            options: '../WebServices/MonteroExpressWS.asmx/ObtenerPaises'

                                        },
                                        IdProvincia: {
                                            title: 'Provincia/Estado',
                                            list: false,
                                            create: true,
                                            dependsOn: 'IdPais',
                                            options: function (data) {
                                                //if (data.source == 'list') {
                                                //    //Return url of all cities for optimization. 
                                                //    return '../WebServices/MonteroExpressWS.asmx/ObtenerCiudadesByProvincia?IdProvincia=0';
                                                //}
                                                //This code runs when user opens edit/create form or changes country combobox on an edit/create form.
                                                return '../WebServices/MonteroExpressWS.asmx/ObtenerProvinciasByPaisJT?IdPais=' + data.dependedValues.IdPais;
                                            },                                           
                                            

                                        },
                                        IdCiudad: {
                                            title: 'Ciudad',
                                            list: true,
                                            create: true,
                                            dependsOn: 'IdProvincia',
                                            options: function (data) {
                                                if (data.source == 'list') {
                                                    //Return url of all cities for optimization. 
                                                    return '../WebServices/MonteroExpressWS.asmx/ObtenerCiudadesByProvinciaJT?IdProvincia=1';
                                                }
                                                //This code runs when user opens edit/create form or changes country combobox on an edit/create form.
                                                return '../WebServices/MonteroExpressWS.asmx/ObtenerCiudadesByProvinciaJT?IdProvincia=' + data.dependedValues.IdProvincia;
                                            },

                                        },
                                        PorDefecto:
                                            {
                                                title: "Por Defecto",
                                                type: "checkbox",
                                                values: {false:'No',true:'Si'}
                                            }
                                    },
                                    recordAdded: function (event, data)
                                    {
                                        //data.childTable.jtable('reload');
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


