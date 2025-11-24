<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MP01.Master" CodeBehind="Menu.aspx.vb" Inherits="EasySapWeb.Menu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <asp:UpdatePanel ID="UP0" runat="server" >
       <ContentTemplate>
         <div class="w3-display-container w3-content" style="max-width:700px" >
            <header class="w3-container w3-blue-grey">
                <h3>Menu principal</h3>
            </header>
            <div class="w3-container">
                <asp:Literal ID="L01" runat="server"></asp:Literal>
                <br />
                <asp:TreeView ID="tv0" runat="server" ExpandDepth="2" ForeColor="black" HoverNodeStyle-CssClass="w3-yellow">
                </asp:TreeView>
                <asp:Timer ID="T0" runat="server" Interval="5000" Enabled="true"  ></asp:Timer>
            </div>
        </div>
       </ContentTemplate>
   </asp:UpdatePanel>
</asp:Content>
