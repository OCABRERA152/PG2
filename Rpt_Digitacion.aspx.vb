Public Class Rpt_Digitacion
    Inherits base

    Private Sub Rpt_Digitacion_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If
        DdBind(TXTPREP, "EXEC PRG_RPT_DIGIT 1", "CODIGO", "REPORTE")
        DdBind(TXTTDA, "EXEC PRG_RPT_DIGIT 2", "CODIGO", "NOMBRE")
        DdBind(TXTPER, "EXEC PRG_RPT_DIGIT 3", "PERIODO", "PERIODO")
        TXTPREP_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub TXTPREP_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TXTPREP.SelectedIndexChanged
        Dim nStr As String = TXTPREP.SelectedItem.Value
        TXTFDEL.Enabled = False
        TXTFAL.Enabled = False
        TXTTDA.Enabled = False
        TXTPER.Enabled = False
        TXTFIL.Enabled = False
        If nStr.Contains("TXTFDEL") Then
            TXTFDEL.Enabled = True
        End If
        If nStr.Contains("TXTFAL") Then
            TXTFAL.Enabled = True
        End If
        If nStr.Contains("TXTTDA") Then
            TXTTDA.Enabled = True
        End If
        If nStr.Contains("TXTPER") Then
            TXTPER.Enabled = True
        End If
        If nStr.Contains("TXTFIL") Then
            TXTFIL.Enabled = True
        End If
    End Sub

    Private Sub BTNGO_Click(sender As Object, e As EventArgs) Handles BTNGO.Click
        GridBind(GVREP, "EXEC PRG_RPT_DIGIT " & TXTPREP.SelectedItem.Value.Substring(0, 3) & ",'" & IIf(TXTPREP.SelectedItem.Value.Substring(0, 3) = "109", Session("UCO"), TXTTDA.Text) & "','" & TXTFDEL.Text & "','" & TXTFAL.Text & "','" & TXTPER.Text & "','" & TXTFIL.Text & "'", "", {"COMIDIN", "Linea", "codigo", "OP1", "OP2", "OP3"})

    End Sub

    Protected Sub BTNEXPORT_Click(sender As Object, e As ImageClickEventArgs) Handles BTNEXPORT.Click
        If GVREP.Rows.Count > 0 Then
            ExportToExcel(Replace(Replace(TXTPREP.SelectedItem.Text, " ", "_", 1), "/", "_", 1) & ".xls", GVREP)
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

End Class