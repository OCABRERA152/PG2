Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.Mail
Imports System.Web.UI
Imports System.Xml

Module Funciones
    Public USR As String
    Public UCO As Integer
    Public CODEMPSAP As Integer
    Public STA As String
    Public NOM As String
    Public TRM As String
    Public SEG As Char
    Public nD As DataSet
    Public nDT As DataTable
    Public SOE As String
    Public SOD As String
    Public FIL As String
    Public nA(50)
    Public BOD As Integer
    Public DBO As String
    Public TMO As Integer
    Public Opt As Integer
    Public Sim As String
    Public pedidos As New List(Of Pedido)()
    Public tipoDoctoSolicitud As Integer '100 = Cotizacion 101= Orden de vena 102=Envio o solicitud de translado

    Public Function Security(ByVal UNI, ByVal USR) As Boolean
        AbrirRecordsetData("Exec Seguridad 5,'" & USR & "','" & UNI & "'")
        If nA(0) = 1 Then
            SEG = nA(1)
            Security = True
        Else
            SEG = " "
            Security = False
        End If
    End Function

    Public Sub AbrirRecordsetData(ByRef SQL As String)
        Try
            Dim nC = New SqlConnection(ConfigurationManager.ConnectionStrings("EASYIDB").ConnectionString)
            Dim nI As Integer
            nD = Nothing
            nD = New DataSet
            Dim Da As New SqlDataAdapter(SQL, nC)
            Da.Fill(nD, "nA")
            nC = Nothing
            Da = Nothing
            For nI = 0 To nD.Tables("nA").Columns.Count - 1
                nA(nI) = nD.Tables("nA").Rows(0)(nI)
            Next
        Catch ex As Exception
            Notifica(ex.Message.ToString(), "Inicio.aspx")
        End Try

    End Sub

    Public Function ObtieneRS(ByVal Sql As String) As DataSet
        Dim nC = New SqlConnection(ConfigurationManager.ConnectionStrings("EASYIDB").ConnectionString)
        Dim nD As New DataSet
        Dim Da As New SqlDataAdapter(Sql, nC)
        Da.Fill(nD, "nA")
        nC = Nothing
        Da = Nothing
        Return nD
    End Function

    Public Sub AbrirLocal(ByRef SQL As String)
        Dim nC = New SqlConnection(ConfigurationManager.ConnectionStrings("WEBDB").ConnectionString)
        Dim nI As Integer
        nD = Nothing
        nD = New DataSet
        Dim Da As New SqlDataAdapter(SQL, nC)
        Da.Fill(nD, "nA")
        nC = Nothing
        Da = Nothing
        For nI = 0 To nD.Tables("nA").Columns.Count - 1
            nA(nI) = nD.Tables("nA").Rows(0)(nI)
        Next
    End Sub

    Public Function Validar_Email(ByVal emailAddress As String) As Boolean

        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"
        Dim emailAddressMatch As Match = Regex.Match(emailAddress, pattern)
        If emailAddressMatch.Success Then
            Validar_Email = True
        Else
            Validar_Email = False
        End If

    End Function


    Public Sub CbBind(ByRef GR As CheckBoxList, ByVal Sql As String, ByVal VALOR As String, ByVal TEXTO As String)
        GR.Items.Clear()
        Dim nC = New SqlConnection(ConfigurationManager.ConnectionStrings("EASYIDB").ConnectionString)
        nD = Nothing
        nD = New DataSet
        Dim Da As New SqlDataAdapter(Sql, nC)
        Da.Fill(nD, "nA")
        GR.DataSource = nD
        GR.DataValueField = VALOR
        GR.DataTextField = TEXTO
        GR.DataBind()
        nC = Nothing
        Da = Nothing
        nD = Nothing
    End Sub

    Public Sub DdBind(ByRef GR As DropDownList, ByVal Sql As String, ByVal VALOR As String, ByVal TEXTO As String)
        GR.Items.Clear()
        Dim nC = New SqlConnection(ConfigurationManager.ConnectionStrings("EASYIDB").ConnectionString)
        nD = Nothing
        nD = New DataSet
        Dim Da As New SqlDataAdapter(Sql, nC)
        Da.Fill(nD, "nA")
        GR.DataSource = nD
        GR.DataValueField = VALOR
        GR.DataTextField = TEXTO
        GR.DataBind()
        nC = Nothing
        Da = Nothing
        nD = Nothing
    End Sub

    Public Function DdBind_(ByVal Sql As String) As DataTable
        Dim nC = New SqlConnection(ConfigurationManager.ConnectionStrings("EASYIDB").ConnectionString)
        nD = Nothing
        nD = New DataSet
        Dim nDT As New DataTable
        Dim Da As New SqlDataAdapter(Sql, nC)
        Da.Fill(nD, "nA")

        nDT = nD.Tables(0)

        nC = Nothing
        Da = Nothing
        nD = Nothing
        'nDT = Nothing

        Return nDT
    End Function


    Public Sub DdBind1(ByRef GR As TextBox, ByRef GR1 As TextBox, ByRef GR2 As TextBox, ByVal Sql As String)
        GR.Text = ""
        Dim nC = New SqlConnection(ConfigurationManager.ConnectionStrings("EASYIDB").ConnectionString)
        nD = Nothing
        nD = New DataSet
        Dim nDT As New DataTable
        Dim Da As New SqlDataAdapter(Sql, nC)
        Da.Fill(nD, "nA")
        If nD.Tables(0).Rows.Count = 0 Then
            MsgBox("no hay registros")
        Else
            nDT = nD.Tables(0)
            GR.Text = nDT.Rows(0).Item(0).ToString
            GR1.Text = nDT.Rows(0).Item(1).ToString
            GR2.Text = nDT.Rows(0).Item(2).ToString
        End If
        nC = Nothing
        Da = Nothing
        nD = Nothing
        nDT = Nothing
    End Sub

    Public Sub TextBind(ByRef TX As TextBox, ByVal Sql As String)
        TX.Text = ""
        Dim nC = New SqlConnection(ConfigurationManager.ConnectionStrings("EASYIDB").ConnectionString)
        nD = Nothing
        nD = New DataSet
        Dim nDT As New DataTable
        Dim Da As New SqlDataAdapter(Sql, nC)
        Da.Fill(nD, "nA")
        If nD.Tables(0).Rows.Count = 0 Then
            TX.Text = "No hay registros"
        Else
            nDT = nD.Tables(0)
            TX.Text = nDT.Rows(0).Item(1).ToString
        End If
        nC = Nothing
        Da = Nothing
        nD = Nothing
        nDT = Nothing
    End Sub

    Public Function SP_EXECUTE_RESULT(ByVal Sql As String) As String
        Dim result As String
        Dim nC = New SqlConnection(ConfigurationManager.ConnectionStrings("EASYIDB").ConnectionString)
        nD = Nothing
        nD = New DataSet
        Dim nDT As New DataTable
        Dim Da As New SqlDataAdapter(Sql, nC)
        Da.Fill(nD, "nA")
        If nD.Tables(0).Rows.Count = 0 Then
            result = "0"
        Else
            nDT = nD.Tables(0)
            result = nDT.Rows(0).Item(1).ToString
        End If
        nC = Nothing
        Da = Nothing
        nD = Nothing
        nDT = Nothing
        Return result
    End Function

    Public Sub GridBind90(ByRef GR As GridView, ByVal Sql As String, ByVal COL As String, ByVal ParamArray Esconder() As String)
        GR.Columns.Clear()
        Dim nC = New SqlConnection(ConfigurationManager.ConnectionStrings("EASYIDB").ConnectionString)
        Dim nI As Integer
        nD = Nothing
        nD = New DataSet
        Dim Da As New SqlDataAdapter(Sql, nC)
        Da.Fill(nD, "nA")
        For nI = 0 To nD.Tables("nA").Columns.Count - 1
            Dim nCol As New BoundField
            nCol.DataField = nD.Tables("nA").Columns(nI).ColumnName
            nCol.HeaderText = nD.Tables("nA").Columns(nI).ColumnName
            For Each nS In Esconder
                If nCol.HeaderText = nS Then
                    nCol.HeaderStyle.CssClass = "hideGridColumn"
                    nCol.ItemStyle.CssClass = "hideGridColumn"
                End If
            Next
            GR.Columns.Add(nCol)
        Next
        GR.DataSource = nD
        GR.DataBind()
        nC = Nothing
        Da = Nothing
        nD = Nothing
    End Sub

    Public Sub añade(ByVal MCI As MenuItem, ByVal DT As DataSet)
        Dim a As Integer
        Dim Codigo, Semana, Padre As String
        For a = 0 To DT.Tables("#TEMPTV").Rows.Count - 1
            Dim child As New MenuItem
            Codigo = Trim(DT.Tables("#TEMPTV").Rows(a).Item("CODIGO"))
            Semana = Trim(DT.Tables("#TEMPTV").Rows(a).Item("SEMANA"))
            Padre = Trim(DT.Tables("#TEMPTV").Rows(a).Item("PADRE"))
            If Padre = MCI.Value Then
                child.Text = Trim(DT.Tables("#TEMPTV").Rows(a).Item("FECHA"))
                MCI.ChildItems.Add(child)
            End If
        Next
    End Sub

    Public Sub RecordsetData(ByRef SQL As String)
        Dim nC = New SqlConnection(ConfigurationManager.ConnectionStrings("EASYIDB").ConnectionString)
        'Dim nI As Integer
        nD = Nothing
        nD = New DataSet
        Dim Da As New SqlDataAdapter(SQL, nC)
        Da.Fill(nD, "nA")
        'nC = Nothing
        'Da = Nothing
        'For nI = 0 To nD.Tables("nA").Columns.Count - 1
        '    nA(nI) = nD.Tables("nA").Rows(0)(nI)
        'Next
    End Sub

    Public Function btAleatorioDistinto() As String
        Dim numAleatorio As New Random(CInt(Date.Now.Ticks And Integer.MaxValue))
        Return CStr(numAleatorio.Next)
    End Function

    Public Function CodigoLinea(longitud As Integer) As String
        Dim caracteres As String = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"
        Dim res As New StringBuilder()
        Dim rnd As New Random()
        While 0 < System.Math.Max(System.Threading.Interlocked.Decrement(longitud), longitud + 1)
            res.Append(caracteres(rnd.[Next](caracteres.Length)))
        End While
        Return res.ToString()
    End Function

    Public Function EmailText(ByVal TextoHTML As String) As String
        Dim nX As String
        nX = "<!DOCTYPE HTML>" & vbNewLine _
        & "<html>" & vbNewLine _
        & "<head> " & vbNewLine _
        & "<meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"">" & vbNewLine _
        & "<title></title>" & vbNewLine _
        & "<style type=""text/css"">" & vbNewLine _
        & "body {" & vbNewLine _
        & "	font: 100%/1.4 Arial, Helvetica, sans-serif;" & vbNewLine _
        & "	background: #fff;" & vbNewLine _
        & "	margin: 0;" & vbNewLine _
        & "	padding: 0;" & vbNewLine _
        & "	color: #000;" & vbNewLine _
        & "}" & vbNewLine _
        & "a.TopMenu {" & vbNewLine _
        & "	font-family: Arial;  " & vbNewLine _
        & "	font-size: 12px; " & vbNewLine _
        & "	font-weight:bold;" & vbNewLine _
        & "	text-decoration:underline;" & vbNewLine _
        & "    text-align:center;" & vbNewLine _
        & "    color:white;" & vbNewLine _
        & "    padding-top:13px;" & vbNewLine _
        & "    padding-bottom:13px;" & vbNewLine _
        & "    padding-left:5px;" & vbNewLine _
        & "    padding-right:5px;" & vbNewLine _
        & "    margin-left:10px;" & vbNewLine _
        & "    margin-right:10px;" & vbNewLine _
        & "    background: #93cede; /* Old browsers */" & vbNewLine _
        & "    /* IE9 SVG, needs conditional override of 'filter' to 'none' */" & vbNewLine _
        & "    background: url(data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiA/Pgo8c3ZnIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDEgMSIgcHJlc2VydmVBc3BlY3RSYXRpbz0ibm9uZSI+CiAgPGxpbmVhckdyYWRpZW50IGlkPSJncmFkLXVjZ2ctZ2VuZXJhdGVkIiBncmFkaWVudFVuaXRzPSJ1c2VyU3BhY2VPblVzZSIgeDE9IjAlIiB5MT0iMCUiIHgyPSIwJSIgeTI9IjEwMCUiPgogICAgPHN0b3Agb2Zmc2V0PSIwJSIgc3RvcC1jb2xvcj0iIzkzY2VkZSIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjQxJSIgc3RvcC1jb2xvcj0iIzc1YmRkMSIgc3RvcC1vcGFjaXR5PSIxIi8+CiAgICA8c3RvcCBvZmZzZXQ9IjEwMCUiIHN0b3AtY29sb3I9IiM0OWE1YmYiIHN0b3Atb3BhY2l0eT0iMSIvPgogIDwvbGluZWFyR3JhZGllbnQ+CiAgPHJlY3QgeD0iMCIgeT0iMCIgd2lkdGg9IjEiIGhlaWdodD0iMSIgZmlsbD0idXJsKCNncmFkLXVjZ2ctZ2VuZXJhdGVkKSIgLz4KPC9zdmc+);" & vbNewLine _
        & "    background: -moz-linear-gradient(top,  #93cede 0%, #75bdd1 41%, #49a5bf 100%); /* FF3.6+ */" & vbNewLine _
        & "    background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,#93cede), color-stop(41%,#75bdd1), color-stop(100%,#49a5bf)); /* Chrome,Safari4+ */" & vbNewLine _
        & "    background: -webkit-linear-gradient(top,  #93cede 0%,#75bdd1 41%,#49a5bf 100%); /* Chrome10+,Safari5.1+ */" & vbNewLine _
        & "    background: -o-linear-gradient(top,  #93cede 0%,#75bdd1 41%,#49a5bf 100%); /* Opera 11.10+ */" & vbNewLine _
        & "    background: -ms-linear-gradient(top,  #93cede 0%,#75bdd1 41%,#49a5bf 100%); /* IE10+ */" & vbNewLine _
        & "    background: linear-gradient(to bottom,  #93cede 0%,#75bdd1 41%,#49a5bf 100%); /* W3C */" & vbNewLine _
        & "    filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#93cede', endColorstr='#49a5bf',GradientType=0 ); /* IE6-8 */" & vbNewLine _
        & "    border-radius:5px;" & vbNewLine _
        & "    -moz-border-radius:5px;" & vbNewLine _
        & "    box-shadow:5px 5px 5px gray;" & vbNewLine _
        & "    float:left;" & vbNewLine _
        & "    width:20%;" & vbNewLine _
        & "}" & vbNewLine _
        & "ul, ol, dl {" & vbNewLine _
        & "	padding: 0;" & vbNewLine _
        & "	margin: 0;" & vbNewLine _
        & "}" & vbNewLine _
        & "h1{" & vbNewLine _
        & "    color:#4BC3D1;" & vbNewLine _
        & "	text-shadow:2px 2px 1px gray;" & vbNewLine _
        & "	margin-top: 0;" & vbNewLine _
        & "	padding-right: 15px;" & vbNewLine _
        & "	padding-left: 15px;" & vbNewLine _
        & "}" & vbNewLine _
        & "h2, h3, h4, h5, h6, p {" & vbNewLine _
        & "    color:#B3B8BB;" & vbNewLine _
        & "	text-shadow:1px 1px 1px gray;" & vbNewLine _
        & "	margin-top: 0;" & vbNewLine _
        & "	padding-right: 15px;" & vbNewLine _
        & "	padding-left: 15px;" & vbNewLine _
        & "}" & vbNewLine _
        & "a img { " & vbNewLine _
        & "	border: none;" & vbNewLine _
        & "}" & vbNewLine _
        & "a:link {" & vbNewLine _
        & "	color: #42413C;" & vbNewLine _
        & "	text-decoration: underline; " & vbNewLine _
        & "}" & vbNewLine _
        & "a:visited {" & vbNewLine _
        & "	color: #6E6C64;" & vbNewLine _
        & "	text-decoration: underline;" & vbNewLine _
        & "}" & vbNewLine _
        & "a:hover, a:active, a:focus { " & vbNewLine _
        & "	text-decoration: none;" & vbNewLine _
        & "}" & vbNewLine _
        & ".container {" & vbNewLine _
        & "	width: 100%;" & vbNewLine _
        & "	background: #FFF;" & vbNewLine _
        & "	margin: 0 auto; " & vbNewLine _
        & "}" & vbNewLine _
        & ".content {" & vbNewLine _
        & "	padding: 10px 0;" & vbNewLine _
        & "}" & vbNewLine _
        & ".fltrt {  " & vbNewLine _
        & "	float: right;" & vbNewLine _
        & "	margin-left: 8px;" & vbNewLine _
        & "}" & vbNewLine _
        & ".fltlft { " & vbNewLine _
        & "	float: left;" & vbNewLine _
        & "	margin-right: 8px;" & vbNewLine _
        & "}" & vbNewLine _
        & ".clearfloat { " & vbNewLine _
        & "	clear:both;" & vbNewLine _
        & "	height:0;" & vbNewLine _
        & "	font-size: 1px;" & vbNewLine _
        & "	line-height: 0px;" & vbNewLine _
        & "}" & vbNewLine _
        & "</style></head>" & vbNewLine _
        & "<body>" & vbNewLine _
        & "<div class=""container"">" & vbNewLine _
        & "  <div class=""content"">" & vbNewLine _
        & TextoHTML & vbNewLine _
        & "    <!-- end .content --></div>" & vbNewLine _
        & "  <!-- end .container --></div>" & vbNewLine _
        & "</body>" & vbNewLine _
        & "</html>"

        Return nX
    End Function

    Public Sub Notifica(ByVal Texto As String, ByVal Siguiente As String)
        HttpContext.Current.Session.Remove("NTX")
        HttpContext.Current.Session.Remove("NNX")
        HttpContext.Current.Session.Add("NTX", Texto)
        HttpContext.Current.Session.Add("NNX", Siguiente)
        HttpContext.Current.Response.Redirect("Notificacion.aspx")
    End Sub

    Public Function XmlSolicitudPedido(ByRef _pedidos As List(Of Pedido), ByRef parametros() As String) As String
        Dim sbuider = New StringBuilder()
        Dim swriter = New StringWriter(sbuider)
        Dim IdInternoPedido As String = parametros(0)
        Dim FechaSolicitud As String = parametros(1)
        Dim FechaDespacho As String = parametros(2)
        Dim CodigoCliente As String = parametros(3)
        Dim NombreCliente As String = parametros(4)
        Dim SerieSolicitud As String = parametros(5)
        Dim NumeroSolicitud As String = parametros(6)
        Dim VendedorAsignado As String = parametros(7)
        Dim UsuarioCreador As String = parametros(8)
        Dim CodigoUsuarioCreador As String = parametros(9)

        Dim xws As XmlWriterSettings = New XmlWriterSettings()
        xws.Indent = True
        xws.NewLineOnAttributes = False
        xws.Encoding = Encoding.UTF8
        xws.OmitXmlDeclaration = True
        Dim xw As XmlWriter = XmlWriter.Create(swriter, xws)
        xw.WriteStartDocument() '0
        xw.WriteStartElement("ENVIOS") '1
        xw.WriteStartElement("Envio") '2
        xw.WriteAttributeString("DocDate", FechaSolicitud)
        xw.WriteAttributeString("DocDueDate", FechaDespacho)
        xw.WriteAttributeString("CardCode", CodigoCliente)
        xw.WriteAttributeString("CardName", NombreCliente)
        xw.WriteAttributeString("NumAtCard", (SerieSolicitud + "-" + NumeroSolicitud))
        xw.WriteAttributeString("SlpCode", VendedorAsignado)
        xw.WriteAttributeString("Series", "1")
        xw.WriteAttributeString("U_web_serie", SerieSolicitud)
        xw.WriteAttributeString("U_web_numero", NumeroSolicitud)
        xw.WriteAttributeString("U_web_codigousuario", CodigoUsuarioCreador)
        xw.WriteAttributeString("U_web_nombreusuario", UsuarioCreador)
        For i As Int32 = 0 To _pedidos.Count - 1
            xw.WriteStartElement("Detalle") '3
            xw.WriteAttributeString("ItemCode", _pedidos.Item(i).Codigo.ToString())
            xw.WriteAttributeString("Dscription", _pedidos.Item(i).Descripcion.ToString())
            xw.WriteAttributeString("Quantity", _pedidos.Item(i).Cantidad.ToString())
            xw.WriteAttributeString("WhsCode", _pedidos.Item(i).Almacen.ToString())
            xw.WriteAttributeString("U_Record", _pedidos.Item(i).Record.ToString())
            xw.WriteEndElement()  '3
        Next
        xw.WriteEndElement()  '2
        xw.WriteEndElement()  '1
        xw.WriteEndDocument() '0
        xw.Flush()
        xw.Close()

        Return swriter.ToString()
    End Function

End Module