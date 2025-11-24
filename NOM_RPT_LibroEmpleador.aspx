<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MP01.Master" CodeBehind="NOM_RPT_LibroEmpleador.aspx.vb" Inherits="EasySapWeb.NOM_RPT_LibroEmpleador" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
<%-- MANEJO DE GRID ESPECIFICO--%>
    <asp:Panel runat="server" ID="PNAUSENCIASESPECIFICAS">
        <div class="container-fluid mt-4">
            <div class="align-content-center text-center mb-2 mt-4">
                <h1 class="h3 mb-0 text-gray-800">REPORTE DEL EMPLEADOR</h1>
            </div>
                <hr class="sidebar-divider d-none d-md-block text-dark">
            <div class="row mt-2 mb-2">
                <div class="col-md-6">
                    <asp:LinkButton runat="server" ID="BTNGENERARPTEMPLEADOR" CssClass="btn btn-danger btn-user">Genera Reporte de Empleador</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="BTNDESCARRPTEMPAEXCEL" CssClass="btn btn-success btn-user"><i class="fa fa-arrow-left"></i> Excel</asp:LinkButton>
                </div>
            </div>
            <div class="container-fluid table-responsive-lg table-responsive-md table-responsive-sm overflow-auto">
                <asp:GridView 
                    ID="GVRPTEMPLEADOR" 
                    runat="server" 
                    AllowSorting="true" 
                    AllowPaging ="true"
                    AutoGenerateColumns="False"
                    PageSize="5">
                    <PagerStyle HorizontalAlign = "Left" CssClass = "GridPager" />      
                </asp:GridView>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
