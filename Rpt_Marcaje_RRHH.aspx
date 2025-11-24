<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MP01.Master" CodeBehind="Rpt_Marcaje_RRHH.aspx.vb" Inherits="EasySapWeb.Rpt_Marcaje_RRHH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
         <asp:UpdatePanel ID="UP0" runat="server" >
        <ContentTemplate>
            <asp:Panel ID="P0" runat="server" Visible="true" >
            <div class="MenuBar">
                <a href="Menu.aspx" target="_self" class="TopMenu">Menú</a>
            </div>
            <h1>REPORTES DE RECURSOS HUMANOS</h1>
            <div class="form1" >
                <table class="t01" id="T0" runat="server"  >
                    <tr>
                        <td>REPORTE</td>
                        <td><asp:DropDownList ID="TXTREP" runat="server" CssClass="TextBox1" AutoPostBack="true"></asp:DropDownList></td>
                    </tr>
                     <tr>
                        <td>DEL</td>
                        <td><asp:TextBox ID="TXTDEL" runat="server" CssClass="TextBox1" TextMode="Date" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>AL</td>
                        <td><asp:TextBox ID="TXTAL" runat="server" CssClass="TextBox1" TextMode="Date" ></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td>TIPO DEPTOS</td>
                          <td><asp:DropDownList ID="TXTDPT" runat="server" CssClass="TextBox1" AutoPostBack="true" ></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>SECCION</td>
                          <td><asp:DropDownList ID="TXTSCN" runat="server" CssClass="TextBox1" AutoPostBack="true" ></asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td>SEMANAS DEL AÑO</td>
                          <td><asp:DropDownList ID="TXTSA" runat="server" CssClass="TextBox1" AutoPostBack="true" ></asp:DropDownList></td>
                    </tr>
                      <tr>
                        <td>PERIODO</td>
                        <td><asp:DropDownList ID="TXTPRD" runat="server" CssClass="TextBox1"  AutoPostBack ="true"  ></asp:DropDownList></td>
                    </tr>
                </table>                                
                <br />
                <div class="MenuBar">
                    <asp:LinkButton ID="BTNRUN" CssClass="TopMenu" Text="EJECUTAR" runat="server" ></asp:LinkButton>
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
                </asp:Panel>
            <br />
             <asp:Panel ID="P1" runat="server" CssClass="Pop" Visible="FALSE" Height="398px" Width="496px">
                <h1>INGRESO DE JUSTIFICACION&nbsp;</h1>
                <label>DEPARTAMENTO</label>
                   <asp:TextBox ID="TXTDEPTO" runat="server" CssClass="TextBox1" Enabled="false" ></asp:TextBox>
                   <br />
                <label>CODIGO DE EMPLEADO</label>
                   <asp:TextBox ID="TXTCOD" runat="server" CssClass="TextBox1"  Enabled="false"></asp:TextBox>
                   <br />
                <label>NOMBRE DE EMPLEADO</label>
                   <asp:TextBox ID="TXTEMP" runat="server" CssClass="TextBox1" Enabled="false" ></asp:TextBox>
                   <br />
                <label>FECHA</label>
                   <asp:TextBox ID="TXTFCH" runat="server" CssClass="TextBox1" Enabled="false"></asp:TextBox>
                   <br />
                <label>JUSTIFICACION</label>
                <asp:TextBox ID="TXTJUS" runat="server" CssClass="TextBox1" TextMode="MultiLine" Rows="3"></asp:TextBox><br />
                <br />
                <asp:Label ID="LBLERR" runat="server" CssClass="ERRM"></asp:Label><br />
                   <div class="MenuBar">
                    <br />
                     <asp:LinkButton ID="BTNGRD" runat="server" CssClass="TopMenu" Text="AGREGAR" OnClientClick ="return confirm('Guardar cambios?');"></asp:LinkButton>
                     <asp:LinkButton ID="BTNBACK" runat="server" CssClass="TopMenu" Text="REGRESAR" OnClientClick ="return confirm('Regresará al Menú?');"></asp:LinkButton>
                   </div>
           </asp:Panel>
            <br />
             <asp:Panel ID="P2" runat="server" CssClass="Pop" Visible="FALSE" Height="458px" Width="496px">
                <h1>ACTUALIZACION DE HORARIOS&nbsp;</h1>
                <label>DEPARTAMENTO</label>
                   <asp:TextBox ID="TXTDEP" runat="server" CssClass="TextBox1" Enabled="false" ></asp:TextBox>
                   <br />
                <label>SECCION</label>
                   <asp:TextBox ID="TXTSEC" runat="server" CssClass="TextBox1" Enabled="false" ></asp:TextBox>
                   <br />
                <label>NOMBRES</label>
                   <asp:TextBox ID="TXTNOM" runat="server" CssClass="TextBox1" Enabled="false" ></asp:TextBox>
                   <br />
                <label>DIAS</label>
                   <br />
                   <asp:DropDownList ID="TXTDIAS" runat="server" CssClass="TextBox1" AutoPostBack="true"></asp:DropDownList>
                   <br />
                <label>HORARIO DE ENTRADA</label>
                    <asp:TextBox ID="TXTHED" runat="server" CssClass="TextBox1" TextMode="Time" ></asp:TextBox><br />
                <label>HORARIO DE SALIDA</label>
                    <asp:TextBox ID="TXTHSD" runat="server" CssClass="TextBox1" TextMode="Time"></asp:TextBox><br />
                <label>HORAS DIARIAS PROYECTADAS</label>
                    <asp:TextBox ID="TXTPROYEC" runat="server" CssClass="TextBox1"  TextMode="Number"></asp:TextBox><br />
                 <asp:TextBox ID="TXTID" runat="server" CssClass="TextBox1" Enabled="false" Visible="false" ></asp:TextBox>
                     <br />
                <asp:Label ID="LBLERR3" runat="server" CssClass="ERRM"></asp:Label><br />
                   <div class="MenuBar">
                    <br />
                     <asp:LinkButton ID="BTNACTUALIZA" runat="server" CssClass="TopMenu" Text="ACTUALIZAR" OnClientClick ="return confirm('Guardar cambios?');"></asp:LinkButton>
                     <asp:LinkButton ID="BTNREGRESA" runat="server" CssClass="TopMenu" Text="REGRESAR" OnClientClick ="return confirm('Regresará al Menú?');"></asp:LinkButton>
                   </div>
                 <br />
           </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="BTNEXPORT" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
