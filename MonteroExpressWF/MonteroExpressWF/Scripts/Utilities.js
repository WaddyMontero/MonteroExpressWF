function ImprimirDialogo(titulo,mensaje)
{
        $("<div id='message' title='"+titulo+"'> '"+mensaje+"'</div>").dialog({

            resizable: false,

            height: 140,

            modal: true,

            buttons: {

                "Cerrar": function () {

                    $(this).dialog("close");

                }//,

                //Cancel: function () {

                //    $(this).dialog("close");

                //}

            }

        });
    //$('<div id="message" title='+titulo+'> '+mensaje+'</div>');//.alert();
}