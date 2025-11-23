<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCompra.aspx.cs" Inherits="TPC_Equipo_6A.AgregarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container my-5">
        
        <!-- Título centrado -->
        <div class="row mb-4">
            <div class="col text-center">
                <h2>Agregar nueva compra</h2>
                <p class="text-muted">Registrar el ingreso de mercadería desde un proveedor</p>
            </div>
        </div>

        <div class="row justify-content-center">

            <!-- CARD 1 — Datos de la compra -->
            <div class="col-md-4 mb-4">
                <div class="card shadow-sm">
                    <div class="card-body">

                        <h5 class="card-title mb-3">Datos de la compra</h5>

                        <!-- Fecha -->
                        <div class="mb-3">
                            <label for="txtFecha" class="form-label">Fecha:</label>
                            <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" CssClass="form-control" />
                        </div>

                        <!-- Proveedor -->
                        <div class="mb-3">
                            <label for="ddlProveedor" class="form-label">Proveedor:</label>
                            <asp:DropDownList ID="ddlProveedor" runat="server"
                                DataTextField="NombreProveedor" DataValueField="IdProveedor"
                                CssClass="form-select">
                            </asp:DropDownList>

                            <asp:RequiredFieldValidator runat="server" ID="rfvProveedor"
                                ControlToValidate="ddlProveedor"
                                InitialValue=""
                                ErrorMessage="Seleccioná un proveedor"
                                CssClass="text-danger d-block mt-1" />
                        </div>

                    </div>
                </div>
            </div>

            <!-- CARD 2 — Agregar productos -->
            <div class="col-md-8 mb-4">
                <div class="card shadow-sm">
                    <div class="card-body">

                        <h5 class="card-title mb-3">Agregar productos a la compra</h5>

                        <div class="row g-3 align-items-end">

                            <!-- Producto -->
                            <div class="col-md-6">
                                <label for="ddlProducto" class="form-label">Producto:</label>
                                <asp:DropDownList ID="ddlProducto" runat="server"
                                    DataTextField="NombreProducto" DataValueField="IdProducto"
                                    CssClass="form-select">
                                </asp:DropDownList>
                            </div>

                            <!-- Cantidad -->
                            <div class="col-md-3">
                                <label for="txtCantidad" class="form-label">Cantidad:</label>
                                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number" />
                            </div>

                            <!-- Botón agregar -->
                            <div class="col-md-3">
                                <asp:Button ID="btnAgregar" runat="server"
                                    Text="Agregar"
                                    CssClass="btn btn-dark w-100"
                                    OnClick="btnAgregar_Click" />
                            </div>

                        </div>

                        <!-- Mensajes de error -->
                        <div class="mt-3">
                            <asp:Label ID="lblError" runat="server" CssClass="text-danger fw-bold" Visible="false"></asp:Label>
                        </div>

                    </div>
                </div>
            </div>

            <!-- CARD 3 — Detalle -->
            <div class="col-md-12 mb-4">
                <div class="card shadow-sm">
                    <div class="card-body">

                        <h5 class="card-title mb-3">Detalle de productos</h5>

                        <asp:GridView ID="gvProductos" runat="server"
                            CssClass="table table-striped table-bordered"
                            AutoGenerateColumns="false">
                            <Columns>
                                <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="Precio" HeaderText="Precio" ItemStyle-HorizontalAlign="Right" />
                            </Columns>
                        </asp:GridView>

                        <!-- Total -->
                        <div class="text-end mt-3">
                            <span class="fw-bold">Total:</span>
                            <asp:Label ID="lblTotal" runat="server" CssClass="fw-bold fs-5 text-dark"></asp:Label>
                        </div>

                    </div>
                </div>
            </div>

        </div>

        <!-- Botones finales -->
        <div class="d-flex justify-content-center gap-3 mt-4">
            <asp:Button Text="Nuevo" ID="btnCrear" OnClick="btnCrear_Click"
                CssClass="btn btn-dark" runat="server" />

            <asp:Button Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click"
                CssClass="btn btn-secondary" runat="server"
                CausesValidation="false" />
        </div>

    </div>

</asp:Content>
