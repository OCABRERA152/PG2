Public Class NOM_Ausencia
    Inherits base

    Private Sub NOM_Ausencia_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If
        LLENACATALOGOS()
        LLENAGRIDAUSENCIA()
    End Sub

    Private Sub LLENACATALOGOS()
        DdBind(DDLTIPOAUSENCIA, "EXEC GESTION_EMPLEADOS 266", "CODIGO", "DESCRIPCION")
    End Sub

    Private Sub LLENAGRIDAUSENCIA()
        GridBind(GVAUSENCIAS, "EXEC GESTION_AUSENCIAS 1", "", {""})
    End Sub

    Private Sub TXTBUSCAREMPLEADO_TextChanged(sender As Object, e As EventArgs) Handles TXTBUSCAREMPLEADO.TextChanged
        GridBind(GVAUSENCIAS, "EXEC GESTION_AUSENCIAS 111,'" + TXTBUSCAREMPLEADO.Text + "'", "", {""})
    End Sub

    Private Sub GVAUSENCIAS_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVAUSENCIAS.PageIndexChanging
        GVAUSENCIAS.PageIndex = e.NewPageIndex
        LLENAGRIDAUSENCIA()
    End Sub

    Private Sub GVAUSENCIAS_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVAUSENCIAS.SelectedIndexChanged
        LLENAGRIDESPECIFICO()
        PNGRIDAUSENCIAS.Visible = False
        PNAUSENCIASESPECIFICAS.Visible = True
    End Sub

    Private Sub BTNREGRESARGENERAL_Click(sender As Object, e As EventArgs) Handles BTNREGRESARGENERAL.Click
        PNGRIDAUSENCIAS.Visible = True
        PNAUSENCIASESPECIFICAS.Visible = False
    End Sub

    Private Sub BTNAGREGARAUSENCIA_Click(sender As Object, e As EventArgs) Handles BTNAGREGARAUSENCIA.Click
        LimpiarFormulario()
        BTNGUARDARAUSENCIA.Visible = True
        BTNACTUALIZARAUSENCIA.Visible = False
        PNAUSENCIASESPECIFICAS.Visible = False
        PNFORMULARIOAUSENCIA.Visible = True
    End Sub

    Private Sub LimpiarFormulario()
        TXTCANTIDADDIAS.Text = 0
        TXTFECHAINICIO.Text = ""
        TXTFECHAFINAL.Text = ""
        DDLTIPOAUSENCIA.SelectedIndex = 0
    End Sub

    Public Sub mensaje(ByRef mensaje As String)
        Dim script As String = "alert('" + mensaje + "');"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "alerta", script, True)
    End Sub

    Private Sub BTNGUARDARAUSENCIA_Click(sender As Object, e As EventArgs) Handles BTNGUARDARAUSENCIA.Click
        GUARDARAUSENCIAPOREMPLEADO()
        LimpiarFormulario()
        LLENAGRIDESPECIFICO()
        PNAUSENCIASESPECIFICAS.Visible = True
        PNFORMULARIOAUSENCIA.Visible = False
        HFLINEAAUSENCIA.Value = "0"
    End Sub

    Private Sub LLENAGRIDESPECIFICO()
        Dim pagina As Int32 = GVAUSENCIAS.PageIndex
        LBLEMPLEADOAUSENCIAS.Text = (GVAUSENCIAS.Rows(GVAUSENCIAS.SelectedIndex - (GVAUSENCIAS.PageSize * pagina)).Cells(1).Text)
        HFIDEMPLEADO.Value = (GVAUSENCIAS.Rows(GVAUSENCIAS.SelectedIndex - (GVAUSENCIAS.PageSize * pagina)).Cells(0).Text)
        GridBind(GVDETALLEAUSENCIA, "EXEC GESTION_AUSENCIAS 2,'','" + HFIDEMPLEADO.Value.ToString() + "'", "", {"LINEA", "TIPO_AUSENCIA"})
    End Sub

    Private Sub GUARDARAUSENCIAPOREMPLEADO()
        If TXTCANTIDADDIAS.Text = "" Or TXTFECHAINICIO.Text = "" Or TXTFECHAFINAL.Text = "" Or TXTCANTIDADDIAS.Text = 0 Then
            mensaje("Algúnos campos están vacíos revise")
            Exit Sub
        End If
        AbrirRecordsetData("EXEC GESTION_AUSENCIAS 3,'" + Session.Item("UCO").ToString() + "','" + HFIDEMPLEADO.Value.ToString() +
                           "','" + DEVUELVECODIGOCATALOGO(DDLTIPOAUSENCIA) + "','" + TXTCANTIDADDIAS.Text +
                           "','" + TRANSFECHA(CDate(TXTFECHAINICIO.Text)) + "','" + TRANSFECHA(CDate(TXTFECHAFINAL.Text)) + "','0'")
        If nA(0) = 0 Then
            mensaje(nA(1))
            Exit Sub
        Else
            mensaje(nA(1))
        End If
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

    Private Function DEVUELVECODIGOCATALOGO(ByRef ddl As DropDownList) As String
        Dim res As String = ""
        Dim arr As Array = ddl.SelectedItem.ToString().Split("-")
        res = arr(0).ToString()
        Return res
    End Function

    Private Sub GVDETALLEAUSENCIA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVDETALLEAUSENCIA.SelectedIndexChanged
        Dim pagina As Int32 = GVDETALLEAUSENCIA.PageIndex

        If CInt((GVDETALLEAUSENCIA.Rows(GVDETALLEAUSENCIA.SelectedIndex - (GVDETALLEAUSENCIA.PageSize * pagina)).Cells(0).Text)) > 0 Then
            LimpiarFormulario()
            BTNACTUALIZARAUSENCIA.Visible = True
            BTNGUARDARAUSENCIA.Visible = False

            HFLINEAAUSENCIA.Value = (GVDETALLEAUSENCIA.Rows(GVDETALLEAUSENCIA.SelectedIndex - (GVDETALLEAUSENCIA.PageSize * pagina)).Cells(0).Text)

            Dim dt As DateTime = Convert.ToDateTime(GVDETALLEAUSENCIA.Rows(GVDETALLEAUSENCIA.SelectedIndex - (GVDETALLEAUSENCIA.PageSize * pagina)).Cells(1).Text)
            TXTFECHAINICIO.Text = String.Format("{0:yyyy-MM-dd}", dt)
            Dim dt_ As DateTime = Convert.ToDateTime(GVDETALLEAUSENCIA.Rows(GVDETALLEAUSENCIA.SelectedIndex - (GVDETALLEAUSENCIA.PageSize * pagina)).Cells(2).Text)
            TXTFECHAFINAL.Text = String.Format("{0:yyyy-MM-dd}", dt_)
            TXTCANTIDADDIAS.Text = (GVDETALLEAUSENCIA.Rows(GVDETALLEAUSENCIA.SelectedIndex - (GVDETALLEAUSENCIA.PageSize * pagina)).Cells(3).Text)

            DDLTIPOAUSENCIA.SelectedIndex = CInt(IndiceCatalogos(CInt((GVDETALLEAUSENCIA.Rows(GVDETALLEAUSENCIA.SelectedIndex - (GVDETALLEAUSENCIA.PageSize * pagina)).Cells(5).Text)), 26)) - 1

            PNFORMULARIOAUSENCIA.Visible = True
            PNAUSENCIASESPECIFICAS.Visible = False
        Else
            mensaje("No hay Registros para mostrar")
        End If
    End Sub

    Private Function IndiceCatalogos(ByRef id As String, ByRef opc As Integer) As String
        Dim resultado As String = ""
        If opc = 26 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        End If

        Return resultado
    End Function

    Private Sub BTNCANCELARAUSENCIA_Click(sender As Object, e As EventArgs) Handles BTNCANCELARAUSENCIA.Click
        PNFORMULARIOAUSENCIA.Visible = False
        LimpiarFormulario()
        BTNACTUALIZARAUSENCIA.Visible = False
        BTNGUARDARAUSENCIA.Visible = False
        PNAUSENCIASESPECIFICAS.Visible = True
    End Sub

    Private Sub BTNACTUALIZARAUSENCIA_Click(sender As Object, e As EventArgs) Handles BTNACTUALIZARAUSENCIA.Click
        If TXTCANTIDADDIAS.Text = "" Or TXTCANTIDADDIAS.Text = 0 Then
            mensaje("La cantidad de días no puede ser cero o estar vacía, revise")
            Exit Sub
        End If
        AbrirRecordsetData("EXEC GESTION_AUSENCIAS 4,'" + Session.Item("UCO").ToString() + "','" + HFIDEMPLEADO.Value.ToString() +
                           "','" + DEVUELVECODIGOCATALOGO(DDLTIPOAUSENCIA) + "','" + TXTCANTIDADDIAS.Text +
                           "','" + TRANSFECHA(CDate(TXTFECHAINICIO.Text)) + "','" + TRANSFECHA(CDate(TXTFECHAFINAL.Text)) + "','" + HFLINEAAUSENCIA.Value.ToString() + "'")
        If nA(0) = 0 Then
            mensaje(nA(1))
            Exit Sub
        Else
            mensaje(nA(1))
        End If

        LimpiarFormulario()
        LLENAGRIDESPECIFICO()
        PNAUSENCIASESPECIFICAS.Visible = True
        PNFORMULARIOAUSENCIA.Visible = False
    End Sub

    Private Sub GVDETALLEAUSENCIA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVDETALLEAUSENCIA.PageIndexChanging
        GVDETALLEAUSENCIA.PageIndex = e.NewPageIndex
        LLENAGRIDESPECIFICO()
    End Sub
End Class