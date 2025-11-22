<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="TPC_Equipo_6A.Consultas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Informes </h1>

    <div class="container text-center">
        <div class="row">
            <div class="col">
                <h2>Compras por clientes </h2>

                <asp:GridView ID="gvComprasCliente" runat="server" CssClass="table table-striped"
                    AutoGenerateColumns="False"
                    DataKeyNames="idCliente">

                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Cliente" ReadOnly="True" />
                        <asp:BoundField DataField="CantidadCompras" HeaderText="Cantidad de Compras" ReadOnly="True" />

                    </Columns>
                </asp:GridView>

            </div>
            <div class="col">
                Column
            </div>
            <div class="col">
                Column
            </div>
        </div>
    </div>


</asp:Content>
