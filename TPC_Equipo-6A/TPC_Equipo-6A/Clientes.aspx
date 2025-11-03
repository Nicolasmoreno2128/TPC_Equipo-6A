<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TPC_Equipo_6A.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card shadow p-4">
                    <h2 class="text-center mb-4">Clientes</h2>

                    <div class="d-flex justify-content gap-2">
                        <asp:Button ID="btnNuevo" runat="server" CssClass="btn btn-dark" Text="Nuevo"
                            CausesValidation="false" OnClick="btnNuevo_Click" />
                    </div>

                    <asp:GridView ID="DgvCliente" runat="server" CssClass="table table-striped"
                        AutoGenerateColumns="False"
                        DataKeyNames="IdCliente" 
                        OnRowCommand="DgvCliente_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                            <asp:BoundField DataField="Cuit" HeaderText="CUIT" />
                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:ButtonField Text="📝" CommandName="Modificar" ButtonType="Button" />
                            <asp:ButtonField Text="❌" CommandName="Eliminar" ButtonType="Button" />
                        </Columns>
                    </asp:GridView>
                    <div class="d-flex gap-3 mt-3">
                        <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-secondary" Text="Volver"
                            CausesValidation="false" OnClick="btnVolver_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
