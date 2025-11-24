Imports System.Data.SqlClient

Partial Public Class MP01
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If

        NombreUsuario.Text = Session("NOM")
        If NombreUsuario.Text.Length = 0 Then
            NombreUsuario.Text = "Sin Ingresar"
        Else
            'If Cache("Menu") Is Nothing Then
            '    Dim nNode As New TreeNode
            '    nNode.Text = "Menú Principal"
            '    LlenaNodo(nNode, "0")
            '    tv0.Nodes.Add(nNode)
            '    Cache.Add("Menu", nNode, Nothing, Nothing, Nothing, CacheItemPriority.Default, Nothing)
            'Else
            '    tv0.Nodes.Add(Cache("Menu"))
            'End If
            MenuHTML()
            PMENU.Visible = True
            'DdBind(DDLEMPRESAS, "EXEC PRG_ADMINISTRACION_GENERAL 4", "CODIGO", "DESCRIPCION")
        End If
    End Sub

    Private Sub BTNSALIR_Click(sender As Object, e As EventArgs) Handles BTNSALIR.Click
        Session.Clear()
        Cache.Remove("Menu")
        Response.Redirect("Inicio_Sesion.aspx")
    End Sub

    Protected Sub LlenaNodo(ByRef Nodo As TreeNode, ByVal Padre As String)
        Dim nC = New SqlConnection(ConfigurationManager.ConnectionStrings("EASYIDB").ConnectionString)
        Dim nI As Integer
        Dim nD = New DataSet
        Try
            Dim Da As New SqlDataAdapter("EXEC SEGURIDAD 1002,'" & Session("UCO") & "','" & Padre & "'", nC)
            Da.Fill(nD, "nA")
            For nI = 0 To nD.Tables("nA").Rows.Count - 1
                Dim nNo As New TreeNode
                nNo.Text = nD.Tables("nA").Rows(nI)(2)
                If nD.Tables("nA").Rows(nI)(1).ToString.Length > 0 Then 'es una hoja
                    If nD.Tables("nA").Rows(nI)(3).ToString.Contains("1") Then
                        nNo.NavigateUrl = nD.Tables("nA").Rows(nI)(1).ToString
                    End If
                Else 'es otro nodo
                    LlenaNodo(nNo, nD.Tables("nA").Rows(nI)(0).ToString)
                End If
                If (nNo.NavigateUrl.Length > 0) Or (nNo.ChildNodes.Count > 0) Then
                    Nodo.ChildNodes.Add(nNo)
                End If
            Next
            Da.Dispose()
        Catch Ex As Exception
            'L01.Text = "<p class=""ERRM"">" & Ex.Message & ">"
            mensaje(Ex.Message)
        End Try
        nD.Dispose()
    End Sub

    Protected Sub MenuHTML()
        Dim nC = New SqlConnection(ConfigurationManager.ConnectionStrings("EASYIDB").ConnectionString)
        Dim nI As Integer
        Dim nD = New DataSet
        Try
            Dim Da As New SqlDataAdapter("EXEC SEGURIDAD 1001,'" & Session("UCO") & "'", nC)
            Da.Fill(nD, "nA")
            For nI = 0 To nD.Tables("nA").Rows.Count - 1
                L01.Text = L01.Text + nD.Tables("nA").Rows(nI)(0).ToString
            Next
            Da.Dispose()
        Catch Ex As Exception
            mensaje(Ex.Message)
        End Try
        nD.Dispose()
    End Sub

    Public Sub mensaje(ByRef mensaje As String)
        Dim script As String = "alert('" + mensaje + "');"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "alerta", script, True)
    End Sub

    'Protected Sub BTNHLP_Click(sender As Object, e As EventArgs) Handles BTNHLP.Click
    '    Response.Redirect("Help.aspx")
    'End Sub
End Class