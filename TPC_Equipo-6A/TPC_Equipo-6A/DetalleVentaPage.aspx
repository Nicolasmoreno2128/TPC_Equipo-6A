<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleVentaPage.aspx.cs" Inherits="TPC_Equipo_6A.DetalleVentaPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container my-5">

        <!-- Título -->
        <div class="row mb-4">
            <div class="col text-center">
                <h2>Detalle de venta</h2>
            </div>
        </div>

        <!-- Datos de la venta -->
        <div class="row mb-4">
            <div class="col-md-8 mx-auto">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h5 class="card-title mb-3">Datos de la venta</h5>

                        <div class="row mb-2">
                            <div class="col-4 fw-semibold">N° Venta:</div>
                            <div class="col-8"><asp:Label ID="lblNroVenta" runat="server" /></div>
                        </div>

                        <div class="row mb-2">
                            <div class="col-4 fw-semibold">Fecha:</div>
                            <div class="col-8"><asp:Label ID="lblFecha" runat="server" /></div>
                        </div>

                        <div class="row mb-2">
                            <div class="col-4 fw-semibold">Cliente:</div>
                            <div class="col-8"><asp:Label ID="lblCliente" runat="server" /></div>
                        </div>

                        <div class="row mb-2">
                            <div class="col-4 fw-semibold">Vendedor:</div>
                            <div class="col-8"><asp:Label ID="lblUsuario" runat="server" /></div>
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
                        <h5 class="card-title mb-3">Productos de la venta</h5>

                        <asp:GridView ID="gvDetalleVenta" runat="server"
                            CssClass="table table-striped table-bordered"
                            AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Producto">
                                    <ItemTemplate>
                                        <%# Eval("Producto.NombreProducto") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Right" />
                            </Columns>
                        </asp:GridView>

                    </div>
                </div>
            </div>
        </div>

        <!-- Botón volver -->
        <div class="row">
            <div class="col text-center">
                <asp:Button ID="btnVolver" runat="server" Text="Volver a Ventas" CssClass="btn btn-dark" OnClick="btnVolver_Click" />
            </div>
        </div>

    </div>

</asp:Content>
