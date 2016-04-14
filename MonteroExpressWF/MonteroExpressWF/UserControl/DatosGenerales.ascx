<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatosGenerales.ascx.cs" Inherits="MonteroExpressWF.UserControl.DatosGenerales" %>
<script src="../Scripts/jquery.mask.min.js"></script>
<script type="text/javascript">

    $(document).ready(function () {
        $('#<%= txtTelefono1.ClientID %>').mask('999-999-9999');
        $('#<%= txtTelefono2.ClientID %>').mask('999-999-9999');
        $('#<%= ddlDireccion.ClientID %>').change(function () {
            var idStartWith = $(this).attr('id').split('_')[0] + '_' + $(this).attr('id').split('_')[1] + '_';
            if ($(this).val() == "") {
                $('#' + idStartWith + 'divDireccion').removeClass('hidden');
            } else {
                $('#' + idStartWith + 'divDireccion').addClass('hidden');
            }

        });

        $('#<%= ddlPais.ClientID %>').change(function () {
            var idStartWith = $(this).attr('id').split('_')[0] + '_' + $(this).attr('id').split('_')[1] + '_';
            restartDropDown(idStartWith + 'ddlProvincia', '', 'Seleccione -->');
            restartDropDown(idStartWith + 'ddlCiudad', '', 'Seleccione -->');
            if ($(this).val() != "") {
                AjaxCall("../WebServices/MonteroExpressWS.asmx/ObtenerProvinciasByPais", { "IdPais": parseInt($(this).val()) }, idStartWith + 'ddlProvincia', CargarDropDown);
            }

        });

        $('#<%= ddlProvincia.ClientID %>').change(function () {
            var idStartWith = $(this).attr('id').split('_')[0] + '_' + $(this).attr('id').split('_')[1] + '_';
            restartDropDown(idStartWith + 'ddlCiudad', '', 'Seleccione -->');
            if ($(this).val() != "") {
                AjaxCall("../WebServices/MonteroExpressWS.asmx/ObtenerCiudadesByProvincia", { "IdProvincia": parseInt($(this).val()) }, idStartWith + 'ddlCiudad', CargarDropDown);
            }

        });


        if ($('#<%= ddlTipoDocumento.ClientID %>').val() == '') {
            $('#<%= txtDocumento.ClientID %>').attr('disabled', 'disabled');
            $('#<%= btnBuscar.ClientID %>').attr('disabled', 'disabled');
            //$('#' + idStartWith + 'divDireccion').addClass('hidden');
            //$('#' + idStartWith + 'divControles').addClass('hidden');
        }

        $('#<%= ddlTipoDocumento.ClientID %>').change(function () {
            var idStartWith = $(this).attr("id").split('_')[0] + '_' + $(this).attr("id").split('_')[1] + '_';
            if ($(this).val() == '') {
                $('#<%= txtDocumento.ClientID %>').attr('disabled', 'disabled');
                $('#<%= btnBuscar.ClientID %>').attr('disabled', 'disabled');
                $('#' + idStartWith + 'divControles').addClass('hidden');
                $('#' + idStartWith + 'divDireccion').addClass('hidden');
                $('#' + idStartWith + 'Mascara').val('');
                

            } else {
                $.ajax({
                    type: "POST",
                    url: "../WebServices/MonteroExpressWS.asmx/ObtenerTipoDocumento",
                    data: JSON.stringify({ 'IdTipoDocumento': parseInt($('#<%= ddlTipoDocumento.ClientID %>').val()) }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        if (data != undefined) {
                            $('#<%= txtDocumento.ClientID %>').removeAttr('disabled');
                            $('#<%= btnBuscar.ClientID %>').removeAttr('disabled');
                            $('#<%= txtDocumento.ClientID %>').mask(data.d.Mascara);
                            $('#' + idStartWith + 'Mascara').val(data.d.Mascara);
                        }
                        //$('#txtNumDocumento').removeAttr("disabled");
                        //$('#txtNumDocumento').mask(data.Mascara);

                    }, error: function (jqXHR, textStatus, errorThrown) {
                        MostrarAlerta("error", textStatus);
                    }
                });
            }
        });
    });

    function Buscar(control) {
        idStartWith = control.id.split('_')[0] + '_' + control.id.split('_')[1] + '_';
        if ($('#' + idStartWith + 'txtDocumento').val() == '') {
            //bootbox.alert('Debe digitar el # de documento que desea buscar');
            MostrarAlerta('warning', 'Debe digitar el # de documento que desea buscar');
            $('#' + idStartWith + 'divControles').addClass('hidden');
            //ImprimirDialogo('Prueba', 'Debe digitar el # de documento que desea buscar');
        } else {            
            AjaxCall("../WebServices/MonteroExpressWS.asmx/BuscarEntidad", { "NumDocumento": $('#' + idStartWith + 'txtDocumento').val() }, idStartWith, BuscarEntidadCallBack);
        }

    }

</script>
<div class="panel panel-default">
    <asp:HiddenField runat="server" ID="IdEntidad" />
    <asp:HiddenField runat="server" ID="Mascara" />
    <div class="panel-body">
        <div class="row">
            <div class="col-lg-6 col-xs-12">
                <div class="form-group">
                    <label for="ddlTipoDocumento">DNI/NIF/Pasaporte:</label>
                    <asp:DropDownList runat="server" CssClass="form-control" name="ddlTipoDocumento" ID="ddlTipoDocumento" AppendDataBoundItems="true">
                        <asp:ListItem Value="" Text="Seleccione -->"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-6 col-xs-12">
                <div class="form-group">
                    <label for="txtDocumento"># Documento:</label>
                    <div class="input-group">
                        <asp:TextBox runat="server" CssClass="form-control" name="txtDocumento" ID="txtDocumento"></asp:TextBox>
                        <span class="input-group-btn">
                            <input type="button" runat="server" class="btn btn-info" id="btnBuscar" value="Buscar" onclick="javascript: Buscar(this);" />
                        </span>
                    </div>
                </div>
            </div>
        </div>

        <div runat="server" id="divControles" class="hidden">
            <div class="row">
                <div class="col-lg-6 col-xs-12">
                    <div class="form-group">
                        <label for="txtNombre">Nombre/Razón Social:</label>
                        <asp:TextBox runat="server" name="txtNombre" CssClass="form-control entidad-group" ID="txtNombre"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-6 col-xs-12">
                    <div class="form-group">
                        <label for="ddlDireccion">Direcciones:</label>
                        <asp:DropDownList runat="server" name="ddlDireccion" ID="ddlDireccion" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div runat="server" id="divDireccion" class="hidden">
                <div class="row">
                    <div class="col-lg-6 col-xs-12">
                        <div class="form-group">
                            <label for="txtDirección">Dirección:</label>
                            <asp:TextBox runat="server" name="txtDireccion" CssClass="form-control entidad-group" ID="txtDireccion" TextMode="MultiLine"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6 col-xs-12">
                        <div class="form-group">
                            <label for="ddlPais">País:</label>
                            <asp:DropDownList runat="server" name="ddlPais" CssClass="form-control" AppendDataBoundItems="true" ID="ddlPais">
                                <asp:ListItem Value="" Text="Seleccione -->"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6 col-xs-12">
                        <div class="form-group">
                            <label for="ddlProvincia">Provincia:</label>
                            <asp:DropDownList runat="server" name="ddlProvincia" CssClass="form-control" ID="ddlProvincia">
                                <asp:ListItem Value="" Text="Seleccione -->"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6 col-xs-12">
                        <div class="form-group">
                            <label for="ddlCiudad">Ciudad:</label>
                            <asp:DropDownList runat="server" name="ddlCiudad" CssClass="form-control entidad-group" ID="ddlCiudad">
                                <asp:ListItem Value="" Text="Seleccione -->"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-6 col-xs-12">
                        <div class="form-group">
                            <label for="txtTelefono1">Teléfono 1:</label>
                            <asp:TextBox runat="server" name="txtTelefono1" CssClass="form-control entidad-group" ID="txtTelefono1"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6 col-xs-12">
                        <div class="form-group">
                            <label for="txtTelefono2">Teléfono 2:</label>
                            <asp:TextBox runat="server" name="txtTelefono2" CssClass="form-control" ID="txtTelefono2"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-6 col-xs-12">
                        <div class="checkbox">
                            <label>
                                <input type="checkbox" name="chkPorDefecto" id="chkPorDefecto">Dirección por defecto</label>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </div>
</div>
