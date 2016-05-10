var idPaquete = 0;
var paquetes = new Array();
$(document).ready(function () {

    $('#txtFecha').datepicker({
        dateFormat:'dd/mm/yy'
    });

    $("#formAgregarPaquete").validate({
        errorClass: 'control-label text-danger',
        rules: {
            txtCantidad: {
                required: true,
                digits:true
            },
            txtDescripcion: {
                required:true,
            },
            txtPeso: {
                digits:true
            },
            ddlTamanioPaquete: {
                required:true
            },
            ddlEstado: {
                required:true
            }
        }
    });

    $("#formRegistroEnvio").validate({
        errorClass: 'control-label text-danger',        
        rules: {
            // simple rule, converted to {required:true}
            txtAlbaran:{
                required:true,
                digits:true
            },
            txtFecha:{
                required:true,
                minlength:10
            },
            ctl00$MainContent$ddlOficina:
            {
                required:true
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
                required: true,
                numDocCompleto: true,
                DifNumDocumentoRemDes:true
            },
            ctl00$MainContent$usrControlDestinatario$txtDocumento: {
                required: true,
                numDocCompleto: true,
                DifNumDocumentoRemDes: true
            },
            txtNombre: {
                required:true
            },
            ddlDireccion: {
                required:true
            },           
            ctl00$MainContent$usrControlDetallesEnvio$ddlOrigen: {
                required:true
            }, ctl00$MainContent$usrControlDetallesEnvio$ddlDestino: {
                required:true
            }, ctl00$MainContent$usrControlDetallesEnvio$txtRecogido: {
                lettersonly:true
            }, ctl00$MainContent$usrControlDetallesEnvio$txtRuta: {
                lettersonly:true
            }, ctl00$MainContent$usrControlDetallesEnvio$txtValor: {
                required:true,
                number: true
            }, ctl00$MainContent$usrControlDestinatario$txtNombre: {
                required:true
            },
            ctl00$MainContent$usrControlDestinatario$txtDireccion: {
                required: '#MainContent_usrControlDestinatario_divDireccion:visible'
            },
            ctl00$MainContent$usrControlDestinatario$ddlCiudad: {
                required: '#MainContent_usrControlDestinatario_divDireccion:visible'
            },
            ctl00$MainContent$usrControlDestinatario$txtTelefono1: {
                required: '#MainContent_usrControlDestinatario_divDireccion:visible',
                minlength:12
            },
            ctl00$MainContent$usrControlDestinatario$txtTelefono2: {
                minlength: 12
            },
            ctl00$MainContent$usrControlRemitente$txtNombre: {
                required: true
            },
            ctl00$MainContent$usrControlRemitente$txtDireccion: {
                required: '#MainContent_usrControlRemitente_divDireccion:visible'
            },
            ctl00$MainContent$usrControlRemitente$ddlCiudad: {
                required: '#MainContent_usrControlRemitente_divDireccion:visible'
            },
            ctl00$MainContent$usrControlRemitente$txtTelefono1: {
                required: '#MainContent_usrControlRemitente_divDireccion:visible',
                minlength: 12
            },
            ctl00$MainContent$usrControlRemitente$txtTelefono2: {
                minlength:12
            }
        }
    });

    $.validator.addMethod( "numDocCompleto", function(value, element) {
        //ctl00$MainContent$usrControlRemitente$txtDocumento
        var idStartWith = element.id.split('_')[0] + '_' + element.id.split('_')[1] + '_';                
        var valueLength = $('#'+element.id).val().length;
        return this.optional(element) || valueLength >= $('#'+idStartWith+'Mascara').val().length;

    }, "Complete el # de documento.");

    $.validator.addMethod("DifNumDocumentoRemDes", function (value, element) {
        //ctl00$MainContent$usrControlRemitente$txtDocumento
        var idStartWith = element.id.split('_')[0] + '_' + element.id.split('_')[1] + '_';
        var compareControlId = '';
        if (element.id.split('_')[1] == 'usrControlRemitente') {
            compareControlId = element.id.split('_')[0] + '_usrControlDestinatario_txtDocumento';
        }else {
            compareControlId = element.id.split('_')[0] + '_usrControlRemitente_txtDocumento';
        }       
        var originalText = $('#' + element.id).val();
        var compareText = $('#'+compareControlId).val();
        return (originalText != compareText);

    }, "El # de documento del comitente y destinatario deben ser diferentes.");
    
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
                var validator = $("#formAgregarPaquete").validate();
                var validado = $("#formAgregarPaquete").valid();
                if (validado) {
                    idPaquete += 1;
                    $('#tblPaquetes').jtable('addRecord', {
                        record: {
                            IdPaqueteEnvio: idPaquete,
                            Cantidad: $('#txtCantidad').val(),
                            IdTamanioPaquete: parseInt($('#MainContent_ddlTamanioPaquete').val()),
                            Descripcion: $('#txtDescripcion').val(),
                            IdEstado: parseInt($('#MainContent_ddlEstado').val()),
                            Peso: parseFloat($('#txtPeso').val())
                        },
                        clientOnly: true
                    });
                    if ($('#lblValidacionPaquetes:visible')) {
                        $('#lblValidacionPaquetes').addClass('hidden');
                    }
                    $('#txtCantidad').val('');
                    $('#txtDescripcion').val('');
                    $('#txtPeso').val('');
                    $(this).dialog("close");
                }
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
                   // var contador = 0;
                    var $selectedRows = $('#tblPaquetes').jtable('selectedRows');
                    if ($selectedRows.length >0) {
                        $selectedRows.each(function () {
                            var record = $(this).data('record');
                            //var personId = record.PersonId;
                            $('#tblPaquetes').jtable('deleteRecord', {
                                key: record.IdPaqueteEnvio,
                                clientOnly: true
                            });
                            var index = paquetes.indexOf(record);
                            paquetes.splice(index, 1);
                        });
                    } else {
                        MostrarDialogo("Eliminar paquete","Seleccione el paquete que desea eliminar");
                    }
                                      
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

function CancelarRegistro()
{
    var botones = new Array();
    botones[0] = $('<input type="button" class="btn btn-primary" value="Aceptar"/>').click(function(){
        window.location('Dashboard.aspx');
    });
    MostrarDialogo('Cancelar registro','¿Confirma que desea cancelar el registro del envio?',true,botones);

}

function FormValido()
{
    var validator = $("#formRegistroEnvio").validate();
    var validado = validator.form();
    if ($('#MainContent_usrControlDetallesEnvio_rbtnListEnvioSeguro').find('input[type="radio"]:checked').length == 0) {
        validado = false;
        $('#lblValidacionSeguro').removeClass('hidden');
    } else {
        $('#lblValidacionSeguro').addClass('hidden');
    }
    if ($('#MainContent_chkListTiposContenidos').find('input[type="checkbox"]:checked').length == 0) {
        validado = false;
        $('#lblValidacionTiposContenidos').removeClass('hidden');
    } else {
        $('#lblValidacionTiposContenidos').addClass('hidden');
    }
    if (paquetes.length == 0) {
        validado = false;
        $('#lblValidacionPaquetes').removeClass('hidden');
    } else {
        $('#lblValidacionPaquetes').addClass('hidden');
    }
    
    return validado;   
}

function GuardarEnvio() {

    if (FormValido()) {        
        //Información del remitente
        var Remitente = new Object();

        Remitente.IdEntidad = parseInt(($('#MainContent_usrControlRemitente_IdEntidad').val() != "") ? $('#MainContent_usrControlRemitente_IdEntidad').val() : 0);
        Remitente.Nombre = $('#MainContent_usrControlRemitente_txtNombre').val();
        Remitente.IdTipoDocumento = parseInt($('#MainContent_usrControlRemitente_ddlTipoDocumento').val());
        Remitente.NumDocumento = $('#MainContent_usrControlRemitente_txtDocumento').val();

        var idDirRem = parseInt(($('#MainContent_usrControlRemitente_ddlDireccion').val() == "") ? "0" : $('#MainContent_usrControlRemitente_ddlDireccion').val());
        var EntidadDireccionesRemitente = new Array();
        var dir1 = {
            "IdEntidadDireccion": idDirRem,
            "Direccion" : $('#MainContent_usrControlRemitente_txtDireccion').val(),
            "IdCiudad": parseInt((idDirRem > 0) ? "0" : $('#MainContent_usrControlRemitente_ddlCiudad').val()),
            "Telefono1": $('#MainContent_usrControlRemitente_txtTelefono1').val(),
            "Telefono2": $('#MainContent_usrControlRemitente_txtTelefono2').val(),        
            "PorDefecto": $('#MainContent_usrControlRemitente_chkPorDefecto').is(':checked')
        };
        EntidadDireccionesRemitente[0] = dir1;
        Remitente.EntidadDirecciones = EntidadDireccionesRemitente;

        //Información del destinatario
        var Destinatario = new Object();
        Destinatario.IdEntidad = parseInt(($('#MainContent_usrControlDestinatario_IdEntidad').val() != "") ? $('#MainContent_usrControlDestinatario_IdEntidad').val() : 0);
        Destinatario.Nombre = $('#MainContent_usrControlDestinatario_txtNombre').val();
        Destinatario.IdTipoDocumento = parseInt($('#MainContent_usrControlDestinatario_ddlTipoDocumento').val());
        Destinatario.NumDocumento = $('#MainContent_usrControlDestinatario_txtDocumento').val();

        var IdDirDest = parseInt(($('#MainContent_usrControlDestinatario_ddlDireccion').val() == "") ? "0" : $('#MainContent_usrControlDestinatario_ddlDireccion').val());
        EntidadDireccionesDestinatario = new Array();
        var dir2 = {
            "IdEntidadDireccion" :IdDirDest,
            "Direccion" : $('#MainContent_usrControlDestinatario_txtDireccion').val(),
            "IdCiudad": parseInt((IdDirDest > 0) ? "0" : $('#MainContent_usrControlDestinatario_ddlCiudad').val()),
            "Telefono1" : $('#MainContent_usrControlDestinatario_txtTelefono1').val(),
            "Telefono2" : $('#MainContent_usrControlDestinatario_txtTelefono2').val(),
            "PorDefecto" : $('#MainContent_usrControlDestinatario_chkPorDefecto').is(':checked')
        };
        EntidadDireccionesDestinatario[0] = dir2;
        Destinatario.EntidadDirecciones = EntidadDireccionesDestinatario;

        var Envio = new Object();
        Envio.IdPuertoOrigen = parseInt($('#MainContent_usrControlDetallesEnvio_ddlOrigen').val());
        Envio.IdPuertoDestino = parseInt($('#MainContent_usrControlDetallesEnvio_ddlDestino').val());
        Envio.RecogidoPor = $('#MainContent_usrControlDetallesEnvio_txtRecogido').val();
        Envio.Ruta = $('#MainContent_usrControlDetallesEnvio_txtRuta').val();
        Envio.Valor = parseFloat($('#MainContent_usrControlDetallesEnvio_txtValor').val());
        Envio.IdSeguro = parseInt($('#MainContent_usrControlDetallesEnvio_rbtnListEnvioSeguro').find('input[type="radio"]:checked').val());
        Envio.AlbaranNum = $('#txtAlbaran').val();
        Envio.IdOficina = parseInt($('#MainContent_ddlOficina').val());
        Envio.IdEstado = parseInt($('#MainContent_ddlEstadoEnvio').val());
        Envio.FechaString = $('#txtFecha').val();
        //Tipos de contenido del envio
        Envio.TiposContenidos = new Array();
        var i = 0;
        $('#MainContent_chkListTiposContenidos').find('input[type="checkbox"]:checked').each(function () {
            var TipoContenido = {

                "IdTipoContenido": parseInt($(this).val())
            };

            Envio.TiposContenidos[i] = TipoContenido;
            i++;
        });

        Envio.Remitente = Remitente;
        Envio.Destinatario = Destinatario;    

        //Paquetes del envio
        Envio.PaquetesEnvios = new Array();
        Envio.PaquetesEnvios = paquetes;

        //Guardando la información...
        AjaxCall("../WebServices/MonteroExpressWS.asmx/InsertarEnvio", { 'Envio': Envio }, "", EnvioGuardadoCallBack);        
    }
}