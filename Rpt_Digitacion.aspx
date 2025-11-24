<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MP01.Master" CodeBehind="Rpt_Digitacion.aspx.vb" Inherits="EasySapWeb.Rpt_Digitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <asp:UpdatePanel ID="UP0" runat="server">
        <ContentTemplate>
            <div class="MenuBar">
                <a href="Menu.aspx" class="TopMenu">Regresar</a>
            </div>
            <h1>Reportes Digitación</h1>
            <br /><br />
            <div class="form1">
                <p style="text-align:center;font-size:large;">Parámetros</p>
                <table style="width:90%;">
                    <tr><td>Reporte</td><td><asp:DropDownList ID="TXTPREP" runat="server" CssClass="TextBox1" Autofocus AutoPostBack="True" ></asp:DropDownList></td></tr>
                    <tr><td>Tienda</td><td><asp:DropDownList ID="TXTTDA" runat="server" CssClass="TextBox1" ></asp:DropDownList></td></tr>
                    <tr><td>Del</td><td><asp:TextBox ID="TXTFDEL" runat="server" CssClass="TextBox1" TextMode="Date"  ></asp:TextBox></td></tr>
                    <tr><td>Al</td><td><asp:TextBox ID="TXTFAL" runat="server" CssClass="TextBox1" TextMode="Date"  ></asp:TextBox></td></tr>
                    <tr><td>Periodo</td><td><asp:DropDownlist runat="server" ID="TXTPER" CssClass="TextBox1" ></asp:DropDownlist></td></tr>
                    <tr><td>Filtro</td><td><asp:TextBox ID="TXTFIL" runat="server" CssClass="TextBox1" TextMode="MultiLine" Rows="5"  ></asp:TextBox></td></tr>
                </table>
                <br /><br />
                <div class="MenuBar">
                    <asp:LinkButton ID="BTNGO"  runat="server" CssClass="TopMenu100" Text="Generar" Width="123px"></asp:LinkButton>
                     
                </div>
            </div>
            <br /><br />
            <asp:GridView ID="GVREP" runat="server" CssClass="grid-view" 
                AllowPaging="False" AllowSorting="False" 
                AutoGenerateColumns="False"
                RowStyle-CssClass="normal"
                AlternatingRowStyle-CssClass="alternate"  
                >                
            </asp:GridView>
            <br /><br />
            <div class="Centrado" >
                <asp:ImageButton ID="BTNEXPORT" runat="server" ImageUrl="~/images/Excel.gif" Width="35" />
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="BTNEXPORT" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
