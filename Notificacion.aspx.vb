Partial Public Class Notificacion
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("NTX") Is Nothing) Or (Session("NNX") Is Nothing) Then
            TXTNOTI.Text = "LA SESION HA CADUCADO, POR FAVOR, VUELVA A INGRESAR"
            FBACK.Value = "Login.aspx"
            Exit Sub
        End If
        TXTNOTI.Text = Session("NTX")
        FBACK.Value = Session("NNX")
        Master.FindControl("BTNHLP").Visible = False
    End Sub

    Protected Sub BTNBACK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles BTNBACK.Click
        Response.Redirect(FBACK.Value)
    End Sub

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        Response.Redirect(FBACK.Value)
    End Sub
End Class