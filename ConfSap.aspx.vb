Public Class ConfSap
    Inherits base

    Private Sub BTNOUT_Click(sender As Object, e As EventArgs) Handles BTNOUT.Click
        Session.Clear()
        Response.Redirect("Login.aspx")
    End Sub

    Private Sub BTNINT_Click(sender As Object, e As EventArgs) Handles BTNINT.Click
        Response.Redirect("Interfaz.aspx")
    End Sub

    Private Sub ConfSap_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If
        AbrirRecordsetData("EXEC PRG_SAP 1")
        TXTSRVSQL.Text = nA(0)
        TXTDBBSQL.Text = nA(1)
        TXTUSRSQL.Text = nA(2)
        TXTPWDSQL.Text = nA(3)
        TXTUSRSAP.Text = nA(4)
        TXTPWDSAP.Text = nA(5)
        TXTEMPSAP.Text = nA(6)
    End Sub

    Private Sub BTNSAV_Click(sender As Object, e As EventArgs) Handles BTNSAV.Click
        'probar el asunto
        Dim nCon As New System.Data.SqlClient.SqlConnection("server=" & TXTSRVSQL.Text & ";database=" & TXTDBBSQL.Text & ";uid=" & TXTUSRSQL.Text & ";password=" & TXTPWDSQL.Text & ";")
        Try
            nCon.Open()
        Catch ex As Exception
            ERRM.Text = ex.Message
            Exit Sub
        End Try
        nCon.Close()
        AbrirRecordsetData("EXEC PRG_SAP 2,'" & TXTSRVSQL.Text & "','" & TXTDBBSQL.Text & "','" & TXTUSRSQL.Text & "','" & TXTPWDSQL.Text & "','" & TXTUSRSAP.Text & "','" & TXTPWDSAP.Text & "','" & TXTEMPSAP.Text & "'")
        ERRM.Text = "Guardado satisfactoriamente"
    End Sub
End Class