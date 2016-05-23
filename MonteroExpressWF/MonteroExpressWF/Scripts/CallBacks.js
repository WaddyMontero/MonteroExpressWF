//Busca una entidad
function BuscarEntidadCallBack(idContenedor, data)
{
    $('#' + idContenedor + 'IdEntidad').val('');    
    if (data.d != undefined) {
        $('#' + idContenedor + 'IdEntidad').val(data.d.IdEntidad);
        $('#' + idContenedor + 'txtNombre').val(data.d.Nombre);
        restartDropDown(idContenedor + 'ddlDireccion', '', 'Agregar nueva dirección');
        if (data.d.EntidadDirecciones) {
            var direcciones = data.d.EntidadDirecciones;
            var direccionPorDefecto = false;
            for (var i = 0; i < direcciones.length; i++)
            {
                if (direcciones[i].PorDefecto == true) {
                    direccionPorDefecto = true;
                }
                $('#' + idContenedor + 'ddlDireccion').append($('<option '+((direcciones[i].PorDefecto == true)?"selected=selected":"")+' value="' + direcciones[i].IdEntidadDireccion + '">' + direcciones[i].Direccion + "," + direcciones[i].Ciudad.Nombre + '</option>'));
            }
            if (direccionPorDefecto == false) {
                $('#' + idContenedor + 'divDireccion').removeClass('hidden');
            } else {
                $('#' + idContenedor + 'divDireccion').addClass('hidden');
            }
            
        } else {
            $('#' + idContenedor + 'divDireccion').removeClass('hidden');
        }

    } else {
        //MostrarAlerta("info","El número de documento consultado no existe.");
        $('#' + idContenedor + 'divControles').removeClass('hidden');
        $('#MainContent_usrControlDestinatario_divActividad').addClass('hidden');
        $('#' + idContenedor + 'divDireccion').removeClass('hidden');        
        restartDropDown(idContenedor + 'ddlDireccion','','Agregar nueva dirección');
    }
    $('#' + idContenedor + 'divControles').removeClass('hidden');
}

function EnvioGuardadoCallBack(data)
{
    if (data.d.Result == "OK") {
        var btn = $('<button type="button" class="btn btn-default">Imprimir</button>').click(function () {
            window.open('http://monteroexpress.azurewebsites.net/Administracion/ImprimirEnvio.aspx?IdEnvio=' + data.d.IdEnvio);
            window.location.assign('http://monteroexpress.azurewebsites.net/Administracion/Dashboard.aspx');
        });
        MostrarDialogo('envioGuardadoCallbackOkModal',data.d.Title, data.d.Message, false, new Array(
            btn,
            $('<button type="button" class="btn btn-default">Nuevo Envio</button>').click(function () {
                window.location.assign('http://monteroexpress.azurewebsites.net/Administracion/RegistrarEnvio.aspx');
            })
            ));
    } else {
        MostrarDialogo('envioGuardadoCallbackErrorModal', data.d.Title, data.d.Message);
    }
   
    
}

function BuscarEnvioByAlbaranCallBack(data)
{
    if (data.d.Result == "OK") {
        //MostrarDialogo('buscarEnvioBYAlbaranCallbackOKModal', "Buscar envio a recibir", "Se encontró el envio", true, null, true, true);
        $('#hdfIdEnvio').val(data.d.Envio.IdEnvio);
        $('#lblRemitente').text(data.d.Envio.Remitente.Nombre);
        $('#lblDirRemitente').text(data.d.Envio.Remitente.EntidadDirecciones[0].Direccion + ", " + data.d.Envio.Remitente.EntidadDirecciones[0].Ciudad.Nombre + ", " + data.d.Envio.Remitente.EntidadDirecciones[0].Ciudad.Provincia.Nombre);
        $('#lblDestinatario').text(data.d.Envio.Destinatario.Nombre);
        $('#lblDirDestinatario').text(data.d.Envio.Destinatario.EntidadDirecciones[0].Direccion + ", " + data.d.Envio.Destinatario.EntidadDirecciones[0].Ciudad.Nombre + ", " + data.d.Envio.Destinatario.EntidadDirecciones[0].Ciudad.Provincia.Nombre);
        $('#lblPuertoOrigen').text(data.d.Envio.nombrePuertoOrigen);
        $('#lblPuertoDestino').text(data.d.Envio.nombrePuertoDestino);
        $('#lblFechaEnvio').text(data.d.Envio.Fecha);
        //$('#lblDirRemitente').val();
        for (var i = 0; i < data.d.Envio.PaquetesEnvios.length; i++) {
            $('#tblListaPaquetes').jtable('addRecord', {
                record: {
                    IdPaqueteEnvio: data.d.Envio.PaquetesEnvios[i].IdPaqueteEnvio,
                    Cantidad: data.d.Envio.PaquetesEnvios[i].Cantidad,
                    TamanioPaquete: data.d.Envio.PaquetesEnvios[i].TamanioPaquete.Descripcion,
                    Descripcion: data.d.Envio.PaquetesEnvios[i].Descripcion,
                    EstadoPaquete: data.d.Envio.PaquetesEnvios[i].Estado.Descripcion,
                    Peso: parseFloat(data.d.Envio.PaquetesEnvios[i].Peso)
                },
                clientOnly: true
            });
            $('#divDetalles').removeClass('hidden');
        }
    } else {
        MostrarDialogo('buscarEnvioBYAlbaranCallbackErrorModal', "Buscar envio a recibir", data.d.Message, true, null, true, true);
    }
}

function RecepcionEnvioCallback(data)
{
    if (data.d.Result == "OK") {
        var botones = new Array();
        botones[0] = $('<button type="button" class="btn btn-primary">Realizar otra recepción</button>').click(function () {
            LimpiarRecibirEnvioModal();
            $('#pnlRecepcion').removeClass('hidden');
            $('#divRecepcionEnvio').appendTo($('#ventanaRecibirEnvioModal').find('.modal-body'));
            $('#recepcionEnvioCallbackOkModal').modal('hide');
        });
        botones[1] = $('<button type="button" class="btn btn-danger">Finalizar</button>').click(function () {
            $('#ventanaRecibirEnvioModal').modal('hide');
            $('#recepcionEnvioCallbackOkModal').modal('hide');
            LimpiarRecibirEnvioModal();
        });
        
        MostrarDialogo("recepcionEnvioCallbackOkModal", "Recepción envio", data.d.Message,false,botones,false);

    } else {
        MostrarDialogo("recepcionEnvioCallbackOkModal", "Error en recepción de envio", data.d.Message, true);
    }

}

//Obtiene los 5 Remitentes que mas envios han hecho
function Top5EnviosCallback(data)
{
    var datos = new Array();
    if (data == undefined) {
        datos[i] = { label: 'No data', value: '100' };
    } else {
        for (var i = 0; i < data.d.length; i++) {
            datos[i] = { label: data.d[i].Key, value: data.d[i].Value };
        }
    }

    Morris.Donut({
        element: 'donut-comitente',
        data: datos
    });
}

function Top5RecepcionesCallback(data) {
    var datos = new Array();
    if (data == undefined) {
        datos[i] = { label: 'No data', value: '100' };
    } else {
    for (var i = 0; i < data.d.length; i++) {
        datos[i] = { label: data.d[i].Key, value: data.d[i].Value };
    }
    }
    Morris.Donut({
        element: 'donut-destinatario',
        data: datos
    });
}
//Total de envios del año actual segmentado POR MESES
function TotalEnviosPorMesCallback(data) {

    if (data == undefined) {
        Morris.Bar({
            element: 'barra',
            data: [
              { y: 'Enero', a: 0 },
              { y: 'Febrero', a: 0 },
              { y: 'Marzo', a: 0 },
              { y: 'Abril', a: 0 },
              { y: 'Mayo', a: 0 },
              { y: 'Junio', a: 0 },
              { y: 'Julio', a: 0 },
              { y: 'Agosto', a: 0 },
              { y: 'Septiembre', a: 0 },
              { y: 'Octubre', a: 0 },
              { y: 'Noviembre', a: 0 },
              { y: 'Diciembre', a: 0 }
            ],
            xkey: 'y',
            ykeys: ['a'],
            labels: ['Total']
        });
    } else {
        Morris.Bar({
            element: 'barra',
            data: [
                      { y: 'Enero', a: data.d[0].Value },
                  { y: 'Febrero', a: data.d[1].Value },
                  { y: 'Marzo', a: data.d[2].Value },
                  { y: 'Abril', a: data.d[3].Value },
                  { y: 'Mayo', a: data.d[4].Value },
                  { y: 'Junio', a: data.d[5].Value },
                  { y: 'Julio', a: data.d[6].Value },
                  { y: 'Agosto', a: data.d[7].Value },
                  { y: 'Septiembre', a: data.d[8].Value },
                  { y: 'Octubre', a: data.d[9].Value },
                  { y: 'Noviembre', a: data.d[10].Value },
                  { y: 'Diciembre', a: data.d[11].Value }
            ],
            xkey: 'y',
            ykeys: ['a'],
            labels: ['Total']
        });
    }
}