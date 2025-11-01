<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC_Equipo_6A.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card shadow p-4">
                    <h2 class="text-center mb-4">Clientes</h2>

                    <asp:GridView ID="DgvCliente" runat="server" CssClass="table"></asp:GridView>
                    <div class="d-flex gap-3 mt-3">
                        <asp:Button ID="btnNuevo" runat="server" CssClass="btn btn-dark" Text="Nuevo"
                            CausesValidation="false" OnClick="btnNuevo_Click" />
                        <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-secondary" Text="Volver"
                            CausesValidation="false" OnClick="btnVolver_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
