<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MP01.Master" CodeBehind="Notificacion.aspx.vb" Inherits="EasySapWeb.Notificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <asp:HiddenField ID="FBACK" runat="server" />
    <asp:Timer ID="Timer1" runat="server" Interval="5000">
    </asp:Timer>
    <p class="Titulo"><asp:Label ID="TXTNOTI" runat="server" Text="Texto Notificacion"></asp:Label></p>
    <div class="MenuBar"><asp:LinkButton ID="BTNBACK" runat="server" Text="Regresar" CssClass="TopMenu"></asp:LinkButton></div>
</asp:Content>
