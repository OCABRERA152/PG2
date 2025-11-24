Public Class NOM_Extras
    Inherits base

    Private Sub NOM_Extras_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If
        LLENACATALOGOS()
        LLENAGRIDEXTRA()
    End Sub

    Private Sub LLENACATALOGOS()
        DdBind(DDLTIPODEEXTRA, "EXEC GESTION_EMPLEADOS 177", "CODIGO", "DESCRIPCION")
    End Sub

    Private Sub LLENAGRIDEXTRA()
        GridBind(GVEXTRAGENERALES, "EXEC SBOSP_GESTION_PAGOS_EXTRA 1", "", {""})
    End Sub

    Private Sub LLENAGRIDESPECIFICO()
        Dim pagina As Int32 = GVDETALLEEXTRAS.PageIndex

        LBLEMPLEADOEXTRAS.Text = HFNOMBREEMPLEADO.Value.ToString()
        GridBind(GVDETALLEEXTRAS, "EXEC SBOSP_GESTION_PAGOS_EXTRA 2,'" + Session.Item("UCO").ToString() + "','" + HFIDEMPLEADO.Value.ToString() + "'", "", {"CODIGO_EXTRA"})
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

    Public Sub mensaje(ByRef mensaje As String)
        Dim script As String = "alert('" + mensaje + "');"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "alerta", script, True)
    End Sub

    Private Sub LimpiarFormulario()
        TXTCODIGOEMPLEADOHE.Text = 0
        TXTNOMBREEMPLEADOHE.Text = ""
        TXTDESCRIPCIONEXTRA.Text = ""
        TXTMONTOEXTRA.Text = 0
        TXTFECHAINICIOEXTRA.Text = ""
        TXTFECHAFINALEXTRA.Text = ""
        DDLTIPODEEXTRA.SelectedIndex = 0
    End Sub

    Private Function DEVUELVECODIGOCATALOGO(ByRef ddl As DropDownList) As String
        Dim res As String = ""
        Dim arr As Array = ddl.SelectedItem.ToString().Split("-")
        res = arr(0).ToString()
        Return res
    End Function

    Private Function IndiceCatalogos(ByRef id As String, ByRef opc As Integer) As String
        Dim resultado As String = ""
        If opc = 17 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        End If

        Return resultado
    End Function

    Private Sub GVEXTRAGENERALES_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVEXTRAGENERALES.PageIndexChanging
        GVEXTRAGENERALES.PageIndex = e.NewPageIndex
        LLENAGRIDEXTRA()
    End Sub

    Private Sub GVEXTRAGENERALES_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVEXTRAGENERALES.SelectedIndexChanged
        Dim pagina As Int32 = GVEXTRAGENERALES.PageIndex

        HFIDEMPLEADO.Value = (GVEXTRAGENERALES.Rows(GVEXTRAGENERALES.SelectedIndex - (GVEXTRAGENERALES.PageSize * pagina)).Cells(0).Text)
        HFNOMBREEMPLEADO.Value = HttpUtility.HtmlDecode((GVEXTRAGENERALES.Rows(GVEXTRAGENERALES.SelectedIndex - (GVEXTRAGENERALES.PageSize * pagina)).Cells(1).Text))
        LLENAGRIDESPECIFICO()
        PNGRIDEXTRA.Visible = False
        PNEXTRAESPECIFICO.Visible = True
    End Sub

    Private Sub BTNREGRESARGENERAL_Click(sender As Object, e As EventArgs) Handles BTNREGRESARGENERAL.Click
        LLENAGRIDEXTRA()
        PNGRIDEXTRA.Visible = True
        PNEXTRAESPECIFICO.Visible = False
    End Sub

    Private Sub BTNAGREGAREXTRAS_Click(sender As Object, e As EventArgs) Handles BTNAGREGAREXTRAS.Click
        TXTCODIGOEMPLEADOHE.Text = HFIDEMPLEADO.Value.ToString()
        TXTNOMBREEMPLEADOHE.Text = HFNOMBREEMPLEADO.Value.ToString()
        BTNGUARDAREXTRA.Visible = True
        BTNACTUALIZAEXTRA.Visible = False
        PNEXTRAESPECIFICO.Visible = False
        PNFORMULARIOEXTRAS.Visible = True
    End Sub

    Private Sub GVDETALLEEXTRAS_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVDETALLEEXTRAS.PageIndexChanging
        GVDETALLEEXTRAS.PageIndex = e.NewPageIndex
        LLENAGRIDESPECIFICO()
    End Sub

    Private Sub GVDETALLEEXTRAS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVDETALLEEXTRAS.SelectedIndexChanged
        Dim pagina As Int32 = GVDETALLEEXTRAS.PageIndex

        If CInt((GVDETALLEEXTRAS.Rows(GVDETALLEEXTRAS.SelectedIndex - (GVDETALLEEXTRAS.PageSize * pagina)).Cells(0).Text)) > 0 Then
            LimpiarFormulario()
            BTNACTUALIZAEXTRA.Visible = True
            BTNGUARDAREXTRA.Visible = False

            HFLINEAEXTRAS.Value = (GVDETALLEEXTRAS.Rows(GVDETALLEEXTRAS.SelectedIndex - (GVDETALLEEXTRAS.PageSize * pagina)).Cells(0).Text)

            TXTCODIGOEMPLEADOHE.Text = HFIDEMPLEADO.Value.ToString()
            TXTCODIGOEMPLEADOHE.Enabled = False
            TXTNOMBREEMPLEADOHE.Text = HttpUtility.HtmlDecode(HFNOMBREEMPLEADO.Value.ToString())
            TXTNOMBREEMPLEADOHE.Enabled = False
            TXTMONTOEXTRA.Text = (GVDETALLEEXTRAS.Rows(GVDETALLEEXTRAS.SelectedIndex - (GVDETALLEEXTRAS.PageSize * pagina)).Cells(1).Text)
            TXTDESCRIPCIONEXTRA.Text = (GVDETALLEEXTRAS.Rows(GVDETALLEEXTRAS.SelectedIndex - (GVDETALLEEXTRAS.PageSize * pagina)).Cells(2).Text)

            If GVDETALLEEXTRAS.Rows(GVDETALLEEXTRAS.SelectedIndex - (GVDETALLEEXTRAS.PageSize * pagina)).Cells(6).Text.Equals("&nbsp;") Then
                Dim dt As DateTime = Convert.ToDateTime(GVDETALLEEXTRAS.Rows(GVDETALLEEXTRAS.SelectedIndex - (GVDETALLEEXTRAS.PageSize * pagina)).Cells(5).Text)
                TXTFECHAINICIOEXTRA.Text = String.Format("{0:yyyy-MM-dd}", dt)
                TXTFECHAFINALEXTRA.Text = ""
            Else
                Dim dt As DateTime = Convert.ToDateTime(GVDETALLEEXTRAS.Rows(GVDETALLEEXTRAS.SelectedIndex - (GVDETALLEEXTRAS.PageSize * pagina)).Cells(11).Text)
                TXTFECHAINICIOEXTRA.Text = String.Format("{0:yyyy-MM-dd}", dt)
                Dim dt_ As DateTime = Convert.ToDateTime(GVDETALLEEXTRAS.Rows(GVDETALLEEXTRAS.SelectedIndex - (GVDETALLEEXTRAS.PageSize * pagina)).Cells(12).Text)
                TXTFECHAFINALEXTRA.Text = String.Format("{0:yyyy-MM-dd}", dt_)
            End If

            DDLTIPODEEXTRA.SelectedIndex = CInt(IndiceCatalogos(CInt((GVDETALLEEXTRAS.Rows(GVDETALLEEXTRAS.SelectedIndex - (GVDETALLEEXTRAS.PageSize * pagina)).Cells(7).Text)), 17)) - 1


            PNFORMULARIOEXTRAS.Visible = True
            PNEXTRAESPECIFICO.Visible = False
        Else
            mensaje("No hay Registros para mostrar")
        End If
    End Sub

    Private Sub GUARDARHEPOREMPLEADO()
        If (TXTMONTOEXTRA.Text = "" Or TXTMONTOEXTRA.Text = 0) Or (TXTDESCRIPCIONEXTRA.Text = "") Then
            mensaje("Algúnos campos están vacíos revise")
            Exit Sub
        End If
        Dim ffin As String = ""
        If TXTFECHAFINALEXTRA.Text = "" Then
            ffin = ""
        Else
            ffin = TRANSFECHA(CDate(TXTFECHAFINALEXTRA.Text))
        End If
        AbrirRecordsetData("EXEC SBOSP_GESTION_PAGOS_EXTRA 3,'" + Session.Item("UCO").ToString() + "','" + HFIDEMPLEADO.Value.ToString() +
                           "','" + TXTMONTOEXTRA.Text + "','" + TXTDESCRIPCIONEXTRA.Text + "','" + DEVUELVECODIGOCATALOGO(DDLTIPODEEXTRA) +
                           "','" + TRANSFECHA(CDate(TXTFECHAINICIOEXTRA.Text)) + "','" + ffin + "',''")
        If nA(0) = 0 Then
            mensaje(nA(1))
            Exit Sub
        Else
            mensaje(nA(1))
        End If
    End Sub
    Private Sub BTNGUARDAREXTRA_Click(sender As Object, e As EventArgs) Handles BTNGUARDAREXTRA.Click
        GUARDARHEPOREMPLEADO()
        LimpiarFormulario()
        LLENAGRIDESPECIFICO()
        PNEXTRAESPECIFICO.Visible = True
        PNFORMULARIOEXTRAS.Visible = False
    End Sub

    Private Sub BTNACTUALIZAEXTRA_Click(sender As Object, e As EventArgs) Handles BTNACTUALIZAEXTRA.Click
        If (TXTMONTOEXTRA.Text = "" Or TXTMONTOEXTRA.Text = 0) Or (TXTDESCRIPCIONEXTRA.Text = "") Then
            mensaje("Algúnos campos están vacíos revise")
            Exit Sub
        End If
        Dim ffin As String = ""
        If TXTFECHAFINALEXTRA.Text = "" Then
            ffin = ""
        Else
            ffin = TRANSFECHA(CDate(TXTFECHAFINALEXTRA.Text))
        End If
        AbrirRecordsetData("EXEC SBOSP_GESTION_PAGOS_EXTRA 4,'" + Session.Item("UCO").ToString() + "','" + HFIDEMPLEADO.Value.ToString() +
                           "','" + TXTMONTOEXTRA.Text + "','" + TXTDESCRIPCIONEXTRA.Text + "','" + DEVUELVECODIGOCATALOGO(DDLTIPODEEXTRA) +
                           "','" + TRANSFECHA(CDate(TXTFECHAINICIOEXTRA.Text)) + "','" + ffin + "','" + HFLINEAEXTRAS.Value.ToString() + "'")
        If nA(0) = 0 Then
            mensaje(nA(1))
            Exit Sub
        Else
            mensaje(nA(1))
        End If

        LimpiarFormulario()
        LLENAGRIDESPECIFICO()
        PNEXTRAESPECIFICO.Visible = True
        PNFORMULARIOEXTRAS.Visible = False
    End Sub

    Private Sub BTNCANCELAREXTRA_Click(sender As Object, e As EventArgs) Handles BTNCANCELAREXTRA.Click
        Cancel()
    End Sub

    Private Sub Cancel()
        PNFORMULARIOEXTRAS.Visible = False
        LimpiarFormulario()
        BTNACTUALIZAEXTRA.Visible = False
        BTNGUARDAREXTRA.Visible = False
        PNEXTRAESPECIFICO.Visible = True
    End Sub

    Private Sub TXTBUSCAREMPLEADO_TextChanged(sender As Object, e As EventArgs) Handles TXTBUSCAREMPLEADO.TextChanged
        GridBind(GVEXTRAGENERALES, "EXEC SBOSP_GESTION_PAGOS_EXTRA 111,'" + TXTBUSCAREMPLEADO.Text + "'", "", {""})
    End Sub
End Class