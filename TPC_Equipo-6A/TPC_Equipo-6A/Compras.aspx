<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="TPC_Equipo_6A.Compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card shadow p-4">
                    <h2 class="text-center mb-4">Compras</h2>

                    <asp:GridView ID="DgvCompras" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" DataKeyNames="idCompra" OnRowCommand="DgvCompras_RowCommand"  OnRowDataBound="DgvCompras_RowDataBound">

                        <Columns>
                            <asp:BoundField DataField="idCompra" HeaderText="ID" ReadOnly="True" />

                            <asp:BoundField DataField="FechaCompra" HeaderText="Fecha de Compra" DataFormatString="{0:dd/MM/yyyy}" />

                            <asp:TemplateField HeaderText="Proveedor">
                                <ItemTemplate>
                                    <%# Eval("IdProveedor") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Recepción">
                                <ItemTemplate>
                                    <%# Eval("FechaRecepcion") == null ? "" : 
                                     String.Format("{0:dd/MM/yyyy}", Eval("FechaRecepcion")) %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TotalCompra" HeaderText="Total" DataFormatString="{0:C}" />

                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:Button ID="btnDetalle" runat="server" Text="📄" CommandName="Detalle" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-sm border-0 bg-transparent" />
                                    <asp:Button ID="btnRecepcionar" runat="server" Text="📦" CommandName="Recepcionar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-sm border-0 bg-transparent" />
                                    <asp:Button ID="btnBorrar" runat="server" Text="🗑️" CommandName="Borrar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-sm border-0 bg-transparent" />
                                    <asp:Label ID="lblAccion" runat="server" Visible="false" CssClass="fw-bold text-danger me-2" />
                                    <asp:Button ID="btnConfirmar" runat="server" Text="✔️" CommandName="Confirmar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-sm border-0 bg-transparent" Visible="false" />
                                    <asp:Button ID="btnCancelar" runat="server" Text="❌" CommandName="Cancelar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-sm border-0 bg-transparent" Visible="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <div class="d-flex gap-3 mt-3">
                        <asp:Button ID="btnNueva" runat="server" CssClass="btn btn-dark" Text="Nueva" CausesValidation="false" OnClick="btnNueva_Click" />
                        <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-secondary" Text="Volver" CausesValidation="false" OnClick="btnVolver_Click" />

                    </div>

                    <div class="mt-3">
                        <asp:Label ID="lblMensajeError" runat="server" CssClass="text-danger"></asp:Label>
                    </div>

                </div>

            </div>
        </div>
    </div>
</asp:Content>
