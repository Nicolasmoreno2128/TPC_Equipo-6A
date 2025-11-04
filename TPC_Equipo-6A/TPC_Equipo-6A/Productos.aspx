<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TPC_Equipo_6A.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card shadow p-4">
                    <h2 class="text-center mb-4">Productos</h2>
                   <asp:GridView ID="DgvProductos" runat="server" CssClass="table table-striped"
                            AutoGenerateColumns="False"
                            DataKeyNames="IdProducto,IdMarcaFk,IdCategoriaFk"
                            OnSelectedIndexChanged="DgvProductos_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="IdProducto" HeaderText="ID" ReadOnly="True" />
                                <asp:BoundField DataField="NombreProducto" HeaderText="Nombre" />
                                <asp:BoundField DataField="DescripcionProducto" HeaderText="Descripcion" />
                                <asp:BoundField DataField="UrlImagen" HeaderText="Imagen" />
                                <asp:BoundField DataField="PrecioProducto" HeaderText="Precio Producto" />
                                <asp:BoundField DataField="Stock" HeaderText="Stock" />
                                <asp:CheckBoxField DataField="Estado" HeaderText="Activo" ReadOnly="True" />

                                
                                <asp:TemplateField HeaderText="Marca">
                                    <ItemTemplate><%# Eval("IdMarca.NombreMarca") %></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Categoría">
                                    <ItemTemplate><%# Eval("IdCategoria.NombreCategoria") %></ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Acciones">
                                  <ItemTemplate>
                                    <asp:HyperLink runat="server" CssClass="btn btn-dark"
                                     Text="📝 
                                        Modificar"
                                     NavigateUrl='<%# "ModificarProducto.aspx?id=" + Eval("IdProducto") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                    <div class="row justify-content-center mt-3">
                        <div class="col-4 col-md-3">
                            <asp:Button ID="btnAgregarProducto" OnClick="btnAgregarProducto_Click" runat="server" CssClass="btn btn-dark w-100" Text="Agregar" />
                        </div>
                        <div class="col-4 col-md-3">
                            <asp:Button ID="btnEliminarProducto" runat="server" CssClass="btn btn-dark w-100" Text="Eliminar" CausesValidation="false" />
                        </div>
                        <div class="col-4 col-md-3">
                            <asp:Button ID="btnVolver" OnClick="btnVolver_Click" runat="server" CssClass="btn btn-dark w-100" Text="Volver" CausesValidation="false" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
