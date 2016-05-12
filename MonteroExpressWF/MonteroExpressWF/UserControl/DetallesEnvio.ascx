<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DetallesEnvio.ascx.cs" Inherits="MonteroExpressWF.UserControl.DetallesEnvio" %>
<div class="panel panel-info">
    <div class="panel-heading">Detalles</div>
    <div class="panel-body">
        <div class="form-group">
            <label for="ddlOrigen">Origen</label>
            <%-- <asp:TextBox ID="ddlOrigen" runat="server" CssClass="form-control"></asp:TextBox>--%>
            <select runat="server" id="ddlOrigen" class="form-control">
                <option value="">Seleccione --></option>
            </select>
        </div>
        <div class="form-group">
            <label for="txtDestino">Destino</label>
            <%--<asp:TextBox ID="txtDestino" runat="server" CssClass="form-control"></asp:TextBox>--%>
            <select runat="server" id="ddlDestino" class="form-control">
                <option value="">Seleccione --></option>
            </select>
        </div>
        <div class="form-group">
            <label for="txtRecogido">Recogido por</label>
            <asp:TextBox ID="txtRecogido" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtRuta">Ruta</label>
            <asp:TextBox ID="txtRuta" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="row">
            <div class="panel panel-info">
                <div class="panel-heading">
                    Valor de la mercancía
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <label for="txtValor">Declarado</label>
                        <asp:TextBox ID="txtValor" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>

            <hr />
            <div class="panel panel-info">
                <div class="panel-heading">
                    
                        Seguro del paquete
                        <%--¿Desea asegurar el paquete?--%>
                   
                    <%-- <label class="radio">
                        <input type="radio" name="rbtnSeguroPaquete" value="0">No
                    </label>
                    <label class="radio">
                        <input type="radio" name="rbtnSeguroPaquete" value="1">Si
                    </label>--%>
                </div>
                <div class="panel-body">
                    <asp:RadioButtonList runat="server" ID="rbtnListEnvioSeguro" OnDataBound="rbtnListEnvioSeguro_DataBound" ItemType="MonteroExpressWF.BOL.SeguroEnvio" RepeatDirection="Vertical"></asp:RadioButtonList>
                    <p id="lblValidacionSeguro" class="control-label text-danger hidden"><strong>Debe seleccionar el seguro del envio.</strong></p>
                </div>
            </div>
        </div>
    </div>
</div>

