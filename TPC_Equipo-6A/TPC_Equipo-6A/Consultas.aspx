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
                <h2>Total recaudado por mes</h2>
                <asp:DropDownList ID="ddlPeriodos" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPeriodos_SelectedIndexChanged" CssClass="form-select w-50 mx-auto my-3 shadow-sm">
                </asp:DropDownList>

                <div class="card w-50 mx-auto my-3 shadow">
                    <div class="card-body text-center">
                        <asp:Label ID="lblResultado" runat="server" CssClass="fw-bold fs-4 text-primary"></asp:Label>
                    </div>
                </div>

            </div>
            <div class="col">
                <h2>Movimientos por productos</h2>
                <asp:DropDownList ID="ddlProducto" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged" CssClass="form-select w-50 mx-auto my-3 shadow-sm">
                </asp:DropDownList>
                <asp:GridView ID="gvMovimientos" runat="server" CssClass="table table-striped" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="Movimiento" HeaderText="Movimiento" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    </Columns>
                </asp:GridView>


                <columns>
                    <asp:BoundField DataField="Producto" HeaderText="Cantidad" ReadOnly="True" />
                    <asp:BoundField DataField="Movimientos" HeaderText="Movimientos producto" ReadOnly="True" />

                </columns>
                </asp:GridView>
            </div>
        </div>
        <div class="d-flex gap-3 mt-3">
            <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-secondary" Text="Volver" CausesValidation="false" OnClick="btnVolver_Click" />

        </div>
    </div>


</asp:Content>
