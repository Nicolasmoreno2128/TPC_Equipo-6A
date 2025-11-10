<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="TPC_Equipo_6A.Marcas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card shadow p-4">
                    <h2 class="text-center mb-4">Marcas</h2>


                    <asp:GridView ID="DgvMarca" runat="server" CssClass="table table-striped"
                        AutoGenerateColumns="False"
                        DataKeyNames="IdMarca"
                        OnRowCommand="DgvMarca_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="IdMarca" HeaderText="ID" ReadOnly="True" />
                            <asp:BoundField DataField="NombreMarca" HeaderText="Nombre" />
                            <asp:BoundField DataField="DescripcionMarca" HeaderText="Descripcion" />
                            <asp:ButtonField Text="✏️" CommandName="Detalles" ButtonType="Button" HeaderText="Detalles" />
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
