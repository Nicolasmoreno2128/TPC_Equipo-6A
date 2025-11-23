<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="TPC_Equipo_6A.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card shadow p-4">
                    <h2 class="text-center mb-4">Usuarios</h2>

                    <asp:GridView
                        ID="DgvUsuario"
                        runat="server"
                        CssClass="table table-striped"
                        AutoGenerateColumns="False"
                        DataKeyNames="IdUsuario"
                        OnRowCommand="DgvUsuario_RowCommand">

                        <Columns>
                            <asp:BoundField DataField="IdUsuario" HeaderText="ID" ReadOnly="True" />
                            <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                            <asp:BoundField DataField="Rol" HeaderText="Rol" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:Button ID="btnDetalles" runat="server"
                                        Text="📄"
                                        CommandName="Detalles"
                                        CommandArgument="<%# Container.DataItemIndex %>"
                                        CssClass="btn btn-sm border-0 bg-transparent" />
                                    <asp:Button ID="btnBorrar" runat="server"
                                        Text="🗑️"
                                        CommandName="Borrar"
                                        CommandArgument="<%# Container.DataItemIndex %>"
                                        CssClass="btn btn-sm border-0 bg-transparent" />
                                    <asp:Label ID="lblEliminar" runat="server"
                                        Text="Eliminar"
                                        Visible="false"
                                        CssClass="fw-bold text-danger me-2" />
                                    <asp:Button ID="btnConfirmar" runat="server"
                                        Text="✔️"
                                        CommandName="Confirmar"
                                        CommandArgument="<%# Container.DataItemIndex %>"
                                        CssClass="btn btn-sm border-0 bg-transparent"
                                        Visible="false" />
                                    <asp:Button ID="btnCancelar" runat="server"
                                        Text="❌"
                                        CommandName="Cancelar"
                                        CommandArgument="<%# Container.DataItemIndex %>"
                                        CssClass="btn btn-sm border-0 bg-transparent"
                                        Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>


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
