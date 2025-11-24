<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MP01.Master" CodeBehind="NOM_HorasExtra.aspx.vb" Inherits="EasySapWeb.NOM_HorasExtra" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
   <asp:UpdatePanel ID="UP0" runat="server" >
    <ContentTemplate>
        <!-- INICIA MANEJO DE GRID GENERAL-->
        <asp:Panel runat="server" id="PNGRIDHE">
            <div class="container-fluid">
                <div class="align-content-center text-center mb-2 mt-4">
                    <h1 class="h3 mb-0 text-gray-800">GESTIÓN DE HORAS EXTRA</h1>
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
                    ID="GVHEGENERALES" 
                    runat="server" 
                    AllowSorting="true" 
                    AllowPaging ="true"
                    AutoGenerateColumns="False"
                    PageSize="10">
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />      
                </asp:GridView>
            </div>
        </asp:Panel>
        <%-- MANEJO DE GRID ESPECIFICO--%>
        <asp:Panel runat="server" ID="PNHEESPECIFICA" Visible="false">
            <div class="container-fluid mt-4">
                <div class="align-content-center text-center mb-2 mt-4">
                    <h1 class="h3 mb-0 text-gray-800">HORAS EXTRA ESPECIFICAS</h1>
                </div>
                 <hr class="sidebar-divider d-none d-md-block text-dark">
                <div class="container-fluid m-2">
                    <h5>EMPLEADO: <asp:Label runat="server" ID="LBLEMPLEADOHE"></asp:Label></h5>
                </div>
                <div class="container-fluid table-responsive-lg table-responsive-md table-responsive-sm">
                    <asp:GridView 
                        ID="GVDETALLEHE" 
                        runat="server" 
                        AllowSorting="true" 
                        AllowPaging ="true"
                        AutoGenerateColumns="False"
                        PageSize="10">
                        <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />      
                    </asp:GridView>
                </div>
                <div class="container-fluid m-2">
                    <asp:LinkButton runat="server" ID="BTNREGRESARGENERAL" CssClass="btn btn-danger btn-user"><i class="fa fa-arrow-left"></i> Regresa</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="BTNAGREGARHE" CssClass="btn btn-warning btn-user">Agregar Hora Extra <i class="fa fa-user-plus"></i></asp:LinkButton>
                </div>
            </div>
        </asp:Panel>
        <%--FORMULARIO PARA GESTIÓN DE AUSENCIAS--%>
        <asp:Panel runat="server" id="PNFORMULARIOHE" Visible="false">
        <asp:HiddenField runat="server" ID="HFLINEAHE" />
        <asp:HiddenField runat="server" ID="HFNOMBREEMPLEADO" />
        <asp:HiddenField runat="server" ID="HFIDEMPLEADO" />
        <div class="container">
                <%--datos generales--%>
                <div class="container p-3 mt-4 card"> 
                    <div class="card-header">HORA EXTRA</div>
                    <div class="card-body">
                        <form>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Código de empleado</label>
                                <asp:TextBox runat="server" ID="TXTCODIGOEMPLEADOHE" CssClass="form-control form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-8">
                                <label>Nombre de empleado</label>
                                <asp:TextBox runat="server" ID="TXTNOMBREEMPLEADOHE" CssClass="form-control form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                 <label>Cantidad de horas</label>
                                <asp:TextBox runat="server" ID="TXTCANTIDADHORAS" CssClass="form-control form-control" TextMode="Number"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                 <label>Fecha de ejecución</label>
                                <asp:TextBox runat="server" ID="TXTFECHAEJECUCION" CssClass="form-control form-control" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                        <%--botones--%>
                        <div class="row mt-4">
                            <div class="col-md-6">
                                <asp:LinkButton runat="server" ID="BTNGUARDARHE" CssClass="btn btn-success btn-user btn-block" Visible="false">
                                    <i class="fa fa-check fa-fw"></i> Guardar
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" ID="BTNACTUALIZARHE" CssClass="btn btn-warning btn-user btn-block" Visible="false">
                                    <i class="fa fa-refresh fa-fw"></i> Actualizar
                                </asp:LinkButton>
                            </div>
                            <div class="col-md-6">
                                <asp:LinkButton runat="server" ID="BTNCANCELARHE" CssClass="btn btn-danger btn-user btn-block">
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