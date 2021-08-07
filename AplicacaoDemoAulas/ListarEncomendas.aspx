<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ListarEncomendas.aspx.cs" Inherits="AplicacaoDemoAulas.ListarEncomendas" %>
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
                    <div class="card-header card-header-danger">
                        <h4 class="card-title">Encomendas</h4>
                        <p class="card-category">Listagem de encomendas atuais</p>
                    </div>
                    <div class="card-body table-responsive">
                        <asp:GridView ID="gv_encomendas"
                            CssClass="table"
                            runat="server"
                            AutoGenerateColumns="false"
                            DataSourceID="SQL_DS_NW" >
                            <Columns>
                                <asp:BoundField DataField="OrderID" HeaderText="ID" />
                                <asp:BoundField DataField="OrderDate" HeaderText="Data" DataFormatString="{0:yyyy}" />
                                <asp:BoundField DataField="ShipAddress" HeaderText="Morada" />
                                <asp:BoundField DataField="ShipCity" HeaderText="Cidade" />
                                <asp:BoundField DataField="ShipCountry" HeaderText="País" />
                            </Columns>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SQL_DS_NW" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:lojaConnectionString %>" 
                            SelectCommand="SELECT [OrderID],[OrderDate],[ShipAddress],[ShipCity],[ShipCountry] FROM [Orders]"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="BodyBottom" runat="server">
</asp:Content>
