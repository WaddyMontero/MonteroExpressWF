<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetallesEnvio.ascx.cs" Inherits="MonteroExpressWF.UserControl.DetallesEnvio" %>
<div class="panel panel-info">
    <div class="panel-heading">
        <div class="panel-title">Detalles</div>
    </div>
    <div class="panel-body">
        <div class="form-group">
            <label for="txtOrigen">Origen:</label>
            <asp:TextBox ID="txtOrigen" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtDestino">Destino:</label>
            <asp:TextBox ID="txtDestino" runat="server" CssClass="form-control"></asp:TextBox>

        </div>
        <div class="form-group">
            <label for="txtRecogido">Recogido por:</label>
            <asp:TextBox ID="txtRecogido" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtRuta">Ruta:</label>
            <asp:TextBox ID="txtRuta" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="row">
            <div class="alert alert-info">
                <div class="form-inline">
                    <label class="control-label">
                        Valor</label>
                </div>
            </div>
            <hr />
            <div class="alert alert-info">
                <div class="form-inline">
                    <label class="control-label">
                        ¿Desea asegurar el paquete?</label>
                    <label class="radio">
                        <input type="radio" name="rbtnSeguroPaquete" value="0">No
                    </label>
                    <label class="radio">
                        <input type="radio" name="rbtnSeguroPaquete" value="1">Si
                    </label>
                </div>
            </div>
            <asp:RadioButtonList runat="server" ID="rbtnListEnvioSeguro" OnDataBound="rbtnListEnvioSeguro_DataBound" ItemType="MonteroExpressWF.BOL.SeguroEnvio" RepeatDirection="Vertical"></asp:RadioButtonList>


        </div>
    </div>
</div>

