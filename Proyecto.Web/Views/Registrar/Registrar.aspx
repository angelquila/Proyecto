<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Proyecto.Web.Views.Registrar.Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Registrar</title>

    <!-- Bootstrap core CSS-->
    <link href="../../vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom fonts for this template-->
    <link href="../../vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css">
    <!-- Custom styles for this template-->
    <link href="../../css/sb-admin.min.css" rel="stylesheet">
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
        <div class="card card-register mx-auto mt-5">
            <div class="card-header">Registrar una cuenta</div>
            <div class="card-body">
                <form id="form1" runat="server">
                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-6">
                                <div class="form-label-group">
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" autofocus="autofocus"></asp:TextBox>
                                    <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-label-group">
                                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblApellido" runat="server" Text="Apellido"></asp:Label>                                   
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-label-group">
                            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                            <asp:Label ID="lblCorreo" runat="server" Text="Correo"></asp:Label>                            
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="form-row">
                            <div class="col-md-6">
                                <div class="form-label-group">
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                                    <asp:Label ID="lblPassword" runat="server" Text="Contraseña"></asp:Label>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-label-group">
                                    <asp:TextBox ID="txtPasswordConfir" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblPasswordConfir" runat="server" Text="Confirmar contraseña"></asp:Label>                                   
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-primary btn-block" OnClick="btnRegistrar_Click" />
                </form>
                <div class="text-center">
                    <a class="d-block small mt-3" href="../Login/Login.aspx">Login</a>
                    <a class="d-block small" href="forgot-password.html">Se te olvidó tu contraseña?</a>
                </div>
            </div>
        </div>
    </div>

</body>
</html>
