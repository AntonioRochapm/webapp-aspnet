<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="AplicacaoDemoAulas.Employees" %>
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
                    LastName:
            <asp:TextBox
                ID="txt_lname"
                runat="server" />

                    FirstName:
            <asp:TextBox
                ID="txt_fname"
                runat="server" />

                    Birthday:
                        <asp:Calendar 
                            ID="calendarEmployee"
                            runat="server"                
                            ></asp:Calendar> 
                     
          
                    Country:
                        <asp:TextBox
                            ID="txt_country"
                            runat="server" />

                    <asp:Button
                        ID="btnGuardarEmployee"
                        OnClick="btnGuardarEmployee_Click"
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
