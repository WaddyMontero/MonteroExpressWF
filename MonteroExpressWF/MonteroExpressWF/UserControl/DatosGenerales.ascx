<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatosGenerales.ascx.cs" Inherits="MonteroExpressWF.UserControl.DatosGenerales" %>
<script src="../Scripts/jquery.mask.min.js"></script>
<script type="text/javascript">

    $(document).ready(function () {

        $('#<%= ddlDireccion.ClientID %>').change(function () {
            var idStartWith = $(this).attr('id').split('_')[0] + '_' + $(this).attr('id').split('_')[1]+'_';
            if ($(this).val()=="") {
                $('#' + idStartWith + 'divDireccion').removeClass('hidden');
            } else {
                $('#' + idStartWith + 'divDireccion').addClass('hidden');
            }

        });
        if ($('#<%= ddlTipoDocumento.ClientID %>').val() == '') {
            $('#<%= txtDocumento.ClientID %>').attr('disabled', 'disabled');
            $('#<%= btnBuscar.ClientID %>').attr('disabled', 'disabled');
            $('#' + idStartWith + 'divDireccion').addClass('hidden');
            $('#' + idStartWith + 'divControles').addClass('hidden');
        } 

        $('#<%= ddlTipoDocumento.ClientID %>').change(function () {
            alert('funciona');
            if ($(this).val() == '') {
                $('#<%= txtDocumento.ClientID %>').attr('disabled', 'disabled');
                $('#<%= btnBuscar.ClientID %>').attr('disabled', 'disabled');
                $('#' + idStartWith + 'divDireccion').addClass('hidden');
     
            } else {
                $.ajax({
                    type: "POST",
                    url: "../WebServices/MonteroExpressWS.asmx/ObtenerTipoDocumento",
                    data: JSON.stringify({ 'IdTipoDocumento': parseInt($('#<%= ddlTipoDocumento.ClientID %>').val()) }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //$('#txtNumDocumento').removeAttr("disabled");
                        //$('#txtNumDocumento').mask(data.Mascara);
                        $('#<%= txtDocumento.ClientID %>').removeAttr('disabled');    
                        $('#<%= btnBuscar.ClientID %>').removeAttr('disabled');    
                        $('#<%= txtDocumento.ClientID %>').mask(data.d.Mascara);
                    }, error: function (jqXHR, textStatus, errorThrown) {
                        MostrarAlerta("error", textStatus);
                    }
                });
            }
        });
    });

    function Buscar(control) {
        idStartWith = control.id.split('_')[0] + '_' + control.id.split('_')[1]+'_';
        if ($('#' + idStartWith +'txtDocumento').val() == '') {
            //bootbox.alert('Debe digitar el # de documento que desea buscar');
            MostrarAlerta('warning', 'Debe digitar el # de documento que desea buscar');
            $('#' + idStartWith + 'divControles').addClass('hidden');
            //ImprimirDialogo('Prueba', 'Debe digitar el # de documento que desea buscar');
        } else {
            $('#' + idStartWith + 'divControles').removeClass('hidden');
            //AjaxCall("../WebServices/MonteroExpressWS.asmx/ObtenerEntidadDirecciones", { "NumDocumento": $('#' + idStartWith + '_' + 'txtDocumento').val() }, function (idStartWith, resultado) { })
        }
    }

</script>
<div class="panel panel-default">

    <div class="panel-body">
        <div class="row">
            <div class="col-lg-6 col-xs-12">
                <div class="form-group">
                    <label for="ddlTipoDocumento">DNI/NIF/Pasaporte:</label>
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlTipoDocumento" AppendDataBoundItems="true">
                        <asp:ListItem Value="" Text="Seleccione -->"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-6 col-xs-12">
                <div class="form-group">
                    <label for="txtDocumento"># Documento:</label>
                    <div class="input-group">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtDocumento"></asp:TextBox>
                        <span class="input-group-btn">
                            <asp:Button runat="server" CssClass="btn btn-info" ID="btnBuscar" Text="Buscar" OnClientClick="Buscar(this); return false;" />
                        </span>
                    </div>
                </div>
            </div>
        </div>

        <div runat="server" id="divControles" class="hidden" >
            <div class="row">
                <div class="col-lg-6 col-xs-12">
                    <div class="form-group">
                        <label for="txtNombre">Nombre/Razón Social:</label>
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-xs-12">
                        <div class="form-group">
                            <label for="ddlDireccion">Direcciones:</label>
                            <asp:DropDownList runat="server" ID="ddlDireccion" CssClass="form-control">
                                <asp:ListItem Value="1" Text="Prueba"></asp:ListItem>
                                <asp:ListItem Value="" Text="Agregar nueva dirección"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
            </div>
            <div runat="server" id="divDireccion" class="hidden">                
                <div class="row">
                    <div class="col-lg-6 col-xs-12">
                        <div class="form-group">
                            <label for="txtDirección">Dirección:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtDireccion" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6 col-xs-12">
                        <div class="form-group">
                            <label for="ddlPais">País:</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlPais">
                                <asp:ListItem Value="" Text="Seleccione -->"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6 col-xs-12">
                        <div class="form-group">
                            <label for="ddlProvincia">Provincia:</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlProvincia">
                                <asp:ListItem Value="" Text="Seleccione -->"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6 col-xs-12">
                        <div class="form-group">
                            <label for="ddlCiudad">Ciudad:</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCiudad">
                                <asp:ListItem Value="" Text="Seleccione -->"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6 col-xs-12">
                        <div class="form-group">
                            <label for="txtTelefono1">Teléfono 1:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtTelefono1"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6 col-xs-12">
                        <div class="form-group">
                            <label for="txtTelefono2">Teléfono 2:</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="txtTelefono2"></asp:TextBox>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </div>
</div>
