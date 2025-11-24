Public Class Admon_Empleado
    Inherits base

    Private Sub Admon_Empleado_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If
        LLENACATALOGOS()
        LLENAGRIDEMPLEADO()
    End Sub

    Private Sub GVEMPLEADOS__SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVEMPLEADOS_.SelectedIndexChanged
        If GVEMPLEADOS_.Rows.Count > 0 Then
            LimpiarFormulario()
            BTNACTUALIZAR.Visible = True
            BTNGUARDEMPLEADO.Visible = False

            Dim pagina As Int32 = GVEMPLEADOS_.PageIndex

            HFIDEMPLEADO.Value = (GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(10).Text)

            TXTPNOMBRE.Text = HttpUtility.HtmlDecode(GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(23).Text)
            TXTSNOMBRE.Text = HttpUtility.HtmlDecode(GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(24).Text)
            TXTTNOMBRE.Text = HttpUtility.HtmlDecode(GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(25).Text)
            TXTPAPELLIDO.Text = HttpUtility.HtmlDecode(GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(26).Text)
            TXTSAPELLIDO.Text = HttpUtility.HtmlDecode(GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(27).Text)
            TXTTAPELLIDO.Text = HttpUtility.HtmlDecode(GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(28).Text)
            TXTCANTHIJOS.Text = HttpUtility.HtmlDecode(GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(33).Text)
            TXTTELEFONO.Text = HttpUtility.HtmlDecode(GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(29).Text)
            TXTAFILIACION.Text = HttpUtility.HtmlDecode(GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(31).Text)
            TXTNIT.Text = HttpUtility.HtmlDecode(GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(30).Text)
            TXTDIPLOMA.Text = HttpUtility.HtmlDecode(GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(34).Text)
            Dim dt As DateTime = Convert.ToDateTime(GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(32).Text)
            TXTFECHANAC.Text = String.Format("{0:yyyy-MM-dd}", dt)
            TXTNOIDENTIFICACION.Text = HttpUtility.HtmlDecode(GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(11).Text)
            TXTCUENTABANCO.Text = HttpUtility.HtmlDecode(GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(39).Text)
            TXTNOEXPEDIENTETE.Text = HttpUtility.HtmlDecode(GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(36).Text)

            DDLIDENTIFICACION.SelectedIndex = CInt(IndiceCatalogos(CInt((GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(12).Text)), 4)) - 1
            DDLNACIONALIDAD.SelectedIndex = CInt(IndiceCatalogos(CInt((GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(13).Text)), 3)) - 1
            DDLSEXO.SelectedIndex = CInt(IndiceCatalogos(CInt((GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(15).Text)), 7)) - 1
            DDLESTADOCIVIL.SelectedIndex = CInt(IndiceCatalogos(CInt((GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(16).Text)), 11)) - 1
            DDLDISCAPACIDAD.SelectedIndex = CInt(IndiceCatalogos(CInt((GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(21).Text)), 10)) - 1
            DDLPAISORIGEN.SelectedIndex = CInt(IndiceCatalogos(CInt((GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(42).Text)), 3)) - 1
            DDLIDIOMA.SelectedIndex = CInt(IndiceCatalogos(CInt((GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(20).Text)), 9)) - 1
            DDLLUGARNAC.SelectedIndex = CInt(IndiceCatalogos(CInt((GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(14).Text)), 5)) - 1
            DDLPUEBLO.SelectedIndex = CInt(IndiceCatalogos(CInt((GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(18).Text)), 12)) - 1
            DDLOCUPACION.SelectedIndex = CInt(IndiceCatalogos(CInt((GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(17).Text)), 55)) - 1
            DDLNIVELACADEMICO.SelectedIndex = CInt(IndiceCatalogos(CInt((GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(19).Text)), 8)) - 1
            DDLIDBANCO.SelectedIndex = CInt(IndiceCatalogos(CInt((GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(40).Text)), 13)) - 1
            DDLTIPOEMPLEADO.SelectedIndex = CInt(IndiceCatalogos(CInt((GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(41).Text)), 14)) - 1
            DDLESTADOEMPLEADO.SelectedIndex = CInt((GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(37).Text))
            DDLTRABAJOEXTRANJERO.SelectedIndex = CInt(IndiceCatalogos(CInt((GVEMPLEADOS_.Rows(GVEMPLEADOS_.SelectedIndex - (GVEMPLEADOS_.PageSize * pagina)).Cells(35).Text)), 25)) - 1

            PNFORMULARIOEMPLEADO.Visible = True
            PNGRIDEMPLEADOS.Visible = False
        Else
            mensaje("No hay Registros para mostrar")
        End If
    End Sub

    Private Sub GVEMPLEADOS__PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVEMPLEADOS_.PageIndexChanging
        GVEMPLEADOS_.PageIndex = e.NewPageIndex
        GridBind(GVEMPLEADOS_, "EXEC SBOSP_EMPLEADOS", "", {"ID_EMPLEADO", "IDENTIFICACION", "TIPO_IDENTIFICACION", "NACIONALIDAD", "LUGAR_NACIMIENTO", "SEXO", "ESTADO_CIVIL", "OCUPACION", "GRUPO_ETNICO", "NIVEL_ACADEMICO", "IDIOMA", "DISCAPACIDAD", "USR_CREACION", "NOMBRE1", "NOMBRE2", "NOMBRE3", "APELLIDO1", "APELLIDO2", "APELLIDO3", "TELEFONO", "NIT", "AFILIACION_IGSS", "FECHA_NACIMIENTO", "CANTIDAD_HIJOS", "TITULO_DIPLOMA", "TRABAJO_EXTRANJERO", "NUMERO_EXPEDIENTE_EXT", "ACTIVO", "FECHA_CREACION", "NUMERO_CUENTA", "BANCO", "TIPO_EMPLEADO", "PAIS_ORIGEN", "TRABAJO_EXTRANJERO", "NUMERO_EXPEDIENTE_EXT", "ACTIVO", "FECHA_CREACION", "NUMERO_CUENTA", "BANCO", "TIPO_EMPLEADO", "PAIS_ORIGEN"})
    End Sub

    Private Sub BTNCANCELAEMPLEADO_Click(sender As Object, e As EventArgs) Handles BTNCANCELAEMPLEADO.Click
        PNFORMULARIOEMPLEADO.Visible = False
        LimpiarFormulario()
        BTNACTUALIZAR.Visible = False
        BTNGUARDEMPLEADO.Visible = False
        PNGRIDEMPLEADOS.Visible = True
    End Sub

    Private Sub BTNAGREGAREMPLEADO_Click(sender As Object, e As EventArgs) Handles BTNAGREGAREMPLEADO.Click
        LimpiarFormulario()
        BTNGUARDEMPLEADO.Visible = True
        BTNACTUALIZAR.Visible = False
        PNGRIDEMPLEADOS.Visible = False
        PNFORMULARIOEMPLEADO.Visible = True
    End Sub

    Private Sub BTNGUARDEMPLEADO_Click(sender As Object, e As EventArgs) Handles BTNGUARDEMPLEADO.Click
        AGREGAREMPLEADOSUB()
        LimpiarFormulario()
        LLENAGRIDEMPLEADO()
        PNGRIDEMPLEADOS.Visible = True
        PNFORMULARIOEMPLEADO.Visible = False
    End Sub

    Private Sub BTNACTUALIZAR_Click(sender As Object, e As EventArgs) Handles BTNACTUALIZAR.Click
        AbrirRecordsetData("EXEC INGRESO_EMPLEADO 2,'" + Session.Item("UCO").ToString() + "','" + HFIDEMPLEADO.Value.ToString() + "','" + TXTNOIDENTIFICACION.Text + "','" + DEVUELVECODIGOCATALOGO(DDLIDENTIFICACION) +
                           "','" + DEVUELVECODIGOCATALOGO(DDLNACIONALIDAD) + "','" + DEVUELVECODIGOCATALOGO(DDLLUGARNAC) + "','" + DEVUELVECODIGOCATALOGO(DDLSEXO) +
                           "','" + DEVUELVECODIGOCATALOGO(DDLESTADOCIVIL) + "','" + DEVUELVECODIGOCATALOGO(DDLOCUPACION) + "','" + DEVUELVECODIGOCATALOGO(DDLPUEBLO) +
                           "','" + DEVUELVECODIGOCATALOGO(DDLNIVELACADEMICO) + "','" + DEVUELVECODIGOCATALOGO(DDLIDIOMA) + "','" + DEVUELVECODIGOCATALOGO(DDLDISCAPACIDAD) +
                           "','" + TXTPNOMBRE.Text + "','" + TXTSNOMBRE.Text + "','" + TXTTNOMBRE.Text + "','" + TXTPAPELLIDO.Text + "','" + TXTSAPELLIDO.Text + "','" + TXTTAPELLIDO.Text +
                           "','" + TXTTELEFONO.Text + "','" + TXTNIT.Text + "','" + TXTAFILIACION.Text + "','" + TRANSFECHA(CDate(TXTFECHANAC.Text)) + "','" + TXTCANTHIJOS.Text +
                           "','" + TXTDIPLOMA.Text + "','" + DEVUELVECODIGOCATALOGO(DDLTRABAJOEXTRANJERO) + "','" + TXTNOEXPEDIENTETE.Text + "','" + DDLESTADOEMPLEADO.SelectedValue.ToString() +
                           "','" + TXTCUENTABANCO.Text + "','" + DEVUELVECODIGOCATALOGO(DDLIDBANCO) + "','" + DEVUELVECODIGOCATALOGO(DDLTIPOEMPLEADO) + "','" + DEVUELVECODIGOCATALOGO(DDLPAISORIGEN) + "'")
        If nA(0) = 0 Then
            mensaje(nA(1))
            Exit Sub
        Else
            mensaje(nA(1))
        End If

        LimpiarFormulario()
        LLENAGRIDEMPLEADO()
        PNGRIDEMPLEADOS.Visible = True
        PNFORMULARIOEMPLEADO.Visible = False
    End Sub

    Private Sub LLENAGRIDEMPLEADO()
        GridBind(GVEMPLEADOS_, "EXEC SBOSP_EMPLEADOS", "", {"ID_EMPLEADO", "IDENTIFICACION", "TIPO_IDENTIFICACION", "NACIONALIDAD", "LUGAR_NACIMIENTO", "SEXO", "ESTADO_CIVIL", "OCUPACION", "GRUPO_ETNICO", "NIVEL_ACADEMICO", "IDIOMA", "DISCAPACIDAD", "USR_CREACION", "NOMBRE1", "NOMBRE2", "NOMBRE3", "APELLIDO1", "APELLIDO2", "APELLIDO3", "TELEFONO", "NIT", "AFILIACION_IGSS", "FECHA_NACIMIENTO", "CANTIDAD_HIJOS", "TITULO_DIPLOMA", "TRABAJO_EXTRANJERO", "NUMERO_EXPEDIENTE_EXT", "ACTIVO", "FECHA_CREACION", "NUMERO_CUENTA", "BANCO", "TIPO_EMPLEADO", "PAIS_ORIGEN", "TRABAJO_EXTRANJERO", "NUMERO_EXPEDIENTE_EXT", "ACTIVO", "FECHA_CREACION", "NUMERO_CUENTA", "BANCO", "TIPO_EMPLEADO", "PAIS_ORIGEN"})
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

    Private Sub AGREGAREMPLEADOSUB()

        AbrirRecordsetData("EXEC INGRESO_EMPLEADO 1,'" + Session.Item("UCO").ToString() + "','0','" + TXTNOIDENTIFICACION.Text + "','" + DEVUELVECODIGOCATALOGO(DDLIDENTIFICACION) +
                           "','" + DEVUELVECODIGOCATALOGO(DDLNACIONALIDAD) + "','" + DEVUELVECODIGOCATALOGO(DDLLUGARNAC) + "','" + DEVUELVECODIGOCATALOGO(DDLSEXO) +
                           "','" + DEVUELVECODIGOCATALOGO(DDLESTADOCIVIL) + "','" + DEVUELVECODIGOCATALOGO(DDLOCUPACION) + "','" + DEVUELVECODIGOCATALOGO(DDLPUEBLO) +
                           "','" + DEVUELVECODIGOCATALOGO(DDLNIVELACADEMICO) + "','" + DEVUELVECODIGOCATALOGO(DDLIDIOMA) + "','" + DEVUELVECODIGOCATALOGO(DDLDISCAPACIDAD) +
                           "','" + TXTPNOMBRE.Text + "','" + TXTSNOMBRE.Text + "','" + TXTTNOMBRE.Text + "','" + TXTPAPELLIDO.Text + "','" + TXTSAPELLIDO.Text + "','" + TXTTAPELLIDO.Text +
                           "','" + TXTTELEFONO.Text + "','" + TXTNIT.Text + "','" + TXTAFILIACION.Text + "','" + TRANSFECHA(CDate(TXTFECHANAC.Text)) + "','" + TXTCANTHIJOS.Text +
                           "','" + TXTDIPLOMA.Text + "','" + DEVUELVECODIGOCATALOGO(DDLTRABAJOEXTRANJERO) + "','" + TXTNOEXPEDIENTETE.Text + "','" + DDLESTADOEMPLEADO.SelectedValue.ToString() +
                           "','" + TXTCUENTABANCO.Text + "','" + DEVUELVECODIGOCATALOGO(DDLIDBANCO) + "','" + DEVUELVECODIGOCATALOGO(DDLTIPOEMPLEADO) + "','" + DEVUELVECODIGOCATALOGO(DDLPAISORIGEN) + "'")
        If nA(0) = 0 Then
            mensaje(nA(1))
            Exit Sub
        Else
            mensaje(nA(1))
        End If
    End Sub

    Private Sub LimpiarFormulario()
        TXTPNOMBRE.Text = ""
        TXTSNOMBRE.Text = ""
        TXTTNOMBRE.Text = ""
        TXTPAPELLIDO.Text = ""
        TXTSAPELLIDO.Text = ""
        TXTTAPELLIDO.Text = ""
        TXTCANTHIJOS.Text = 0
        TXTTELEFONO.Text = ""
        TXTAFILIACION.Text = ""
        TXTNIT.Text = ""
        TXTDIPLOMA.Text = ""
        TXTFECHANAC.Text = ""
        TXTNOIDENTIFICACION.Text = ""
        TXTCUENTABANCO.Text = ""
        TXTNOEXPEDIENTETE.Text = ""

        DDLIDENTIFICACION.SelectedIndex = 0
        DDLNACIONALIDAD.SelectedIndex = 0
        DDLSEXO.SelectedIndex = 0
        DDLESTADOCIVIL.SelectedIndex = 0
        DDLDISCAPACIDAD.SelectedIndex = 0
        DDLPAISORIGEN.SelectedIndex = 0
        DDLIDIOMA.SelectedIndex = 0
        DDLLUGARNAC.SelectedIndex = 0
        DDLPUEBLO.SelectedIndex = 0
        DDLOCUPACION.SelectedIndex = 0
        DDLNIVELACADEMICO.SelectedIndex = 0
        DDLIDBANCO.SelectedIndex = 0
        DDLTIPOEMPLEADO.SelectedIndex = 0
        DDLESTADOEMPLEADO.SelectedIndex = 0
        DDLTRABAJOEXTRANJERO.SelectedIndex = 0
    End Sub

    Private Sub LLENACATALOGOS()
        DdBind(DDLIDENTIFICACION, "EXEC GESTION_EMPLEADOS 1", "CODIGO", "DESCRIPCION")
        DdBind(DDLNACIONALIDAD, "EXEC GESTION_EMPLEADOS 2", "CODIGO", "DESCRIPCION")
        DdBind(DDLPAISORIGEN, "EXEC GESTION_EMPLEADOS 2", "CODIGO", "DESCRIPCION")
        DdBind(DDLPUEBLO, "EXEC GESTION_EMPLEADOS 122", "CODIGO", "DESCRIPCION")
        DdBind(DDLLUGARNAC, "EXEC GESTION_EMPLEADOS 55", "CODIGO", "DESCRIPCION")
        DdBind(DDLSEXO, "EXEC GESTION_EMPLEADOS 77", "CODIGO", "DESCRIPCION")
        DdBind(DDLNIVELACADEMICO, "EXEC GESTION_EMPLEADOS 88", "CODIGO", "DESCRIPCION")
        DdBind(DDLIDIOMA, "EXEC GESTION_EMPLEADOS 99", "CODIGO", "DESCRIPCION")
        DdBind(DDLDISCAPACIDAD, "EXEC GESTION_EMPLEADOS 100", "CODIGO", "DESCRIPCION")
        DdBind(DDLESTADOCIVIL, "EXEC GESTION_EMPLEADOS 111", "CODIGO", "DESCRIPCION")
        DdBind(DDLIDBANCO, "EXEC GESTION_EMPLEADOS 133", "CODIGO", "DESCRIPCION")
        DdBind(DDLTIPOEMPLEADO, "EXEC GESTION_EMPLEADOS 144", "CODIGO", "DESCRIPCION")
        DdBind(DDLOCUPACION, "EXEC GESTION_EMPLEADOS 155", "CODIGO", "DESCRIPCION")
        DdBind(DDLESTADOEMPLEADO, "EXEC GESTION_EMPLEADOS 355", "CODIGO", "DESCRIPCION")
        DdBind(DDLTRABAJOEXTRANJERO, "EXEC GESTION_EMPLEADOS 255", "CODIGO", "DESCRIPCION")
        DDLESTADOEMPLEADO.SelectedIndex = 0
    End Sub

    Public Sub mensaje(ByRef mensaje As String)
        Dim script As String = "alert('" + mensaje + "');"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "alerta", script, True)
    End Sub

    Private Function IndiceCatalogos(ByRef id As String, ByRef opc As Integer) As String
        Dim resultado As String = ""
        If opc = 3 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 4 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 7 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 11 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 10 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 9 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 5 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 12 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 55 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 8 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 13 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 35 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 14 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 25 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        End If

        Return resultado
    End Function

    Private Sub TXTBUSCAREMPLEADO_TextChanged(sender As Object, e As EventArgs) Handles TXTBUSCAREMPLEADO.TextChanged
        GridBind(GVEMPLEADOS_, "EXEC INGRESO_EMPLEADO 111,'" + TXTBUSCAREMPLEADO.Text + "'", "", {"ID_EMPLEADO", "IDENTIFICACION", "TIPO_IDENTIFICACION", "NACIONALIDAD", "LUGAR_NACIMIENTO", "SEXO", "ESTADO_CIVIL", "OCUPACION", "GRUPO_ETNICO", "NIVEL_ACADEMICO", "IDIOMA", "DISCAPACIDAD", "USR_CREACION", "NOMBRE1", "NOMBRE2", "NOMBRE3", "APELLIDO1", "APELLIDO2", "APELLIDO3", "TELEFONO", "NIT", "AFILIACION_IGSS", "FECHA_NACIMIENTO", "CANTIDAD_HIJOS", "TITULO_DIPLOMA", "TRABAJO_EXTRANJERO", "NUMERO_EXPEDIENTE_EXT", "ACTIVO", "FECHA_CREACION", "NUMERO_CUENTA", "BANCO", "TIPO_EMPLEADO", "PAIS_ORIGEN", "TRABAJO_EXTRANJERO", "NUMERO_EXPEDIENTE_EXT", "ACTIVO", "FECHA_CREACION", "NUMERO_CUENTA", "BANCO", "TIPO_EMPLEADO", "PAIS_ORIGEN"})
    End Sub
End Class