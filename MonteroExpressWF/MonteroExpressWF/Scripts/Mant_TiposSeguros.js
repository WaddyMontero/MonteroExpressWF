$(document).ready(function () {
    //Se inicializa la tabla de los paquetes
    //alert("Esto es una Tabla");
    $('#tblMantTipoSeguros').jtable({
        title: 'Lista Tipos Seguros',
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
            listAction: "../WebServices/MonteroExpressWS.asmx/ObtenerSegurosEnvios",
            updateAction: "../WebServices/MonteroExpressWS.asmx/ActualizarNombreEntidad",
            createAction: function (postData) {

                var SeguroEnvio = new Object();
                
                SeguroEnvio.IdSeguroEnvio = 0;
                SeguroEnvio.Descripcion = postData;
                SeguroEnvio.Activo = true;
                SeguroEnvio.FechaIngreso = "04/17/2016";

                return $.Deferred(function ($dfd) {
                    $.ajax({
                        url: '../WebServices/MonteroExpressWS.asmx/InsertaSeguroEnvio',
                        type: 'POST',
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify({"SeguroEnvio":SeguroEnvio}),
                        dataType: 'json',
                        success: function (data) {
                            $dfd.resolve(data);
                        },
                        error: function (jqXHR, textStatus, errorThrown) {
                            alert(JSON.stringify(jqXHR));
                            $dfd.reject();
                        }
                    });
                });
            },
            deleteAction: function (postData)
            {
                $.ajax({
                    url: '../WebServices/MonteroExpressWS.asmx/EliminaSeguroEnvio',
                    type: 'POST',
                    dataType: 'json',
                    data: postData,
                    success: function (data) {
                        alert(data);
                    }
                    , error: function (jqXHR) {
                        alert(JSON.stringify(jqXHR));
                    }
                });
            }
            }
        ,
        rowUpdated: function (event, data) {
            if (data.record) {
                $('#tblMantEntidades').jtable('reload');
            }
        },
        fields: {
            IdSeguroEnvio: {
                key: true,
                create: false,
                edit: false,
                list: false
            },
            Descripcion: {
                title: 'Tipo de Seguro',
                width: '10%',
                create: true,
                edit: true,
                list: true
            },
            FechaIngreso: {
                title: 'FechaIngreso',
                create: false,
                type: "date",
                dateFormat: "dd/MM/yyyy",
                edit: false,
                list: true
            }
        }
        }
    );

$('#tblMantTipoSeguros').jtable('load');
});


