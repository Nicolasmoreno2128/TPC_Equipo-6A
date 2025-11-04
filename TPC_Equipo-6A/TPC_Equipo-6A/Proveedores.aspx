<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Proveedores.aspx.cs" Inherits="TPC_Equipo_6A.Proveedores" %>

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

                    <asp:GridView ID="DgvProveedores" runat="server" CssClass="table table-striped"
                        AutoGenerateColumns="False"
                        DataKeyNames="IdProveedor"
                        OnRowCommand="DgvProveedores_RowCommand"
                        >
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                            <asp:BoundField DataField="Cuit" HeaderText="CUIT" />
                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:ButtonField Text="📝" CommandName="Modificar" ButtonType="Button" />
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEliminar" runat="server"
                                        Text="❌"
                                        CommandName="Eliminar"
                                        CommandArgument='<%# Container.DataItemIndex %>'
                                        CssClass="btn btn-danger btn-sm"
                                        OnClientClick="return confirm('¿Seguro que deseas eliminar este proveedor?');">
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
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
