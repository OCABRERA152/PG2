Public Class NOM_Salarios
    Inherits base

    Private Sub NOM_Salarios_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If
        LLENAGRIDSALARIO()
    End Sub

    Private Sub LLENAGRIDSALARIO()
        GridBind(GVSALARIOS, "EXEC SBOSP_INGRESO_SALARIOS 1", "", {"LINEA", "CODIGO"})
    End Sub

    Private Sub GVSALARIOS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVSALARIOS.SelectedIndexChanged
        Dim pagina As Int32 = GVSALARIOS.PageIndex

        If CInt((GVSALARIOS.Rows(GVSALARIOS.SelectedIndex - (GVSALARIOS.PageSize * pagina)).Cells(0).Text)) > 0 Then
            LimpiarFormulario()

            HFLINEASALARIO.Value = (GVSALARIOS.Rows(GVSALARIOS.SelectedIndex - (GVSALARIOS.PageSize * pagina)).Cells(0).Text)
            HFIDEMPLEADO.Value = (GVSALARIOS.Rows(GVSALARIOS.SelectedIndex - (GVSALARIOS.PageSize * pagina)).Cells(1).Text)

            TXTCODIGOEMPLEADO.Text = (GVSALARIOS.Rows(GVSALARIOS.SelectedIndex - (GVSALARIOS.PageSize * pagina)).Cells(1).Text)
            TXTCODIGOEMPLEADO.Enabled = False
            TXTCODIGODECONTRATO.Text = (GVSALARIOS.Rows(GVSALARIOS.SelectedIndex - (GVSALARIOS.PageSize * pagina)).Cells(6).Text)
            TXTCODIGODECONTRATO.Enabled = False
            TXTEMPLEADO.Text = HttpUtility.HtmlDecode(GVSALARIOS.Rows(GVSALARIOS.SelectedIndex - (GVSALARIOS.PageSize * pagina)).Cells(3).Text)
            TXTEMPLEADO.Enabled = False

            Dim dt As DateTime = Convert.ToDateTime(GVSALARIOS.Rows(GVSALARIOS.SelectedIndex - (GVSALARIOS.PageSize * pagina)).Cells(7).Text)
            TXTFECHAAPLICA.Text = String.Format("{0:yyyy-MM-dd}", dt)
            TXTSALARIOMENSUAL.Text = (GVSALARIOS.Rows(GVSALARIOS.SelectedIndex - (GVSALARIOS.PageSize * pagina)).Cells(4).Text)
            TXTBONIFICACION.Text = (GVSALARIOS.Rows(GVSALARIOS.SelectedIndex - (GVSALARIOS.PageSize * pagina)).Cells(5).Text)

            PNFORMULARIOSALARIOS.Visible = True
            PNGRIDSALARIOS.Visible = False
        Else
            mensaje("No hay Registros para mostrar")
        End If
    End Sub

    Private Sub GVSALARIOS_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVSALARIOS.PageIndexChanging
        GVSALARIOS.PageIndex = e.NewPageIndex
        LLENAGRIDSALARIO()
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

    Private Sub LimpiarFormulario()
        TXTCODIGOEMPLEADO.Text = 0
        TXTCODIGODECONTRATO.Text = 0
        TXTEMPLEADO.Text = ""
        TXTFECHAAPLICA.Text = ""
        TXTBONIFICACION.Text = 0
        TXTSALARIOMENSUAL.Text = 0
    End Sub

    Public Sub mensaje(ByRef mensaje As String)
        Dim script As String = "alert('" + mensaje + "');"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "alerta", script, True)
    End Sub

    Private Sub BTNCANCELARSALARIO_Click(sender As Object, e As EventArgs) Handles BTNCANCELARSALARIO.Click
        PNFORMULARIOSALARIOS.Visible = False
        LimpiarFormulario()
        PNGRIDSALARIOS.Visible = True
    End Sub

    Private Sub BTNACTUALIZASALARIO_Click(sender As Object, e As EventArgs) Handles BTNACTUALIZASALARIO.Click
        If (TXTSALARIOMENSUAL.Text = "" Or TXTSALARIOMENSUAL.Text = 0) Or (TXTBONIFICACION.Text = "" Or TXTBONIFICACION.Text = 0) Then
            mensaje("El monto de salario o bonifiación no puede ser cero, revise")
            Exit Sub
        End If
        AbrirRecordsetData("EXEC SBOSP_INGRESO_SALARIOS 2,'" + Session.Item("UCO").ToString() + "','" + HFLINEASALARIO.Value.ToString() +
                           "','" + TXTSALARIOMENSUAL.Text + "','" + TXTBONIFICACION.Text +
                           "','" + TRANSFECHA(CDate(TXTFECHAAPLICA.Text)) + "',''")
        If nA(0) = 0 Then
            mensaje(nA(1))
            Exit Sub
        Else
            mensaje(nA(1))
        End If

        LLENAGRIDSALARIO()
        PNFORMULARIOSALARIOS.Visible = False
        LimpiarFormulario()
        PNGRIDSALARIOS.Visible = True
    End Sub

    Private Sub TXTBUSCAREMPLEADO_TextChanged(sender As Object, e As EventArgs) Handles TXTBUSCAREMPLEADO.TextChanged
        GridBind(GVSALARIOS, "EXEC SBOSP_INGRESO_SALARIOS 111,'" + TXTBUSCAREMPLEADO.Text + "'", "", {""})
    End Sub
End Class