<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioProducto.aspx.cs" Inherits="TPC_Equipo_6A.ModificarProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hfIdProducto" runat="server" />

    <h2 class="mb-4 text-center">Detalles Producto</h2>
    <div class="container d-flex justify-content-center align-items-center" style="min-height: 70vh;">
        <div class="col-md-6">

            <div class="row mb-3 align-items-center">
                <div class="col-md-3 text-md-end">
                    <label for="txtNombreProdm" class="form-label mb-0">Nombre:</label>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtNombreProdm" CssClass="form-control" runat="server" />
                </div>
            </div>
            <div class="row mb-3 align-items-center">
                <div class="col-md-3 text-md-end">
                    <label for="txtDescripcionProdm" class="form-label mb-0">Descripción:</label>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtDescripcionProdm" CssClass="form-control" runat="server" />
                </div>
            </div>

            <div class="row mb-3 align-items-center">
                <div class="col-md-3 text-md-end">
                    <label for="txtPrecioProdm" class="form-label mb-0">Precio:</label>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtPrecioProdm" CssClass="form-control" runat="server" />
                </div>
            </div>
            <div class="row mb-3 align-items-center">
                <div class="col-md-3 text-md-end">
                    <label for="txtStockProdm" class="form-label mb-0">Stock:</label>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtStockProdm" CssClass="form-control" runat="server" />
                </div>
            </div>
            <div class="row mb-3 align-items-center">
                <div class="col-md-3 text-md-end">
                    <label for="ddlMarcam" class="form-label mb-0">Marca:</label>
                </div>
                <div class="col-md-9">
                    <asp:DropDownList ID="ddlMarcam" runat="server" DataTextField="NombreMarca" DataValueField="IdMarca" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ID="rfvMarca" ControlToValidate="ddlMarcam" InitialValue="" ErrorMessage="Seleccioná una marca" CssClass="text-danger d-block mt-1" />
                </div>
            </div>
            <div class="row mb-3 align-items-center">
                <div class="col-md-3 text-md-end">
                    <label for="ddlCategoriam" class="form-label mb-0">Categoría:</label>
                </div>
                <div class="col-md-9">
                    <asp:DropDownList ID="ddlCategoriam" runat="server" DataTextField="NombreCategoria" DataValueField="IdCategoria" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ID="rfvCategoria" ControlToValidate="ddlCategoriam" InitialValue="" ErrorMessage="Seleccioná una categoría" CssClass="text-danger d-block mt-1" />
                </div>
            </div>


        </div>
            <div class="col-md-6">
                <div class="row mb-3 align-items-center">
                    <asp:Image ID="imgProducto" runat="server" CssClass="img-fluid rounded shadow-sm mb-3" Style="max-height: 300px;" />
                    

                </div>
            </div>
    </div>
        <div class="d-flex justify-content-center gap-3 mt-4">
            <asp:Button Text="Modificar" ID="btnModificarProd" OnClick="btnModificarProd_Click" CssClass="btn btn-dark" runat="server" />
            <asp:Button ID="btnEliminarProducto" runat="server" Text="Eliminar" CssClass="btn btn-danger" OnClick="btnEliminarProducto_Click" />
            <asp:Button Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" runat="server" />
            <asp:Label ID="lblMensajeProducto" runat="server" CssClass="text-danger d-block mt-2" />

        </div>
</asp:Content>

