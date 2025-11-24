<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MP01.Master" CodeBehind="Interfaz.aspx.vb" Inherits="EasySapWeb.Interfaz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <asp:UpdatePanel ID="UP0" runat="server">
        <ContentTemplate>
            <asp:Panel ID="P01" runat="server" Visible="true"  >
                <div class="MenuBar" >
                    <asp:LinkButton ID="BTNOUT" runat="server" CssClass="TopMenu" Text="Salir" OnClientClick="return confirm('Regresar al Menú?');"></asp:LinkButton>
                    <asp:LinkButton ID="BTNCFG" runat="server" CssClass="TopMenu" Text="Conf. SAP" Visible="False"></asp:LinkButton>
                </div>           
                <br /><br />
                <br />
                <div class="form1">
                    <h1>Interfaz Easy - SAP</h1>
                    <br />
                    <br />
                    <table style="margin-left:auto;margin-right:auto;">
                        <caption>Parámetros</caption>
                        <tr>
                            <td>Origen</td>
                            <td>
                                <asp:DropDownList ID="TXTORIG" runat="server" CssClass="TextBox1"  ></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>Del</td>
                            <td><asp:TextBox ID="TXTDEL" runat="server" TextMode="Date" CssClass="TextboxF" required autofocus ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Al</td>
                            <td><asp:TextBox ID="TXTAL" runat="server" TextMode="Date" CssClass="TextboxF" required ></asp:TextBox></td> 
                        </tr>
                        <tr>
                            <td colspan="2"><asp:LinkButton ID="BTNGO" runat="server" CssClass="TopMenu100" Text="Generar"></asp:LinkButton><br />
                                <asp:UpdateProgress ID="UP1" runat="server" AssociatedUpdatePanelID="UP0">
                                    <ProgressTemplate>
                                        Actualizando ... Espere<br />
                                        <img src="Images/wait.gif" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <h2><asp:Label ID="LBLTITLE" runat="server" Text="Seleccione parámetros" ></asp:Label></h2> 
                    <br />
                    <br />
                    <asp:Label ID="ERRM" CssClass="ERRM" runat="server"></asp:Label>
                </div>
                    <hr />                    
                    <asp:GridView ID="GVVTA" runat="server" CssClass="grid-view" 
                        AllowPaging="False" AllowSorting="False" 
                        AutoGenerateColumns="False"
                        RowStyle-CssClass="normal"
                        AlternatingRowStyle-CssClass="alternate"  
                        DataKeyNames="Codigo"
                        >                
                    </asp:GridView>
                    <br /><br />
            <div class="Centrado" >
                <asp:ImageButton ID="BTNEXPORT" runat="server" ImageUrl="~/images/Excel.gif" Width="35" />
            </div><br /><br />
                    <div class="form1" >
                        <br />
                        <br />
                        <asp:Label ID="LBLBTNSAPERR" runat="server" CssClass="ERRM"></asp:Label>
                        <asp:LinkButton ID="BTNSAP" runat="server" CssClass="TopMenu100" Enabled="false" Text="Generar Archivos SAP"></asp:LinkButton>
                        <br />
                        <asp:Literal ID="LSAP" runat="server" ></asp:Literal>
                        <br />
                        <br />
                    </div>
                </asp:Panel>
                <asp:Panel ID="P02" runat="server" Visible="false" >
                    <div class="MenuBar">
                        <asp:LinkButton ID="BTNDBCK" runat="server" CssClass="TopMenu" Text="Regresar"></asp:LinkButton>
                    </div>
                    <asp:Literal ID="TITDET" runat="server" ></asp:Literal>
                    <div class="form1">
                        <table class="t01" >
                            <caption>Filtro</caption>
                            <tr>
                                <td>Tienda</td>
                                <td><asp:DropDownList runat="server" ID="TXTFTDA" CssClass="TextBox1"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td>Del</td>
                                <td><asp:TextBox ID="TXTFDEL" runat="server" CssClass="TextBox1" TextMode="Date" ></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>Al</td>
                                <td><asp:TextBox ID="TXTFAL" runat="server" CssClass="TextBox1" TextMode="Date" ></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align:center;"><asp:LinkButton ID="BTNFGO" runat="server" CssClass="TopMenu" Text="Filtrar"></asp:LinkButton></td>
                            </tr>
                        </table>
                    </div>
                    <br /><br />
                    <asp:GridView ID="GVDET" runat="server" CssClass="grid-view" 
                        AllowPaging="False" AllowSorting="False" 
                        AutoGenerateColumns="False"
                        RowStyle-CssClass="normal"
                        AlternatingRowStyle-CssClass="alternate"  
                        >                
                    </asp:GridView>
                    <br /><br />
                    <div class="Centrado" >
                <asp:ImageButton ID="BTNEXPOR2" runat="server" ImageUrl="~/images/Excel.gif" Width="35" />
            </div><br /><br />
                </asp:Panel>
            <asp:Timer ID="T0" runat="server" Interval="10000" Enabled="false"></asp:Timer>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger  ControlID="BTNSAP"/>
            <asp:PostBackTrigger ControlID="BTNEXPORT" />
            <asp:PostBackTrigger ControlID="BTNEXPOR2" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
