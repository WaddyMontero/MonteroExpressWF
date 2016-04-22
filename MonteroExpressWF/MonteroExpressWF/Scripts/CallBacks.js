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
            for (var i = 0; i < direcciones.length; i++)
            {
                $('#' + idContenedor + 'ddlDireccion').append($('<option '+((direcciones[i].PorDefecto == true)?"selected=selected":"")+' value="' + direcciones[i].IdEntidadDireccion + '">' + direcciones[i].Direccion + "," + direcciones[i].Ciudad.Nombre + '</option>'));
            }
            $('#' + idContenedor + 'divDireccion').addClass('hidden');
        } else {
            $('#' + idContenedor + 'divDireccion').removeClass('hidden');
        }

    } else {
        MostrarAlerta("info","El número de documento consultado no existe.");
        $('#' + idContenedor + 'divControles').removeClass('hidden');
        $('#' + idContenedor + 'divDireccion').removeClass('hidden');        
        restartDropDown(idContenedor + 'ddlDireccion','','Agregar nueva dirección');
    }
    $('#' + idContenedor + 'divControles').removeClass('hidden');
}

function EnvioGuardadoCallBack(IdContenedor, data)
{
    if (data.d.Result == "OK") {
        var btn = $('<button type="button" class="btn btn-default">Imprimir</button>').click(function () {
            window.location('ImprimirEnvio.aspx?IdEnvio=' + data.d.IdEnvio);
        });
        MostrarDialogo(data.d.Title, data.d.Message, false, new Array(
            btn,
            $('<button type="button" class="btn btn-default">Nuevo Envio</button>').click(function () {
                window.location('RegistrarEnvio.aspx');
            })
            ));
    } else {
        MostrarDialogo(data.d.Title, data.d.Message);
    }
   
    
}


//Obtiene los 5 Remitentes que mas envios han hecho
function Top5EnviosCallback(data)
{
    var datos = new Array();
    for (var i = 0; i < data.d.length; i++) {
        datos[i] = { label: data.d[i].Key, value: data.d[i].Value };
    }

    Morris.Donut({
        element: 'donut-comitente',
        data: datos
    });
}

function Top5RecepcionesCallback(data) {
    var datos = new Array();
    for (var i = 0; i < data.d.length; i++) {
        datos[i] = { label: data.d[i].Key, value: data.d[i].Value };
    }

    Morris.Donut({
        element: 'donut-destinatario',
        data: datos
    });

}
//Total de envios del año actual segmentado POR MESES
function TotalEnviosPorMesCallback(data) {

    Morris.Bar({
        element: 'barra',
        data: [
          { y: 'Enero', a: data.d[0].Value},
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