Public Class Rpt_Marcaje_RRHH
    Inherits base
    Private Sub Rpt_Marcaje_RRHH_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If
        AbrirRecordsetData("EXEC PRG_RPT_RRHH 3,'" & Session("UCO") & "'")
        If nA(0) = 0 Then
            Notifica(nA(1), "Menu.aspx")
            Exit Sub
        End If
        T0.Rows(1).Visible = False
        T0.Rows(2).Visible = False
        T0.Rows(3).Visible = False
        T0.Rows(4).Visible = False
        T0.Rows(5).Visible = False
        T0.Rows(6).Visible = False
        DdBind(TXTPRD, "EXEC PRG_RPT_RRHH 11", "PERIODO", "PERIODO")
        DdBind(TXTREP, "EXEC PRG_RPT_RRHH 1", "CODIGO", "REPORTE")
        DdBind(TXTDPT, "EXEC PRG_RPT_RRHH 2, '" & Session("UCO") & "'", "DEPARTAMENTO", "DESCRIPCION")
        DdBind(TXTSA, "EXEC PRG_RPT_RRHH 10", "SEMANA", "SEMANA")
        GridBind(GVREP, "SELECT 'Seleccione el reporte y sus parametros luego presione ""Ejecutar""'", "", {""})
        TXTREP.SelectedIndex = 0
        TXTREP_SelectedIndexChanged(sender, e)
    End Sub
    Protected Sub BTNRUN_Click(sender As Object, e As EventArgs) Handles BTNRUN.Click
        If TXTREP.SelectedItem.Value.Substring(0, 3) = 101 Or TXTREP.SelectedItem.Value.Substring(0, 3) = 103 Then
            GridBind(GVREP, "EXEC PRG_RPT_RRHH " & TXTREP.SelectedItem.Value.Substring(0, 3) & ",'" & Session("UCO") & "','" & TXTDEL.Text & "','" & TXTAL.Text & "','" & TXTDPT.SelectedItem.Value & "','" & TXTSCN.SelectedItem.Value & "','" & TXTSA.Text & "','" & TXTPRD.SelectedItem.Value & "'", "", {"CODIGO"})
        End If
        If TXTREP.SelectedItem.Value.Substring(0, 3) = 104 Then
            GridBind(GVREP, "EXEC PRG_RPT_RRHH " & TXTREP.SelectedItem.Value.Substring(0, 3) & ",'" & Session("UCO") & "','" & TXTPRD.SelectedItem.Value & "'", "", {"CODIGO"})
        End If
        If TXTREP.SelectedItem.Value.Substring(0, 3) = 108 Then
            If Session("UCO") = 6 Or Session("UCO") = 38 Or Session("UCO") = 39 Then
                GridBind(GVREP, "EXEC PRG_RPT_RRHH " & TXTREP.SelectedItem.Value.Substring(0, 3) & ",'" & Session("UCO") & "','" & TXTDEL.Text & "','" & TXTAL.Text & "','" & TXTDPT.SelectedItem.Value & "','" & TXTSCN.SelectedItem.Value & "','" & TXTSA.Text & "'", "", {"CODIGO"})
            End If
        End If
        If TXTREP.SelectedItem.Value.Substring(0, 3) = 109 Then
            GridBind(GVREP, "EXEC PRG_RPT_RRHH " & TXTREP.SelectedItem.Value.Substring(0, 3) & ",'" & Session("UCO") & "','" & TXTPRD.SelectedItem.Value & "'", "", {"CODIGO"})
        End If
    End Sub

    Protected Sub BTNEXPORT_Click(sender As Object, e As ImageClickEventArgs) Handles BTNEXPORT.Click
        If GVREP.Rows.Count > 0 Then
            ExportToExcel(Replace(Replace(TXTREP.SelectedItem.Text, " ", "_", 1), "/", "_", 1) & ".xls", GVREP)
        End If
    End Sub

    Private Sub ExportToExcel(ByVal strFileName As String, ByVal dg As GridView)
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=" & strFileName)
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Dim oStringWriter As New System.IO.StringWriter
        Dim oHtmlTextWriter As New System.Web.UI.HtmlTextWriter(oStringWriter)
        dg.RenderControl(oHtmlTextWriter)
        Response.Write(oStringWriter.ToString())
        Response.End()
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        'MyBase.VerifyRenderingInServerForm(control)
    End Sub

    Private Sub TXTREP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TXTREP.SelectedIndexChanged
        If TXTREP.SelectedIndex = -1 Then
            Exit Sub
        End If
        T0.Rows(1).Visible = False
        T0.Rows(2).Visible = False
        T0.Rows(3).Visible = False
        T0.Rows(4).Visible = False
        T0.Rows(5).Visible = False
        T0.Rows(6).Visible = False
        Dim nRep As String
        Dim nRow As String()
        nRep = TXTREP.SelectedItem.Value.Substring(0, 3)
        nRow = TXTREP.SelectedItem.Value.Substring(4, Len(TXTREP.SelectedItem.Value) - 4).Split(",")
        For nI = 0 To nRow.Length - 1
            T0.Rows(nRow(nI)).Visible = True
        Next
    End Sub

    Protected Sub GVREP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVREP.SelectedIndexChanged
        If TXTREP.SelectedItem.Value.Substring(0, 3) = 104 Then

            If GVREP.SelectedRow.Cells(0).Text.Length = 0 Then
                Exit Sub
            End If
            P0.Visible = False
            P1.Visible = True
            TXTDEPTO.Text = GVREP.SelectedRow.Cells(0).Text
            TXTCOD.Text = GVREP.SelectedRow.Cells(1).Text
            TXTEMP.Text = GVREP.SelectedRow.Cells(2).Text
            TXTFCH.Text = GVREP.SelectedRow.Cells(3).Text
            TXTJUS.Text = GVREP.SelectedRow.Cells(7).Text
            GVREP.SelectedIndex = -1
        End If
        If TXTREP.SelectedItem.Value.Substring(0, 3) = 108 Then

            If GVREP.SelectedRow.Cells(0).Text.Length = 0 Then
                Exit Sub
            End If
            P0.Visible = False
            P2.Visible = True
            DdBind(TXTDIAS, "EXEC PRG_RPT_RRHH 9", "DIA", "DIA")
            TXTID.Text = GVREP.SelectedRow.Cells(0).Text
            TXTDEP.Text = TXTDPT.SelectedItem.Text
            TXTSEC.Text = TXTSCN.SelectedItem.Text
            TXTNOM.Text = GVREP.SelectedRow.Cells(1).Text
            GVREP.SelectedIndex = -1
        End If
    End Sub

    Protected Sub BTNBACK_Click(sender As Object, e As EventArgs) Handles BTNBACK.Click
        P0.Visible = True
        P1.Visible = False
    End Sub

    Protected Sub BTNGRD_Click(sender As Object, e As EventArgs) Handles BTNGRD.Click
        LBLERR.Text = ""
        AbrirRecordsetData("PRG_RPT_RRHH 102,'" & TXTCOD.Text & "','" & TXTFCH.Text & "','" & TXTJUS.Text & "','" & Session("UCO") & "'")
        If nA(0) = 0 Then
            LBLERR.Text = nA(1)
            Exit Sub
        End If
        P0.Visible = True
        P1.Visible = False
        If TXTREP.SelectedItem.Value.Substring(0, 3) = 104 Then
            GridBind(GVREP, "EXEC PRG_RPT_RRHH " & TXTREP.SelectedItem.Value.Substring(0, 3) & ",'" & Session("UCO") & "','" & TXTPRD.SelectedItem.Value & "'", "", {"CODIGO"})
        End If
    End Sub

    Protected Sub TXTDPT_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TXTDPT.SelectedIndexChanged
        DdBind(TXTSCN, "EXEC PRG_RPT_RRHH 6," & TXTDPT.SelectedItem.Value & "", "DEPARTAMENTO", "DEPARTAMENTO")
    End Sub

    Protected Sub BTNREGRESA_Click(sender As Object, e As EventArgs) Handles BTNREGRESA.Click
        P0.Visible = True
        P2.Visible = False
        TXTHED.Text = ""
        TXTHSD.Text = ""
        TXTPROYEC.Text = ""
        LBLERR3.Text = ""
    End Sub

    Protected Sub TXTDIAS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TXTDIAS.SelectedIndexChanged
        DdBind1(TXTHED, TXTHSD, TXTPROYEC, "EXEC PRG_RPT_RRHH 8,'" & TXTDIAS.Text & "','" & TXTDPT.SelectedItem.Value & "','" & TXTSCN.SelectedItem.Value & "','" & TXTID.Text & "'")
    End Sub

    Protected Sub BTNACTUALIZA_Click(sender As Object, e As EventArgs) Handles BTNACTUALIZA.Click
        LBLERR3.Text = ""
        AbrirRecordsetData("PRG_RPT_RRHH 107,'" & TXTHED.Text & "','" & TXTHSD.Text & "','" & TXTPROYEC.Text & "','" & Session("UCO") & "','" & TXTSEC.Text & "','" & TXTID.Text & "','" & TXTDPT.SelectedItem.Value & "','" & TXTDIAS.Text & "'")
        If nA(0) = 0 Then
            LBLERR3.Text = nA(1)
            P0.Visible = True
            P2.Visible = False
            TXTHED.Text = ""
            TXTHSD.Text = ""
            TXTPROYEC.Text = ""
            LBLERR3.Text = ""
            Exit Sub
        End If
    End Sub

End Class
