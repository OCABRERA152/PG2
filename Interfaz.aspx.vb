Public Class Interfaz
    Inherits base

    Protected Sub BTNGO_Click(sender As Object, e As EventArgs) Handles BTNGO.Click
        ERRM.Text = ""
        LSAP.Text = ""
        Try
            LBLTITLE.Text = TXTORIG.SelectedItem.Text & " " & "DEL " & Format(Date.ParseExact(TXTDEL.Text, "yyyy-MM-dd", Nothing), "dd/MM/yyyy") & " AL " & Format(Date.ParseExact(TXTAL.Text, "yyyy-MM-dd", Nothing), "dd/MM/yyyy")
        Catch ex As Exception
            ERRM.Text = ex.Message
            Exit Sub
        End Try
        GridBind(GVVTA, "EXEC PRG_DATA " & TXTORIG.SelectedItem.Value & ",'" & TXTDEL.Text & "','" & TXTAL.Text & "'", "", {"CODIGO"})
        If GVVTA.Columns.Count > 2 Then
            GVVTA.Columns(GVVTA.Columns.Count - 1).ItemStyle.HorizontalAlign = HorizontalAlign.Right
            GVVTA.Columns(GVVTA.Columns.Count - 2).ItemStyle.HorizontalAlign = HorizontalAlign.Right
        End If
        If GVVTA.Rows(0).Cells(0).Text = "1" Then
            BTNSAP.Enabled = True
        End If
    End Sub

    Protected Sub BTNOUT_Click(sender As Object, e As EventArgs) Handles BTNOUT.Click
        Response.Redirect("Menu.aspx")
    End Sub

    Private Sub Page_Load1(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If
        DdBind(TXTORIG, "EXEC PRG_DATA 2", "VALOR", "TEXTO")
        GridBind(GVVTA, "EXEC PRG_DATA 101", "", {"CODIGO"})
    End Sub

    Private Sub BTNCFG_Click(sender As Object, e As EventArgs) Handles BTNCFG.Click
        Response.Redirect("ConfSap.aspx")
    End Sub


    Protected Sub BTNDBCK_Click(sender As Object, e As EventArgs) Handles BTNDBCK.Click
        P02.Visible = False
        P01.Visible = True
    End Sub

    Private Sub GVVTA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GVVTA.SelectedIndexChanged
        If Trim$(HttpUtility.HtmlDecode(GVVTA.SelectedRow.Cells(1).Text)) <> " " Then
            P01.Visible = False
            P02.Visible = True
            TITDET.Text = "<table style=""margin-left:auto; margin-right:auto;""> " _
                & "<caption>Poliza de Ventas</caption> " _
                & "<tr><td>Del</td><td>" & TXTDEL.Text & "</td></tr>" _
                & "<tr><td>Al</td><td>" & TXTAL.Text & "</td></tr>" _
                & "<tr><td>Cuenta</td><td> " & HttpUtility.HtmlDecode(GVVTA.SelectedRow.Cells(1).Text) & "</td></tr> " _
                & "<tr><td>Nombre</td><td>" & HttpUtility.HtmlDecode(GVVTA.SelectedRow.Cells(2).Text) & "</td></tr> " _
                & "<tr><td><strong>Debe</strong></td><td><strong>" & HttpUtility.HtmlDecode(GVVTA.SelectedRow.Cells(3).Text) & "</strong></td></tr> " _
                & "<tr><td><strong>Haber</strong></td><td><strong>" & HttpUtility.HtmlDecode(GVVTA.SelectedRow.Cells(4).Text) & "</strong></td></tr> " _
                & "</table><br /><br />"
            GridBind(GVDET, "EXEC PRG_DATA 104,'" & TXTORIG.SelectedItem.Value & "','" & HttpUtility.HtmlDecode(GVVTA.SelectedRow.Cells(1).Text) & "','" & TXTDEL.Text & "','" & TXTAL.Text & "'", "", {})
            If GVDET.Rows.Count > 0 Then
                GVDET.Columns(2).ItemStyle.HorizontalAlign = HorizontalAlign.Right
                GVDET.Columns(3).ItemStyle.HorizontalAlign = HorizontalAlign.Right
            End If
            LlenaFiltro()
        End If
    End Sub
    Private Sub LlenaFiltro()
        Dim nTda As String
        Dim nLTD As Integer
        nTda = 0
        For nLTD = 0 To GVDET.Rows.Count - 1
            If nTda <> GVDET.Rows(nLTD).Cells(0).Text Then
                TXTFTDA.Items.Add(GVDET.Rows(nLTD).Cells(0).Text)
                nTda = GVDET.Rows(nLTD).Cells(0).Text
            End If
            nLTD = nLTD + 1
        Next
        TXTFTDA.SelectedIndex = -1
    End Sub

    Private Sub BTNFGO_Click(sender As Object, e As EventArgs) Handles BTNFGO.Click
        If BTNFGO.Text = "Filtrar" Then
            BTNFGO.Text = "Quitar Filtro"
            If TXTFTDA.SelectedIndex >= 0 Then
                If (Date.TryParseExact(TXTFDEL.Text, "yyyy-MM-dd", Nothing, Globalization.DateTimeStyles.None, Nothing)) And (Date.TryParseExact(TXTFAL.Text, "yyyy-MM-dd", Nothing, Globalization.DateTimeStyles.None, Nothing)) Then
                    For nI = 0 To GVDET.Rows.Count - 1
                        If (GVDET.Rows(nI).Cells(0).Text = TXTFTDA.SelectedValue) And (Date.ParseExact(GVDET.Rows(nI).Cells(1).Text, "dd/MM/yyyy", Nothing) >= Date.ParseExact(TXTFDEL.Text, "yyyy-MM-dd", Nothing)) And (Date.ParseExact(GVDET.Rows(nI).Cells(1).Text, "dd/MM/yyyy", Nothing) <= Date.ParseExact(TXTFAL.Text, "yyyy-MM-dd", Nothing)) Then
                        Else
                            GVDET.Rows(nI).Visible = False
                        End If
                    Next
                Else 'no hay fechas, o están malas
                    For nI = 0 To GVDET.Rows.Count - 1
                        If (GVDET.Rows(nI).Cells(0).Text = TXTFTDA.SelectedValue) Then
                        Else
                            GVDET.Rows(nI).Visible = False
                        End If
                    Next
                End If
            End If
        Else
            BTNFGO.Text = "Filtrar"
            For nI = 0 To GVDET.Rows.Count - 1
                If GVDET.Rows(nI).Visible = False Then
                    GVDET.Rows(nI).Visible = True
                End If
            Next
        End If
    End Sub

    Protected Sub BTNSAP_Click(sender As Object, e As EventArgs) Handles BTNSAP.Click
        LBLBTNSAPERR.Text = ""

        If GVVTA.Rows.Count = 0 Then
            Exit Sub
        End If
        If GVVTA.Rows(0).Cells(0).Text <> "1" Then
            Exit Sub
        End If
        AbrirRecordsetData("EXEC SEGURIDAD 4001,'" & Session("UCO") & "','SAP IMPORTA DATOS'")
        If nA(0) = 0 Then 'No tiene la propiedad
            LBLBTNSAPERR.Text = nA(1)
            Exit Sub
        End If
        If nA(1) <> "1" Then
            LBLBTNSAPERR.Text = "El usuario no tiene acceso a esta opción"
            Exit Sub
        End If
        CreaArchivo("EXEC PRG_DATA " & TXTORIG.SelectedValue & ",'" & TXTDEL.Text & "','" & TXTAL.Text & "','ENC'", "ENC.txt", "SAP")
        CreaArchivo("EXEC PRG_DATA " & TXTORIG.SelectedValue & ",'" & TXTDEL.Text & "','" & TXTAL.Text & "','DET'", "DET.txt", "SAP")
        LSAP.Text = "<br /><br /><div class=""MenuBar""><a download href=""./Files/SAP/ENC.txt"" class=""TopMenu"">Descargar ENC.txt</a>&nbsp;&nbsp;&nbsp;"
        LSAP.Text = LSAP.Text & "<a download href=""./Files/SAP/DET.txt"" class=""TopMenu"">Descargar DET.txt</a></div><br><br><br>"
        T0.Enabled = True
    End Sub
    Protected Sub CreaArchivo(ByVal Query As String, ByVal Nombre As String, ByVal Ruta As String)
        'Borrar archivo de existir
        If System.IO.File.Exists(Server.MapPath("./Files/" & Ruta & IIf(Ruta = "", "", "/") & Nombre)) Then
            System.IO.File.Delete(Server.MapPath("./Files/" & Ruta & IIf(Ruta = "", "", "/") & Nombre))
        End If
        'Crear ruta de no existir
        If Ruta <> "" Then
            If Not System.IO.Directory.Exists(Server.MapPath("./Files/" & Ruta)) Then
                System.IO.Directory.CreateDirectory(Server.MapPath("./Files/" & Ruta))
            End If
        End If
        Dim nFile As System.IO.StreamWriter
        nFile = System.IO.File.CreateText(Server.MapPath("./Files/" & Ruta & IIf(Ruta = "", "", "/") & Nombre))
        'abrir query y llenar archivo
        Dim nC = New System.Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("EASYIDB").ConnectionString)
        nD = Nothing
        nD = New DataSet
        Dim Da As New System.Data.SqlClient.SqlDataAdapter(Query, nC)
        Da.Fill(nD, "nA")
        nC = Nothing
        Da = Nothing
        Dim nR As Integer
        Dim nK As Integer
        Dim nTxt As String
        Try
            For nR = 0 To nD.Tables("nA").Rows.Count
                nTxt = ""
                For nK = 0 To nD.Tables("nA").Columns.Count - 1
                    nTxt = nTxt & nD.Tables("nA").Rows(nR)(nK).ToString & IIf(nK = nD.Tables("nA").Columns.Count - 1, "", vbTab)
                Next
                nFile.WriteLine(nTxt)
            Next
            nFile.Close()
        Catch nE As Exception
            nFile.Close()
        End Try
    End Sub

    Protected Sub T0_Tick(sender As Object, e As EventArgs) Handles T0.Tick
        LSAP.Text = ""
        T0.Enabled = False
    End Sub

    Protected Sub BTNEXPORT_Click(sender As Object, e As ImageClickEventArgs) Handles BTNEXPORT.Click
        If GVVTA.Rows.Count > 0 Then
            ExportToExcel(TXTORIG.SelectedItem.Text & "_" & TXTDEL.Text & "_" & TXTAL.Text & ".xls", GVVTA)
        End If
    End Sub

    Private Sub ExportToExcel(ByVal strFileName As String, ByVal dg As GridView)
        Response.Clear()
        Response.AddHeader("content-disposition", "attachment;filename=" & strFileName)
        Response.Charset = ""
        Response.ContentType = "application/vnd.ms-excel"
        Dim oStringWriter As New System.IO.StringWriter
        Dim oHtmlTextWriter As New System.Web.UI.HtmlTextWriter(oStringWriter)
        dg.RenderControl(oHtmlTextWriter)
        Response.Write(oStringWriter.ToString())
        Response.End()
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(control As Control)
        'MyBase.VerifyRenderingInServerForm(control)
    End Sub

    Private Sub BTNEXPOR2_Click(sender As Object, e As ImageClickEventArgs) Handles BTNEXPOR2.Click
        If GVDET.Rows.Count > 0 Then
            ExportToExcel(TXTORIG.SelectedItem.Text & "_" & TXTDEL.Text & "_" & TXTAL.Text & "_DET.xls", GVDET)
        End If
    End Sub
End Class