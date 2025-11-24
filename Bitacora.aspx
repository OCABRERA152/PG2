<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MP01.Master" CodeBehind="Bitacora.aspx.vb" Inherits="EasySapWeb.Bitacora" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <asp:UpdatePanel ID="UP0" runat="server">
        <ContentTemplate>
            <asp:HiddenField ID="HF01" runat="server" />
            <asp:Panel ID="P0" runat="server" >
                <div class="MenuBar" >
                    <a href="Menu.aspx" target="_self" class="TopMenu" >Menú</a>
                </div>
                <br />
                <h1 class="h1azul">Bitácora de Usuario</h1>
                <br /><br />
                <div class="form1" >
                    <br />
                    <table class="t01" >
                        <tr>
                            <td>Del</td>
                            <td><asp:TextBox ID="TXTDEL" runat="server" CssClass="TextBox1" TextMode="Date"  AUTOFOCUS="true"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Al</td>
                            <td><asp:TextBox ID="TXTAL" runat="server" CssClass="TextBox1" TextMode="Date"  ></asp:TextBox></td>
                        </tr>
                    </table>
                    <br />
                       <div class="MenuBar" >
                           <asp:LinkButton ID="BTNFLT" runat="server" CssClass="TopMenu" Text="FILTRAR"></asp:LinkButton>
                       </div>
                </div>
                <br />
               <asp:GridView ID="GVBIT" runat="server" CssClass="grid-view" 
                AllowPaging="False" AllowSorting="False" 
                AutoGenerateColumns="False"
                RowStyle-CssClass="normal"
                AlternatingRowStyle-CssClass="alternate"  
                >                
                </asp:GridView>
                <br /><br />
                <div class="MenuBar" >
                    <asp:LinkButton ID="BTNADD" runat="server" CssClass="TopMenu" Text="Agregar"></asp:LinkButton>
                </div>
            </asp:Panel>
            <asp:Panel ID="P1" runat="server" Visible="false">
                <h1 class="h1azul">Agregar Actividad Bitácora</h1>
                <br />
                <asp:Literal ID="L01" runat="server"></asp:Literal>
                <div class="form1">
                    <table class="t01" >
                        <tr>
                            <td>SOLICITANTE</td>
                            <td><asp:TextBox ID="TXTSOL" runat="server" CssClass="TextBox1" Autofocus="true" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>DESCRIPCION</td>
                            <td><asp:TextBox ID="TXTDES" runat="server" CssClass="TextBox1" TextMode="MultiLine" Rows="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="LBLERRM01" runat="server" CssClass="ERRM"></asp:Label>
                            </td>
                        </tr>
                        <tr class="MenuBar">
                            <td colspan="2"><asp:LinkButton ID="BTNADDACT" runat="server" CssClass="TopMenu" Text="Guardar"></asp:LinkButton> &nbsp;&nbsp;
                                <asp:LinkButton ID="BTNCANACT" runat="server" CssClass="TopMenu" Text="Cancelar" OnClientClick="return confirm('Cancelar Cambios?');"></asp:LinkButton>&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
            </asp:Panel>
             <asp:Panel ID="P2" runat="server" Visible="false">
                <h1 class="h1azul">Modificar o Cerrar Actividad Bitácora</h1>
                <br />
                <asp:Literal ID="L02" runat="server"></asp:Literal>
                <div class="form1">
                    <table class="t01" >
                        <tr>
                            <td>SOLICITANTE</td>
                            <td><asp:TextBox ID="TXTSOL1" runat="server" CssClass="TextBox1" Autofocus="true" Enabled="true" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>DESCRIPCION</td>
                            <td><asp:TextBox ID="TXTDESC1" runat="server" CssClass="TextBox1" TextMode="MultiLine" Rows="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label1" runat="server" CssClass="ERRM"></asp:Label>
                            </td>
                        </tr>
                        <tr class="MenuBar">
                            <td colspan="2"><asp:LinkButton ID="LinkButton1" runat="server" CssClass="TopMenu" Text="Actualizar"></asp:LinkButton> &nbsp;&nbsp;
                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="TopMenu" Text="Cancelar" OnClientClick="return confirm('Cancelar Cambios?');"></asp:LinkButton>&nbsp;&nbsp;
                            <asp:LinkButton ID="BTNCLOACT" runat="server" CssClass="TopMenu" Text="Cerrar" OnClientClick="return confirm('Cerrar la actividad?');" Visible="false" ></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
            </asp:Panel>
            <asp:Panel ID="P3" runat="server" Visible="false">
                <h1 class="h1azul">Comentario de Cierre</h1>
                <br />
                <asp:Literal ID="L03" runat="server"></asp:Literal>
                <div class="form1">
                    <table class="t01" >
                        <tr>
                            <td>DESCRIPCION</td>
                            <td><asp:TextBox ID="TXTCOMENTCIERRE" runat="server" CssClass="TextBox1" TextMode="MultiLine" Rows="10"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label2" runat="server" CssClass="ERRM"></asp:Label>
                            </td>
                        </tr>
                        <tr class="MenuBar">
                            <td colspan="2">
                                <asp:LinkButton ID="BTNCCCANCELAR" runat="server" CssClass="TopMenu" Text="Cancelar" OnClientClick="return confirm('Cancelar Cambios?');"></asp:LinkButton>&nbsp;&nbsp;
                                <asp:LinkButton ID="BTNPROCESAR" runat="server" CssClass="TopMenu" Text="Cerrar" OnClientClick="return confirm('Cerrar la actividad?');" Visible="True" ></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
