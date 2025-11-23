<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormularioCliente.aspx.cs" Inherits="TPC_Equipo_6A.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container d-flex justify-content-center align-items-center" style="min-height: 70vh;">
        <div class="col-md-4 text-center">
            <h2 class="mb-4">Detalles Cliente</h2>

            <div class="row mb-3 align-items-center">
                <div class="col-md-3 text-md-end">
                    <label for="txtNombre" class="form-label mb-0">Nombre:</label>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtNombre" CssClass="form-control mx-auto w-75" placeholder="Nombre" runat="server" ReadOnly="true" />
                </div>
            </div>
            <div class="row mb-3 align-items-center">
                <div class="col-md-3 text-md-end">
                    <label for="txtCuit" class="form-label mb-0">CUIT:</label>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtCuit" CssClass="form-control mx-auto w-75" placeholder="CUIT" runat="server" />
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
            <div class="row mb-3 align-items-center">
                <div class="col-md-3 text-md-end">
                    <label for="txtTelefono" class="form-label mb-0">Teléfono:</label>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtTelefono" CssClass="form-control mx-auto w-75" placeholder="Telefono" runat="server" />
                </div>
            </div>
            <div class="row mb-3 align-items-center">
                <div class="col-md-3 text-md-end">
                    <label for="txtEmail" class="form-label mb-0">Email:</label>
                </div>
                <div class="col-md-9">
                    <asp:TextBox ID="txtEmail" CssClass="form-control mx-auto w-75" placeholder="Email" runat="server" />
                </div>
            </div>
            <div class="d-flex justify-content-center gap-3 mt-3">
                <asp:Button ID="btnModificarCliente" runat="server" Text="Modificar" CssClass="btn btn-dark"
                    OnClick="btnModificarCliente_Click" />
                <asp:Button ID="btnCancelarCliente" runat="server" Text="Cancelar" CssClass="btn btn-secondary"
                    OnClick="btnCancelarCliente_Click" />
                <asp:Label ID="lblMensajeCliente" runat="server" CssClass="text-danger d-block mt-2" />
            </div>
        </div>
    </div>

</asp:Content>
