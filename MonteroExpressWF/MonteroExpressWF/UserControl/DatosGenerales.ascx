<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatosGenerales.ascx.cs" Inherits="MonteroExpressWF.UserControl.DatosGenerales" %>
<script type="text/javascript">

    $(document).ready(function () {
        if ($('#<%= ddlTipoDocumento.ClientID %>').val() == '') {
            $('#<%= txtDocumento.ClientID %>').attr('disabled', 'disabled');
        }

        $('#<%= ddlTipoDocumento.ClientID %>').change(function () {            
            if ($(this).val() == '') {
                $('#<%= txtDocumento.ClientID %>').attr('disabled', 'disabled');
            } else {
                $.ajax({
                    type: "POST",
                    url: "../WebServices/MonteroExpressWS.asmx/ObtenerTipoDocumento",
                    data: { IdTipoDocumento: $('#<%= ddlTipoDocumento.ClientID %>').val() },
                    //contentType: "application/json; charset=utf-8",
                    success: function (data) {
                        //$('#txtNumDocumento').removeAttr("disabled");
                        //$('#txtNumDocumento').mask(data.Mascara);
                        alert(data[0]);
                    }, error: function () {
                        alert('ocurrio un error');
                    }
                })
            }
        });
    });

    function prueba(control)
    {
        idStartWith = control.id.split('_')[0] + '_' + control.id.split('_')[1];
        $('#' + idStartWith + '_' + 'txtDocumento').val('asas');
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
                        <asp:Button runat="server" CssClass="btn btn-info" ID="btnBuscar" Text="Buscar" OnClientClick="prueba(this); return false;" />
                            </span>
                    </div>
                </div>
            </div>
        </div>
        <div id="divControles" class="hidden">
            <div class="row">
            <div class="col-lg-6 col-xs-12">
                <div class="form-group">
                    <label for="txtNombre">Nombre/Razón Social:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre"></asp:TextBox>
                </div>
            </div>
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
