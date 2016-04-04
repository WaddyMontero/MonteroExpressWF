<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarEnvio.aspx.cs" Inherits="MonteroExpressWF.Administracion.RegistrarEnvio" %>

<%@ Register Src="~/UserControl/DatosGenerales.ascx" TagName="DatosGenerales" TagPrefix="DG" %>
<%@ Register Src="~/UserControl/DetallesEnvio.ascx" TagName="DetallesEnvio" TagPrefix="DE" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContentPlaceHolder">
    <script type="text/javascript">
        $(document).ready(function () {            
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
                    }
                },
                toolbar: {
                    items: [{
                        //icon: '/images/excel.png',
                        text: '+ Agregar',
                        //cssClass: "form-control",
                        click: function () {
                            $('#tblPaquetes').jtable();
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
                            <div id="tblPaquetes"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>


