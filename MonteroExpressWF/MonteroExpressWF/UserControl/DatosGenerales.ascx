<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DatosGenerales.ascx.cs" Inherits="MonteroExpressWF.UserControl.DatosGenerales" %>

<div class="panel panel-default">

    <div class="panel-body">
        <div class="row">
            <div class="col-lg-6 col-xs-12">
                <div class="form-group">
                    <label for="ddlTipoDocumento">DNI/NIF/Pasaporte:</label>
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlTipoDocumento">
                        <asp:ListItem Value="" Text="Seleccione -->"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-6 col-xs-12">
                <div class="form-group">
                    <label for="txtDocumento"># Documento:</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtDocumento"></asp:TextBox>
                </div>

            </div>
        </div>
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
