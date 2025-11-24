Public Class NOM_Nomina
    Inherits base

    Private Sub NOM_Nomina_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If
        LLENACATALOGOS()
        LLENANOMINAENCABEZADO()
    End Sub

    Private Sub LLENANOMINAENCABEZADO()
        GridBind(GVENCABEZADONOMINA, "EXEC SBOSP_INGRESO_NOMINA 7", "", {"TIPO_NOMINA"})
    End Sub

    Public Sub mensaje(ByRef mensaje As String)
        Dim script As String = "alert('" + mensaje + "');"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "alerta", script, True)
    End Sub

    Private Function DEVUELVECODIGOCATALOGO(ByRef ddl As DropDownList) As String
        Dim res As String = ""
        Dim arr As Array = ddl.SelectedItem.ToString().Split("-")
        res = arr(0).ToString()
        Return res
    End Function

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

    Private Sub LLENACATALOGOS()
        DdBind(DDLMESNOMINA, "EXEC GESTION_EMPLEADOS 388", "CODIGO", "DESCRIPCION")
        DdBind(DDLTIPODENOMINA, "EXEC GESTION_EMPLEADOS 233", "CODIGO", "DESCRIPCION")
    End Sub

    Private Function IndiceCatalogos(ByRef id As String, ByRef opc As Integer) As String
        Dim resultado As String = ""
        If opc = 38 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        ElseIf opc = 23 Then 'tipo de id
            AbrirRecordsetData("EXEC GESTION_EMPLEADOS " & opc & ",'" & id & "'")
            If nA(0) > 0 Then
                resultado = nA(0)
            End If
        End If
        Return resultado
    End Function

    Private Sub BTNCANCELARNOMINA_Click(sender As Object, e As EventArgs) Handles BTNCANCELARNOMINA.Click
        DDLMESNOMINA.SelectedIndex = 0
        TXTFECHANOMINA.Text = ""
        DDLTIPODENOMINA.SelectedIndex = 0
        PNFRMNOMINA.Visible = False
        PNGRIDNOMINAS.Visible = True
    End Sub

    Private Sub BTNAGREGARNOMINA_Click(sender As Object, e As EventArgs) Handles BTNAGREGARNOMINA.Click
        PNFRMNOMINA.Visible = True
        PNGRIDNOMINAS.Visible = False
    End Sub

    Private Sub BTNGUARDARNOMINA_Click(sender As Object, e As EventArgs) Handles BTNGUARDARNOMINA.Click
        If TXTFECHANOMINA.Text = "" Then
            mensaje("Debe elegir una fecha")
            Exit Sub
        End If
        If CDate(TXTFECHANOMINA.Text).Month = CInt(DEVUELVECODIGOCATALOGO(DDLMESNOMINA)) Then
            GoTo Inserta
        Else
            mensaje("El mes de la fecha no coincide con el mes de la nómina")
            Exit Sub
        End If

Inserta:
        If DEVUELVECODIGOCATALOGO(DDLTIPODENOMINA) = "1" Then
            AbrirRecordsetData("EXEC SBOSP_INGRESO_NOMINA 1,'" + Session.Item("UCO").ToString() + "','','','" + DEVUELVECODIGOCATALOGO(DDLMESNOMINA) +
                           "','" + TRANSFECHA(CDate(TXTFECHANOMINA.Text)) + "','" + DEVUELVECODIGOCATALOGO(DDLTIPODENOMINA) + "','',''")
        ElseIf DEVUELVECODIGOCATALOGO(DDLTIPODENOMINA) = "2" Then
            AbrirRecordsetData("EXEC SBOSP_INGRESO_NOMINA 2,'" + Session.Item("UCO").ToString() + "','','','" + DEVUELVECODIGOCATALOGO(DDLMESNOMINA) +
                           "','" + TRANSFECHA(CDate(TXTFECHANOMINA.Text)) + "','" + DEVUELVECODIGOCATALOGO(DDLTIPODENOMINA) + "','',''")
        ElseIf DEVUELVECODIGOCATALOGO(DDLTIPODENOMINA) = "3" Then
            AbrirRecordsetData("EXEC SBOSP_INGRESO_NOMINA 3,'" + Session.Item("UCO").ToString() + "','','','" + DEVUELVECODIGOCATALOGO(DDLMESNOMINA) +
                           "','" + TRANSFECHA(CDate(TXTFECHANOMINA.Text)) + "','" + DEVUELVECODIGOCATALOGO(DDLTIPODENOMINA) + "','',''")
        End If

        If nA(0) = 0 Then
            mensaje(nA(1))
            Exit Sub
        Else
            mensaje(nA(1))
            DDLMESNOMINA.SelectedIndex = 0
            TXTFECHANOMINA.Text = ""
            DDLTIPODENOMINA.SelectedIndex = 0
            PNFRMNOMINA.Visible = False
            PNGRIDNOMINAS.Visible = True
            LLENANOMINAENCABEZADO()
        End If
    End Sub

    Private Sub BTNREGRESARESTATUSNOM_Click(sender As Object, e As EventArgs) Handles BTNREGRESARESTATUSNOM.Click
        PNGGC.Visible = False
        PNGRIDNOMINAS.Visible = True
    End Sub

    Private Sub GVENCABEZADONOMINA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVENCABEZADONOMINA.SelectedIndexChanged
        HFESTATUSNOMINA.Value = GVENCABEZADONOMINA.SelectedRow.Cells(5).Text
        HFTIPODENOMINA.Value = GVENCABEZADONOMINA.SelectedRow.Cells(6).Text
        GVNOMINAGENERADA.DataSource = Nothing
        GVNOMINAGENERADA.DataBind()
        If HFESTATUSNOMINA.Value.ToString().Equals("ABIERTO") Then
            HFCODIGONOMINA.Value = GVENCABEZADONOMINA.SelectedRow.Cells(0).Text
            PNGGC.Visible = True
            PNGRIDNOMINAS.Visible = False
            BTNCERRARNOMINA.Visible = False
            BTNCREARNOMINA.Visible = True
            BTNGNERARNOMINA.Visible = True
        ElseIf HFESTATUSNOMINA.Value.ToString().Equals("GENERADA") Then
            HFCODIGONOMINA.Value = GVENCABEZADONOMINA.SelectedRow.Cells(0).Text
            If HFTIPODENOMINA.Value.ToString() = "1" Then
                GridBind(GVNOMINAGENERADA, "EXEC SBOSP_INGRESO_NOMINA 13,'','" + HFCODIGONOMINA.Value.ToString() + "'", "", {"LINEA_DETALLE", "CODIGO_ENCABEZADO"})
            ElseIf HFTIPODENOMINA.Value.ToString() = "2" Or HFTIPODENOMINA.Value.ToString() = "3" Then
                GridBind(GVNOMINAGENERADA, "EXEC SBOSP_INGRESO_NOMINA 14,'','" + HFCODIGONOMINA.Value.ToString() + "'", "", {"LINEA_DETALLE", "CODIGO_ENCABEZADO"})
            End If
            PNGGC.Visible = True
            PNGRIDNOMINAS.Visible = False
            BTNCERRARNOMINA.Visible = True
            BTNCREARNOMINA.Visible = False
            BTNGNERARNOMINA.Visible = False
        ElseIf HFESTATUSNOMINA.Value.ToString().Equals("CERRADO") Then
            HFCODIGONOMINA.Value = GVENCABEZADONOMINA.SelectedRow.Cells(0).Text
            If HFTIPODENOMINA.Value.ToString() = "1" Then
                GridBind(GVNOMINAGENERADA, "EXEC SBOSP_INGRESO_NOMINA 13,'','" + HFCODIGONOMINA.Value.ToString() + "'", "", {"LINEA_DETALLE", "CODIGO_ENCABEZADO"})
            ElseIf HFTIPODENOMINA.Value.ToString() = "2" Or HFTIPODENOMINA.Value.ToString() = "3" Then
                GridBind(GVNOMINAGENERADA, "EXEC SBOSP_INGRESO_NOMINA 14,'','" + HFCODIGONOMINA.Value.ToString() + "'", "", {"LINEA_DETALLE", "CODIGO_ENCABEZADO"})
            End If
            PNGGC.Visible = True
            PNGRIDNOMINAS.Visible = False
            BTNCERRARNOMINA.Visible = False
            BTNCREARNOMINA.Visible = False
            BTNGNERARNOMINA.Visible = False
        End If
    End Sub

    Private Sub BTNGNERARNOMINA_Click(sender As Object, e As EventArgs) Handles BTNGNERARNOMINA.Click
        GVNOMINAGENERADA.PageIndex = 0
        If HFTIPODENOMINA.Value.ToString() = "1" Then
            GridBind(GVNOMINAGENERADA, "EXEC SBOSP_INGRESO_NOMINA 4", "", {""})
        ElseIf HFTIPODENOMINA.Value.ToString() = "2" Then
            GridBind(GVNOMINAGENERADA, "EXEC SBOSP_INGRESO_NOMINA 5", "", {""})
        ElseIf HFTIPODENOMINA.Value.ToString() = "3" Then
            GridBind(GVNOMINAGENERADA, "EXEC SBOSP_INGRESO_NOMINA 6", "", {""})
        End If
    End Sub

    Private Sub GVENCABEZADONOMINA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVENCABEZADONOMINA.PageIndexChanging
        GVENCABEZADONOMINA.PageIndex = e.NewPageIndex
        LLENANOMINAENCABEZADO()
    End Sub

    Private Sub GVNOMINAGENERADA_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles GVNOMINAGENERADA.PageIndexChanging
        GVNOMINAGENERADA.PageIndex = e.NewPageIndex
        If HFESTATUSNOMINA.Value.ToString() = "ABIERTO" Then
            If HFTIPODENOMINA.Value.ToString() = "1" Then
                GridBind(GVNOMINAGENERADA, "EXEC SBOSP_INGRESO_NOMINA 4", "", {""})
            ElseIf HFTIPODENOMINA.Value.ToString() = "2" Then
                GridBind(GVNOMINAGENERADA, "EXEC SBOSP_INGRESO_NOMINA 5", "", {""})
            ElseIf HFTIPODENOMINA.Value.ToString() = "3" Then
                GridBind(GVNOMINAGENERADA, "EXEC SBOSP_INGRESO_NOMINA 6", "", {""})
            End If
        Else
            If HFTIPODENOMINA.Value.ToString() = "1" Then
                GridBind(GVNOMINAGENERADA, "EXEC SBOSP_INGRESO_NOMINA 13,'','" + HFCODIGONOMINA.Value.ToString() + "'", "", {"LINEA_DETALLE", "CODIGO_ENCABEZADO"})
            ElseIf HFTIPODENOMINA.Value.ToString() = "2" Or HFTIPODENOMINA.Value.ToString() = "3" Then
                GridBind(GVNOMINAGENERADA, "EXEC SBOSP_INGRESO_NOMINA 14,'','" + HFCODIGONOMINA.Value.ToString() + "'", "", {"LINEA_DETALLE", "CODIGO_ENCABEZADO"})
            End If
        End If
    End Sub

    Private Sub BTNCREARNOMINA_Click(sender As Object, e As EventArgs) Handles BTNCREARNOMINA.Click
        If HFTIPODENOMINA.Value.ToString() = "1" Then
            AbrirRecordsetData("EXEC SBOSP_INGRESO_NOMINA 8,'','" + HFCODIGONOMINA.Value.ToString() + "'")
        ElseIf HFTIPODENOMINA.Value.ToString() = "2" Or HFTIPODENOMINA.Value.ToString() = "3" Then
            AbrirRecordsetData("EXEC SBOSP_INGRESO_NOMINA 9,'','" + HFCODIGONOMINA.Value.ToString() + "'")
        End If
        If nA(0) = 0 Then
            mensaje(nA(1))
            Exit Sub
        Else
            Notifica(nA(1).ToString(), "NOM_Nomina.aspx")
        End If
    End Sub

    Public Sub mensajehtmlprincipal(ByRef texto As String)
        DIVALERTAPRINCIPAL.Attributes.Remove("class")
        LTALERTAPRINCIPAL.Text = texto
        DIVALERTAPRINCIPAL.Attributes.Add("class", "alert alert-warning alert-dismissible fade show")
    End Sub

    Private Sub BTNCERRARNOMINA_Click(sender As Object, e As EventArgs) Handles BTNCERRARNOMINA.Click
        If HFTIPODENOMINA.Value.ToString() = "1" Then
            AbrirRecordsetData("EXEC SBOSP_INGRESO_NOMINA 11,'','" + HFCODIGONOMINA.Value.ToString() + "'")
        ElseIf HFTIPODENOMINA.Value.ToString() = "2" Or HFTIPODENOMINA.Value.ToString() = "3" Then
            AbrirRecordsetData("EXEC SBOSP_INGRESO_NOMINA 12,'','" + HFCODIGONOMINA.Value.ToString() + "'")
        End If
        If nA(0) = 0 Then
            mensaje(nA(1))
            Exit Sub
        Else
            Notifica(nA(1).ToString(), "NOM_Nomina.aspx")
        End If
    End Sub

    Private Sub GVNOMINAGENERADA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVNOMINAGENERADA.SelectedIndexChanged
        If HFESTATUSNOMINA.Value.ToString() = "GENERADA" Then
            HFNOLINEANOMINAD.Value = GVNOMINAGENERADA.SelectedRow.Cells(1).Text

            myModal.Attributes.Remove("class")
            myModal.Attributes.Remove("style")
            myModal.Attributes.Remove("aria-hidden")

            myModal.Attributes.Add("class", "modal fade show")
            myModal.Attributes.Add("style", "display: block")
            myModal.Attributes.Add("aria-modal", "true")
            myModal.Attributes.Add("rol", "dialog")
        End If
    End Sub

    Private Sub BTNCLOSETEXTDOCTO_Click(sender As Object, e As EventArgs) Handles BTNCLOSETEXTDOCTO.Click
        myModal.Attributes.Remove("class")
        myModal.Attributes.Remove("style")
        myModal.Attributes.Remove("aria-modal")
        myModal.Attributes.Remove("rol")

        myModal.Attributes.Add("class", "modal fade")
        myModal.Attributes.Add("style", "display: none")
        myModal.Attributes.Add("aria-hidden", "true")

        TXTNODOCTOPAGO.Text = ""

    End Sub

    Private Sub BTNGUARDARNODOCTO_Click(sender As Object, e As EventArgs) Handles BTNGUARDARNODOCTO.Click
        If HFESTATUSNOMINA.Value.ToString() = "GENERADA" Then
            If TXTNODOCTOPAGO.Text = "" Then
                mensaje("El campo de texto no puedo estar vacío")
                Exit Sub
            End If
            AbrirRecordsetData("EXEC SBOSP_INGRESO_NOMINA 10,'','','" + HFNOLINEANOMINAD.Value.ToString() + "','','','','','" + TXTNODOCTOPAGO.Text + "'")
            If nA(0) = 0 Then
                mensaje(nA(1))
                Exit Sub
            Else
                mensaje(nA(1))
                BTNCLOSETEXTDOCTO_Click(sender, e)
                If HFTIPODENOMINA.Value.ToString() = "1" Then
                    GridBind(GVNOMINAGENERADA, "EXEC SBOSP_INGRESO_NOMINA 13,'','" + HFCODIGONOMINA.Value.ToString() + "'", "", {"LINEA_DETALLE", "CODIGO_ENCABEZADO"})
                ElseIf HFTIPODENOMINA.Value.ToString() = "2" Or HFTIPODENOMINA.Value.ToString() = "3" Then
                    GridBind(GVNOMINAGENERADA, "EXEC SBOSP_INGRESO_NOMINA 14,'','" + HFCODIGONOMINA.Value.ToString() + "'", "", {"LINEA_DETALLE", "CODIGO_ENCABEZADO"})
                End If
            End If
        End If
    End Sub
End Class