Public Class Clasificacion_region
    Inherits base

    Private Sub Clasificacion_region_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub btnGuardarPais_Click(sender As Object, e As EventArgs) Handles btnGuardarPais.Click
        Dim activo As String = "false"
        If txtCodPais.Text.Length = 0 Then
            MostrarMensaje("El codigo no puede ser vacío")
            Exit Sub
        ElseIf txtDescPais.Text.Length = 0 Then
            MostrarMensaje("La descripción no puede establecerce vacía")
            Exit Sub
        Else
            If txtEstatusPais.Checked Then
                activo = "true"
            Else
                activo = "false"
            End If
            AbrirRecordsetData("EXEC DB_RRHH.cat.IUPais '','" + txtIsoPais.Text + "','" + txtCodPais.Text + "','','" + txtDescPais.Text + "','','" + activo + "','1',''")
            If nA(0) = 0 Then
                MostrarMensaje(nA(1).ToString)
                GVCR.DataBind()
                txtCodPais.Text = ""
                txtIsoPais.Text = ""
                txtDescPais.Text = ""
                txtEstatusPais.Checked = False
            End If
        End If
    End Sub

    Private Sub MostrarMensaje(ByVal mensaje As String)
        Dim script As String = "alert('" + mensaje + "');"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "alerta", Script, True)
    End Sub

    Private Sub GVCR_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles GVCR.RowCommand
        If e.CommandName = "Select" Then
            ' Se obtiene indice de la row seleccionada
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            ' Obtengo el id de la entidad que se esta editando
            ' en este caso de la entidad Torneo
            Dim id As Integer = Convert.ToInt32(GVCR.DataKeys(index).Value)
            Dim row As GridViewRow = GVCR.Rows(index)
            Dim item As String = Server.HtmlDecode(row.Cells(4).Text)
            HFPAIS.Value = id
            LBLPAIS.Text = "/ País | " + item
            GVRP.DataBind()
            'MostrarMensaje(CStr(id))
        End If
    End Sub

    Private Sub btnAgregarRegion_Click(sender As Object, e As EventArgs) Handles btnAgregarRegion.Click
        Dim activo As String = "false"
        If txtCodigoRegion.Text.Length = 0 Then
            MostrarMensaje("El codigo de región no puede ser vacío")
            Exit Sub
        ElseIf txtRegionNombre.Text.Length = 0 Then
            MostrarMensaje("El nombre de región no puede ser vacío")
            Exit Sub
        ElseIf txtDescRegion.Text.Length = 0 Then
            MostrarMensaje("La descripción de región no puede ser vacía")
            Exit Sub
        Else
            If txtEstatusPais.Checked Then
                activo = "true"
            Else
                activo = "false"
            End If
            AbrirRecordsetData("EXEC DB_RRHH.cat.IURegion '','" + txtCodigoRegion.Text + "','" + txtRegionNombre.Text + "','" + txtDescRegion.Text + "','" + activo + "','1'," + "'" + HFPAIS.Value + "'")
            If nA(0) = 0 Then
                MostrarMensaje(nA(1).ToString)
                GVRP.DataBind()
                txtCodigoRegion.Text = ""
                txtRegionNombre.Text = ""
                txtDescRegion.Text = ""
                txtEstadoRegion.Checked = False
            End If
        End If
    End Sub
End Class