<%@ Page Title="Nueva Venta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaVenta.aspx.cs" Inherits="TPC_Equipo_6A.NuevaVenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="container my-5">

        <!-- Título -->
        <div class="row mb-4">
            <div class="col text-center">
                <h2>Nueva Venta</h2>
                <p class="text-muted">Registrar una venta con uno o varios productos</p>
            </div>
        </div>

        <!-- Datos generales de la venta -->
        <div class="row mb-4">
            <div class="col-md-6">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h5 class="card-title mb-3">Datos del cliente</h5>

                        <!-- Cliente -->
                        <div class="mb-3">
                            <label for="ddlClientes" class="form-label">Cliente</label>

                            <div class="input-group">
                                <!-- Combo de clientes -->
                                <asp:DropDownList ID="ddlClientes" runat="server" CssClass="form-select">
                                </asp:DropDownList>

                                <asp:HyperLink 
                                    ID="hlNuevoCliente" runat="server" NavigateUrl="AgregarCliente.aspx" CssClass="btn btn-outline-dark" Target="_blank">
                                    + Nuevo
                                </asp:HyperLink>
                            </div>

                            <small class="form-text text-muted">
                                Si el cliente no existe, podés crearlo con el botón ⬆️"<b>+ Nuevo</b>".
                            </small>
                        </div>

                        <!-- Fecha venta (solo display) -->
                        <div class="mb-3">
                            <label class="form-label">Fecha de venta:</label>
                            <asp:Label ID="lblFechaVenta" runat="server" CssClass="form-control-plaintext fw-semibold"></asp:Label>
                        </div>

                        <!-- Usuario (solo display) -->
                        <div class="mb-3">
                            <label class="form-label">Usuario:</label>
                            <asp:Label ID="lblUsuario" runat="server" CssClass="form-control-plaintext fw-semibold"></asp:Label>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <!-- Agregar productos -->
        <div class="row mb-4">
            <div class="col-md-8">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h5 class="card-title mb-3">Agregar productos a la venta</h5>

                        <div class="row g-3 align-items-end">
                            <!-- Producto -->
                            <div class="col-md-6">
                                <label for="ddlProductos" class="form-label">Producto</label>
                                <asp:DropDownList ID="ddlProductos" runat="server" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="ddlProductos_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                            <!-- Cantidad -->
                            <div class="col-md-3">
                                <label for="ddlCantidad" class="form-label">Cantidad</label>
                                <asp:DropDownList ID="ddlCantidad" runat="server" CssClass="form-select">
                                </asp:DropDownList>

                                <small class="form-text text-muted">
                                 Stock disponible: <asp:Label ID="lblStockDisponible" runat="server" Text="-" />
                                </small>
                            </div>

                            <!-- Botón agregar -->
                            <div class="col-md-3 text-md-start text-center">
                                <asp:Button ID="btnAgregarProducto" runat="server" Text="Agregar" CssClass="btn btn-dark w-100" OnClick="btnAgregarProducto_Click" ValidationGroup="Agregar" />
                            </div>
                        </div>

                        <!-- Mensajes de error -->
                        <div class="mt-3">
                            <asp:Label ID="lblMensajeError" runat="server" CssClass="text-danger"></asp:Label>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <!-- Detalle de la venta -->
        <div class="row mb-4">
            <div class="col-md-10">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h5 class="card-title mb-3">Detalle de productos</h5>

                        <asp:GridView ID="gvDetalleVenta" runat="server" CssClass="table table-striped table-bordered"
                            AutoGenerateColumns="False" OnRowDeleting="gvDetalleVenta_RowDeleting" DataKeyNames="IdDetalleVenta">
                            <Columns>
                                <asp:BoundField DataField="Producto.NombreProducto" HeaderText="Producto" />

                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />

                                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" DataFormatString="{0:C}" />

                                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />

                                <asp:CommandField ShowDeleteButton="True" DeleteText="Quitar" />
                            </Columns>
                        </asp:GridView>

                        <!-- Total -->
                        <div class="d-flex justify-content-end mt-3">
                            <h5>Total: <asp:Label ID="lblTotalVenta" runat="server" Text="$0,00" CssClass="fw-bold"></asp:Label></h5>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Botones finales -->
        <div class="row mb-5">
            <div class="col-md-6 d-flex gap-2">
            <asp:Button ID="btnConfirmarVenta" runat="server" Text="Confirmar venta" CssClass="btn btn-dark w-100" OnClick="btnConfirmarVenta_Click" CausesValidation="False" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-dark w-100" OnClick="btnCancelar_Click" CausesValidation="False" />
            </div>
        </div>
    </div>
</asp:Content>
