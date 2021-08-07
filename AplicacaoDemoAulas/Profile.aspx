<%@ Page Title="" Language="C#"
    MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Profile.aspx.cs" Inherits="AplicacaoDemoAulas.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadUpper" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadMiddle" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="HeadBottom" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="BodyUpper" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="BodyMiddle" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-6">
                <div class="card">
                    Username:
            <asp:TextBox
                ID="txt_user"
                runat="server" />

                    Nova Palavra-passe:
            <asp:TextBox
                ID="txt_ppass"
                runat="server" />

                    Repetir nova palavra-passe:
            <asp:TextBox
                ID="txt_nppass"
                runat="server" />

                    Nome:
            <asp:TextBox
                ID="txt_nome"
                runat="server" />

                    <asp:Button
                        ID="btnGuardar"
                        OnClientClick="return ValidarDados();"
                        OnClick="btnGuardar_Click"
                        CssClass="btn btn-sm btn-success"
                        Text="Guardar"
                        runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="BodyBottom" runat="server">
    <script>
        function ValidarDados() {
            //Validar as caixas de texto (deste lado, ou seja, do lado do CLIENTE)
        }
    </script>
</asp:Content>
