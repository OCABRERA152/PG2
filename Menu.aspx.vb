Imports System.Data.SqlClient

Public Class Menu
    Inherits base

    Private Sub Menu_Load(sender As Object, e As EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If
        If Cache("Menu") Is Nothing Then
            Dim nNode As New TreeNode
            nNode.Text = "Menú Principal"
            LlenaNodo(nNode, "0")
            tv0.Nodes.Add(nNode)
            Cache.Add("Menu", nNode, Nothing, Nothing, Nothing, CacheItemPriority.Default, Nothing)
        Else
            tv0.Nodes.Add(Cache("Menu"))
        End If
        T0_Tick(sender, e)
    End Sub
    Protected Sub LlenaMenu()

        Dim nC = New SqlConnection(ConfigurationManager.ConnectionStrings("EASYIDB").ConnectionString)
        Dim nI As Integer
        nD = Nothing
        nD = New DataSet
        Try
            Dim Da As New SqlDataAdapter("EXEC SEGURIDAD 1001,'" & Session("UCO") & "'", nC)
            Da.Fill(nD, "nA")
            For nI = 0 To nD.Tables("nA").Rows.Count - 1
                L01.Text = L01.Text & nD.Tables("nA").Rows(nI)(0)
            Next
        Catch Ex As Exception
            L01.Text = "<p class=""ERRM"">" & Ex.Message & ">"
        End Try
        
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
            L01.Text = "<p class=""ERRM"">" & Ex.Message & ">"
        End Try
        nD.Dispose()
    End Sub
    Private Sub BTNOUT_Click(sender As Object, e As EventArgs) Handles BTNOUT.Click
        Session.Clear()
        Cache.Remove("Menu")
        Response.Redirect("Login.aspx")
    End Sub

    Protected Sub T0_Tick(sender As Object, e As EventArgs) Handles T0.Tick
        AbrirRecordsetData("EXEC PRG_TICKET 22,'" & Session("UCO") & "','COUNT'")
        If nA(0) <> 0 Then
            L01.Text = "<a href=""Tickets_Atender.aspx"" target=""_self"" class=" & "lblblanco" & ">Hay " & nA(0) & " Tickets por Atender</a>"
        End If
    End Sub
End Class