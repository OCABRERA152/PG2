<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MP01.Master" CodeBehind="NOM_Nomina.aspx.vb" Inherits="EasySapWeb.NOM_Nomina" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
   <asp:UpdatePanel ID="UP0" runat="server" >
    <ContentTemplate>
<!-- INICIA MANEJO DE GRID NÓMINA ENCABEZADO-->
        <div runat="server" id="DIVALERTAPRINCIPAL" class="alert alert-warning alert-dismissible fade hide mt-4" role="alert">
            <asp:Literal runat="server" ID="LTALERTAPRINCIPAL"></asp:Literal>
            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                <span aria-hidden="true">&times;</span>
        </button>
        </div>
        <asp:Panel runat="server" id="PNGRIDNOMINAS">
            <div class="container-fluid">
                <div class="align-content-center text-center mb-2 mt-4">
                    <h1 class="h3 mb-0 text-gray-800">ESTATUS DE NÓMINAS</h1>
                </div>
                <hr class="sidebar-divider d-none d-md-block text-dark">
            </div>
            <div class="container-fluid table-responsive-lg table-responsive-md table-responsive-sm">
            <div class="row mt-2 mb-2">
                <div class="col-md-6">
                    <label class="font-weight-bold">Buscar nómina</label>
                    <asp:TextBox runat="server" ID="TXTBUSCARNOMINA" CssClass="form-control form-control border-warning" ToolTip="Dejé el cmapo en blanco par ver a todos los registros" AutoPostBack="true" placeholder="Ingrese mes-año de nómina" required="required"></asp:TextBox>
                </div>
            </div>
                <asp:GridView 
                    ID="GVENCABEZADONOMINA" 
                    runat="server" 
                    AllowSorting="true" 
                    AllowPaging ="true"
                    AutoGenerateColumns="False"
                    PageSize="10">
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />      
                </asp:GridView>
            </div>
            <!-- Button to Open the collapse -->
            <div class="container-fluid m-2">
                <asp:LinkButton runat="server" ID="BTNAGREGARNOMINA" CssClass="btn btn-warning btn-user" >
                    <i class="fa fa-plus-circle"></i> Agregar nueva nómina</asp:LinkButton>
            </div>           
        </asp:Panel>
        <asp:Panel runat="server" ID="PNFRMNOMINA" Visible="false">
                        <div class="container-fluid">
                <div class="align-content-center text-center mb-2 mt-4">
                    <h1 class="h3 mb-0 text-gray-800">AGREGAR NÓMINA<h1>
                </div>
                <hr class="sidebar-divider d-none d-md-block text-dark">
            </div>
          <div class="container">
                  <form>
                    <div class="form-group">
                        <label for="DDLMESNOMINA">Mes:</label>
                        <asp:DropDownList runat="server" ID="DDLMESNOMINA" CssClass="form-control" name="DDLMESNOMINA"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="TXTFECHANOMINA">Fecha de nómina:</label>
                        <asp:TextBox runat="server" ID="TXTFECHANOMINA" CssClass="form-control" TextMode="Date" name="TXTFECHANOMINA"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="DDLTIPODENOMINA">Tipo de Nómina</label>
                        <asp:DropDownList runat="server" ID="DDLTIPODENOMINA" CssClass="form-control" name="DDLTIPODENOMINA"></asp:DropDownList>
                    </div>
                    </form>
                <!-- Botones -->
                <div class="container">
                    <asp:LinkButton runat="server" ID="BTNCANCELARNOMINA" CssClass="btn btn-danger btn-user"><i class="fa fa-arrow-left"></i> Cancelar</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="BTNGUARDARNOMINA" CssClass="btn btn-warning btn-user">Agregar nómina <i class="fa fa-user-plus"></i></asp:LinkButton>
                </div>
        
              </div>
        </asp:Panel> 
        <%--PANEL PARA GENERAR, GUARDAR y CERRAR NOMINA--%>
        <asp:Panel runat="server" ID="PNGGC" Visible="false">
            <asp:HiddenField runat="server" ID="HFESTATUSNOMINA" />
            <asp:HiddenField runat="server" ID="HFCODIGONOMINA" />
            <asp:HiddenField runat="server" ID="HFNOLINEANOMINAD" />
            <asp:HiddenField runat="server" ID="HFTIPODENOMINA" />
            <div class="container-fluid">
                <div class="align-content-center text-center mb-2 mt-4">
                    <h1 class="h3 mb-0 text-gray-800">GESTIÓN DE NÓMINA</h1>
                </div>
                <hr class="sidebar-divider d-none d-md-block text-dark">
            </div>
            <div class="container-fluid mt-2 mb-2">
                <asp:LinkButton runat="server" ID="BTNREGRESARESTATUSNOM" CssClass="btn btn-danger btn-user" >
                <i class="fa fa-arrow-left"></i> Regresar</asp:LinkButton>
                <asp:LinkButton runat="server" ID="BTNGNERARNOMINA" CssClass="btn btn-info btn-user" >
                <i class="fa fa-spinner"></i> Generar</asp:LinkButton>
                <asp:LinkButton runat="server" ID="BTNCREARNOMINA" CssClass="btn btn-success btn-user" >
                <i class="fa fa-hdd"></i> Guardar</asp:LinkButton>
                <asp:LinkButton runat="server" ID="BTNCERRARNOMINA" CssClass="btn btn-success btn-user" >
                <i class="fa fa-lock"></i> Cerrar</asp:LinkButton>
            </div>  
            <div class="container-fluid table-responsive-lg table-responsive-md table-responsive-sm overflow-auto ">
                <asp:GridView 
                    ID="GVNOMINAGENERADA" 
                    runat="server" 
                    AllowSorting="true" 
                    AllowPaging ="true"
                    AutoGenerateColumns="False"
                    PageSize="5">
                    <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />      
                </asp:GridView>
            </div>
              <!-- The Modal -->
              <div class="modal fade" id="myModal" runat="server">
                <div class="modal-dialog modal-dialog-centered">
                  <div class="modal-content">
      
                    <!-- Modal Header -->
                    <div class="modal-header">
                      <h4 class="modal-title">No. de Documento de pago</h4>
                      <%--<button type="button" class="close" data-dismiss="modal" runat="server" id="BTNCLOSETEXTDOCTO">&times;</button>--%>
                      <asp:LinkButton CssClass="close" data-dismiss="modal" runat="server" id="BTNCLOSETEXTDOCTO">&times;</asp:LinkButton>
                    </div>
        
                    <!-- Modal body -->
                    <div class="modal-body">
                      <div class="container">
                          <asp:TextBox runat="server" ID="TXTNODOCTOPAGO" CssClass="form-control"></asp:TextBox>
                      </div>
                    </div>
        
                    <!-- Modal footer -->
                    <div class="modal-footer">
                      <asp:LinkButton runat="server" ID="BTNGUARDARNODOCTO" CssClass="btn btn-secondary">Guardar</asp:LinkButton>
                    </div>
        
                  </div>
                </div>
              </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>