<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MP01.Master" CodeBehind="REP_PLANTA.aspx.vb" Inherits="EasySapWeb.REP_PLANTA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
 <asp:UpdatePanel ID="UP0" runat="server" >
        <ContentTemplate>
            <div class="MenuBar">
                <a href="Menu.aspx" target="_self" class="TopMenu">Menú</a>
            </div>
            <h1>REPORTES CATALOGO</h1>
            <div class="form1" >
                <table class="t01" id="T0" runat="server"  >
                    <tr>
                        <td>REPORTE</td>
                        <td><asp:DropDownList ID="TXTREP" runat="server" CssClass="TextBox1" Autofocus="true" AutoPostBack ="true"  ></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>PERIODO</td>
                        <td><asp:DropDownList ID="TXTPRD" runat="server" CssClass="TextBox1"  AutoPostBack ="true"></asp:DropDownList></td>
                    </tr>
                     <tr><td>Del</td><td><asp:TextBox ID="TXTFDEL" runat="server" CssClass="TextBox1" TextMode="Date"  ></asp:TextBox></td></tr>
                    <tr><td>Al</td><td><asp:TextBox ID="TXTFAL" runat="server" CssClass="TextBox1" TextMode="Date"  ></asp:TextBox></td></tr>
                     <tr>
                        <td>TIPO</td>
                        <td><asp:DropDownList ID="TXTTIPO" runat="server" CssClass="TextBox1"  AutoPostBack ="true"></asp:DropDownList></td>
                    </tr>
                </table>                                
                <br />
                <div class="MenuBar">
                    <asp:LinkButton ID="BTNGO" CssClass="TopMenu" Text="EJECUTAR" runat="server" ></asp:LinkButton>
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
