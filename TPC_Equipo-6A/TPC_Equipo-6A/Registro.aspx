<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="TPC_Equipo_6A.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Registro</h2>
    <div class="row">
        <div class="col-md-6 mb-3">
            <label for="txbNombreUsuario" class="form-label">Nombre de Usuario <span class="text-danger">*</span></label>
            <asp:TextBox runat="server" ID="txbNombreUsuario" CssClass="form-control" placeholder="Nombre de Usuario" />
            <asp:Label ID="lblError" runat="server" CssClass="text-danger fw-bold" Visible="false"></asp:Label>
            <asp:RequiredFieldValidator ID="rfvNombreUsuario" runat="server" ControlToValidate="txbNombreUsuario" CssClass="text-danger d-block" EnableClientScript="true" Display="Dynamic" ValidationGroup="LoginGroup" />
        </div>
        <div class="col-md-6 mb-3">
            <label for="txbContraseña" class="form-label">Contraseña <span class="text-danger">*</span></label>
            <asp:TextBox runat="server" ID="txbContraseña" CssClass="form-control" placeholder="Contraseña" TextMode="Password" />
            <asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="txbContraseña" CssClass="text-danger d-block" EnableClientScript="true" Display="Dynamic" ValidationGroup="LoginGroup" />
        </div>
        <div class="col-md-6 mb-3">
            <label for="txbRepetirContraseña" class="form-label">Repetir Contraseña <span class="text-danger">*</span></label>
            <asp:TextBox runat="server" ID="txbRepetirContraseña" CssClass="form-control" placeholder="Repetir Contraseña" TextMode="Password" />
            <asp:RequiredFieldValidator ID="rfvRepetircontraseña" runat="server" ControlToValidate="txbRepetirContraseña" CssClass="text-danger d-block" Display="Dynamic" ValidationGroup="LoginGroup" />
            <asp:CompareValidator ID="cvContraseñas" runat="server" ControlToValidate="txbRepetirContraseña" ControlToCompare="txbContraseña" CssClass="text-danger d-block" Display="Dynamic" ValidationGroup="LoginGroup" />
        </div>
        <div class="col-md-6 mb-3">
            <label for="txbNombre" class="form-label">Nombre</label>
            <asp:TextBox runat="server" ID="txbNombre" CssClass="form-control" placeholder="Nombre" />
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txbNombre" CssClass="text-danger d-block" EnableClientScript="true" Display="Dynamic" />
        </div>
        <div class="col-md-6 mb-3">
            <label for="txbApellido" class="form-label">Apellido</label>
            <asp:TextBox runat="server" ID="txbApellido" CssClass="form-control" placeholder="Apellido" />
            <asp:RequiredFieldValidator ID="rfvApellido" runat="server" ControlToValidate="txbApellido" CssClass="text-danger d-block" EnableClientScript="true" Display="Dynamic" />
        </div>
        <div class="col-md-6 mb-3">
            <label for="ddlRol" class="form-label">Rol <span class="text-danger">*</span></label>
            <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-select" AppendDataBoundItems="true">
                <asp:ListItem Text="Seleccione un rol" Value="" />
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfvRol" runat="server" ControlToValidate="ddlRol" InitialValue="" CssClass="text-danger d-block" Display="Dynamic" ValidationGroup="RegistroGroup" />
        </div>
        <div class="col-md-6 mb-3">
            <label for="txbEmail" class="form-label">Email <span class="text-danger">*</span></label>
            <asp:TextBox runat="server" ID="txbEmail" CssClass="form-control" placeholder="Email" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txbEmail" CssClass="text-danger d-block" Display="Dynamic" ValidationGroup="LoginGroup" />
            <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txbEmail" CssClass="text-danger d-block" Display="Dynamic" ValidationGroup="LoginGroup" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" />

        </div>
        <div class="col-md-6 mb-3">
            <label for="txbTelefono" class="form-label">Teléfono</label>
            <asp:TextBox runat="server" ID="txbTelefono" CssClass="form-control" placeholder="Teléfono" />
            <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txbTelefono" CssClass="text-danger d-block" EnableClientScript="true" Display="Dynamic" />
        </div>
        <div class="mt-3">
            <asp:Button Text="Crear" ID="btnCrear" CssClass="btn btn-dark mt-3" runat="server" OnClick="btnCrear_Click" ValidationGroup="LoginGroup" CausesValidation="true" />
            <asp:Button Text="Volver" ID="btnVolver" CssClass="btn btn-secondary mt-3" runat="server" OnClick="btnVolver_Click" CausesValidation="false" />
        </div>
    </div>
</asp:Content>
