<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCategoria.aspx.cs" Inherits="TPC_Equipo_6A.ModificarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container d-flex justify-content-center align-items-center" style="min-height: 70vh;">
        <div class="col-md-4 text-center">
            <h2 class="mb-4">Detalle Categoría</h2>

            <div class="row mb-3 align-items-center">
                <div class="col-md-3 text-md-end">
                    <label for="txtNombre" class="form-label mb-0">Categoría:</label>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtNombre" CssClass="form-control mx-auto w-75" placeholder="Nombre de la Categoria" runat="server" />
                </div>
            </div>
            <div class="row mb-3 align-items-center">
                <div class="col-md-3 text-md-end">
                    <label for="txtDescripcion" class="form-label mb-0">Descripción:</label>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtDescripcion" CssClass="form-control mx-auto w-75" placeholder="Descripción" runat="server" />
                </div>
            </div>
            <div class="d-flex justify-content-center gap-3 mt-3">
                <asp:Button ID="btnModificarCategoria" runat="server" Text="Modificar" CssClass="btn btn-dark"
                    OnClick="btnModificarCategoria_Click" />
                <asp:Button ID="btnEliminarCategoria" runat="server" Text="Eliminar" CssClass="btn btn-danger"
                    OnClick="btnEliminarCategoria_Click" />
                <asp:Button ID="btnCancelarCategoria" runat="server" Text="Cancelar" CssClass="btn btn-secondary"
                    OnClick="btnCancelarCategoria_Click" />
                <asp:Label ID="lblMensajeCategoria" runat="server" CssClass="text-danger d-block mt-2" />
            </div>
        </div>
    </div>

</asp:Content>
