Public Class Inicio
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack Then
            Exit Sub
        End If
        'AbrirRecordsetData("EXEC PRG_KPI_DASHBOARD_NOMINA 1,'" & Session("BD_NOMINA") & "'")
        'LBLEMPLEADOSACTIVOS.Text = nA(0).ToString
        'AbrirRecordsetData("EXEC PRG_KPI_DASHBOARD_NOMINA 2,'" & Session("BD_NOMINA") & "'")
        'LBLEMPLEADOSSUSPENDIDOS.Text = nA(0).ToString
        'AbrirRecordsetData("EXEC PRG_KPI_DASHBOARD_NOMINA 3,'" & Session("BD_NOMINA") & "'")
        'LBLCUMPLEAÑEROMES.Text = nA(0).ToString
        'AbrirRecordsetData("EXEC PRG_KPI_DASHBOARD_NOMINA 4,'" & Session("BD_NOMINA") & "'")
        'LBLCUMPLEAÑERODIA.Text = nA(0).ToString
    End Sub

End Class