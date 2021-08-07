<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ListarEmpregados.aspx.cs" Inherits="AplicacaoDemoAulas.ListarEmpregados" %>

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
            <div class="col-12">
                <div class="card">
                    <div class="card-header card-header-info">
                        <h4 class="card-title">Empregados</h4>
                        <p class="card-category">Listagem de empregados atuais</p>
                    </div>                    
                    <div class="card-body table-responsive">
                        <asp:GridView CssClass="table" runat="server" DataSourceID="obj_Employee" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID"></asp:BoundField>
                                <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName"></asp:BoundField>
                                <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName"></asp:BoundField>
                                <asp:BoundField DataField="Birthday" HeaderText="Birthday" SortExpression="Birthday"></asp:BoundField>
                                <asp:BoundField DataField="Country" HeaderText="Country" SortExpression="Country"></asp:BoundField>
                                <asp:BoundField DataField="reportsTo" HeaderText="reportsTo" SortExpression="reportsTo"></asp:BoundField>
                            </Columns>
                        </asp:GridView>


                        <asp:ObjectDataSource runat="server" ID="obj_Employee" SelectMethod="listEmployees" TypeName="AplicacaoDemoAulas.Classes.BL"></asp:ObjectDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="BodyBottom" runat="server">
</asp:Content>
