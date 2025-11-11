<%@ Page Title="Modificar Usuario" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="TPC_Equipo_6A.ModificarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="hfIdUsuario" runat="server" />

    <div class="container d-flex justify-content-center align-items-center" style="min-height: 70vh;">
        <div class="col-md-6">
            <h2 class="mb-4 text-center">Detalles Usuario</h2>

            <div class="row mb-3 align-items-center">
                <div class="col-md-4 text-md-end">
                    <label for="txbNombreUsuario" class="form-label mb-0">Usuario:</label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txbNombreUsuario" CssClass="form-control bg-light text-muted" runat="server" ReadOnly="true" />
                </div>
            </div>
            <div class="row mb-3 align-items-center">
                <div class="col-md-4 text-md-end">
                    <label for="txtContrasena" class="form-label mb-0">Contraseña:</label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtContrasena" CssClass="form-control" runat="server" TextMode="Password" />
                </div>
            </div>
            <div class="row mb-3 align-items-center">
                <div class="col-md-4 text-md-end">
                    <label for="txtRepetirContrasena" class="form-label mb-0">Repetir Contraseña:</label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txtRepetirContrasena" TextMode="Password" CssClass="form-control" runat="server" />
                    
                </div>
            </div>
            <div class="row mb-3 align-items-center">
                <div class="col-md-4 text-md-end">
                    <label for="txbNombre" class="form-label mb-0">Nombre:</label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txbNombre" CssClass="form-control" runat="server" />
                </div>
            </div>
            <div class="row mb-3 align-items-center">
                <div class="col-md-4 text-md-end">
                    <label for="txbApellido" class="form-label mb-0">Apellido:</label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txbApellido" CssClass="form-control" runat="server" />
                </div>
            </div>
            <div class="row mb-3 align-items-center">
                <div class="col-md-4 text-md-end">
                    <label for="txbEmail" class="form-label mb-0">Email:</label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txbEmail" CssClass="form-control" runat="server" />
                </div>
            </div>
            <div class="row mb-3 align-items-center">
                <div class="col-md-4 text-md-end">
                    <label for="txbTelefono" class="form-label mb-0">Teléfono:</label>
                </div>
                <div class="col-md-8">
                    <asp:TextBox ID="txbTelefono" CssClass="form-control" runat="server" />
                </div>
            </div>
            <div class="row mb-3 align-items-center">
                <div class="col-md-4 text-md-end">
                    <label for="ddlRol" class="form-label mb-0">Rol:</label>
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control"></asp:DropDownList>
                </div>
            </div>
            <div class="row mb-3 align-items-center">
                <div class="col-md-4 text-md-end">
                    <label for="ddlEstado" class="form-label mb-0">Estado:</label>
                </div>
                <div class="col-md-8">
                    <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Activo" Value="true"></asp:ListItem>
                        <asp:ListItem Text="Inactivo" Value="false"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="d-flex justify-content-center gap-3 mt-4">
                <asp:Button Text="Modificar" ID="btnModificarUsuario" CssClass="btn btn-dark" runat="server" OnClick="btnModificarUsuario_Click" />
                <asp:Button Text="Cancelar" ID="btnCancelar" CssClass="btn btn-secondary" runat="server" OnClick="btnCancelar_Click" />
            </div>
            <div class="d-flex justify-content-center mt-3">
                <asp:Label ID="lblMensajeUsuario" runat="server" CssClass="text-danger fw-bold" />                
            </div>


        </div>
    </div>
</asp:Content>
