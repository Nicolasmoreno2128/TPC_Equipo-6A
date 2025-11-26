<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="TPC_Equipo_6A.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Hubo un problema! </h1>
    <asp:Label Text="text" ID="lblError" runat="server" />

    <div class="col-4 col-md-3">
        <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-dark w-100" Text="Volver" CausesValidation="false" OnClick="btnVolver_Click" />
    </div>



</asp:Content>
