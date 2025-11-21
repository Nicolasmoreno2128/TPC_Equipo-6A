<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="TPC_Equipo_6A.Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card shadow p-4">
                    <h2 class="text-center mb-4">Categorias</h2>


                    <asp:GridView ID="DgvCategoria" runat="server" CssClass="table table-striped"
                        AutoGenerateColumns="False"
                        DataKeyNames="IdCategoria"
                        OnRowCommand="DgvCategoria_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="IdCategoria" HeaderText="ID" ReadOnly="True" />
                            <asp:BoundField DataField="NombreCategoria" HeaderText="Nombre" />
                            <asp:BoundField DataField="DescripcionCategoria" HeaderText="Descripcion" />
                            <asp:ButtonField Text="📄" CommandName="Detalles" ButtonType="Button" HeaderText="Detalles" />
                            <asp:ButtonField Text="🗑️" CommandName="Borrar" ButtonType="Button" HeaderText="Borrar" />
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
