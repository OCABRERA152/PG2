Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Exit Sub
        End If
        If Session("prv") Is Nothing Then
            Session.Abandon()
        End If
        'REVISAR SI EXISTE EL COOKIE QUE GUARDA EL USUARIO Y CONTRASEÑA
        If Not (Request.Cookies("UNA") Is Nothing) Then
            TXTUSR.Text = Request.Cookies("UNA").Value
            TXTPWD.Focus()
        Else
            TXTUSR.Focus()
        End If
    End Sub

    Protected Sub BTNLOGIN_Click(sender As Object, e As EventArgs) Handles BTNLOGIN.Click
        TXTUSR.Text = LCase(TXTUSR.Text)
        AbrirRecordsetData("EXEC SEGURIDAD 4,'ADMINISTRADOR','" & TXTUSR.Text & "','" & TXTPWD.Text & "',''")
        If nA(0) = 0 Then
            ERRMSG.Text = nA(1)
            Exit Sub
        End If
        USR = "ADMINISTRADOR"
        STA = "CONECTADO"
        NOM = nA(2)
        UCO = nA(3)
        CODEMPSAP = nA(4)
        TRM = ""
        Session.Add("USR", USR)
        Session.Add("NOM", NOM)
        Session.Add("TRM", TRM)
        Session.Add("UCO", UCO)
        Session.Add("CODEMPSAP", CODEMPSAP)
        Session.Add("EML", TXTUSR.Text)
        'COOKIE
        If Request.Cookies("UNA") Is Nothing Then
            Dim nCookie As New HttpCookie("UNA")
            nCookie.Value = TXTUSR.Text
            nCookie.Expires = Date.Now.AddDays(7)
            Response.Cookies.Add(nCookie)
        Else
            Response.Cookies("UNA").Value = TXTUSR.Text
            Response.Cookies("UNA").Expires = Date.Now.AddDays(7)
        End If
        Response.Redirect("Pagina_inicio.aspx")
    End Sub

    Protected Sub TXTPWD_TextChanged(sender As Object, e As EventArgs) Handles TXTPWD.TextChanged
        BTNLOGIN_Click(BTNLOGIN, e)
    End Sub
End Class