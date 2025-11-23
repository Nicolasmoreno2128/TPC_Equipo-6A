<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="FormularioMarca.aspx.cs" Inherits="TPC_Equipo_6A.ModificarMarca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container d-flex justify-content-center align-items-center" style="min-height: 70vh;">
        <div class="col-md-4 text-center">
            <h2 class="mb-4">Detalle Marca</h2>

            <div class="row mb-3 align-items-center">
                <div class="col-md-3 text-md-end">
                    <label for="txtNombre" class="form-label mb-0">Marca:</label>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtNombre" CssClass="form-control mx-auto w-75" placeholder="Nombre de la marca" runat="server" ReadOnly="true"/>
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
            <asp:Button ID="btnModificarMarca" runat="server" Text="Modificar" CssClass="btn btn-dark"
                OnClick="btnModificarMarca_Click" />
            <asp:Button ID="btnCancelarMarca" runat="server" Text="Cancelar" CssClass="btn btn-secondary"
                OnClick="btnCancelarMarca_Click" />
            <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger d-block mt-2" />
        </div>
    </div>
    </div>
</asp:Content>
