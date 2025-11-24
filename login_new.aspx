<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login_new.aspx.vb" Inherits="EasySapWeb.Login_new" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>VIFRIO PW | Inicio de sesión</title>
   <!--Made with love by Mutiullah Samim -->
   
	<!--Bootsrap 4 CDN-->
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css"  />
    
    <!--Fontawesome CDN-->
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" />

	<!--Custom styles-->
    <link href="CssLoginNew.css" rel="stylesheet" />
	<meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="shortcut icon" type="image/x-icon" href="images/llanta.ico" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

</head>
<body>

<div class="container">
	<div class="d-flex justify-content-center h-100">
		<div class="card">
			<div class="card-header">
				<h3>Iniciar sesión</h3>
			</div>
			<div class="card-body">
                <form id="form2" runat="server">
					<div class="input-group form-group">
						<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-user"></i></span>
						</div>
                        <asp:TextBox runat="server" ID="TXTUSR" placeholder="Nombre de usuario" CssClass="form-control" autofocus="true" TextMode="SingleLine"></asp:TextBox>
					</div>
					<div class="input-group form-group">
						<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-key"></i></span>
						</div>
                         <asp:TextBox runat="server" ID="TXTPWD" TextMode="Password" AutoPostBack="true" CssClass="form-control" placeholder="Contraseña"></asp:TextBox>
					</div>
					<div class="row align-items-center remember">
                        <asp:CheckBox runat="server" Text="Recordar" CssClass="w3-check" />
					</div>
					<div class="form-group">
                        <asp:LinkButton ID="BTNLOGIN" Text="Iniciar" runat="server" CssClass="btn float-right login_btn" ></asp:LinkButton>
					</div>
                </form>
			</div>
			<div class="card-footer">
                <asp:Label runat="server" ID="ERRMSG" BackColor="Red" ForeColor="White" ></asp:Label>
			</div>
		</div>
	</div>
</div>
</body>
</html>
