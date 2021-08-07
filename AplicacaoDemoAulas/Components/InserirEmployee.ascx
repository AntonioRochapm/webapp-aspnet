<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="InserirEmployee.ascx.cs" Inherits="AplicacaoDemoAulas.Components.InserirEmployee" %>

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
                    <asp:ScriptManager ID="smCalendar" runat="server"/> 
                    <asp:UpdatePanel ID="upCalendar" runat="server">
                        <ContentTemplate><asp:Calendar 
                            ID="calendarEmployee"
                            runat="server"                
                            ></asp:Calendar></ContentTemplate>
                    </asp:UpdatePanel>
                                        
          
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