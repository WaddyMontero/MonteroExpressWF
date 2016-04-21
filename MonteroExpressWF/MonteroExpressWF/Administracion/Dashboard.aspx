<%@ Page Title="" Language="C#" MasterPageFile="~/Administracion/Site1.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MonteroExpressWF.Administracion.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/jquery-1.11.4/jquery-ui.min.css" rel="stylesheet" />
    <link href="../Content/jquery-1.11.4/jquery-ui.structure.min.css" rel="stylesheet" />
    <link href="../Content/jquery-1.11.4/jquery-ui.theme.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap/bootstrap.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-ui-1.11.4/external/jquery/jquery.js"></script>
    <script src="../Scripts/jquery-ui-1.11.4/jquery-ui.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/graphs/morris.min.js"></script>


    <script type="text/javascript">
        

        $(document).ready(function () {

            Morris.Line({
                element: 'line-example',
                data: [
                  { y: '2006', a: 100, b: 90 },
                  { y: '2007', a: 75, b: 65 },
                  { y: '2008', a: 50, b: 40 },
                  { y: '2009', a: 75, b: 65 },
                  { y: '2010', a: 50, b: 40 },
                  { y: '2011', a: 75, b: 65 },
                  { y: '2012', a: 100, b: 90 }
                ],
                xkey: 'y',
                ykeys: ['a', 'b'],
                labels: ['Series A', 'Series B']
            });

        });

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">

        <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">
            <div id="donut"></div>
        </div>
        <div class="col-lg-6 col-md-6 col-xs-12 col-sm-12">

        </div>
        <div class="col-sm-12">
            <div id="barra"></div>

        </div>


    </div>
</asp:Content>
