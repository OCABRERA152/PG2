<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MP01.Master" CodeBehind="Login.aspx.vb" Inherits="EasySapWeb.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
    <div class="w3-display-container w3-content" style="max-width:700px" >
    <div class="w3-card-4">

            <header class="w3-container w3-yellow">
              <h3>Inicio de Sesión</h3>
            </header>
            <br />
            <div class="w3-container">
              <label for="TXTUSR" >Usuario</label>
                        <br />
                        <asp:TextBox runat="server"  ID="TXTUSR"  TextMode="SingleLine" autofocus="true" CssClass="w3-input" ></asp:TextBox>
                        <br />
                        <label for="TXTPWD" >Constraseña</label>
                        <br />
                        <asp:TextBox runat="server"  ID="TXTPWD"  TextMode="Password" AutoPostBack ="true" CssClass="w3-input"></asp:TextBox>
                        <br />
                <asp:CheckBox runat="server" Text="Recordar en este equipo" CssClass="w3-check" />
                <br /><br />
                <asp:Label runat="server" ID="ERRMSG" ></asp:Label>
            </div>
 
             <asp:LinkButton ID="BTNLOGIN" Text="Ingresar" runat="server" CssClass="w3-button w3-block w3-red w3-hover-yellow" ></asp:LinkButton>
    </div>       
</div>

</asp:Content>
