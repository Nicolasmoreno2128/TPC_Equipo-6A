<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleCompraPage.aspx.cs" Inherits="TPC_Equipo_6A.DetalleCompraPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container my-5">

        <!-- Título -->
        <div class="row mb-4">
            <div class="col text-center">
                <h2>Detalle de compra</h2>
            </div>
        </div>

        <!-- Datos de la compra -->
        <div class="row mb-4">
            <div class="col-md-8 mx-auto">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h5 class="card-title mb-3">Datos de la compra</h5>

                        <div class="row mb-2">
                            <div class="col-4 fw-semibold">N° Compra:</div>
                            <div class="col-8">
                                <asp:Label ID="lblNroCompra" runat="server" />
                            </div>
                        </div>

                        <div class="row mb-2">
                            <div class="col-4 fw-semibold">Fecha de compra:</div>
                            <div class="col-8">
                                <asp:Label ID="lblFechaCompra" runat="server" />
                            </div>
                        </div>

                        <div class="row mb-2">
                            <div class="col-4 fw-semibold">Fecha de recepción:</div>
                            <div class="col-8">
                                <asp:Label ID="lblFechaRecepcion" runat="server" />
                            </div>
                        </div>

                        <div class="row mb-2">
                            <div class="col-4 fw-semibold">Proveedor:</div>
                            <div class="col-8">
                                <asp:Label ID="lblProveedor" runat="server" />
                            </div>
                        </div>

                        <div class="row mb-2">
                            <div class="col-4 fw-semibold">Estado:</div>
                            <div class="col-8">
                                <asp:Label ID="lblEstado" runat="server" />
                            </div>
                        </div>

                        <div class="row mt-3">
                            <div class="col-4 fw-semibold">Total:</div>
                            <div class="col-8">
                                <asp:Label ID="lblTotal" runat="server" CssClass="fw-bold" />
                            </div>
                        </div>

                        <asp:Label ID="lblError" runat="server" CssClass="text-danger fw-bold mt-3 d-block" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
        </div>

        <!-- Detalle de productos -->
        <div class="row mb-4">
            <div class="col-md-10 mx-auto">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h5 class="card-title mb-3">Productos de la compra</h5>

                        <asp:GridView ID="gvDetalleCompra" runat="server"
                            CssClass="table table-striped table-bordered"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="ProductoNombre" HeaderText="Producto" />
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Right" />
                            </Columns>
                        </asp:GridView>

                    </div>
                </div>
            </div>
        </div>

        <!-- Botones -->
        <div class="row">
            <div class="col-md-10 mx-auto">
                <div class="d-flex gap-4 mt-3">
                    <asp:Button ID="btnVolver" runat="server" Text="Volver"
                        CssClass="btn btn-secondary" OnClick="btnVolver_Click" />

                    <button type="button" class="btn btn-dark" onclick="window.print();">
                        Imprimir
                    </button>
                </div>
            </div>
        </div>

        <style>
            @media print {
                button, .btn, .btn-secondary, .btn-dark {
                    display: none !important;
                }
            }
        </style>

    </div>
</asp:Content>
