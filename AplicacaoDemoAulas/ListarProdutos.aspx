<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" 
    EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="ListarProdutos.aspx.cs" Inherits="AplicacaoDemoAulas.ListarProdutos" %>
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
        <asp:Button 
            ID="btn_inserir"
            onClick="btn_inserir_Click"
            runat="server"
            target="_blank"
            Text="Inserir" />
        <div class="row">
            <div class="col-12">
                <div class="card">
                    <div class="card-header card-header-warning">
                        <h4 class="card-title">Produtos</h4>
                        <p class="card-category">Listagem de produtos atuais</p>
                    </div>
                    <div class="card-body table-responsive">
                        <asp:GridView ID="gv_produtos" 
                            AutoGenerateColumns="false"
                            CssClass="table"
                            runat="server">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" />
                                <asp:BoundField DataField="Designacao" HeaderText="Designação" />
                                <asp:BoundField DataField="Preco" HeaderText="Preço" />Ti
                                <asp:BoundField DataField="QtdStock" HeaderText="Unidades em Stock" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:Button 
                                            ID="btn_Apagar"
                                            OnClick="btn_Apagar_Click"
                                            CommandArgument='<%#Eval("ID") %>'
                                            CommandName=""
                                            CssClass="btn btn-danger btn-sm"
                                            Text="Apagar" 
                                            runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="BodyBottom" runat="server">
</asp:Content>
