<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImprimirEnvio.aspx.cs" Inherits="MonteroExpressWF.Administracion.ImprimirEnvio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/jquery-1.11.4/jquery-ui.min.css" rel="stylesheet" />
    <link href="../Content/jquery-1.11.4/jquery-ui.structure.min.css" rel="stylesheet" />
    <link href="../Content/jquery-1.11.4/jquery-ui.theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap/bootstrap-theme.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-ui-1.11.4/external/jquery/jquery.js"></script>
    <script src="../Scripts/jquery-ui-1.11.4/jquery-ui.min.js"></script>


    <script src="../Scripts/bootstrap.min.js"></script>
    <title>Impresión Envio - MonteroExpresss</title>
    <style type="text/css">
        .table tr th {
            width: 13%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container body-content">
            <div class="row">
                <div class="col-xs-6">
                    <img src="../Content/img/logo.png" style="float: left" alt="logo" />
                </div>
                <div class="col-xs-6">
                    <img src="../Content/img/logoAddress.png" style="float: right" alt="logoAddress" />
                </div>
            </div>
            <h4 class="text-center">AUTORIZACIÓN DE DESPACHO POR GRUPAJE</h4>
            <div class="row">
                <div class="col-lg-6">
                    <h4><asp:Label runat="server" ID="lblAlbaran"></asp:Label></h4>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <table class="table table-responsive table-bordered">
                        <tr>
                            <th>Comitente</th>
                            <td>
                                <asp:Label runat="server" ID="lblNombreRem"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>D.N.I</th>
                            <td>
                                <asp:Label runat="server" ID="lblNumDocumentoRem"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>Domicilio</th>
                            <td>
                                <asp:Label runat="server" ID="lblDireccionRem"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>Télefono/s</th>
                            <td>
                                <asp:Label runat="server" ID="lblTelefonoRem"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>Actividad</th>
                            <td>
                                <asp:Label runat="server" ID="lblActividadRem"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <p class="text-justify">
                        El que suscribe
                        <asp:Label runat="server" ID="lblSuscribe" Style="text-decoration: underline"></asp:Label>
                        provisto de D.N.I
                        <asp:Label runat="server" Style="text-decoration: underline" ID="lblDni"></asp:Label>
                        en calidad de EXPORTADOR por el presente documento, hago constar y participo 
                    a la Aduana que  autorizo a  MONTERO EXPRESS S.L para  agrupar mis  artículos personales en  un contendor los cuales  envió a  la Republica Dominicana, a   PHI EXPRESS con domicilio en: c/ Lea  de  Castro # 256 Edifico 
                    tegui, Apto 2ª, 2do piso Gazcue Santo Domingo Republica Dominicana, 
                    De acuerdo con el artículo 45 de las ordenanzas de aduanas, AUTORIZO  a MONTERO EXPRES S.L  para la presentación y tramitación de toda clase de  documentos y realización de todas nuestras operaciones aduaneras que hayan 
                    de efectuarse ante dicha administración cualquiera que sea el régimen comercial y/o aduanero que en cada caso resulte procedente, así como bajo la modalidad de representación INDIRECTA y comprometiéndonos en cuanto a la 
                    exactitud y veracidad de la información suministrada al agente para realizar las operaciones aduaneras, así como respecto a la autenticidad de todos los documentos entregados a dicho fin.
                    La presente autorización se establece para despachos sin límite de monto y fecha

                    </p>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <h4 class="text-center">Datos del Destinatario</h4>
                    <table class="table table-responsive table-bordered">
                        <tr>
                            <th>Nombre</th>
                            <td>
                                <asp:Label runat="server" ID="lblNombreDest"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>D.N.I</th>
                            <td>
                                <asp:Label runat="server" ID="lblNumDocumentoDest"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>Dirección</th>
                            <td>
                                <asp:Label runat="server" ID="lblDireccionDest"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <th>Télefono/s</th>
                            <td>
                                <asp:Label runat="server" ID="lblTelefonoDest"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <h4>Descripción de la Mercancía</h4>
                    <div class="row">
                        <div class="col-xs-12">
                            <strong>Contenidos del envio:</strong>
                            <asp:Label runat="server" ID="lblContenidoEnvio"></asp:Label>
                        </div>
                    </div>
                    <table id="tblPaquetes" class="table table-responsive table-bordered">
                        <thead>
                            <tr>
                                <th style="width: 8%">Cantidad</th>
                                <th colspan="2" style="width: 81%">Descripción</th>
                                <th style="width: 1%">Peso</th>
                                <th style="width: 5%">Tamaño</th>
                                <th style="width: 5%">Estado</th>
                            </tr>
                        </thead>
                        <tbody runat="server" id="tblBodyPaquetes">
                        </tbody>
                        <tfoot>
                            <tr>
                                <th colspan="2"></th>
                                <th>Peso Total:</th>
                                <th>
                                    <asp:Label runat="server" ID="lblPesoTotal"></asp:Label>
                                </th>
                            </tr>
                        </tfoot>
                    </table>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    <p class="text-justify">
                        Así mismo, a los efectos de lo previsto en el R.D.296/1998 de 27 de febrero, se declara formalmente que esta empresa, en su condición de Sujeto Pasivo tiene derecho a la deducción total del Impuesto 
                    del Valor Añadido que grava la importación.<br />
                        Montero Express S.L no  se  hace  responsable  de  mercancía  delicadas propicias  a  roturas  o derramamiento por  lo que se  recomienda  a  los  cliente  la contratación de  un  seguro de riesgo. 
                    Por el contrario será responsabilidad del propietario de la paquetería.
                    Es responsabilidad del propietario el correcto embalaje   e identificación de sus bultos.
                    Las paquetería  llevadas  a  créditos   los  clientes  dispondrán  de  15 naturales para el pago de la misma,  si  a la llegada  a  destino  no está pagada,  se  procederá  a la venta para  cubrir los  costos  del  transporte  y la  aduana  en destino
                    </p>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    En ________ a ________ de ________ de 2016
                </div>
            </div>
            <div class="row">
                <div class="col-xs-12">
                    ____________________________<br />
                    Firma del Exportador
                </div>
            </div>

        </div>
    </form>
</body>
</html>
