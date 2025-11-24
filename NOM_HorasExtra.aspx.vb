Public Class NOM_HorasExtra
    Inherits base
    Private Sub NOM_HorasExtra_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If
        LLENAGRIDHE()
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

    Private Sub LLENAGRIDESPECIFICO()
        Dim pagina As Int32 = GVDETALLEHE.PageIndex

        LBLEMPLEADOHE.Text = HFNOMBREEMPLEADO.Value.ToString()
        GridBind(GVDETALLEHE, "EXEC GESTION_HORAS_EXTRA 2,'" + Session.Item("UCO").ToString() + "','" + HFIDEMPLEADO.Value.ToString() + "'", "", {"CODIGO"})
    End Sub

    Public Sub mensaje(ByRef mensaje As String)
        Dim script As String = "alert('" + mensaje + "');"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "alerta", script, True)
    End Sub

    Private Sub LimpiarFormulario()
        TXTCODIGOEMPLEADOHE.Text = 0
        TXTNOMBREEMPLEADOHE.Text = ""
        TXTFECHAEJECUCION.Text = ""
        TXTCANTIDADHORAS.Text = 0
    End Sub

    Private Sub LLENAGRIDHE()
        GridBind(GVHEGENERALES, "EXEC GESTION_HORAS_EXTRA 1", "", {""})
    End Sub

    Private Sub TXTBUSCAREMPLEADO_TextChanged(sender As Object, e As EventArgs) Handles TXTBUSCAREMPLEADO.TextChanged
        GridBind(GVHEGENERALES, "EXEC GESTION_HORAS_EXTRA 111,'" + TXTBUSCAREMPLEADO.Text + "'", "", {""})
    End Sub

    Private Sub GVHEGENERALES_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVHEGENERALES.PageIndexChanging
        GVHEGENERALES.PageIndex = e.NewPageIndex
        LLENAGRIDHE()
    End Sub

    Private Sub GVHEGENERALES_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVHEGENERALES.SelectedIndexChanged
        Dim pagina As Int32 = GVHEGENERALES.PageIndex

        HFIDEMPLEADO.Value = (GVHEGENERALES.Rows(GVHEGENERALES.SelectedIndex - (GVHEGENERALES.PageSize * pagina)).Cells(0).Text)
        HFNOMBREEMPLEADO.Value = HttpUtility.HtmlDecode((GVHEGENERALES.Rows(GVHEGENERALES.SelectedIndex - (GVHEGENERALES.PageSize * pagina)).Cells(1).Text))
        LLENAGRIDESPECIFICO()
        PNGRIDHE.Visible = False
        PNHEESPECIFICA.Visible = True
    End Sub

    Private Sub BTNREGRESARGENERAL_Click(sender As Object, e As EventArgs) Handles BTNREGRESARGENERAL.Click
        LLENAGRIDHE()
        PNGRIDHE.Visible = True
        PNHEESPECIFICA.Visible = False
    End Sub

    Private Sub BTNAGREGARHE_Click(sender As Object, e As EventArgs) Handles BTNAGREGARHE.Click
        TXTCODIGOEMPLEADOHE.Text = HFIDEMPLEADO.Value.ToString()
        TXTNOMBREEMPLEADOHE.Text = HFNOMBREEMPLEADO.Value.ToString()
        BTNGUARDARHE.Visible = True
        BTNACTUALIZARHE.Visible = False
        PNHEESPECIFICA.Visible = False
        PNFORMULARIOHE.Visible = True
    End Sub

    Private Sub GVDETALLEHE_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVDETALLEHE.PageIndexChanging
        GVDETALLEHE.PageIndex = e.NewPageIndex
        LLENAGRIDESPECIFICO()
    End Sub

    Private Sub GVDETALLEHE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVDETALLEHE.SelectedIndexChanged
        Dim pagina As Int32 = GVDETALLEHE.PageIndex

        If CInt((GVDETALLEHE.Rows(GVDETALLEHE.SelectedIndex - (GVDETALLEHE.PageSize * pagina)).Cells(0).Text)) > 0 Then
            LimpiarFormulario()
            BTNACTUALIZARHE.Visible = True
            BTNGUARDARHE.Visible = False

            HFLINEAHE.Value = (GVDETALLEHE.Rows(GVDETALLEHE.SelectedIndex - (GVDETALLEHE.PageSize * pagina)).Cells(0).Text)

            TXTCODIGOEMPLEADOHE.Text = HFIDEMPLEADO.Value.ToString()
            TXTCODIGOEMPLEADOHE.Enabled = False
            TXTNOMBREEMPLEADOHE.Text = HttpUtility.HtmlDecode(HFNOMBREEMPLEADO.Value.ToString())
            TXTNOMBREEMPLEADOHE.Enabled = False

            Dim dt As DateTime = Convert.ToDateTime(GVDETALLEHE.Rows(GVDETALLEHE.SelectedIndex - (GVDETALLEHE.PageSize * pagina)).Cells(1).Text)
            TXTFECHAEJECUCION.Text = String.Format("{0:yyyy-MM-dd}", dt)

            TXTCANTIDADHORAS.Text = (GVDETALLEHE.Rows(GVDETALLEHE.SelectedIndex - (GVDETALLEHE.PageSize * pagina)).Cells(2).Text)


            PNFORMULARIOHE.Visible = True
            PNHEESPECIFICA.Visible = False
        Else
            mensaje("No hay Registros para mostrar")
        End If
    End Sub

    Private Sub GUARDARHEPOREMPLEADO()
        If TXTCANTIDADHORAS.Text = "" Or TXTCANTIDADHORAS.Text = 0 Then
            mensaje("Algúnos campos están vacíos revise")
            Exit Sub
        End If
        AbrirRecordsetData("EXEC GESTION_HORAS_EXTRA 3,'" + Session.Item("UCO").ToString() + "','" + HFIDEMPLEADO.Value.ToString() +
                           "','" + TXTCANTIDADHORAS.Text + "','" + TRANSFECHA(CDate(TXTFECHAEJECUCION.Text)) + "',''")
        If nA(0) = 0 Then
            mensaje(nA(1))
            Exit Sub
        Else
            mensaje(nA(1))
        End If
    End Sub

    Private Sub BTNGUARDARHE_Click(sender As Object, e As EventArgs) Handles BTNGUARDARHE.Click
        GUARDARHEPOREMPLEADO()
        LimpiarFormulario()
        LLENAGRIDESPECIFICO()
        PNHEESPECIFICA.Visible = True
        PNFORMULARIOHE.Visible = False
    End Sub

    Private Sub BTNCANCELARHE_Click(sender As Object, e As EventArgs) Handles BTNCANCELARHE.Click
        Cancel()
    End Sub

    Private Sub BTNACTUALIZARHE_Click(sender As Object, e As EventArgs) Handles BTNACTUALIZARHE.Click
        If TXTCANTIDADHORAS.Text = "" Or TXTCANTIDADHORAS.Text = 0 Then
            mensaje("La cantidad de Horas no puede ser cero o estar vacía, revise")
            Exit Sub
        End If
        AbrirRecordsetData("EXEC GESTION_HORAS_EXTRA 4,'" + Session.Item("UCO").ToString() + "','" + HFIDEMPLEADO.Value.ToString() +
                           "','" + TXTCANTIDADHORAS.Text + "','" + TRANSFECHA(CDate(TXTFECHAEJECUCION.Text)) + "','" + HFLINEAHE.Value.ToString() + "'")
        If nA(0) = 0 Then
            mensaje(nA(1))
            Exit Sub
        Else
            mensaje(nA(1))
        End If

        LimpiarFormulario()
        LLENAGRIDESPECIFICO()
        PNHEESPECIFICA.Visible = True
        PNFORMULARIOHE.Visible = False
    End Sub

    Private Sub Cancel()
        PNFORMULARIOHE.Visible = False
        LimpiarFormulario()
        BTNACTUALIZARHE.Visible = False
        BTNGUARDARHE.Visible = False
        PNHEESPECIFICA.Visible = True
    End Sub
End Class