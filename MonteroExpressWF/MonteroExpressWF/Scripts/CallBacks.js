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
        MostrarDialogo(data.d.Title, data.d.Message, false, new Array(
            btn,
            $('<button type="button" class="btn btn-default">Nuevo Envio</button>').click(function () {
                window.location.assign('http://monteroexpress.azurewebsites.net/Administracion/RegistrarEnvio.aspx');
            })
            ));
    } else {
        MostrarDialogo(data.d.Title, data.d.Message);
    }
   
    
}

function BuscarEnvioByAlbaranCallBack(data)
{
    if (data.d.Result == "OK") {
        alert('Fue OK');
    } else {
        MostrarDialogo("Buscar envio a recibir", data.d.Message, true, null);
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