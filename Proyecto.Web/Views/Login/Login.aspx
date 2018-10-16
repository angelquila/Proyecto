<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Proyecto.Web.Views.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Login</title>
    <!-- Bootstrap core CSS-->
    <link href="../../vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom fonts for this template-->
    <link href="../../vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <!-- Custom styles for this template-->
    <link href="../../css/sb-admin.css" rel="stylesheet">
    <!-- Bootstrap core JavaScript-->
    <script src="../../vendor/jquery/jquery.min.js"></script>
    <script src="../../vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- Core plugin JavaScript-->
    <script src="../../vendor/jquery-easing/jquery.easing.min.js"></script>
    <!-- esto es para llamar el estilo de mensajes bonitos-->
    <link href="../../css/sweetalert.css" rel="stylesheet" />
    <script src="../../js/sweetalert.min.js" type="text/javascript"></script>

</head>
<body class="bg-dark">

    <div class="container">
        <div class="card card-login mx-auto mt-5">
            <div class="card-header">Iniciar sesión</div>
            <div class="card-body">
                <form runat="server">
                    <div class="form-group">
                        <%--<div class="form-label-group">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                            <asp:Label ID="lblEmail" runat="server" Text="Correo"></asp:Label>
                        </div>--%>
                        
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                            <asp:Label ID="lblEmail" runat="server" Text="Correo"></asp:Label>
                        
                    </div>
                    <div class="form-group">
                        <%--<div class="form-label-group">
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            <asp:Label ID="lblPassword" runat="server" Text="Contraseña"></asp:Label>
                        </div>--%>
                       
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            <asp:Label ID="lblPassword" runat="server" Text="Contraseña"></asp:Label>

                    </div>
                    <div class="form-group">
                        <div class="checkbox">
                            <asp:CheckBox ID="chkRecordar" runat="server" Text="Recordar contraseña" />
                        </div>
                    </div>
                    <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary btn-block" Text="Iniciar sesión" OnClick="btnAceptar_Click" />
                </form>
                <div class="text-center">
                    <a class="d-block small mt-3" href="../Registrar/Registrar.aspx">Registrar Cuenta</a>
                    <a class="d-block small" href="forgot-password.aspx">Olvido Contraseña?</a>
                </div>
            </div>
        </div>
    </div>
</body>
</html>


