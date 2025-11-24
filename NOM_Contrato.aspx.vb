Public Class NOM_Contrato
    Inherits base

    Private Sub NOM_Contrato_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If
        LLENACATALOGOS()
        LLENAGRIDCONTRATO()
    End Sub

    '---------------------------------- GESTIÓN DE GRID -------------------------------------------------------------------------
    Private Sub GVCONTRATO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVCONTRATO.SelectedIndexChanged
        If GVCONTRATO.Rows.Count > 0 Then
            LimpiarFormulario()
            DdBind(DDLLISTAEMPLEADO, "EXEC GESTION_EMPLEADOS 377", "CODIGO", "DESCRIPCION")
            DDLLISTAEMPLEADO.Enabled = False
            BTNACTUALIZARCONTRATO.Visible = True
            BTNGUARDARCONTRATO.Visible = False

            Dim pagina As Int32 = GVCONTRATO.PageIndex

            HFIDEMPLEADO.Value = (GVCONTRATO.Rows(GVCONTRATO.SelectedIndex - (GVCONTRATO.PageSize * pagina)).Cells(0).Text)
            HFIDCONTRATO.Value = (GVCONTRATO.Rows(GVCONTRATO.SelectedIndex - (GVCONTRATO.PageSize * pagina)).Cells(1).Text)


            TXTPOLIZAS.Text = HttpUtility.HtmlDecode(GVCONTRATO.Rows(GVCONTRATO.SelectedIndex - (GVCONTRATO.PageSize * pagina)).Cells(13).Text)
            TXTCETIFICADOS.Text = HttpUtility.HtmlDecode(GVCONTRATO.Rows(GVCONTRATO.SelectedIndex - (GVCONTRATO.PageSize * pagina)).Cells(14).Text)
            TXTNOCONTRATO.Text = HttpUtility.HtmlDecode(GVCONTRATO.Rows(GVCONTRATO.SelectedIndex - (GVCONTRATO.PageSize * pagina)).Cells(22).Text)

            If GVCONTRATO.Rows(GVCONTRATO.SelectedIndex - (GVCONTRATO.PageSize * pagina)).Cells(15).Text.Equals("1") Then
                Dim dt As DateTime = Convert.ToDateTime(GVCONTRATO.Rows(GVCONTRATO.SelectedIndex - (GVCONTRATO.PageSize * pagina)).Cells(11).Text)
                TXTFECHAINICIO.Text = String.Format("{0:yyyy-MM-dd}", dt)
                TXTFECHAFIN.Text = ""
            Else
                Dim dt As DateTime = Convert.ToDateTime(GVCONTRATO.Rows(GVCONTRATO.SelectedIndex - (GVCONTRATO.PageSize * pagina)).Cells(11).Text)
                TXTFECHAINICIO.Text = String.Format("{0:yyyy-MM-dd}", dt)
                Dim dt_ As DateTime = Convert.ToDateTime(GVCONTRATO.Rows(GVCONTRATO.SelectedIndex - (GVCONTRATO.PageSize * pagina)).Cells(12).Text)
                TXTFECHAFIN.Text = String.Format("{0:yyyy-MM-dd}", dt_)
            End If

            DDLTIPODECONTRATO.SelectedIndex = CInt(IndiceCatalogos(CInt((GVCONTRATO.Rows(GVCONTRATO.SelectedIndex - (GVCONTRATO.PageSize * pagina)).Cells(18).Text)), 20)) - 1
            DDLTEMPORALIDADC.SelectedIndex = CInt(IndiceCatalogos(CInt((GVCONTRATO.Rows(GVCONTRATO.SelectedIndex - (GVCONTRATO.PageSize * pagina)).Cells(17).Text)), 19)) - 1
            DDLJORNADAC.SelectedIndex = CInt(IndiceCatalogos(CInt((GVCONTRATO.Rows(GVCONTRATO.SelectedIndex - (GVCONTRATO.PageSize * pagina)).Cells(19).Text)), 21)) - 1
            DDLTIPOFINCONTRATO.SelectedIndex = CInt(IndiceCatalogos(CInt((GVCONTRATO.Rows(GVCONTRATO.SelectedIndex - (GVCONTRATO.PageSize * pagina)).Cells(16).Text)), 18)) - 1
            DDLESTADO.SelectedIndex = CInt((GVCONTRATO.Rows(GVCONTRATO.SelectedIndex - (GVCONTRATO.PageSize * pagina)).Cells(15).Text))
            DDLLISTAEMPLEADO.SelectedIndex = CInt(IndiceCatalogos(CInt((GVCONTRATO.Rows(GVCONTRATO.SelectedIndex - (GVCONTRATO.PageSize * pagina)).Cells(0).Text)), 37)) - 1

            PNFORMULARIOEMPLEADO.Visible = True
            PNGRIDEMPLEADOS.Visible = False
        Else
            mensaje("No hay Registros para mostrar")
        End If
    End Sub

    Private Sub GVCONTRATO_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVCONTRATO.PageIndexChanging
        GVCONTRATO.PageIndex = e.NewPageIndex
        LLENAGRIDCONTRATO()
    End Sub

    '------------------------ PROCEDIMIENTO INHOUSE ---------------------------------------------------------------------------------
    Private Sub LLENAGRIDCONTRATO()
        GridBind(GVCONTRATO, "EXEC SBOSP_CONTRATOS", "", {"CODIGO", "ID_EMPLEADO", "FECHA_INICIO", "FECHA_FIN", "POLIZA_SEGURO", "CERTIFICADO_SEGURO", "ACTIVO", "TIPO_FIN_CONTRATO",
                 "TEMPORALIDAD_CONTRATO", "TIPO_CONTRATO", "JORNADA", "USR_CREADO", "FECHA_CREADO", "NUMERO_CONTRATO", "ID_EMPLEADO", "ID_CONTRATO", "ID_EMPLEADO1"})
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

    Private Sub GUARDARCONTRATO()
        If TXTFECHAINICIO.Text = "" Or TXTPOLIZAS.Text = "" Or TXTCETIFICADOS.Text = "" Or TXTNOCONTRATO.Text = "" Then
            mensaje("Algúnos campos están vacíos revise")
            Exit Sub
        End If
        Dim ffin As String = ""
        If TXTFECHAFIN.Text = "" Then
            ffin = ""
        Else
            ffin = TRANSFECHA(CDate(TXTFECHAFIN.Text))
        End If
        AbrirRecordsetData("EXEC SBOSP_INGRESO_CONTRATO 1,'" + Session.Item("UCO").ToString() + "','0','" + DEVUELVECODIGOCATALOGO(DDLLISTAEMPLEADO) +
                           "','" + TRANSFECHA(CDate(TXTFECHAINICIO.Text)) + "','" + ffin + "','" + TXTPOLIZAS.Text + "','" + TXTCETIFICADOS.Text +
                           "','" + DDLESTADO.SelectedValue.ToString() + "','" + DEVUELVECODIGOCATALOGO(DDLTIPOFINCONTRATO) + "','" + DEVUELVECODIGOCATALOGO(DDLTEMPORALIDADC) +
                           "','" + DEVUELVECODIGOCATALOGO(DDLTIPODECONTRATO) + "','" + DEVUELVECODIGOCATALOGO(DDLJORNADAC) + "','" + TXTNOCONTRATO.Text + "'")
        If nA(0) = 0 Then
            mensaje(nA(1))
            Exit Sub
        Else
            mensaje(nA(1))
        End If
    End Sub

    Private Sub LimpiarFormulario()
        TXTNOCONTRATO.Text = ""
        TXTFECHAINICIO.Text = ""
        TXTFECHAFIN.Text = ""
        TXTPOLIZAS.Text = ""
        TXTCETIFICADOS.Text = ""

        DDLTIPODECONTRATO.SelectedIndex = 0
        DDLTEMPORALIDADC.SelectedIndex = 0
        DDLJORNADAC.SelectedIndex = 0
        DDLTIPOFINCONTRATO.SelectedIndex = 0
        DDLLISTAEMPLEADO.SelectedIndex = 0
        DDLESTADO.SelectedIndex = 0

        DDLLISTAEMPLEADO.Enabled = True

    End Sub

    Private Sub LLENACATALOGOS()
        DdBind(DDLTIPODECONTRATO, "EXEC GESTION_EMPLEADOS 200", "CODIGO", "DESCRIPCION")
        DdBind(DDLTEMPORALIDADC, "EXEC GESTION_EMPLEADOS 199", "CODIGO", "DESCRIPCION")
        DdBind(DDLJORNADAC, "EXEC GESTION_EMPLEADOS 211", "CODIGO", "DESCRIPCION")
        DdBind(DDLTIPOFINCONTRATO, "EXEC GESTION_EMPLEADOS 188", "CODIGO", "DESCRIPCION")
        DdBind(DDLESTADO, "EXEC GESTION_EMPLEADOS 355", "CODIGO", "DESCRIPCION")
        DdBind(DDLLISTAEMPLEADO, "EXEC GESTION_EMPLEADOS 277", "CODIGO", "DESCRIPCION")

    End Sub

    Public Sub mensaje(ByRef mensaje As String)
        Dim script As String = "alert('" + mensaje + "');"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "alerta", script, True)
    End Sub

    Private Function IndiceCatalogos(ByRef id As String, ByRef opc As Integer) As String
        Dim resultado As String = ""
        If opc = 18 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 19 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 20 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 21 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 37 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        End If

        Return resultado
    End Function

    '--------------- BOTONES PARA LA GESTIÓN DE CONTRATOS ---------------------------------------------------------------------
    Private Sub BTNACTUALIZARCONTRATO_Click(sender As Object, e As EventArgs) Handles BTNACTUALIZARCONTRATO.Click
        Dim ffin As String = ""
        If TXTFECHAFIN.Text = "" Then
            ffin = ""
        Else
            ffin = TRANSFECHA(CDate(TXTFECHAFIN.Text))
        End If
        AbrirRecordsetData("EXEC SBOSP_INGRESO_CONTRATO 2,'" + Session.Item("UCO").ToString() + "','" + HFIDCONTRATO.Value.ToString() + "','" + DEVUELVECODIGOCATALOGO(DDLLISTAEMPLEADO) +
                       "','" + TRANSFECHA(CDate(TXTFECHAINICIO.Text)) + "','" + ffin + "','" + TXTPOLIZAS.Text + "','" + TXTCETIFICADOS.Text +
                       "','" + DDLESTADO.SelectedValue.ToString() + "','" + DEVUELVECODIGOCATALOGO(DDLTIPOFINCONTRATO) + "','" + DEVUELVECODIGOCATALOGO(DDLTEMPORALIDADC) +
                       "','" + DEVUELVECODIGOCATALOGO(DDLTIPODECONTRATO) + "','" + DEVUELVECODIGOCATALOGO(DDLJORNADAC) + "','" + TXTNOCONTRATO.Text + "'")
        If nA(0) = 0 Then
                mensaje(nA(1))
                Exit Sub
            Else
                mensaje(nA(1))
            End If

            LimpiarFormulario()
            LLENAGRIDCONTRATO()
            PNGRIDEMPLEADOS.Visible = True
            PNFORMULARIOEMPLEADO.Visible = False
    End Sub

    Private Sub BTNAGREGARNUEVOCONTRATO_Click(sender As Object, e As EventArgs) Handles BTNAGREGARNUEVOCONTRATO.Click
        LimpiarFormulario()
        DdBind(DDLLISTAEMPLEADO, "EXEC GESTION_EMPLEADOS 277", "CODIGO", "DESCRIPCION")
        BTNGUARDARCONTRATO.Visible = True
        BTNACTUALIZARCONTRATO.Visible = False
        PNGRIDEMPLEADOS.Visible = False
        PNFORMULARIOEMPLEADO.Visible = True
    End Sub

    Private Sub BTNGUARDARCONTRATO_Click(sender As Object, e As EventArgs) Handles BTNGUARDARCONTRATO.Click
        GUARDARCONTRATO()
        LimpiarFormulario()
        LLENAGRIDCONTRATO()
        PNGRIDEMPLEADOS.Visible = True
        PNFORMULARIOEMPLEADO.Visible = False
    End Sub

    Private Sub BTNCANCELARCONTRATO_Click(sender As Object, e As EventArgs) Handles BTNCANCELARCONTRATO.Click
        PNFORMULARIOEMPLEADO.Visible = False
        LimpiarFormulario()
        BTNACTUALIZARCONTRATO.Visible = False
        BTNGUARDARCONTRATO.Visible = False
        PNGRIDEMPLEADOS.Visible = True
    End Sub

    Private Sub TXTBUSCAREMPLEADO_TextChanged(sender As Object, e As EventArgs) Handles TXTBUSCAREMPLEADO.TextChanged
        GridBind(GVCONTRATO, "EXEC SBOSP_INGRESO_CONTRATO 111,'" + TXTBUSCAREMPLEADO.Text + "'", "", {"CODIGO", "ID_EMPLEADO", "FECHA_INICIO", "FECHA_FIN", "POLIZA_SEGURO", "CERTIFICADO_SEGURO", "ACTIVO", "TIPO_FIN_CONTRATO",
                 "TEMPORALIDAD_CONTRATO", "TIPO_CONTRATO", "JORNADA", "USR_CREADO", "FECHA_CREADO", "NUMERO_CONTRATO", "ID_EMPLEADO", "ID_CONTRATO", "ID_EMPLEADO1"})
    End Sub
End Class