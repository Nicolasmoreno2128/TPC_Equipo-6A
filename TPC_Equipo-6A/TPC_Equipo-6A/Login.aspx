<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TPC_Equipo_6A.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container vh-50 d-flex justify-content-center align-items-center">
        <div class="col-md-4 text-center">
            <h2 class="mb-4">Login</h2>

            <div class="mb-3">
                <label for="txbUsuario" class="form-label d-block">Usuario</label>
                <asp:TextBox runat="server" ID="txbUsuario" CssClass="form-control mx-auto w-75" placeholder="Usuario" />
                <asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txbUsuario" ErrorMessage="Campo obligatorio." CssClass="text-danger d-block" EnableClientScript="true" Display="Dynamic" ValidationGroup="LoginGroup"/>
            </div>

            <div class="mb-4">
                <label for="txbContraseña" class="form-label d-block">Contraseña</label>
                <asp:TextBox runat="server" ID="txbContraseña" CssClass="form-control mx-auto w-75" placeholder="Contraseña" TextMode="Password" />
                <asp:RequiredFieldValidator ID="rfvContraseña" runat="server" ControlToValidate="txbContraseña" ErrorMessage="Campo obligatorio." CssClass="text-danger d-block" EnableClientScript="true" Display="Dynamic" ValidationGroup="LoginGroup" />
            </div>

            <div class="d-flex justify-content-center gap-2 mt-2">
                <asp:Button Text="Ingresar" ID="btnIngresar" CssClass="btn btn-dark mt-3" runat="server" OnClick="btnIngresar_Click" CausesValidation="false" />
                <asp:Button Text="Volver" ID="btnVolver" CssClass="btn btn-dark mt-3" runat="server" OnClick="btnVolver_Click" CausesValidation="false" />
                <asp:Button Text="Registrarse" ID="btnRegistrarse" CssClass="btn btn-dark mt-3" runat="server" OnClick="btnRegistrarse_Click" CausesValidation="false" />
            </div>
        </div>
        </div>
</asp:Content>

