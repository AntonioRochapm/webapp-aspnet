<%@ Page Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs" Inherits="AplicacaoDemoAulas.Dashboard" %>



<asp:Content ContentPlaceHolderID="HeadUpper" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="HeadMiddle" runat="server">
    <style>
        .tab {
  overflow: hidden;
  border: 1px solid #ccc;
  background-color: #f1f1f1;
}

/* Style the buttons inside the tab */
.tab button {
  background-color: inherit;
  float: left;
  border: none;
  outline: none;
  cursor: pointer;
  padding: 14px 16px;
  transition: 0.3s;
  font-size: 17px;
}

/* Change background color of buttons on hover */
.tab button:hover {
  background-color: #ddd;
}

/* Create an active/current tablink class */
.tab button.active {
  background-color: #ccc;
}

/* Style the tab content */
.tabcontent {
  display: none;
  padding: 6px 12px;
  border: 1px solid #ccc;
  border-top: none;
}
    </style>
</asp:Content>
<asp:Content ContentPlaceHolderID="HeadBottom" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="BodyUpper" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="BodyMiddle" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <h1>Página inicial</h1>

                <div class="tab">
                    <asp:Button 
                        CssClass="tablinks"
                        onClientClick="openTab(event, 'primeiro'); return false; "
                        runat="server"            
                        Text="Inserir" />
                    <asp:Button 
                        CssClass="tablinks"
                        onClientClick="openTab(event, 'segundo'); return false;"
                        runat="server"            
                        Text="Inserir" />
                    <asp:Button 
                        CssClass="tablinks"
                        onClientClick="openTab(event, 'terceiro'); return false;"
                        runat="server"            
                        Text="Inserir" />                  
                </div>
                <div id="primeiro" class="tabcontent">
                    <asp:PlaceHolder runat="server" ID="ph_InserirProduto"/>
                </div>

                <div id="segundo" class="tabcontent">
                    <asp:PlaceHolder runat="server" ID="ph_InserirEmpregado"/>
                </div>

                <div id="terceiro" class="tabcontent">
                    <asp:PlaceHolder runat="server" ID="ph_InserirEncomenda"/>
                </div>
            </div>
        </div>
    </div>
    <script>
        openTab(null, primeiro);
        function openTab(evt, cena) {
            // Declare all variables
            var i, tabcontent, tablinks;

            // Get all elements with class="tabcontent" and hide them
            tabcontent = document.getElementsByClassName("tabcontent");
            for (i = 0; i < tabcontent.length; i++) {
                tabcontent[i].style.display = "none";
            }

            // Get all elements with class="tablinks" and remove the class "active"
            tablinks = document.getElementsByClassName("tablinks");
            for (i = 0; i < tablinks.length; i++) {
                tablinks[i].className = tablinks[i].className.replace(" active", "");
            }

            // Show the current tab, and add an "active" class to the button that opened the tab
            document.getElementById(cena).style.display = "block";
            evt.currentTarget.className += " active";            
        }
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="BodyBottom" runat="server">
</asp:Content>
