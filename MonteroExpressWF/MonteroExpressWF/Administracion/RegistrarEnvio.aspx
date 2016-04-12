<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarEnvio.aspx.cs" Inherits="MonteroExpressWF.Administracion.RegistrarEnvio" %>

<%@ Register Src="~/UserControl/DatosGenerales.ascx" TagName="DatosGenerales" TagPrefix="DG" %>
<%@ Register Src="~/UserControl/DetallesEnvio.ascx" TagName="DetallesEnvio" TagPrefix="DE" %>

<asp:Content runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="formRegistroEnvio" runat="server">
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        Datos Generales
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label for="txtCantidad"># Albarán</label>
                                    <input type="text" name="txtAlbaran" class="form-control" id="txtAlbaran" />
                                </div>
                            </div>
                            <div class="col-lg-3"></div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label for="ddlOficina">Oficina</label>
                                    <asp:DropDownList runat="server" name="ddlOficina" ID="ddlOficina" AppendDataBoundItems="true" required CssClass="form-control">
                                        <asp:ListItem Value="" Text="Seleccione -->"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3"></div>
                        </div>
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
                                <div class="panel panel-info">
                                    <div class="panel-heading">Contenidos</div>
                                    <div class="panel-body">
                                        <asp:CheckBoxList runat="server" CssClass="" name="chkListTiposContenidos" OnDataBound="chkListTiposContenidos_DataBound" ItemType="MonteroExpressWF.BOL.TipoContenido" RepeatColumns="3" RepeatDirection="Vertical" ID="chkListTiposContenidos"></asp:CheckBoxList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <DE:DetallesEnvio ID="usrControlDetallesEnvio" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <div id="tblPaquetes" name="tblPaquetes"></div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label for="ddlEstadoEnvio">Estado</label>
                                    <asp:DropDownList runat="server" name="ddlEstadoEnvio" ID="ddlEstadoEnvio" AppendDataBoundItems="true" required CssClass="form-control">
                                        <asp:ListItem Value="" Text="Seleccione -->"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel-footer">
                        <div class="row">
                            <div class="col-xs-3"></div>
                            <div class="col-xs-3">
                                <input type="button" class="form-control btn btn-primary" onclick="GuardarEnvio()" value="Guardar" />
                            </div>
                            <div class="col-xs-3">
                                <input type="button" class="form-control btn btn-danger" value="Cancelar" />
                            </div>
                            <div class="col-xs-3"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <form id="formAgregarPaquete">
        <div class="row">
            <div id="divAgregarPaquete" title="Agregar Paquete">
                <div class="row">
                    <div class="form-group">
                        <label for="txtCantidad">Cantidad</label>
                        <input type="text" name="txtCantidad" class="form-control" id="txtCantidad" />
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
                        <input type="text" class="form-control" id="txtPrecioUnitario" />
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label for="txtPeso">Peso</label>
                        <input type="text" class="form-control" id="txtPeso" />
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label for="ddlTamanioPaquete">Tamaño</label>
                        <select runat="server" class="form-control" id="ddlTamanioPaquete"></select>
                    </div>
                </div>
                <div class="row">
                    <div class="form-group">
                        <label for="ddlEstado">Estado</label>
                        <select runat="server" class="form-control" id="ddlEstado"></select>
                    </div>
                </div>
            </div>

        </div>
    </form>
</asp:Content>


