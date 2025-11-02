<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EliminarCategoria.aspx.cs" Inherits="TPC_Equipo_6A.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container d-flex justify-content-center align-items-center" style="min-height: 70vh;">
        <div class="col-md-4 text-center">
            <h4 class="mb-4">Seleccione la categoria a eliminar:</h4>

            <div class="mb-4">
                <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-select"></asp:DropDownList>
            </div>

            <div class="d-flex justify-content-center gap-3 mt-3">
                <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-dark" runat="server" />
                <asp:Button Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" runat="server" />
            </div>
        </div>
    </div>




</asp:Content>
