<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarEnvio.aspx.cs" Inherits="MonteroExpressWF.Administracion.RegistrarEnvio" %>

<%@ Register Src="~/UserControl/DatosGenerales.ascx" TagName="DatosGenerales" TagPrefix="DG" %>
<%@ Register Src="~/UserControl/DetallesEnvio.ascx" TagName="DetallesEnvio" TagPrefix="DE" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContentPlaceHolder">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#txtCantidad').mask('999999');
            $('#txtPrecioUnitario').mask('9999999.99');
            $('#txtPeso').mask('999999.99');
            //Dialogo para insertar un nuevo paquete al envio
            $("#divAgregarPaquete").dialog({
                resizable: true,
                height: "auto",
                modal: true,
                autoOpen:false,
                buttons: {
                    "Agregar": function () {
                        $('#divAgregarPaquete').validate({
                            submitHandler: function (form) {
                                alert('Validando');
                            },
                            onsubmit:false
                        });
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
                actions: {
                    listAction: '../WebServices/MonteroExpressWS.asmx/ListarPaquetes'
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
                        width: '15%',
                        create: true,
                        edit: true,
                        list: true
                    },
                    IdTamanioPaquete: {
                        title: 'Tamaño',
                        width: '12%',
                        input: function () {
                            var $ddl = $('<select id="ddlTamanoPaquete"></select>');
                            $.ajax({
                                type: "POST",
                                url: '../WebServices/MonteroExpressWS.asmx/ObtieneTamaniosPaquetes',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (data) {
                                    //Llamada a la funcion para el callback
                                    if (data!= undefined) {
                                        for (var i = 0; i < data.d.length;i++)
                                        {
                                            $ddl.append($('<option value="'+data.d[i].Value+'">'+data.d[i].Text+'</option>'));
                                        }
                                    }
                                }, error: function (jqXHR, textStatus, errorThrown) {
                                    ImprimirAlerta("error", textStatus);
                                }
                            });
                            return $ddl;
                        },
                        list: true
                    },
                    Descripcion: {
                        title: 'Descripción',
                        create: true,
                        edit: true,
                        list: true
                    },
                    PrecioUnitario: {
                        title: 'Precio Unit.',
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
                        input: function () {
                            var $ddl = $('<select id="ddlEstadoPaquete"></select>');
                            $.ajax({
                                type: "POST",
                                url: '../WebServices/MonteroExpressWS.asmx/ObtieneEstadosPaquetes',
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (data) {
                                    //Llamada a la funcion para el callback
                                    if (data != undefined) {
                                        for (var i = 0; i < data.d.length; i++) {
                                            $ddl.append($('<option value="' + data.d[i].Value + '">' + data.d[i].Text + '</option>'));
                                        }
                                    }
                                }, error: function (jqXHR, textStatus, errorThrown) {
                                    ImprimirAlerta("error", textStatus);
                                }
                            });
                            return $ddl;
                        },
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
                            //perform your custom job...
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

    </script>

</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    Datos Generales
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="panel panel-info">
                                <div class="panel-heading">Remitente</div>
                                <div class="panel-body">
                            <DG:DatosGenerales ID="usrControlRemitente" runat="server" />
                                </div>
                            </div>

                            <div class="panel panel-info">
                                <div class="panel-heading">Destinatario</div>
                                <div class="panel-body">
                                <DG:DatosGenerales ID="usrControlDestinatario" runat="server" />
                                </div>
                                </div>
                            <asp:CheckBoxList runat="server" CssClass="table table-responsive borderless" OnDataBound="chkListTiposContenidos_DataBound" ItemType="MonteroExpressWF.BOL.TipoContenido" RepeatColumns="3" RepeatDirection="Horizontal" ID="chkListTiposContenidos"></asp:CheckBoxList>
                        </div>
                        <div class="col-lg-6">
                            <DE:DetallesEnvio ID="usrControlDetallesEnvio" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div id="divAgregarPaquete" title="Agregar Paquete">
                                <div class="row">
                                    <div class="form-group">
                                        <label for="txtCantidad">Cantidad</label>
                                        <input type="text" required="required" class="form-control" id="txtCantidad"/>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label for="txtDescripcion">Descripción</label>
                                        <textarea class="form-control" id="txtDescripcion"></textarea>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label for="txtPrecioUnitario">Precio Unitario</label>
                                        <input type="text" class="form-control" id="txtPrecioUnitario"/>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label for="txtPeso">Peso</label>
                                        <input type="text" class="form-control" id="txtPeso"/>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <label for="ddlEstadoPaquete">Estado</label>
                                        <select runat="server" class="dropdown" id="ddlEstadoPaquete"></select>
                                    </div>
                                </div>
                            </div>
                            <div id="tblPaquetes"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


