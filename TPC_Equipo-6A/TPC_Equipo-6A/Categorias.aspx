<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPC_Equipo_6A.Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card shadow p-4">
                    <h2 class="text-center mb-4">Categorias</h2>

                    <% if (Session["usuario"] != null && ((dominio.Usuario)Session["usuario"]).Rol == dominio.Rol.Administrador)
                        { %>
                    <div class="mb-3">
                        <asp:CheckBox ID="chbMostrarTodos" OnCheckedChanged="chbMostrarTodos_CheckedChanged" runat="server" AutoPostBack="true" />
                        <asp:Label ID="lblCheckBox" runat="server" Text="Mostrar Inactivos" CssClass="form-check-label" />
                    </div>
                    <% } %>
                    <asp:GridView ID="DgvCategoria" runat="server" CssClass="table table-striped"
                        AutoGenerateColumns="False"
                        DataKeyNames="IdCategoria"
                        OnRowCommand="DgvCategoria_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="IdCategoria" HeaderText="ID" ReadOnly="True" />
                            <asp:BoundField DataField="NombreCategoria" HeaderText="Nombre" />
                            <asp:BoundField DataField="DescripcionCategoria" HeaderText="Descripcion" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" Visible="False" />

                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:Button ID="btnDetalles" runat="server"
                                        Text="📄"
                                        CommandName="Detalles"
                                        CommandArgument="<%# Container.DataItemIndex %>"
                                        CssClass="btn btn-sm border-0 bg-transparent" />
                                    <% if (Session["usuario"] != null && ((dominio.Usuario)Session["usuario"]).Rol == dominio.Rol.Administrador)
                                        { %>
                                    <asp:Button ID="btnBorrar" runat="server"
                                        Text="🗑️"
                                        CommandName="Borrar"
                                        CommandArgument="<%# Container.DataItemIndex %>"
                                        CssClass="btn btn-sm border-0 bg-transparent" />
                                    <asp:Button ID="btnActivar"
                                        runat="server"
                                        Text="🔄"
                                        CommandName="ActivarCategoria"
                                        CommandArgument='<%# Container.DataItemIndex %>'
                                        Visible='<%# !(bool)Eval("Estado") %>'
                                        CssClass="btn btn-sm border-0 bg-transparent" />                                    
                                    <asp:Label ID="lblEliminar" runat="server"
                                        Text="Eliminar"
                                        Visible="false"
                                        CssClass="fw-bold text-danger me-2" />
                                    <asp:Label ID="lblActivar" runat="server"
                                        Text="Activar"
                                        Visible="false"
                                        CssClass="fw-bold text-success me-2" />
                                    <asp:Button ID="btnConfirmar" runat="server"
                                        Text="✔️"
                                        CommandName="Confirmar"
                                        CommandArgument="<%# Container.DataItemIndex %>"
                                        CssClass="btn btn-sm border-0 bg-transparent"
                                        Visible="false" />
                                    <asp:Button ID="btnConfirmarActivo" runat="server"
                                        Text="✔️"
                                        CommandName="ConfirmarActivo"
                                        CommandArgument="<%# Container.DataItemIndex %>"
                                        CssClass="btn btn-sm border-0 bg-transparent"
                                        Visible="false" />
                                    <asp:Button ID="btnCancelar" runat="server"
                                        Text="❌"
                                        CommandName="Cancelar"
                                        CommandArgument="<%# Container.DataItemIndex %>"
                                        CssClass="btn btn-sm border-0 bg-transparent"
                                        Visible="false" />  
                                    <% } %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <div class="d-flex gap-3 mt-3">
                        <asp:Button ID="btnNueva" runat="server" CssClass="btn btn-dark" Text="Nueva"
                            CausesValidation="false" OnClick="btnNueva_Click" />
                        <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-secondary" Text="Volver"
                            CausesValidation="false" OnClick="btnVolver_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>










</asp:Content>
