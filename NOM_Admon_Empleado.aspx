<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MP01.Master" CodeBehind="NOM_Admon_Empleado.aspx.vb" Inherits="EasySapWeb.Admon_Empleado" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <asp:UpdatePanel ID="UP0" runat="server" >
    <ContentTemplate>
        <asp:Panel runat="server" id="PNFORMULARIOEMPLEADO" Visible="false">
        <asp:HiddenField runat="server" ID="HFIDEMPLEADO" />
        <div class="container">
            <form>
                <%--datos generales--%>
                <div class="container p-3 mt-4 card"> 
                    <div class="card-header">Datos Generales</div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-4">
                                    <label>Primer nombre</label>
                                    <asp:TextBox runat="server" ID="TXTPNOMBRE" CssClass="form-control form-group" placeholder="Primer nombre"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label>Segundo nombre</label>
                                    <asp:TextBox runat="server" ID="TXTSNOMBRE" CssClass="form-control form-group" placeholder="Segundo nombre"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label>Tercer nombre (Opcional)</label>
                                    <asp:TextBox runat="server" ID="TXTTNOMBRE" CssClass="form-control form-group" placeholder="Tercer nombre"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <label>Primer apellido</label>
                                    <asp:TextBox runat="server" ID="TXTPAPELLIDO" CssClass="form-control form-control" placeholder="Primer apellido"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label>Segundo apellido</label>
                                    <asp:TextBox runat="server" ID="TXTSAPELLIDO" CssClass="form-control form-control" placeholder="Segundo apellido"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label>Tercer apellido (Opcional)</label>
                                    <asp:TextBox runat="server" ID="TXTTAPELLIDO" CssClass="form-control form-control" placeholder="Tercero apellido"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <label>Sexo</label>
                                    <asp:DropDownList runat="server" ID="DDLSEXO" CssClass="form-control form-control"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label>Estado Civil</label>
                                    <asp:DropDownList runat="server" ID="DDLESTADOCIVIL" CssClass="form-control form-control"></asp:DropDownList>
                                </div>
                                <div class="col-md-4">
                                    <label>Cant. de Hijos</label>
                                    <asp:TextBox runat="server" ID="TXTCANTHIJOS" CssClass="form-control form-group" TextMode="Number" ></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <label>¿Tiene alguna discapacidad?</label>
                                    <asp:DropDownList runat="server" ID="DDLDISCAPACIDAD" CssClass="form-control form-group"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                </div>

                 <%--datos de identificación--%>
                <div class="container p-3 mt-4 card">
                    <div class="card-header">Datos de Identificación</div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-4">
                                <label>Pais de Origen</label>
                                <asp:DropDownList runat="server" ID="DDLPAISORIGEN" CssClass="form-control form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-4">
                                <label>Nacionalidad</label>
                                <asp:DropDownList runat="server" ID="DDLNACIONALIDAD" CssClass="form-control form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-4">
                                <label>Idioma</label>
                                <asp:DropDownList runat="server" ID="DDLIDIOMA" CssClass="form-control form-group"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Fecha de Nac.</label>
                                <asp:TextBox runat="server" ID="TXTFECHANAC" CssClass="form-control form-group" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label>Lugar de Nac.</label>
                                <asp:DropDownList runat="server" ID="DDLLUGARNAC" CssClass="form-control form-group"></asp:DropDownList>
                            </div>
                            <div class="col-md-4">
                                <label>Pueblo</label>
                                <asp:DropDownList runat="server" ID="DDLPUEBLO" CssClass="form-control form-group"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <label>Ocupación</label>
                                <asp:DropDownList runat="server" ID="DDLOCUPACION" CssClass="form-control form-group"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Teléfono</label>
                                <asp:TextBox runat="server" ID="TXTTELEFONO" CssClass="form-control form-group" ></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label>Afiliación IGSS</label>
                                <asp:TextBox runat="server" ID="TXTAFILIACION" CssClass="form-control form-group" placeholder="No. de identificación"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label>NIT</label>
                                <asp:TextBox runat="server" ID="TXTNIT" CssClass="form-control form-control" placeholder="Digite su NIT"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>ID</label>
                                <asp:DropDownList runat="server" ID="DDLIDENTIFICACION" CssClass="form-control form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-8">
                                <label>No. de Identificación</label>
                                <asp:TextBox runat="server" ID="TXTNOIDENTIFICACION" CssClass="form-control form-control" placeholder="No. de identificación"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>¿trabajo en el extranjero</label>
                                <asp:DropDownList runat="server" ID="DDLTRABAJOEXTRANJERO" CssClass="form-control form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <label>No. de expediente</label>
                                <asp:TextBox runat="server" ID="TXTNOEXPEDIENTETE" CssClass="form-control form-control" placeholder="No. de expediente"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <%--datos academicos--%>
                <div class="container p-3 mt-4 card">
                    <div class="card-header">Datos Acádemicos</div>
                    <div class="card-body">
                        <div class="form-group row">
                            <div class="col-md-4">
                                <label>Nivel Académico</label>
                                    <asp:DropDownList runat="server" ID="DDLNIVELACADEMICO" CssClass="form-control form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-8">
                                <label>Título o Diploma</label>
                                <asp:TextBox runat="server" ID="TXTDIPLOMA" CssClass="form-control form-control" placeholder="Ingrese nombre de título o diploma"></asp:TextBox>
                            </div>
                        </div>        
                    </div>
                </div>
                <%--datos bancarios--%>
                <div class="container p-3 mt-4 card">
                    <div class="card-header">Datos Bancarios</div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Banco</label>
                                <asp:DropDownList runat="server" ID="DDLIDBANCO" CssClass="form-control form-group"></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <label>No. de Cuenta</label>
                                <asp:TextBox runat="server" ID="TXTCUENTABANCO" CssClass="form-control form-group" placeholder="Ingrese nombre de título o diploma"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <%--datos para el sistema--%>
                <div class="container p-3 mt-4 card">
                    <div class="card-header">Datos para sistema</div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <label>Tipo de empleado</label>
                                <asp:DropDownList runat="server" ID="DDLTIPOEMPLEADO" CssClass="form-control form-group"></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <label>Estado de empleado</label>
                                <asp:DropDownList runat="server" ID="DDLESTADOEMPLEADO" CssClass="form-control form-group"></asp:DropDownList>
                            </div>         
                        </div>
                    </div>
                </div>
                <%--botones--%>
                <div class=" container row mt-4  mb-4">
                    <div class="col-md-6">
                        <asp:LinkButton runat="server" ID="BTNGUARDEMPLEADO" CssClass="btn btn-success btn-user btn-block" Visible="false">
                            <i class="fa fa-check fa-fw"></i> Guardar
                        </asp:LinkButton>
                        <asp:LinkButton runat="server" ID="BTNACTUALIZAR" CssClass="btn btn-warning btn-user btn-block" Visible="false">
                            <i class="fa fa-refresh fa-fw"></i> Actualizar
                        </asp:LinkButton>
                    </div>
                    <div class="col-md-6">
                        <asp:LinkButton runat="server" ID="BTNCANCELAEMPLEADO" CssClass="btn btn-danger btn-user btn-block">
                            <i class="fa fa-ban fa-fw"></i> Cancelar
                        </asp:LinkButton>
                    </div>
                </div>
            </form>
          </div>
        </asp:Panel>

    <div class="container-fluid">
        <!-- Divider -->
        <asp:Panel runat="server" id="PNGRIDEMPLEADOS">
        <div class="align-content-center text-center mb-2 mt-4">
            <h1 class="h3 mb-0 text-gray-800">GESTIÓN DE EMPLEADOS</h1>
        </div>
        <hr class="sidebar-divider d-none d-md-block text-dark">
        <div class="container-fluid m-2">
            <asp:LinkButton runat="server" ID="BTNAGREGAREMPLEADO" CssClass="btn btn-warning btn-user">Agregar nuevo empleado <i class="fa fa-user-plus"></i></asp:LinkButton>
        </div>
        <div class=" container-fluid overflow-auto">
            <div class="row mt-2 mb-2">
                <div class="col-md-6">
                    <label class="font-weight-bold">Buscar empleado</label>
                    <asp:TextBox runat="server" ID="TXTBUSCAREMPLEADO" CssClass="form-control form-control border-warning" ToolTip="Dejé el cmapo en blanco par ver a todos los empleados" AutoPostBack="true" placeholder="Ingrese nombre de empleado" required="required"></asp:TextBox>
                </div>
            </div>
            <asp:GridView ID="GVEMPLEADOS_" runat="server"
                AllowPaging="true" AllowSorting="true" 
                AutoGenerateColumns="False" PageSize ="10">                
            </asp:GridView>   
        </asp:Panel>
    </div>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
