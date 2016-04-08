$(document).ready(function () {
    $('#txtCantidad').mask('999999');
    $('#txtPrecioUnitario').mask('9999999.99');
    $('#txtPeso').mask('999999.99');
    //Dialogo para insertar un nuevo paquete al envio
    $("#divAgregarPaquete").dialog({
        resizable: true,
        height: "auto",
        modal: true,
        autoOpen: false,
        buttons: {
            "Agregar": function () {
                idPaquete += 1;
                $('#tblPaquetes').jtable('addRecord', {
                    record: {
                        IdPaqueteEnvio: idPaquete,
                        Cantidad: $('#txtCantidad').val(),
                        IdTamanioPaquete: $('#MainContent_ddlTamanioPaquete').val(),
                        Descripcion: $('#txtDescripcion').text(),
                        IdEstado: $('#MainContent_ddlEstado').val(),
                        Peso: $('#txtPeso').val()
                    },
                    clientOnly: true
                });
                $(this).dialog("close");
                GuardarEnvio();
            },
            "Cancelar": function () {
                $(this).dialog("close");
            }
        }
    });
    $("#divAgregarPaquete").find("button").addClass("form-control");

    //Se inicializa la tabla de los paquetes

    $('#tblPaquetes').jtable({
        title: 'Listado Paquetes',
        paging: false, //Enable paging
        sorting: false, //Enable sorting
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
            //listAction: '../WebServices/MonteroExpressWS.asmx/ListarPaquetes'
        },
        fields: {
            IdPaqueteEnvio: {
                key: true,
                create: false,
                edit: false,
                list: false
            },
            Cantidad: {
                title: 'Cantidad',
                width: '10%',
                create: true,
                edit: true,
                list: true
            },
            IdTamanioPaquete: {
                title: 'Tamaño',
                width: '8%',
                options: "../WebServices/MonteroExpressWS.asmx/ObtieneTamaniosPaquetes",
                list: true
            },
            Descripcion: {
                title: 'Descripción',
                create: true,
                edit: true,
                list: true
            },
            Peso: {
                title: 'Peso',
                width: '12%',
                create: true,
                edit: true,
                list: true
            },
            IdEstado: {
                title: 'Estado',
                width: '12%',
                options: "../WebServices/MonteroExpressWS.asmx/ObtieneEstadosPaquetes",
                list: true
            }
        },
        toolbar: {
            items: [{
                //icon: '/images/excel.png',
                text: '+ Agregar',
                //cssClass: "form-control",
                click: function () {
                    //alert('asf');
                    //$('#tblPaquetes').jtable().showCreateForm();
                    $("#divAgregarPaquete").dialog('open');
                }
            }, {
                //icon: '/images/pdf.png',
                text: 'Eliminar',
                //cssClass:"form-control",
                click: function () {
                    var $selectedRows = $('#tblPaquetes').jtable('selectedRows');
                    $selectedRows.each(function () {
                        var record = $(this).data('record');
                        //var personId = record.PersonId;
                        $('#tblPaquetes').jtable('deleteRecord', {
                            key: record.IdPaqueteEnvio,
                            clientOnly: true
                        });
                    });
                }
            }]
        }//,

        ////Initialize validation logic when a form is created
        //formCreated: function (event, data) {
        //    data.form.find('input[name="Cantidad"]').addClass('validate[required]');
        //    data.form.find('input[name="Descripcion"]').addClass('validate[required]');
        //    data.form.find('input[name="PrecioUnitario"]').addClass('validate[required]');
        //    data.form.find('input[name="Peso"]').addClass('validate[required]');
        //    data.form.validationEngine();
        //},
        ////Validate form when it is being submitted
        //formSubmitting: function (event, data) {
        //    return data.form.validationEngine('validate');
        //},
        ////Dispose validation logic when form is closed
        //formClosed: function (event, data) {
        //    data.form.validationEngine('hide');
        //    data.form.validationEngine('detach');
        //}
    });

    //    //Load student list from server
    //$('#tblPaquetes').jtable('load');

});


function GuardarEnvio() {
    //Información del remitente
    //var remitente = new Array();
    //var idRemitente = 0;
    //if ($('#MainContent_usrControlRemitente_IdEntidad').val() != "") {
    //remitente.IdRemitente = $('#MainContent_usrControlRemitente_IdEntidad').val();
    //} else {
    var Remitente = new Object();
    
    Remitente.IdRemitente = ($('#MainContent_usrControlRemitente_IdEntidad').val() != "") ? $('#MainContent_usrControlRemitente_IdEntidad').val() : 0;
    Remitente.Nombre = $('#MainContent_usrControlRemitente_txtNombre').val();
    Remitente.IdTipoDocumento = $('#MainContent_usrControlRemitente_ddlTipoDocumento').val();
    Remitente.NumDocumento = $('#MainContent_usrControlRemitente_txtDocumento').val();
    
    //var Remitente = {
    //    "IdRemitente": ($('#MainContent_usrControlRemitente_IdEntidad').val() != "") ? $('#MainContent_usrControlRemitente_IdEntidad').val():0,
    //    "Nombre": $('#MainContent_usrControlRemitente_txtNombre').val(),
    //    "IdTipoDocumento": $('#MainContent_usrControlRemitente_ddlTipoDocumento').val(),
    //    "NumDocumento": $('#MainContent_usrControlRemitente_txtDocumento').val()
    //};
    //remitente.IdRemitente = 0;
    //remitente.Nombre = $('#MainContent_usrControlRemitente_txtNombre').val();
    //remitente.IdTipoDocumento = $('#MainContent_usrControlRemitente_ddlTipoDocumento').val();
    //remitente.NumDocumento = $('#MainContent_usrControlRemitente_txtDocumento').val();
    // }
    var EntidadDireccionesRemitente = new Array();
    var dir1 = {
        "IdEntidadDireccion" : ($('#MainContent_usrControlRemitente_ddlDireccion').val() == "") ? "0" : $('#MainContent_usrControlRemitente_ddlDireccion').val(),
        "Direccion" : $('#MainContent_usrControlRemitente_txtDireccion').val(),
        "IdCiudad" : (Remitente.IdRemitente > 0)?"0":$('#MainContent_usrControlRemitente_ddlCiudad').val(),
        "Telefono1": $('#MainContent_usrControlRemitente_txtTelefono1').val(),
        "Telefono2": $('#MainContent_usrControlRemitente_txtTelefono2').val(),        
        "PorDefecto": $('#MainContent_usrControlRemitente_chkPorDefecto').is(':checked')
    };
    EntidadDireccionesRemitente[0] = dir1;
    Remitente.EntidadDirecciones = EntidadDireccionesRemitente;
    //Remitente.EntidadDireccion = {
    //    "IdEntidadDireccion": ($('#MainContent_usrControlRemitente_ddlDireccion').val() == "") ? 0 : $('#MainContent_usrControlRemitente_ddlDireccion').val(),
    //    "Direccion": $('#MainContent_usrControlRemitente_txtDireccion').val(),
    //    "IdCiudad": $('#MainContent_usrControlRemitente_ddlCiudad').val(),
    //    "Telefono1": $('#MainContent_usrControlRemitente_txtTelefono1').val(),
    //    "Telefono2": $('#MainContent_usrControlRemitente_txtTelefono2').val(),
    //    "PorDefecto": $('#MainContent_usrControlRemitente_chkPorDefecto').is(':checked')
    //};
    //if ($('#MainContent_usrControlRemitente_ddlDireccion').val() == "") {
    //    remitente.EntidadDireccion.IdEntidadDireccion = 0;
    //    remitente.EntidadDireccion.Direccion = $('#MainContent_usrControlRemitente_txtDireccion').val();
    //    remitente.EntidadDireccion.IdCiudad = $('#MainContent_usrControlRemitente_ddlCiudad').val();
    //    remitente.EntidadDireccion.Telefono1 = $('#MainContent_usrControlRemitente_txtTelefono1').val();
    //    remitente.EntidadDireccion.Telefono2 = $('#MainContent_usrControlRemitente_txtTelefono2').val();
    //    remitente.EntidadDireccion.PorDefecto = $('#MainContent_usrControlRemitente_chkPorDefecto').is(':checked');
    //} else {
    //    remitente.EntidadDireccion.IdEntidadDireccion = $('#MainContent_usrControlRemitente_ddlDireccion').val();
    //}

    //Información del destinatario
    var Destinatario = new Object();
    Destinatario.IdRemitente = ($('#MainContent_usrControlDestinatario_IdEntidad').val() != "") ? $('#MainContent_usrControlDestinatario_IdEntidad').val():0;
    Destinatario.Nombre = $('#MainContent_usrControlDestinatario_txtNombre').val();
    Destinatario.IdTipoDocumento = $('#MainContent_usrControlDestinatario_ddlTipoDocumento').val();
    Destinatario.NumDocumento = $('#MainContent_usrControlDestinatario_txtDocumento').val();
    
    EntidadDireccionesDestinatario = new Array();
    var dir2 = {
        "IdEntidadDireccion" : ($('#MainContent_usrControlDestinatario_ddlDireccion').val() == "") ? "0" : $('#MainContent_usrControlDestinatario_ddlDireccion').val(),
        "Direccion" : $('#MainContent_usrControlDestinatario_txtDireccion').val(),
        "IdCiudad" : (Destinatario.IdRemitente > 0)?"0":$('#MainContent_usrControlDestinatario_ddlCiudad').val(),
        "Telefono1" : $('#MainContent_usrControlDestinatario_txtTelefono1').val(),
        "Telefono2" : $('#MainContent_usrControlDestinatario_txtTelefono2').val(),
        "PorDefecto" : $('#MainContent_usrControlDestinatario_chkPorDefecto').is(':checked')
    };
    EntidadDireccionesDestinatario[0] = dir2;
    Destinatario.EntidadDirecciones = EntidadDireccionesDestinatario;
    //var Destinatario = {
    //    "IdRemitente": ($('#MainContent_usrControlDestinatario_IdEntidad').val() != "") ? $('#MainContent_usrControlDestinatario_IdEntidad').val():0,
    //    "Nombre": $('#MainContent_usrControlDestinatario_txtNombre').val(),
    //    "IdTipoDocumento": $('#MainContent_usrControlDestinatario_ddlTipoDocumento').val(),
    //    "NumDocumento": $('#MainContent_usrControlDestinatario_txtDocumento').val()
    //};
    //Destinatario.EntidadDireccion = {
    //    "IdEntidadDireccion": ($('#MainContent_usrControlDestinatario_ddlDireccion').val() == "") ? 0 : $('#MainContent_usrControlDestinatario_ddlDireccion').val(),
    //    "Direccion": $('#MainContent_usrControlDestinatario_txtDireccion').val(),
    //    "IdCiudad": $('#MainContent_usrControlDestinatario_ddlCiudad').val(),
    //    "Telefono1": $('#MainContent_usrControlDestinatario_txtTelefono1').val(),
    //    "Telefono2": $('#MainContent_usrControlDestinatario_txtTelefono2').val(),
    //    "PorDefecto": $('#MainContent_usrControlDestinatario_chkPorDefecto').is(':checked')
    //};
    //var destinatario = new Array();
    //if ($('#MainContent_usrControlDestinatario_IdEntidad').val() != "") {
    //    destinatario.IdRemitente = $('#MainContent_usrControlDestinatario_IdEntidad').val();
    //} else {
    //    destinatario.Nombre = $('#MainContent_usrControlDestinatario_txtNombre').val();
    //    destinatario.IdTipoDocumento = $('#MainContent_usrControlDestinatario_ddlTipoDocumento').val();
    //    destinatario.NumDocumento = $('#MainContent_usrControlDestinatario_txtDocumento').val();
    //}
    //destinatario.EntidadDireccion = new Array();
    //if ($('#MainContent_usrControlDestinatario_ddlDireccion').val() == "") {
    //    destinatario.EntidadDireccion.IdEntidadDireccion = 0;
    //    destinatario.EntidadDireccion.Direccion = $('#MainContent_usrControlDestinatario_txtDireccion').val();
    //    destinatario.EntidadDireccion.IdCiudad = $('#MainContent_usrControlDestinatario_ddlCiudad').val();
    //    destinatario.EntidadDireccion.Telefono1 = $('#MainContent_usrControlDestinatario_txtTelefono1').val();
    //    destinatario.EntidadDireccion.Telefono2 = $('#MainContent_usrControlDestinatario_txtTelefono2').val();
    //    destinatario.EntidadDireccion.PorDefecto = $('#MainContent_usrControlDestinatario_chkPorDefecto').is(':checked');
    //} else {
    //    destinatario.EntidadDireccion.IdEntidadDireccion = $('#MainContent_usrControlDestinatario_ddlDireccion').val();
    //}

    //Información del envio
    //var Envio = {
    //    "IdOrigen" : $('#MainContent_usrControlDetallesEnvio_ddlOrigen').val(),
    //    "IdDestino": $('#MainContent_usrControlDetallesEnvio_ddlDestino').val(),
    //    "RecogidoPor" : $('#MainContent_usrControlDetallesEnvio_txtRecogido').val(),
    //    "Ruta" : $('#MainContent_usrControlDetallesEnvio_txtRuta').val(),
    //    "Valor" : $('#MainContent_usrControlDetallesEnvio_txtValor').val(),
    //    "IdSeguro" : $('#MainContent_usrControlDetallesEnvio_rbtnListEnvioSeguro').val()
    //};
    //Envio.TiposContenidos = new Array();
    //var i = 0;
    //$('#MainContent_chkListTiposContenidos').find('input[type="checkbox"]:checked').each(function () {
    //    var contenido = {"TipoContenido":{
    //        "IdTipoContenido":$(this).val()
    //    }};

    //    Envio.TiposContenidos[0] = contenido;
    //    i++;
//});

    var Envio = new Object();
    Envio.IdOrigen = $('#MainContent_usrControlDetallesEnvio_ddlOrigen').val();
    Envio.IdDestino = $('#MainContent_usrControlDetallesEnvio_ddlDestino').val();
    Envio.RecogidoPor = $('#MainContent_usrControlDetallesEnvio_txtRecogido').val();
    Envio.Ruta = $('#MainContent_usrControlDetallesEnvio_txtRuta').val();
    Envio.Valor = $('#MainContent_usrControlDetallesEnvio_txtValor').val();
    Envio.IdSeguro = $('#MainContent_usrControlDetallesEnvio_rbtnListEnvioSeguro').find('input[type="radio"]:checked').val();
    
    var TiposContenidos = new Array();
    var i = 0;
    $('#MainContent_chkListTiposContenidos').find('input[type="checkbox"]:checked').each(function () {
        var TipoContenido = {

            "IdTipoContenido": $(this).val()
        };

        TiposContenidos[i] = TipoContenido;
        i++;
    });
    
    Envio.Remitente = Remitente;
    Envio.Destinatario = Destinatario;
    Envio.TiposContenidos = TiposContenidos;
    //var json = JSON.stringify(Envio);
    //alert(json);
    alert(JSON.stringify({ 'Envio': Envio }));
    //AjaxCall("../WebServices/MonteroExpressWS.asmx/InsertarEnvio", {'Envio':Envio}, "", MostrarAlerta);
    //rbtnListEnvioSeguro
    $.ajax({
        type: "POST",
        url: '../WebServices/MonteroExpressWS.asmx/InsertarEnvio',
        data: JSON.stringify({ 'Envio': Envio }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //Llamada a la funcion para el callback
            
           MostrarDialogo("Mensaje informativo", "La acción se realizó exitosamente.");            
        }, error: function (jqXHR, textStatus, errorThrown) {
            MostrarAlerta("error", textStatus);
        }
    });
}