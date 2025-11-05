<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCategoria.aspx.cs" Inherits="TPC_Equipo_6A.ModificarCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container d-flex justify-content-center align-items-center" style="min-height: 70vh;">
        <div class="col-md-4 text-center">
            <h2 class="mb-4">Detalles Categoria</h2>

            <div class="mb-3">
                <asp:TextBox ID="txtNombre" CssClass="form-control mx-auto w-75" placeholder="Nombre de la Categoria" runat="server" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtDescripcion" CssClass="form-control mx-auto w-75" placeholder="Descripción" runat="server" />
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
