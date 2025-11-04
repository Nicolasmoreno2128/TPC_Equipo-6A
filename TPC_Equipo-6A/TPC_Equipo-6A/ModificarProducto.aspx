<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarProducto.aspx.cs" Inherits="TPC_Equipo_6A.ModificarProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hfIdProducto" runat="server" />

    <div class="container d-flex justify-content-center align-items-center" style="min-height: 70vh;">
    <div class="col-md-4 text-center">
        <h2 class="mb-4">Modificar Producto</h2>

        <div class="mb-3">
    <asp:TextBox ID="txtNombreProdm" CssClass="form-control mx-auto w-75" placeholder="Nombre del producto" runat="server" />
        </div>
        <div class="mb-3">
            <asp:TextBox ID="txtDescripcionProdm" CssClass="form-control mx-auto w-75" placeholder="Descripción" runat="server" />
        </div>
        <div class="mb-3">
            <asp:TextBox ID="txtImagenProdm" CssClass="form-control mx-auto w-75" placeholder="Imagen" runat="server" />
        </div>
        <div class="mb-3">
            <asp:TextBox ID="txtPrecioProdm" CssClass="form-control mx-auto w-75" placeholder="Precio Producto" runat="server" />
        </div>
        <div class="mb-3">
            <asp:TextBox ID="txtStockProdm" CssClass="form-control mx-auto w-75" placeholder="Stock" runat="server" />
        </div>
    <div>
        <label>Marca</label>
        <asp:DropDownList ID="ddlMarcam" runat="server" DataTextField="NombreMarca" CssClass="form-control mx-auto w-75" DataValueField="IdMarca"></asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlMarcam" CssClass="form-control mx-auto w-75" InitialValue="" ErrorMessage="Seleccioná una marca" />
    </div>

    <div>
        <label>Categoría</label>
        <asp:DropDownList ID="ddlCategoriam" runat="server" DataTextField="NombreCategoria" CssClass="form-control mx-auto w-75" DataValueField="IdCategoria"></asp:DropDownList>
        <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlCategoriam" CssClass="form-control mx-auto w-75" InitialValue="" ErrorMessage="Seleccioná una categoría" />
    </div>

        <div class="d-flex justify-content-center gap-3 mt-3">
            <asp:Button Text="Modificar" ID="btnModificarProd" OnClick="btnModificarProd_Click" CssClass="btn btn-dark" runat="server" />
            <asp:Button Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" runat="server" />
        </div>
    </div>
</div>



</asp:Content>
