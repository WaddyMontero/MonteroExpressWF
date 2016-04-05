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
                        IdTamanioPaquete: $('#<%= ddlTamanioPaquete.ClientID %>').val(),
                        Descripcion: $('#txtDescripcion').text(),
                        IdEstado: $('#<%= ddlEstado.ClientID %>').val(),
                        Peso: $('#txtPeso').val()
                    },
                    clientOnly: true
                });
                //$('#tblPaquetes')
                $(this).dialog("close");
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
                //input: function () {
                //    var $ddl = $('<select id="ddlEstadoPaquete"></select>');
                //    $.ajax({
                //        type: "POST",
                //        url: '../WebServices/MonteroExpressWS.asmx/ObtieneEstadosPaquetes',
                //        contentType: "application/json; charset=utf-8",
                //        dataType: "json",
                //        success: function (data) {
                //            //Llamada a la funcion para el callback
                //            if (data != undefined) {
                //                for (var i = 0; i < data.d.length; i++) {
                //                    $ddl.append($('<option value="' + data.d[i].Value + '">' + data.d[i].Text + '</option>'));
                //                }
                //            }
                //        }, error: function (jqXHR, textStatus, errorThrown) {
                //            ImprimirAlerta("error", textStatus);
                //        }
                //    });
                //    return $ddl;
                //},
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
        },

        //Initialize validation logic when a form is created
        formCreated: function (event, data) {
            data.form.find('input[name="Cantidad"]').addClass('validate[required]');
            data.form.find('input[name="Descripcion"]').addClass('validate[required]');
            data.form.find('input[name="PrecioUnitario"]').addClass('validate[required]');
            data.form.find('input[name="Peso"]').addClass('validate[required]');
            data.form.validationEngine();
        },
        //Validate form when it is being submitted
        formSubmitting: function (event, data) {
            return data.form.validationEngine('validate');
        },
        //Dispose validation logic when form is closed
        formClosed: function (event, data) {
            data.form.validationEngine('hide');
            data.form.validationEngine('detach');
        }
    });

    //    //Load student list from server
    //$('#tblPaquetes').jtable('load');

});


function GuardarEnvio() {
    //Información del remitente
    var remitente = new Array();
    if ($('#MainContent_usrControlRemitente_IdEntidad').val() != "") {
        remitente.IdRemitente = $('#MainContent_usrControlRemitente_IdEntidad').val();
    } else {
        remitente.IdRemitente = 0;
        remitente.Nombre = $('#MainContent_usrControlRemitente_txtNombre').val();
        remitente.IdTipoDocumento = $('#MainContent_usrControlRemitente_ddlTipoDocumento').val();
        remitente.NumDocumento = $('#MainContent_usrControlRemitente_txtNumDocumento').val();
    }
    remitente.EntidadDireccion = new Array();
    if ($('#MainContent_usrControlRemitente_ddlDireccion').val() == "") {
        remitente.EntidadDireccion.IdEntidadDireccion = 0;
        remitente.EntidadDireccion.Direccion = $('#MainContent_usrControlRemitente_txtDireccion').val();
        remitente.EntidadDireccion.IdCiudad = $('#MainContent_usrControlRemitente_ddlCiudad').val();
        remitente.EntidadDireccion.Telefono1 = $('#MainContent_usrControlRemitente_txtTelefono1').val();
        remitente.EntidadDireccion.Telefono2 = $('#MainContent_usrControlRemitente_txtTelefono2').val();
        remitente.EntidadDireccion.PorDefecto = $('#MainContent_usrControlRemitente_chkPorDefecto').is(':checked');
    } else {
        remitente.EntidadDireccion.IdEntidadDireccion = $('#MainContent_usrControlRemitente_ddlDireccion').val();
    }
    remitente.Detalles = new Array();
    remitente.Detalles.Origen = $('#MainContent_usrControlRemitente_txtOrigen').val();
    remitente.Detalles.Destino = $('#MainContent_usrControlRemitente_txtDestino').val();
    remitente.Detalles.RecogidoPor = $('#MainContent_usrControlRemitente_txtRecogido').val();
    remitente.Detalles.Ruta = $('#MainContent_usrControlRemitente_txtRuta').val();


    //Información del destinatario
    var destinatario = new Array();
    if ($('#MainContent_usrControlDestinatario_IdEntidad').val() != "") {
        destinatario.IdRemitente = $('#MainContent_usrControlDestinatario_IdEntidad').val();
    } else {
        destinatario.Nombre = $('#MainContent_usrControlDestinatario_txtNombre').val();
        destinatario.IdTipoDocumento = $('#MainContent_usrControlDestinatario_ddlTipoDocumento').val();
        destinatario.NumDocumento = $('#MainContent_usrControlDestinatario_txtNumDocumento').val();
    }
    destinatario.EntidadDireccion = new Array();
    if ($('#MainContent_usrControlDestinatario_ddlDireccion').val() == "") {
        destinatario.EntidadDireccion.IdEntidadDireccion = 0;
        destinatario.EntidadDireccion.Direccion = $('#MainContent_usrControlDestinatario_txtDireccion').val();
        destinatario.EntidadDireccion.IdCiudad = $('#MainContent_usrControlDestinatario_ddlCiudad').val();
        destinatario.EntidadDireccion.Telefono1 = $('#MainContent_usrControlDestinatario_txtTelefono1').val();
        destinatario.EntidadDireccion.Telefono2 = $('#MainContent_usrControlDestinatario_txtTelefono2').val();
        destinatario.EntidadDireccion.PorDefecto = $('#MainContent_usrControlDestinatario_chkPorDefecto').is(':checked');
    } else {
        destinatario.EntidadDireccion.IdEntidadDireccion = $('#MainContent_usrControlDestinatario_ddlDireccion').val();
    }
    remitente.Detalles = new Array();
    remitente.Detalles.Origen = $('#MainContent_usrControlDestinatario_txtOrigen').val();
    remitente.Detalles.Destino = $('#MainContent_usrControlDestinatario_txtDestino').val();
    remitente.Detalles.RecogidoPor = $('#MainContent_usrControlDestinatario_txtRecogido').val();
    remitente.Detalles.Ruta = $('#MainContent_usrControlDestinatario_txtRuta').val();

}