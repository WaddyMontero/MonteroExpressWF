function MostrarAlerta(tipoAlerta,mensaje)
{
        //$("<div id='message' title='"+titulo+"'> '"+mensaje+"'</div>").dialog({

        //    resizable: false,

        //    height: 140,

        //    modal: true,

        //    buttons: {

        //        "Cerrar": function () {

        //            $(this).dialog("close");

        //        }//,

        //        //Cancel: function () {

        //        //    $(this).dialog("close");

        //        //}

        //    }

    //});
    var height = window.screen.availHeight
    var width = window.screen.availWidth
    $('<div class="alert alert-'+tipoAlerta+' alert-dismissable" style="z-index:9000;position:absolute;top:10%;left:40%"><button type = "button" class = "close" data-dismiss = "alert" aria-hidden = "true">&times;</button>'+mensaje+'</div>').appendTo($('form'));
    //$('<div id="message" title='+titulo+'> '+mensaje+'</div>');//.alert();
}

function MostrarDialogo(titulo, mensaje) {
    var modal = $('<!-- Modal -->' +
        '<div id="myCustomModal" class="modal fade in" style="padding-left: 17px; display: block;" role="dialog">' +
        '<div class="modal-dialog">' +
        '<!-- Modal content-->' +
        '<div class="modal-content">' +
        '<div class="modal-header">' +
        '<button type="button" class="close" data-dismiss="modal">&times;</button>' +
        '<h4 class="modal-title">'+titulo+'</h4>' +
        '</div>' +
        '<div class="modal-body">' +
        '<p>'+mensaje+'</p>' +
        '</div>' +
        '<div class="modal-footer">' +
        '<button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>' +
        '</div>' +
        '</div>' +
        '</div>' +
        '</div>');
    modal.appendTo($('form'));
    //$('<div id="message" title='+titulo+'> '+mensaje+'</div>');//.alert();
}

function AjaxCall(url, data,idContenedor ,callBackFunction)
{ 
    $.ajax({
        type: "POST",
        url: url,
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            //Llamada a la funcion para el callback
            callBackFunction(idContenedor, data);
        }, error: function (jqXHR, textStatus, errorThrown) {
            ImprimirAlerta("error", textStatus);
        }
    });
}
//Reinicia el dropdown de direcciones por el id.
function restartDropDown(id,value,text) {
    $('#' + id).empty();
    $('#' + id).append($('<option value="'+value+'" selected="selected">'+text+'</option>'));
}

function CargarDropDown(idDropDown, options) {
    if (options.d.length > 0) {
        for (var i = 0; i < options.d.length; i++) {
            $('#' + idDropDown).append($('<option value="' + options.d[i].Value + '">' + options.d[i].Text + '</option>'));
        }
    }
    
}