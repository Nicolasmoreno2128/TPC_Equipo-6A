<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="TPC_Equipo_6A.Ventas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card shadow p-4">
                    <h2 class="text-center mb-4">Ventas</h2>

                    <asp:Label ID="lblMensaje" runat="server" CssClass="d-block mb-2"></asp:Label>
                    <asp:GridView ID="dgvVentas" runat="server" AutoGenerateColumns="false" DataKeyNames="IdVenta" OnRowCommand="dgvVentas_RowCommand" CssClass="table table-striped mt-3">
                        <Columns>
                            <asp:BoundField DataField="IdVenta" HeaderText="ID" />
                            <asp:BoundField DataField="FechaVenta" HeaderText="Fecha"
                                DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Cliente.Nombre" HeaderText="Cliente" />
                            <asp:BoundField DataField="Usuario.NombreUsuario" HeaderText="Vendedor" />
                            <asp:BoundField DataField="TotalVenta" HeaderText="Total" DataFormatString="{0:C}" />
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:Button ID="btnDetalles" runat="server" Text="📄" CommandName="Detalles" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-sm border-0 bg-transparent" ToolTip="Ver detalles de la venta"/>
                                    <% if (Session["usuario"] != null && ((dominio.Usuario)Session["usuario"]).Rol == dominio.Rol.Administrador)
                                        { %>
                                    <asp:Button ID="btnBorrar" runat="server" Text="🗑️" CommandName="Eliminar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-sm border-0 bg-transparent" ToolTip="Anular esta venta" />
                                    <% } %>
                                    <asp:Label ID="lblEliminar" runat="server" Text="Eliminar" Visible="false" CssClass="fw-bold text-danger me-2" />
                                    <asp:Button ID="btnConfirmar" runat="server" Text="✔️" CommandName="Confirmar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-sm border-0 bg-transparent" Visible="false" ToolTip="Confirmar anulación"/>
                                    <asp:Button ID="btnCancelar" runat="server" Text="❌" CommandName="Cancelar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-sm border-0 bg-transparent" Visible="false" ToolTip="Cancelar acción" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <div class="d-flex gap-3 mt-3">
                        <asp:Button ID="btnAgregarVenta" runat="server" CssClass="btn btn-dark" Text="Nueva" OnClick="btnAgregarVenta_Click" />
                        <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-secondary" Text="Volver" CausesValidation="false" OnClick="btnVolver_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
