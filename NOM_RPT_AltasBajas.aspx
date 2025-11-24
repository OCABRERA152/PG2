<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MP01.Master" CodeBehind="NOM_RPT_AltasBajas.aspx.vb" Inherits="EasySapWeb.NOM_RPT_AltasBajas" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
<%-- MANEJO DE GRID ESPECIFICO--%>
    <asp:Panel runat="server" ID="PNAUSENCIASESPECIFICAS">
        <asp:HiddenField runat="server" ID="HFFECHAINI" />
        <asp:HiddenField runat="server" ID="HFFECHAFIN" />
        <div class="container-fluid mt-4">
            <div class="align-content-center text-center mb-2 mt-4">
                <h1 class="h3 mb-0 text-gray-800">REPORTE DEL ALTAS Y BAJAS</h1>
            </div>
            <hr class="sidebar-divider d-none d-md-block text-dark">
            <asp:Panel runat="server" ID="PNPARAMETROS">
            <div class="container">
                <%--datos generales--%>
                <div class="container p-3 mt-4 card"> 
                    <div class="card-header">Parametros:</div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-4">
                                <label>Fecha Inicio</label>
                                <asp:TextBox runat="server" ID="TXTFECHAINI" CssClass="form-control form-control" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label>Fecha Fin</label>
                                <asp:TextBox runat="server" ID="TXTFECHAFIN" CssClass="form-control form-control" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mt-2 mb-2">
                            <div class="col-md-6">
                                <asp:LinkButton runat="server" ID="BTNGENERARPTALTASBAJAS" CssClass="btn btn-danger btn-user">Genera Reporte de Altas y Bajas</asp:LinkButton>
                                <asp:LinkButton runat="server" ID="BTNDESCARRPTALTASBAJASEXCEL" CssClass="btn btn-success btn-user"><i class="fa fa-arrow-left"></i> Excel</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </asp:Panel>
            <div class="container-fluid table-responsive-lg table-responsive-md table-responsive-sm overflow-auto mt-2">
                <asp:GridView 
                    ID="GVRPTALTASYBAJAS" 
                    runat="server" 
                    AllowSorting="true" 
                    AllowPaging ="true"
                    AutoGenerateColumns="False"
                    PageSize="10">
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />      
                </asp:GridView>
            </div>
        </div>
    </asp:Panel>
</asp:Content>