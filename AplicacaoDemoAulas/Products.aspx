<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="AplicacaoDemoAulas.Products" %>
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
                    
                            Nome do Produto:
                        <asp:TextBox
                            ID="txt_nome"
                            runat="server" />
                                Supplier name:
                        <asp:DropDownList
                            ID="dd_supplier"
                            runat="server" DataTextField="CompanyName" DataValueField="SupplierID" DataSourceID="SqlDataSource1">
                        </asp:DropDownList>

                    Category Name:                        
                    <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:lojaConnectionString %>' SelectCommand="SELECT * FROM [Suppliers]"></asp:SqlDataSource>
                    <asp:DropDownList
                        ID="dd_category"
                        runat="server" DataSourceID="ObjectDataSource1" DataTextField="Designacao" DataValueField="ID">
                    </asp:DropDownList>
                    <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" SelectMethod="GetCategories" TypeName="AplicacaoDemoAulas.Classes.DAL"></asp:ObjectDataSource>
                    
                    Quantity per unit:                        
                    <asp:TextBox
                            ID="TextBox2"
                            runat="server" />
                                Preco unitario:
                        <asp:TextBox
                            ID="txt_preco"
                            runat="server" />

                                Unidades em stock:
                        <asp:TextBox
                            ID="txt_unidade_stock"
                            runat="server" />
                                Unidade encomendadas
                        <asp:TextBox
                            ID="txt_u_encomendadas"
                            runat="server" />
                                Recorder Level
                        <asp:TextBox
                            ID="txt_r_level"
                            runat="server" />
                                
                        <asp:CheckBox ID="cb_descontinuado" Text="Descontinuado" runat="server" />

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
</asp:Content>
