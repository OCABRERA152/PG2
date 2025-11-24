<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MP01.Master" CodeBehind="ConfSap.aspx.vb" Inherits="EasySapWeb.ConfSap" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    inter<asp:UpdatePanel ID="UP0" runat="server">
        <ContentTemplate>
            <div class="MenuBar" >
                <asp:LinkButton ID="BTNOUT" runat="server" CssClass="TopMenu" Text="Salir" OnClientClick="return confirm('Salir del sistema?');"></asp:LinkButton>
                <asp:LinkButton ID="BTNINT" runat="server" CssClass="TopMenu" Text="Interfaz"></asp:LinkButton>
            </div>
            <br /><br />
            <table class="t01" >
                <caption>Configuración de Acceso a SAP</caption>
                <tr>
                    <td>SQL SAP (ip o Nombre)</td>
                    <td><asp:TextBox runat="server"  ID="TXTSRVSQL" CssClass="TextBox1" TextMode="SingleLine" required autofocus ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>SQL DB</td>
                    <td><asp:TextBox runat="server"  ID="TXTDBBSQL" CssClass="TextBox1" TextMode="SingleLine" required  ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>SQL USR</td>
                    <td><asp:TextBox runat="server"  ID="TXTUSRSQL" CssClass="TextBox1" TextMode="SingleLine" required  ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>SQL PWD</td>
                    <td><asp:TextBox runat="server"  ID="TXTPWDSQL" CssClass="TextBox1" TextMode="SingleLine" required  ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>USUARIO SAP</td>
                    <td><asp:TextBox runat="server"  ID="TXTUSRSAP" CssClass="TextBox1" TextMode="SingleLine" required  ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>PWD SAP</td>
                    <td><asp:TextBox runat="server"  ID="TXTPWDSAP" CssClass="TextBox1" TextMode="SingleLine" required  ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Empresa SAP</td>
                    <td><asp:TextBox runat="server"  ID="TXTEMPSAP" CssClass="TextBox1" TextMode="SingleLine" required  ></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td><asp:Label ID="ERRM" runat="server" CssClass="ERRM"></asp:Label><br />
                        <div class="MenuBar"><asp:LinkButton ID="BTNSAV" runat="server" CssClass="TopMenu100" Text="Guardar"></asp:LinkButton></div>
                        <br />
                        <asp:UpdateProgress ID="UP1" runat="server" AssociatedUpdatePanelID="UP0">
                            <ProgressTemplate>
                                Actualizando ... Espere<br />
                                <img src="Images/wait.gif" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>

                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
