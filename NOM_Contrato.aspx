<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MP01.Master" CodeBehind="NOM_Contrato.aspx.vb" Inherits="EasySapWeb.NOM_Contrato" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <asp:UpdatePanel ID="UP0" runat="server" >
    <ContentTemplate>
        <asp:Panel runat="server" id="PNFORMULARIOEMPLEADO" Visible="false">
        <asp:HiddenField runat="server" ID="HFIDEMPLEADO" />
        <asp:HiddenField runat="server" ID="HFIDCONTRATO" />
        <div class="container">
                <%--datos generales--%>
                <div class="container p-3 mt-4 card"> 
                    <div class="card-header">CONTRATO</div>
                    <div class="card-body">
                        <form>
                        <div class="row">
                            <div class="col-md-4">
                                <label>No. de contrato</label>
                                <asp:TextBox runat="server" ID="TXTNOCONTRATO" CssClass="form-control form-group" placeholder="no. contrato"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label>Fecha de inicio</label>
                                <asp:TextBox runat="server" ID="TXTFECHAINICIO" CssClass="form-control form-group" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label>Fecha de finalización</label>
                                <asp:TextBox runat="server" ID="TXTFECHAFIN" CssClass="form-control form-group" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Poliza de seguro</label>
                                <asp:TextBox runat="server" ID="TXTPOLIZAS" CssClass="form-control form-control" placeholder="No. Poliza de seguro" required="required"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label>Certificado de Seguro</label>
                                <asp:TextBox runat="server" ID="TXTCETIFICADOS" CssClass="form-control form-control" placeholder="No. Certificado de seguro" required="required"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Tipo de Contrato</label>
                                <asp:DropDownList runat="server" ID="DDLTIPODECONTRATO" CssClass="form-control form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <label>Temporalidad</label>
                                <asp:DropDownList runat="server" ID="DDLTEMPORALIDADC" CssClass="form-control form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Jornada</label>
                                <asp:DropDownList runat="server" ID="DDLJORNADAC" CssClass="form-control form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <label>Asunto de finalización</label>
                                <asp:DropDownList runat="server" ID="DDLTIPOFINCONTRATO" CssClass="form-control form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Estado de Contrato</label>
                                <asp:DropDownList runat="server" ID="DDLESTADO" CssClass="form-control form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <label>Empleado asociado</label>
                                <asp:DropDownList runat="server" ID="DDLLISTAEMPLEADO" CssClass="form-control form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <%--botones--%>
                        <div class="row mt-4">
                            <div class="col-md-6">
                                <asp:LinkButton runat="server" ID="BTNGUARDARCONTRATO" CssClass="btn btn-success btn-user btn-block" Visible="false">
                                    <i class="fa fa-check fa-fw"></i> Guardar
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" ID="BTNACTUALIZARCONTRATO" CssClass="btn btn-warning btn-user btn-block" Visible="false">
                                    <i class="fa fa-refresh fa-fw"></i> Actualizar
                                </asp:LinkButton>
                            </div>
                            <div class="col-md-6">
                                <asp:LinkButton runat="server" ID="BTNCANCELARCONTRATO" CssClass="btn btn-danger btn-user btn-block">
                                    <i class="fa fa-ban fa-fw"></i> Cancelar
                                </asp:LinkButton>
                            </div>
                        </div>
                        </form>
                    </div>
                </div>
          </div>
        </asp:Panel>

        <!-- Divider -->
        <asp:Panel runat="server" id="PNGRIDEMPLEADOS">
        <div class="container-fluid">
            <div class="align-content-center text-center mb-2 mt-4">
                <h1 class="h3 mb-0 text-gray-800">GESTIÓN DE CONTRATOS</h1>
            </div>
            <hr class="sidebar-divider d-none d-md-block text-dark">
            <div class="container-fluid m-2">
                <asp:LinkButton runat="server" ID="BTNAGREGARNUEVOCONTRATO" CssClass="btn btn-warning btn-user">Agregar nuevo contrato <i class="fa fa-user-plus"></i></asp:LinkButton>
            </div>
        </div>
        <div class="container-fluid table-responsive-lg table-responsive-md table-responsive-sm">
            <div class="row mt-2 mb-2">
                <div class="col-md-6">
                    <label class="font-weight-bold">Buscar empleado</label>
                    <asp:TextBox runat="server" ID="TXTBUSCAREMPLEADO" CssClass="form-control form-control border-warning" ToolTip="Dejé el cmapo en blanco par ver a todos los empleados" AutoPostBack="true" placeholder="Ingrese nombre de empleado" required="required"></asp:TextBox>
                </div>
            </div>
            <asp:GridView 
                ID="GVCONTRATO" 
                runat="server" 
                AllowSorting="true" 
                AllowPaging ="true"
                AutoGenerateColumns="False"
                PageSize="10">
                <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" />      
            </asp:GridView>
        </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
