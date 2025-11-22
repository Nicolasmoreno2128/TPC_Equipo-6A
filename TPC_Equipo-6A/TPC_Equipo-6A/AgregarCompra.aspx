<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCompra.aspx.cs" Inherits="TPC_Equipo_6A.AgregarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container" style="min-height: 70vh;">
        <h2 class="mb-4 text-center">Agregar nueva compra</h2>

        <div class="row">

            
            <div class="col-md-4">

                <div class="mb-3">
                    <label for="txtFecha" class="form-label">Fecha:</label>
                    <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" CssClass="form-control" />
                </div>

                <div class="mb-3">
                    <label for="ddlProveedor" class="form-label">Proveedor:</label>
                    <asp:DropDownList ID="ddlProveedor" runat="server" DataTextField="NombreProveedor"
                        DataValueField="IdProveedor" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ID="rfvProveedor" ControlToValidate="ddlProveedor"
                        InitialValue="" ErrorMessage="Seleccioná un proveedor"
                        CssClass="text-danger d-block mt-1" />
                </div>

            </div>

           
            <div class="col-md-8">

                    <div class ="row mb-5">
                    
                    <div class="col-md-6">
                        <label for="ddlProducto" class="form-label">Producto:</label>
                        <asp:DropDownList ID="ddlProducto" runat="server"
                            DataTextField="NombreProducto" DataValueField="IdProducto"
                            CssClass="form-control" />
                    </div>
                    
                    
                    <div class="col-md-3">
                        <label for="txtCantidad" class="form-label">Cantidad:</label>
                        <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number" />
                    </div>

                    
                    <div class="col-md-3">
                        <asp:Button ID="btnAgregar" runat="server"
                            Text="Agregar" CssClass="btn btn-dark"
                            OnClick="btnAgregar_Click" />
                    </div>

                </div>

               
                <asp:GridView ID="gvProductos" runat="server" CssClass="table table-bordered"
                    AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    </Columns>
                </asp:GridView>

                
                <div class="mt-3 text-end">
                    <asp:Label ID="lblTotal" runat="server" CssClass="fw-bold fs-4 text-dark"></asp:Label>
                </div>

            </div>

        </div>
    </div>

    
    <div class="d-flex justify-content-center gap-3 mt-4">
        <asp:Button Text="Nuevo" ID="btnCrear" OnClick="btnCrear_Click" CssClass="btn btn-dark" runat="server" />
        <asp:Button Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary"
            runat="server" CausesValidation="false" />
    </div>

    <div class="d-flex justify-content-center mt-3">
        <asp:Label ID="lblError" runat="server" CssClass="text-danger fw-bold" Visible="false"></asp:Label>
    </div>

   






</asp:Content>
