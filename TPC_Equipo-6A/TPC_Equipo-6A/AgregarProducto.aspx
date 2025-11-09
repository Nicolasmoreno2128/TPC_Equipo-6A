<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="TPC_Equipo_6A.AgregarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div class="container mt-5">
    <div class="text-center mb-5">
        <h2 class="fw-bold">Agregar Producto</h2>
    </div>

    <div class="row justify-content-center align-items-start g-5">

        <div class="col-md-6">
            <div class="p-4">
                <h5 class="text-center mb-4 fw-semibold">Detalles del Producto</h5>

                <div class="mb-3">
                    <asp:TextBox ID="txtNombreProdn" runat="server" CssClass="form-control" placeholder="Nombre del producto" />
                </div>

                <div class="mb-3">
                    <asp:TextBox ID="txtDescripcionProdn" runat="server" CssClass="form-control" placeholder="Descripción" />
                </div>

                <div class="mb-3">
                    <asp:TextBox ID="txtPrecioProdn" runat="server" CssClass="form-control" placeholder="Precio del producto" />
                </div>

                <div class="mb-3">
                    <asp:TextBox ID="txtStockProdn" runat="server" CssClass="form-control" placeholder="Stock disponible" />
                </div>

                <div class="mb-3 text-center">
                    <asp:Label Text="Marca" runat="server" CssClass="form-label fw-semibold d-block" />
                    <asp:DropDownList ID="ddlMarcan" runat="server" CssClass="form-select"></asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlMarcan" CssClass="text-danger small d-block mt-1" ErrorMessage="Seleccioná una marca" />
                </div>

                <div class="mb-3 text-center">
                    <asp:Label Text="Categoría" runat="server" CssClass="form-label fw-semibold d-block" />
                    <asp:DropDownList ID="ddlCategorian" runat="server" CssClass="form-select"></asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCategorian" CssClass="text-danger small d-block mt-1" ErrorMessage="Seleccioná una categoría" />
                </div>
            </div>
        </div>

        <div class="col-md-5 text-center">
            <div class="p-4">
                <h5 class="fw-semibold mb-4">Imagen del Producto</h5>

                <div class="mb-3">
                    <input type="file" id="txtImagen" runat="server" class="form-control" />
                </div>

                <asp:Image ID="imgNuevoPerfil"
                    runat="server"
                    CssClass="img-fluid rounded shadow-sm border"
                    ImageUrl="https://upload.wikimedia.org/wikipedia/commons/6/65/No-Image-Placeholder.svg"
                    AlternateText="Vista previa del producto" />
            </div>
        </div>
    </div>

    <div class="d-flex justify-content-center gap-3 mt-5">
        <asp:Button Text="Guardar Producto" ID="btnNuevoProd" OnClick="btnNuevoProd_Click" CssClass="btn btn-dark px-4 py-2 fw-semibold" runat="server" />
        <asp:Button Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-outline-secondary px-4 py-2 fw-semibold" runat="server" />
    </div>
</div>




</asp:Content>
