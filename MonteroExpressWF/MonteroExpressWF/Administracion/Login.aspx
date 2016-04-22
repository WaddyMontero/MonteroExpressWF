<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MonteroExpressWF.Administracion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Montero Express Login</title>

    <!-- Bootstrap Core CSS -->
    <link href="../Content/bootstrap/bootstrap.min.css" rel="stylesheet" />    
    <!-- MetisMenu CSS -->
    <link href="../Content/page-theme/metisMenu.min.css" rel="stylesheet" />    
    <!-- Custom CSS -->
    <link href="../Content/page-theme/sb-admin-2.css" rel="stylesheet" />   
    <!-- Custom Fonts -->
    <link href="../Content/page-theme/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body style="background-color:white">

    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <img src="../Content/img/logo.png" alt="Logo" class="center-block"/>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 col-md-offset-4">
                <div class="login-panel panel panel-default">
                    <div class="panel-heading">
                        <h3 class="panel-title">Inicio de Sesión</h3>
                    </div>
                    <div class="panel-body">
                        <form runat="server" id="formLogin" role="form">
                            <fieldset>
                                <div class="form-group">
                                    <asp:TextBox runat="server" name="txtUsuario" ID="txtUsuario" CssClass="form-control" placeholder="Nombre de usuario"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <asp:TextBox runat="server" name="txtContrasena" ID="txtContrasena" CssClass="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                                </div>
                                <%--<div class="checkbox">
                                    <label>
                                        <input name="remember" type="checkbox" value="Remember Me"/>Remember Me
                                    </label>
                                </div>--%>
                                <!-- Change this to a button or input when using this as a form -->
                                <asp:LinkButton runat="server" OnClick="btnLogin_Click" OnClientClick="javascript: return ValidarLogin()" ID="btnLogin" CssClass="btn btn-lg btn-success btn-block">Login</asp:LinkButton>
                            </fieldset>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- jQuery -->
        <script src="../Scripts/jquery-ui-1.11.4/external/jquery/jquery.js"></script>
    <!-- Bootstrap Core JavaScript -->
        <script src="../Scripts/bootstrap.min.js"></script>    
    <!-- Metis Menu Plugin JavaScript -->
        <script src="../Scripts/page-theme/metisMenu.min.js"></script>    
    <!-- Custom Theme JavaScript -->
        <script src="../Scripts/page-theme/sb-admin-2.js"></script>  
    <script src="../Scripts/jquery.validate/jquery.validate.js"></script>
        <script src="../Scripts/jquery.validate/messages_es.js"></script>
        <script src="../Scripts/Utilities.js"></script>
    <script type="text/javascript">

        function ValidarLogin()
            {
                //var validator = $("#formLogin").validate();
                //var validado = validator.form();
            //return validado;
            return true;
            }

        $("#formLogin").validate({
            errorClass: 'control-label text-danger',
            rules: {
                // simple rule, converted to {required:true}
                txtUsuario: {
                    required: true                    
                },
                txtContrasena: {
                    required: true
                }
            }
        });

    </script>  
</body>

</html>
