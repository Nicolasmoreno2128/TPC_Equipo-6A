<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Compras.aspx.cs" Inherits="TPC_Equipo_6A.Compras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card shadow p-4">
                    <h2 class="text-center mb-4">Compras</h2>

                    <asp:GridView ID="DgvCompra" runat="server" CssClass="table table-striped"
                        AutoGenerateColumns="False"
                        DataKeyNames="idCompra"
                        OnRowCommand="DgvCompra_RowCommand">

                        <Columns>
                            <asp:BoundField DataField="idCompra" HeaderText="ID" ReadOnly="True" />

                            <asp:BoundField DataField="FechaCompra" HeaderText="Fecha de Compra"
                                DataFormatString="{0:dd/MM/yyyy}" />

                            <asp:TemplateField HeaderText="Proveedor">
                                <ItemTemplate>
                                    <%# Eval("Proveedor.Nombre") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Recepción">
                                <ItemTemplate>
                                    <%# Eval("FechaRecepcion", "{0:dd/MM/yyyy}") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:BoundField DataField="TotalCompra" HeaderText="Total"
                                DataFormatString="{0:C}" />
                           
                            <asp:TemplateField HeaderText="Detalles">
                                <ItemTemplate>
                                    <asp:Button runat="server"
                                        Text="✏️"
                                        CssClass="btn btn-sm btn-outline-primary"
                                        CommandName="Detalles"
                                        CommandArgument='<%# Eval("idCompra") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                    </asp:GridView>

                    <div class="d-flex gap-3 mt-3">
                        <asp:Button ID="btnNueva" runat="server" CssClass="btn btn-dark" Text="Nueva"
                            CausesValidation="false" OnClick="btnNueva_Click" />
                        <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-secondary" Text="Volver"
                            CausesValidation="false" OnClick="btnVolver_Click" />

                    </div>

                </div>

            </div>
        </div>
    </div>
</asp:Content>
