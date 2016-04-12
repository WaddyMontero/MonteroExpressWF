var idPaquete = 0;
var paquetes = new Array();
$(document).ready(function () {

    $("#formRegistroEnvio").validate({
        rules: {
            // simple rule, converted to {required:true}
            txtAlbaran:{
                required:true,
                digits:true
            },
            ctl00$MainContent$ddlOficina:
            {
                required:true
            },

            // compound rule
            chkListTiposContenidos: {
                required: true,
                minlength:1                
            },
            ddlEstadoEnvio: {
                required:true
            },
            ctl00$MainContent$usrControlRemitente$ddlTipoDocumento: {
                required:true
            },
            ctl00$MainContent$usrControlDestinatario$ddlTipoDocumento: {
                required: true
            },
            ctl00$MainContent$usrControlRemitente$txtDocumento: {
                required:true
            },
            ctl00$MainContent$usrControlDestinatario$txtDocumento: {
                required: true
            },
            txtNombre: {
                required:true
            },
            ddlDireccion: {
                required:true
            },
            tblPaquetes: {
                required:true,
                minCantPaquetes: 1
            }
        }
    });
    //Metodo para validar los tipos de contenidos
    jQuery.validator.addMethod("minCantPaquetes", function (value, element) {
        return (paquetes.length >= value) ? true : false;
        alert((paquetes.length >= value));
    }, "Debe seleccionar los contenidos del envio");
    
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
                        Descripcion: $('#txtDescripcion').val(),
                        IdEstado: $('#MainContent_ddlEstado').val(),
                        Peso: $('#txtPeso').val()
                    },
                    clientOnly: true
                });
                $(this).dialog("close");
               // GuardarEnvio();
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
        },
        rowInserted: function (event, data) {
            //var paq = {
            //    "IdPaqueteEnvio":0,
            //    "Cantidad": data.record.Cantidad                
            //};
            paquetes[paquetes.length] = data.record;

        }

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

    var validator = $("#formRegistroEnvio").validate();
    validator.form();


    ////Información del remitente
    //var Remitente = new Object();
    
    //Remitente.IdEntidad = ($('#MainContent_usrControlRemitente_IdEntidad').val() != "") ? $('#MainContent_usrControlRemitente_IdEntidad').val() : 0;
    //Remitente.Nombre = $('#MainContent_usrControlRemitente_txtNombre').val();
    //Remitente.IdTipoDocumento = $('#MainContent_usrControlRemitente_ddlTipoDocumento').val();
    //Remitente.NumDocumento = $('#MainContent_usrControlRemitente_txtDocumento').val();
    
    //var EntidadDireccionesRemitente = new Array();
    //var dir1 = {
    //    "IdEntidadDireccion" : ($('#MainContent_usrControlRemitente_ddlDireccion').val() == "") ? "0" : $('#MainContent_usrControlRemitente_ddlDireccion').val(),
    //    "Direccion" : $('#MainContent_usrControlRemitente_txtDireccion').val(),
    //    "IdCiudad" : (Remitente.IdRemitente > 0)?"0":$('#MainContent_usrControlRemitente_ddlCiudad').val(),
    //    "Telefono1": $('#MainContent_usrControlRemitente_txtTelefono1').val(),
    //    "Telefono2": $('#MainContent_usrControlRemitente_txtTelefono2').val(),        
    //    "PorDefecto": $('#MainContent_usrControlRemitente_chkPorDefecto').is(':checked')
    //};
    //EntidadDireccionesRemitente[0] = dir1;
    //Remitente.EntidadDirecciones = EntidadDireccionesRemitente;

    ////Información del destinatario
    //var Destinatario = new Object();
    //Destinatario.IdEntidad = ($('#MainContent_usrControlDestinatario_IdEntidad').val() != "") ? $('#MainContent_usrControlDestinatario_IdEntidad').val() : 0;
    //Destinatario.Nombre = $('#MainContent_usrControlDestinatario_txtNombre').val();
    //Destinatario.IdTipoDocumento = $('#MainContent_usrControlDestinatario_ddlTipoDocumento').val();
    //Destinatario.NumDocumento = $('#MainContent_usrControlDestinatario_txtDocumento').val();
    
    //EntidadDireccionesDestinatario = new Array();
    //var dir2 = {
    //    "IdEntidadDireccion" : ($('#MainContent_usrControlDestinatario_ddlDireccion').val() == "") ? "0" : $('#MainContent_usrControlDestinatario_ddlDireccion').val(),
    //    "Direccion" : $('#MainContent_usrControlDestinatario_txtDireccion').val(),
    //    "IdCiudad" : (Destinatario.IdRemitente > 0)?"0":$('#MainContent_usrControlDestinatario_ddlCiudad').val(),
    //    "Telefono1" : $('#MainContent_usrControlDestinatario_txtTelefono1').val(),
    //    "Telefono2" : $('#MainContent_usrControlDestinatario_txtTelefono2').val(),
    //    "PorDefecto" : $('#MainContent_usrControlDestinatario_chkPorDefecto').is(':checked')
    //};
    //EntidadDireccionesDestinatario[0] = dir2;
    //Destinatario.EntidadDirecciones = EntidadDireccionesDestinatario;

    //var Envio = new Object();
    //Envio.IdOrigen = $('#MainContent_usrControlDetallesEnvio_ddlOrigen').val();
    //Envio.IdDestino = $('#MainContent_usrControlDetallesEnvio_ddlDestino').val();
    //Envio.RecogidoPor = $('#MainContent_usrControlDetallesEnvio_txtRecogido').val();
    //Envio.Ruta = $('#MainContent_usrControlDetallesEnvio_txtRuta').val();
    //Envio.Valor = $('#MainContent_usrControlDetallesEnvio_txtValor').val();
    //Envio.IdSeguro = $('#MainContent_usrControlDetallesEnvio_rbtnListEnvioSeguro').find('input[type="radio"]:checked').val();
    //Envio.AlbaranNum = $('#txtAlbaran').val();
    //Envio.IdOficina = $('#MainContent_ddlOficina').val();
    
    ////Tipos de contenido del envio
    //Envio.TiposContenidos = new Array();
    //var i = 0;
    //$('#MainContent_chkListTiposContenidos').find('input[type="checkbox"]:checked').each(function () {
    //    var TipoContenido = {

    //        "IdTipoContenido": $(this).val()
    //    };

    //    Envio.TiposContenidos[i] = TipoContenido;
    //    i++;
    //});
    
    //Envio.Remitente = Remitente;
    //Envio.Destinatario = Destinatario;    

    ////Paquetes del envio
    //Envio.PaquetesEnvios = new Array();
    //Envio.PaquetesEnvios = paquetes;

    ////Guardando la información...
    //AjaxCall("../WebServices/MonteroExpressWS.asmx/InsertarEnvio", { 'Envio': Envio }, "", EnvioGuardadoCallBack);
    ////$.ajax({
    ////    type: "POST",
    ////    url: '../WebServices/MonteroExpressWS.asmx/InsertarEnvio',
    ////    data: JSON.stringify({ 'Envio': Envio }),
    ////    contentType: "application/json; charset=utf-8",
    ////    dataType: "json",
    ////    success: function (result) {
    ////        //Llamada a la funcion para el callback
    ////        MostrarDialogo(result.d.Result, result.d.Message);
    ////    }, error: function (jqXHR, textStatus, errorThrown) {
    ////        MostrarDialogo("Guardar envio", textStatus +"\nHa ocurrido un error al guardar el envio. Si el problema persiste contacte su administrador.");
    ////    }
    ////});
}