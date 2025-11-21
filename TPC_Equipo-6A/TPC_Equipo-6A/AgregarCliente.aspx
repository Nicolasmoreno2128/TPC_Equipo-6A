<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="TPC_Equipo_6A.AgregarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container d-flex justify-content-center align-items-center" style="min-height: 70vh;">
        <div class="col-md-4 text-center">
            <h2 class="mb-4">Agregar nuevo cliente</h2>

            <div class="mb-3">
                <asp:TextBox ID="txtNombre" CssClass="form-control mx-auto w-75" placeholder="Nombre del cliente" runat="server" />
                <asp:RequiredFieldValidator
                    ID="rfvNombre"
                    runat="server"
                    ControlToValidate="txtNombre"
                    ErrorMessage="El nombre es obligatorio."
                    ForeColor="Red"
                    Display="Dynamic" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtDescripcion" CssClass="form-control mx-auto w-75" placeholder="Descripción" runat="server" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtCuit" CssClass="form-control mx-auto w-75" placeholder="CUIT del cliente" runat="server" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtTelefono" CssClass="form-control mx-auto w-75" placeholder="Teléfono del cliente" runat="server" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtEmail" CssClass="form-control mx-auto w-75" placeholder="Email del cliente" runat="server" />
                <asp:RequiredFieldValidator
                    ID="rfvEmail"
                    runat="server"
                    ControlToValidate="txtEmail"
                    ErrorMessage="El email es obligatorio."
                    ForeColor="Red"
                    Display="Dynamic" />

                <asp:RegularExpressionValidator
                    ID="revEmail"
                    runat="server"
                    ControlToValidate="txtEmail"
                    ErrorMessage="El formato de email no es válido."
                    ForeColor="Red"
                    Display="Dynamic"
                    ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" />
            </div>
            <div class="d-flex justify-content-center gap-3 mt-3">
                <asp:Button Text="Nuevo" ID="btnCrear" OnClick="btnNuevo_Click" CssClass="btn btn-dark" runat="server" />
                <asp:Button Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" runat="server" CausesValidation="false" />
            </div>
            <div class="d-flex justify-content-center gap-3 mt-3">
                <asp:Label ID="lblError" runat="server" CssClass="text-danger fw-bold" Visible="false"></asp:Label>
            </div>

        </div>
    </div>

</asp:Content>
