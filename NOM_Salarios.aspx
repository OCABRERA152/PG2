<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MP01.Master" CodeBehind="NOM_Salarios.aspx.vb" Inherits="EasySapWeb.NOM_Salarios" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
   <asp:UpdatePanel ID="UP0" runat="server" >
    <ContentTemplate>
        <!-- INICIA MANEJO DE GRID GENERAL-->
        <asp:Panel runat="server" id="PNGRIDSALARIOS">
            <div class="container-fluid">
                <div class="align-content-center text-center mb-2 mt-4">
                    <h1 class="h3 mb-0 text-gray-800">GESTIÓN DE SALARIOS</h1>
                </div>
                <hr class="sidebar-divider d-none d-md-block text-dark">
            </div>
            <div class="container-fluid table-responsive-lg table-responsive-md table-responsive-sm">
            <div class="row mt-2 mb-2">
                <div class="col-md-6">
                    <label class="font-weight-bold">Buscar empleado</label>
                    <asp:TextBox runat="server" ID="TXTBUSCAREMPLEADO" CssClass="form-control form-control border-warning" ToolTip="Dejé el cmapo en blanco par ver a todos los empleados" AutoPostBack="true" placeholder="Ingrese nombre de empleado" required="required"></asp:TextBox>
                </div>
            </div>
                <asp:GridView 
                    ID="GVSALARIOS" 
                    runat="server" 
                    AllowSorting="true" 
                    AllowPaging ="true"
                    AutoGenerateColumns="False"
                    PageSize="10">
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />      
                </asp:GridView>
            </div>
        </asp:Panel>
        <%--FORMULARIO PARA GESTIÓN DE SALARIOS--%>
        <asp:Panel runat="server" id="PNFORMULARIOSALARIOS" Visible="false">
        <asp:HiddenField runat="server" ID="HFLINEASALARIO" />
        <asp:HiddenField runat="server" ID="HFIDEMPLEADO" />
        <div class="container">
                <%--datos generales--%>
                <div class="container p-3 mt-4 card"> 
                    <div class="card-header">SALARIO</div>
                    <div class="card-body">
                        <form>
                        <div class="row">
                            <div class="col-md-3">
                                <label>Código de empleado</label>
                                <asp:TextBox runat="server" ID="TXTCODIGOEMPLEADO" CssClass="form-control form-control" placeholder="Código de empleado"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label>Nombre de empleado</label>
                                <asp:TextBox runat="server" ID="TXTEMPLEADO" CssClass="form-control form-control" placeholder="Nombre de empleado"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <label>Código de Contrato</label>
                                <asp:TextBox runat="server" ID="TXTCODIGODECONTRATO" CssClass="form-control form-control" placeholder="Código de contrato"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                 <label>Salario mensual</label>
                                <asp:TextBox runat="server" ID="TXTSALARIOMENSUAL" CssClass="form-control form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                 <label>Bonificación de Ley</label>
                                <asp:TextBox runat="server" ID="TXTBONIFICACION" CssClass="form-control form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                 <label>Fecha de aplicación</label>
                                <asp:TextBox runat="server" ID="TXTFECHAAPLICA" CssClass="form-control form-control" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                        <%--botones--%>
                        <div class="row mt-4">
                            <div class="col-md-6">
                                <asp:LinkButton runat="server" ID="BTNACTUALIZASALARIO" CssClass="btn btn-warning btn-user btn-block">
                                    <i class="fa fa-refresh fa-fw"></i> Actualizar
                                </asp:LinkButton>
                            </div>
                            <div class="col-md-6">
                                <asp:LinkButton runat="server" ID="BTNCANCELARSALARIO" CssClass="btn btn-danger btn-user btn-block">
                                    <i class="fa fa-ban fa-fw"></i> Cancelar
                                </asp:LinkButton>
                            </div>
                        </div>
                        </form>
                    </div>
                </div>
          </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>

