<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AplicacaoDemoAulas.Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <title></title>
    <meta content='width=device-width, initial-scale=1.0, shrink-to-fit=no' name='viewport' />
    <!-- CSS Files -->
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <!-- Sweet Alert 2 CSS -->
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/sweetalert2@10.15.5/dist/sweetalert2.min.css">
</head>
<body>
    <form runat="server">
        <h1>Login</h1>
        <div class="row d-flex justify-content-center align-items-center"
            style="margin-top: 5em !important;">
            <div class="col-4">
                <div class="mb-2">
                    <asp:TextBox ID="login_u"
                        CssClass="form-control"
                        placeholder="Utilizador" 
                        runat="server" />
                </div>
                <div class="mb-2">
                    <asp:TextBox ID="login_p"
                        CssClass="form-control"
                        TextMode="Password"
                        placeholder="Palavra-Passe" 
                        runat="server" />
                </div>
                <div class="mb-2">
                    <asp:Button ID="btn_entrar" 
                        Text="Entrar" 
                        OnClick="btn_entrar_Click"
                        CssClass="btn btn-primary btn-block"
                        runat="server" />
                </div>
            </div>
        </div>
        <hr style="border: 2px solid #ff6a00;margin: 3em 0 3em 0;" />
        <h1>Novo registo</h1>
        <div class="row d-flex justify-content-center align-items-center"
            style="margin-top: 5em !important;">
            <div class="col-4">
                <div class="mb-2">
                    <asp:TextBox ID="registar_u"
                        CssClass="form-control"
                        placeholder="Utilizador" 
                        runat="server" />
                </div>
                <div class="mb-2">
                    <asp:TextBox ID="registar_p"
                        CssClass="form-control"
                        TextMode="Password"
                        placeholder="Palavra-Passe" 
                        runat="server" />
                </div>
                <div class="mb-2">
                    <asp:TextBox ID="registar_n"
                        CssClass="form-control"
                        placeholder="Nome" 
                        runat="server" />
                </div>
                <div class="mb-2">
                    <asp:Button ID="btn_registar" 
                        Text="Registar" 
                        OnClick="btn_registar_Click"
                        CssClass="btn btn-primary btn-block"
                        runat="server" />
                </div>
            </div>
        </div>
    </form>
    <script src="assets/js/core/jquery.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10.15.5/dist/sweetalert2.min.js"></script>
</body>
</html>
