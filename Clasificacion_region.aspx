<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MP01.Master" CodeBehind="Clasificacion_region.aspx.vb" Inherits="EasySapWeb.Clasificacion_region" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Contenido" runat="server">
<asp:UpdatePanel ID="UP0" runat="server" >
        <ContentTemplate>
        <asp:SqlDataSource ID="SQLDS_CLASREGION" runat="server" ConnectionString="<%$ ConnectionStrings:interfaceConnectionString %>" SelectCommand="SELECT id, ISO, codigo, descripcion,activo FROM cat.Pais order by activo desc" UpdateCommand="UPDATE cat.Pais SET ISO = @ISO, descripcion = @descripcion, codigo = @codigo, activo=@activo WHERE (id = @id)">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="activo" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="ISO" />
                <asp:Parameter Name="descripcion" />
                <asp:Parameter Name="codigo" />
                <asp:Parameter Name="activo" />
                <asp:Parameter Name="id" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SQLDS_REGIONPAIS" runat="server" ConnectionString="<%$ ConnectionStrings:interfaceConnectionString %>" SelectCommand="SELECT id, abreviatura, descripcion, observaciones, activo, id_pais FROM cat.Region WHERE (id_pais = @id_pais) ORDER BY activo DESC" UpdateCommand="UPDATE cat.Region SET abreviatura = @abreviatura, descripcion = @descripcion, observaciones = @observaciones, activo=@activo WHERE (id = @id)">
            <SelectParameters>
                <asp:ControlParameter ControlID="HFPAIS" Name="id_pais" PropertyName="Value" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="abreviatura" />
                <asp:Parameter Name="descripcion" />
                <asp:Parameter Name="observaciones" />
                <asp:Parameter Name="activo" />
                <asp:Parameter Name="id" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <div class="w3-content w3-padding-32">
            <asp:Panel ID="P0" runat="server" Visible="true">
                <header class="w3-container"> 
                <asp:HiddenField ID="HF01" runat="server" />
                <asp:HiddenField ID="HFPAIS" runat="server" />
                <h2>Clasificación Regional</h2>               
                <hr>
                </header>
<%--                <div class="w3-row">
                    <asp:LinkButton ID="BTN1" runat="server" Text="Agregar Usuario" cssclass="w3-block w3-col s4 w3-button w3-red w3-mobile w3-hover-yellow" ></asp:LinkButton>
                    <asp:LinkButton ID="BTN2" runat="server" Text="Editar Menú" cssclass="w3-block w3-col s4 w3-button w3-red w3-mobile w3-hover-yellow"></asp:LinkButton>
                    <asp:LinkButton ID="BTN3" runat="server" Text="Editar Perfiles" cssclass="w3-block w3-col s4 w3-button w3-red w3-mobile w3-hover-yellow"></asp:LinkButton>
                </div>--%>
                <div class="w3-row">
                    <h4>Gestionar País</h4>
                </div>
                <div class="w3-row">
                    <div class="w3-col s2">
                        <h5>Código</h5>
                    </div>
                    <div class="w3-col s2 ">
                        <h5>ISO</h5>
                    </div>
                    <div class="w3-col s4">
                        <h5>Descripción</h5>
                    </div>
                    <div class="w3-col s1">
                        <h5>Estado</h5>
                    </div>
                </div>
                 <div class="w3-row">
                    <div class="w3-col s2" style="padding-right:10px">
                        <asp:TextBox ID="txtCodPais" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
                    </div>
                    <div class="w3-col s2" style="padding-right:10px">
                        <asp:TextBox ID="txtIsoPais" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
                    </div>
                    <div class="w3-col s4" style="padding-right:10px">
                        <asp:TextBox ID="txtDescPais" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
                    </div>
                    <div class="w3-col s1" style="padding-right:10px">
                        <asp:CheckBox ID="txtEstatusPais" runat="server" CssClass="w3-check alert" />
                    </div>
                      <div class="w3-col s3" style="padding-right:10px">
                        <asp:Button ID="btnGuardarPais" runat="server"  CssClass="w3-button w3-block w3-red w3-hover-yellow" Text="Guardar"/>
                    </div>
                </div>
                <div class="w3-row w3-padding-16">
                        <asp:GridView 
                        ID="GVCR" 
                        runat="server" 
                        CssClass="table table-bordered table-condensed w3-small" HeaderStyle-CssClass="header w3-centered" RowStyle-CssClass="rows"
                        AllowPaging="True" 
                        AllowSorting="True" 
                        AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SQLDS_CLASREGION">
                        <Columns>
                            <asp:CommandField ShowEditButton="True" ButtonType="Image" CancelImageUrl="~/images/CANCEL.gif" DeleteImageUrl="~/images/DEL.gif" EditImageUrl="~/images/EDIT.gif" UpdateImageUrl="~/images/UPD.gif" ShowSelectButton="True" />
                            <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" Visible="False" />
                            <asp:BoundField DataField="ISO" HeaderText="ISO" SortExpression="ISO">
                            <HeaderStyle ForeColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="codigo" HeaderText="Código" SortExpression="codigo" >
                            <HeaderStyle ForeColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="descripcion" HeaderText="Descripcion" SortExpression="descripcion" >
                            <HeaderStyle ForeColor="White" />
                            </asp:BoundField>
                            <asp:CheckBoxField DataField="activo" HeaderText="activo" SortExpression="activo" >
                            <HeaderStyle ForeColor="White" />
                            </asp:CheckBoxField>
                        </Columns>
                            <HeaderStyle CssClass="header w3-centered" />
                        <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /> 
                            <RowStyle CssClass="rows" />
                    </asp:GridView>
                </div>
                <%-- Gestionar Regiones --%>
                <div class="w3-row">
                    <h4>Gestionar Regiones <asp:Label ID="LBLPAIS" runat="server"></asp:Label></h4>
                </div>
                <div class="w3-row">
                    <div class="w3-col s2">
                        <h5>Código</h5>
                    </div>
                    <div class="w3-col s2 ">
                        <h5>Región</h5>
                    </div>
                    <div class="w3-col s4">
                        <h5>Descripción</h5>
                    </div>
                    <div class="w3-col s1">
                        <h5>Estado</h5>
                    </div>
                </div>
                <div class="w3-row">
                    <div class="w3-col s2" style="padding-right:10px">
                        <asp:TextBox ID="txtCodigoRegion" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
                    </div>
                    <div class="w3-col s2" style="padding-right:10px">
                        <asp:TextBox ID="txtRegionNombre" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
                    </div>
                    <div class="w3-col s4" style="padding-right:10px">
                        <asp:TextBox ID="txtDescRegion" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
                    </div>
                    <div class="w3-col s1" style="padding-right:10px">
                        <asp:CheckBox ID="txtEstadoRegion" runat="server" CssClass="w3-check alert" />
                    </div>
                      <div class="w3-col s3" style="padding-right:10px">
                        <asp:Button ID="btnAgregarRegion" runat="server"  CssClass="w3-button w3-block w3-red w3-hover-yellow" Text="Guardar"/>
                    </div>
                </div>
                 <div class="w3-row w3-padding-16">
                        <asp:GridView 
                        ID="GVRP" 
                        runat="server" 
                        CssClass="table table-bordered table-condensed w3-small" HeaderStyle-CssClass="header w3-centered" RowStyle-CssClass="rows"
                        AllowPaging="True" 
                        AllowSorting="True" 
                        AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SQLDS_REGIONPAIS">
                        <Columns>
                            <asp:CommandField ShowEditButton="True" ShowSelectButton="True" />
                            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:BoundField DataField="abreviatura" HeaderText="abreviatura" SortExpression="abreviatura">
                            </asp:BoundField>
                            <asp:BoundField DataField="descripcion" HeaderText="descripcion" SortExpression="descripcion" >
                            </asp:BoundField>
                            <asp:BoundField DataField="observaciones" HeaderText="observaciones" SortExpression="observaciones" >
                            </asp:BoundField>
                            <asp:CheckBoxField DataField="activo" HeaderText="activo" SortExpression="activo" >
                            </asp:CheckBoxField>
                            <asp:BoundField DataField="id_pais" HeaderText="id_pais" SortExpression="id_pais" />
                        </Columns>
                            <HeaderStyle CssClass="header w3-centered" />
                        <PagerStyle HorizontalAlign = "Center" CssClass = "GridPager" /> 
                            <RowStyle CssClass="rows" />
                    </asp:GridView>
                </div>
            </asp:Panel> 
        </div>
        </ContentTemplate>
</asp:UpdatePanel> 
</asp:Content>
