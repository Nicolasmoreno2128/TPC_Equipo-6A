<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_Equipo_6A.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card shadow p-4">
                    <h2 class="text-center mb-4">Productos</h2>
                    <asp:CheckBox Text="Mostrar Todos" ID="chbMostrarTodos" OnCheckedChanged="chbMostrarTodos_CheckedChanged" runat="server" AutoPostBack="true" />
                    <asp:GridView ID="DgvProductos" runat="server" CssClass="table table-striped"
                        AutoGenerateColumns="False"
                        DataKeyNames="IdProducto,IdMarcaFk,IdCategoriaFk"
                        OnRowCommand="DgvProductos_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="IdProducto" HeaderText="ID" ReadOnly="True" />
                            <asp:BoundField DataField="NombreProducto" HeaderText="Nombre" />
                            <asp:BoundField DataField="DescripcionProducto" HeaderText="Descripcion" />
                            <asp:BoundField DataField="PrecioProducto" HeaderText="Precio" />
                            <asp:BoundField DataField="Stock" HeaderText="Stock" />

                            <asp:TemplateField HeaderText="Marca">
                                <ItemTemplate><%# Eval("IdMarca.NombreMarca") %></ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Categoría">
                                <ItemTemplate><%# Eval("IdCategoria.NombreCategoria") %></ItemTemplate>
                            </asp:TemplateField>
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
                                    <% } %>
                                    <asp:Label ID="lblEliminar" runat="server"
                                        Text="Eliminar"
                                        Visible="false"
                                        CssClass="fw-bold text-danger me-2" />
                                    <asp:Button ID="btnConfirmar" runat="server"
                                        Text="✔️"
                                        CommandName="Confirmar"
                                        CommandArgument="<%# Container.DataItemIndex %>"
                                        CssClass="btn btn-sm border-0 bg-transparent"
                                        Visible="false" />
                                    <asp:Button ID="btnCancelar" runat="server"
                                        Text="❌"
                                        CommandName="Cancelar"
                                        CommandArgument="<%# Container.DataItemIndex %>"
                                        CssClass="btn btn-sm border-0 bg-transparent"
                                        Visible="false" />
                                    <asp:Button ID="btnActivar"
                                        runat="server"
                                        Text="Dar de alta"
                                        CssClass="btn btn-success btn-sm"
                                        CommandName="ActivarProducto"
                                        CommandArgument='<%# Container.DataItemIndex %>'
                                        Visible='<%# !(bool)Eval("Estado") %>' />

                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>

                    <div class="d-flex gap-3 mt-3">
                        <asp:Button ID="btnAgregarProducto" OnClick="btnAgregarProducto_Click" runat="server" CssClass="btn btn-dark" Text="Agregar" />
                        <asp:Button ID="btnVolver" OnClick="btnVolver_Click" runat="server" CssClass="btn btn-secondary" Text="Volver" CausesValidation="false" />
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
