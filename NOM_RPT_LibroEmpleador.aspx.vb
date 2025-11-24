Imports System.IO

Public Class NOM_RPT_LibroEmpleador
    Inherits base

    Private Sub NOM_RPT_LibroEmpleador_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If
    End Sub

    Private Sub BTNGENERARPTEMPLEADOR_Click(sender As Object, e As EventArgs) Handles BTNGENERARPTEMPLEADOR.Click
        RPTEMPLEADOR()
    End Sub

    Private Sub RPTEMPLEADOR()
        GridBind(GVRPTEMPLEADOR, "SELECT * FROM SBOV_INFORME_EMPLEADOR", "", {""})
    End Sub

    Private Sub BTNDESCARRPTEMPAEXCEL_Click(sender As Object, e As EventArgs) Handles BTNDESCARRPTEMPAEXCEL.Click
        If GVRPTEMPLEADOR.Rows.Count > 0 Then
            ExportToExcel("Informe del Empleador", GVRPTEMPLEADOR)
        End If
    End Sub

    Private Sub ExportToExcel(ByVal strFileName As String, ByVal dg As GridView)

        Dim sb As StringBuilder = New StringBuilder()
        Dim sw As StringWriter = New StringWriter(sb)
        Dim htw As HtmlTextWriter = New HtmlTextWriter(sw)
        Dim pagina As Page = New Page
        Dim form = New HtmlForm
        dg.AllowPaging = False
        GridBind(GVRPTEMPLEADOR, "SELECT * FROM SBOV_INFORME_EMPLEADOR", "", {""})
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

    Private Sub GVRPTEMPLEADOR_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVRPTEMPLEADOR.PageIndexChanging
        GVRPTEMPLEADOR.PageIndex = e.NewPageIndex
        GridBind(GVRPTEMPLEADOR, "SELECT * FROM SBOV_INFORME_EMPLEADOR", "", {""})
    End Sub
End Class