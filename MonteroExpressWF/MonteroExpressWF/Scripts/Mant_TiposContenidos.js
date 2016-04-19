$(document).ready(function () {
    //Se inicializa la tabla de los paquetes
    //alert("Esto es una Tabla");
    $('#tblMantTipoContenidos').jtable({
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
            listAction: "../WebServices/MonteroExpressWS.asmx/ObtenerTiposContenidos",
            createAction:"../WebServices/MonteroExpressWS.asmx/InsertaTipoContenido",
            updateAction: "../WebServices/MonteroExpressWS.asmx/ActualizaTipoContenido"
        },       
        fields: {
            IdTipoContenido: {
                key: true,
                create: false,
                edit: false,
                list: false
            },
            Descripcion: {
                title: 'Tipo de Contenido',
                width: '10%',
                create: true,
                edit: false,
                list: true
            },
            FechaIngreso: {
                title: 'Fecha Ingreso',
                create: false,
                width:'2.5%',
                type: "date",
                dateFormat: "dd/MM/yyyy",
                edit: false,
                list: true
            },
            Activo: {
                title: 'Activo',
                list: true,
                width: '2.5%',
                type: "checkbox",
                edit:true,
                values: {false:'No',true:'Si'},
                create:false
            }
        },
        rowAdded: function (event, data) {
            if (data.record)
            {
                $('#tblMantTipoContenidos').jtable('reload');
            }
        },
        recordUpdated: function (event, data) {
            if (data.record)
            {
                $('#tblMantTipoContenidos').jtable('reload');
            }
        },
        recordAdded: function (event, data) {
            if (data.record)
            {
                $('#tblMantTipoContenidos').jtable('reload');
            }
        },
        rowUpdated: function (event, data) {
            if (data.record)
            {
                $('#tblMantTipoContenidos').jtable('reload');
            }
        },
    });

    $('#tblMantTipoContenidos').jtable('load');
});


