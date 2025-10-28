<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPC_Equipo_6A.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Registro</h2>
    <div class="row">
        <div class="col-md-6 mb-3">
            <label for="txbNombreUsuario" class="form-label">Nombre de Usuario</label>
            <asp:TextBox runat="server" ID="txbNombreUsuario" CssClass="form-control" placeholder="Nombre de Usuario" />
            <asp:RequiredFieldValidator ID="rfvNombreUsuario" runat="server" ControlToValidate="txbNombreUsuario" ErrorMessage="Campo obligatorio." CssClass="text-danger d-block" EnableClientScript="true" Display="Dynamic" ValidationGroup="LoginGroup" />
        </div>
        <div class="col-md-6 mb-3">
            <label for="txbContraseña" class="form-label">Contraseña</label>
            <asp:TextBox runat="server" ID="txbContraseña" CssClass="form-control" placeholder="Contraseña" TextMode="Password" />
            <asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="txbContraseña" ErrorMessage="Campo obligatorio." CssClass="text-danger d-block" EnableClientScript="true" Display="Dynamic" ValidationGroup="LoginGroup" />
        </div>
        <div class="col-md-6 mb-3">
            <label for="txbRepetirContraseña" class="form-label">Repetir Contraseña</label>
            <asp:TextBox runat="server" ID="txbRepetirContraseña" CssClass="form-control" placeholder="Repetir Contraseña" TextMode="Password" />
            <asp:RequiredFieldValidator ID="rfvRepetircontraseña" runat="server" ControlToValidate="txbRepetirContraseña" ErrorMessage="La contraseña no coincide" CssClass="text-danger d-block" EnableClientScript="true" Display="Dynamic" ValidationGroup="LoginGroup" />
        </div>
        <div class="col-md-6 mb-3">
            <label for="txbNombre" class="form-label">Nombre</label>
            <asp:TextBox runat="server" ID="txbNombre" CssClass="form-control" placeholder="Nombre" />
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txbNombre" ErrorMessage="Campo obligatorio." CssClass="text-danger d-block" EnableClientScript="true" Display="Dynamic" ValidationGroup="LoginGroup" />
        </div>
        <div class="col-md-6 mb-3">
            <label for="txbApellido" class="form-label">Apellido</label>
            <asp:TextBox runat="server" ID="txbApellido" CssClass="form-control" placeholder="Apellido" />
            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txbApellido" ErrorMessage="Campo obligatorio." CssClass="text-danger d-block" EnableClientScript="true" Display="Dynamic" ValidationGroup="LoginGroup" />
        </div>
        <div class="col-md-6 mb-3">
            <label for="txbRol" class="form-label">Rol</label>
            <asp:TextBox runat="server" ID="txbRol" CssClass="form-control" placeholder="Rol" />
            <asp:RequiredFieldValidator ID="rfvRol" runat="server" ControlToValidate="txbRol" ErrorMessage="Campo obligatorio." CssClass="text-danger d-block" EnableClientScript="true" Display="Dynamic" ValidationGroup="LoginGroup" />
        </div>
        <div class="col-md-6 mb-3">
            <label for="txbEmail" class="form-label">Email</label>
            <asp:TextBox runat="server" ID="txbEmail" CssClass="form-control" placeholder="Email" />
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txbEmail" ErrorMessage="Campo obligatorio." CssClass="text-danger d-block" EnableClientScript="true" Display="Dynamic" ValidationGroup="LoginGroup" />
        </div>
        <div class="col-md-6 mb-3">
            <label for="txbTelefono" class="form-label">Teléfono</label>
            <asp:TextBox runat="server" ID="txbTelefono" CssClass="form-control" placeholder="Teléfono" />
            <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txbTelefono" ErrorMessage="Campo obligatorio." CssClass="text-danger d-block" EnableClientScript="true" Display="Dynamic" ValidationGroup="LoginGroup" />
        </div>
        <div class="mt-3">
            <asp:Button Text="Crear" ID="btnCrear" CssClass="btn btn-dark mt-3" runat="server" OnClick="btnCrear_Click" CausesValidation="false" />
            <asp:Button Text="Volver" ID="btnVolver" CssClass="btn btn-dark mt-3" runat="server" OnClick="btnVolver_Click" CausesValidation="false" />
        </div>
    </div>
</asp:Content>
