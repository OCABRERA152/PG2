Imports System.IO

Public Class NOM_RPT_AltasBajas
    Inherits base

    Private Sub NOM_RPT_AltasBajas_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If
    End Sub

    Private Sub RPTALTASBAJAS()
        HFFECHAINI.Value = TRANSFECHA(CDate(TXTFECHAINI.Text))
        HFFECHAFIN.Value = TRANSFECHA(CDate(TXTFECHAFIN.Text))
        GridBind(GVRPTALTASYBAJAS, "EXEC SBOSP_ALTAS_BAJAS '" + HFFECHAINI.Value.ToString() + "','" + HFFECHAFIN.Value.ToString() + "'", "", {""})
    End Sub

    Private Sub ExportToExcel(ByVal strFileName As String, ByVal dg As GridView)

        Dim sb As StringBuilder = New StringBuilder()
        Dim sw As StringWriter = New StringWriter(sb)
        Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim pagina As Page = New Page
        Dim form = New HtmlForm
        dg.AllowPaging = False
        GridBind(GVRPTALTASYBAJAS, "EXEC SBOSP_ALTAS_BAJAS '" + HFFECHAINI.Value.ToString() + "','" + HFFECHAFIN.Value.ToString() + "'", "", {""})
        dg.EnableViewState = False
        pagina.EnableEventValidation = False
        pagina.DesignerInitialize()
        pagina.Controls.Add(form)
        form.Controls.Add(dg)
        pagina.RenderControl(htw)
        Response.Clear()
        Response.Buffer = True
        Response.ContentType = "application/vnd.ms-excel"
        Response.AddHeader("Content-Disposition", "attachment;filename=" + strFileName + ".xls")
        Response.Charset = "UTF-8"
        Response.ContentEncoding = Encoding.Default
        Response.Write(sb.ToString())
        Response.End()
    End Sub

    Private Sub BTNGENERARPTALTASBAJAS_Click(sender As Object, e As EventArgs) Handles BTNGENERARPTALTASBAJAS.Click
        RPTALTASBAJAS
    End Sub

    Private Sub BTNDESCARRPTALTASBAJASEXCEL_Click(sender As Object, e As EventArgs) Handles BTNDESCARRPTALTASBAJASEXCEL.Click
        If GVRPTALTASYBAJAS.Rows.Count > 0 Then
            ExportToExcel("Informe del Altas y Bajas", GVRPTALTASYBAJAS)
        End If
    End Sub

    Private Sub GVRPTALTASYBAJAS_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVRPTALTASYBAJAS.PageIndexChanging
        GVRPTALTASYBAJAS.PageIndex = e.NewPageIndex
        GridBind(GVRPTALTASYBAJAS, "EXEC SBOSP_ALTAS_BAJAS '" + HFFECHAINI.Value.ToString() + "','" + HFFECHAFIN.Value.ToString() + "'", "", {""})
    End Sub

    Private Function TRANSFECHA(ByRef fecha As Date) As String
        Dim res As String
        res = fecha.Year.ToString()
        If fecha.Month.ToString().Length = 1 Then
            res += "0" + fecha.Month.ToString()
        ElseIf fecha.Month.ToString().Length > 1 Then
            res += fecha.Month.ToString()
        End If
        If fecha.Day.ToString().Length = 1 Then
            res += "0" + fecha.Day.ToString()
        ElseIf fecha.Day.ToString().Length > 1 Then
            res += fecha.Day.ToString()
        End If

        Return res
    End Function
End Class