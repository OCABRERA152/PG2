Public Class Bitacora
    Inherits base

    Private Sub Bitacora_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If
        GridBind(GVBIT, "EXEC PRG_BITACORA 1,'" & Session.Item("UCO") & "'", "", {"CODIGO"})
        HF01.Value = "0"
    End Sub

    Private Sub BTNADD_Click(sender As Object, e As EventArgs) Handles BTNADD.Click
        HF01.Value = "0"
        P0.Visible = False
        P1.Visible = True
        TXTSOL.Text = ""
        TXTDES.Text = ""
        L01.Text = "<h2 Class=" & "h1azul" & ">Nueva Actividad</h2>"
    End Sub

    Private Sub BTNCANACT_Click(sender As Object, e As EventArgs) Handles BTNCANACT.Click
        P1.Visible = False
        P0.Visible = True
        GVBIT.SelectedIndex = -1
    End Sub

    Private Sub BTNADDACT_Click(sender As Object, e As EventArgs) Handles BTNADDACT.Click
        If TXTDES.Text.Length = 0 Then
            Exit Sub
        End If
        If HF01.Value = "0" Then
            AbrirRecordsetData("EXEC PRG_BITACORA 2,'" & Session("UCO") & "','" & TXTSOL.Text & "','" & TXTDES.Text & "'")
        Else
            GridBind(GVBIT, "EXEC PRG_BITACORA 1,'" & Session("UCO") & "'", "", {"CODIGO"})
            Exit Sub
        End If
        GridBind(GVBIT, "EXEC PRG_BITACORA 1,'" & Session("UCO") & "'", "", {"CODIGO"})
        HF01.Value = "0"
        P1.Visible = False
        P0.Visible = True
        GVBIT.SelectedIndex = -1
    End Sub

    Private Sub GVBIT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVBIT.SelectedIndexChanged
        If (Val(GVBIT.SelectedRow.Cells(0).Text) = 0) Or (GVBIT.SelectedRow.Cells(5).Text.Contains("TERMINADA")) Then
            Exit Sub
        End If
        L02.Text = "<table class=""t090""><tr><td>Fecha</td><td>" & GVBIT.SelectedRow.Cells(1).Text & "</td></tr>" _
            & "<tr><td>Hora</td><td>" & GVBIT.SelectedRow.Cells(2).Text & "</td></tr>" _
            & "<tr><td>Solicitante</td><td>" & GVBIT.SelectedRow.Cells(3).Text & "</td></tr>" _
            & "<tr><td>Descripcion</td><td>" & GVBIT.SelectedRow.Cells(4).Text & "</td></tr>" _
            & "<tr><td>Estado</td><td>" & GVBIT.SelectedRow.Cells(5).Text & "</td></tr></table><br />"
        HF01.Value = GVBIT.SelectedRow.Cells(0).Text
        TXTSOL1.Text = HttpUtility.HtmlDecode(GVBIT.SelectedRow.Cells(3).Text)
        TXTDESC1.Text = HttpUtility.HtmlDecode(GVBIT.SelectedRow.Cells(4).Text)
        If GVBIT.SelectedRow.Cells(5).Text.Contains("PENDIENTE") Then
            BTNCLOACT.Visible = True
        Else
            BTNCLOACT.Visible = False
        End If
        P0.Visible = False
        P1.Visible = False
        P2.Visible = True
    End Sub

    Private Sub BTNCLOACT_Click(sender As Object, e As EventArgs) Handles BTNCLOACT.Click
        P2.Visible = False
        P3.Visible = True
    End Sub

    Private Sub BTNFLT_Click(sender As Object, e As EventArgs) Handles BTNFLT.Click
        GridBind(GVBIT, "EXEC PRG_BITACORA 1,'" & Session("UCO") & "','" & TXTDEL.Text & "','" & TXTAL.Text & "'", "", {"CODIGO"})
    End Sub

    Protected Sub LinkButton2_Click(sender As Object, e As EventArgs) Handles LinkButton2.Click
        P2.Visible = False
        P0.Visible = True
        GVBIT.SelectedIndex = -1
    End Sub

    Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles LinkButton1.Click
        If HF01.Value = "0" Then
            GridBind(GVBIT, "EXEC PRG_BITACORA 1,'" & Session("UCO") & "'", "", {"CODIGO"})
            Exit Sub
        Else
            AbrirRecordsetData("EXEC PRG_BITACORA 3,'" & Session("UCO") & "','" & TXTSOL1.Text & "','" & TXTDESC1.Text & "','" & HF01.Value & "'")
        End If
        GridBind(GVBIT, "EXEC PRG_BITACORA 1,'" & Session("UCO") & "'", "", {"CODIGO"})
        HF01.Value = "0"
        P2.Visible = False
        P0.Visible = True
        GVBIT.SelectedIndex = -1
    End Sub

    Private Sub BTNPROCESAR_Click(sender As Object, e As EventArgs) Handles BTNPROCESAR.Click
        AbrirRecordsetData("EXEC PRG_BITACORA 4,'" & Session.Item("UCO") & "','" & TXTSOL1.Text & "','" & TXTCOMENTCIERRE.Text & "','" & HF01.Value & "'")
        GridBind(GVBIT, "EXEC PRG_BITACORA 1,'" & Session.Item("UCO") & "'", "", {"CODIGO"})
        TXTCOMENTCIERRE.Text = ""
        P3.Visible = False
        P2.Visible = False
        P0.Visible = True
    End Sub
End Class