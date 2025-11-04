<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_Equipo_6A._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- DESPUES PONER EN UNA HOJA DE ESTILOS -->
<style>
    .menu-btn {
        display: inline-block;
        background-color: white;
        border: 2px solid #212529;
        border-radius: 12px;
        font-weight: 700;               
        font-size: 1.1rem;           
        padding: 1.5rem;
        color: #212529 !important;
        text-decoration: none;
        transition: all 0.3s ease;
        width: 100%;
    }

    .menu-btn:hover {
        background-color: #212529;
        color: white !important;
        transform: scale(1.05);
        box-shadow: 0 4px 12px rgba(0, 0, 0, 0.3);
    }
</style>

<div class="bg-dark bg-opacity-50 p-5 rounded text-center text-white shadow-lg">
    <h1 class="fw-bold display-4 mb-3">Sistema de Gestión de Colchones</h1>
    <p class="lead mb-0">Administrá tus productos, clientes, proveedores y más desde un solo lugar</p>
</div>

<div class="container mt-5">
    <div class="row text-center g-4 justify-content-center">

        <div class="col-md-3 col-sm-6">
            <asp:LinkButton ID="btnMarcas" runat="server"
                CssClass="menu-btn"
                PostBackUrl="Marcas.aspx">
                <i class="bi bi-bookmark-star fs-1 mb-2 d-block"></i>
                MARCAS
            </asp:LinkButton>
        </div>
        <div class="col-md-3 col-sm-6">
            <asp:LinkButton ID="btnProd" runat="server"
                CssClass="menu-btn"
                PostBackUrl="Productos.aspx">
                <i class="bi bi-bookmark-star fs-1 mb-2 d-block"></i>
                PRODUCTOS
            </asp:LinkButton>
        </div>

        <div class="col-md-3 col-sm-6">
            <asp:LinkButton ID="btnCategorias" runat="server"
                CssClass="menu-btn"
                PostBackUrl="Categorias.aspx">
                <i class="bi bi-tags fs-1 mb-2 d-block"></i>
                CATEGORÍAS
            </asp:LinkButton>
        </div>

        <div class="col-md-3 col-sm-6">
            <asp:LinkButton ID="btnClientes" runat="server"
                CssClass="menu-btn"
                PostBackUrl="Clientes.aspx">
                <i class="bi bi-people fs-1 mb-2 d-block"></i>
                CLIENTES
            </asp:LinkButton>
        </div>

        <div class="col-md-3 col-sm-6">
            <asp:LinkButton ID="btnProveedores" runat="server"
                CssClass="menu-btn"
                PostBackUrl="Proveedores.aspx">
                <i class="bi bi-truck fs-1 mb-2 d-block"></i>
                PROVEEDORES
            </asp:LinkButton>
        </div>

        <div class="col-md-3 col-sm-6">
            <asp:LinkButton ID="btnUsuarios" runat="server"
                CssClass="menu-btn"
                PostBackUrl="Usuarios.aspx">
                <i class="bi bi-person-badge fs-1 mb-2 d-block"></i>
                USUARIOS
            </asp:LinkButton>
        </div>

        <div class="col-md-3 col-sm-6">
            <asp:LinkButton ID="btnCompras" runat="server"
                CssClass="menu-btn"
                PostBackUrl="Compras.aspx">
                <i class="bi bi-cart-check fs-1 mb-2 d-block"></i>
                COMPRAS
            </asp:LinkButton>
        </div>

        <div class="col-md-3 col-sm-6">
            <asp:LinkButton ID="btnVentas" runat="server"
                CssClass="menu-btn"
                PostBackUrl="Ventas.aspx">
                <i class="bi bi-receipt fs-1 mb-2 d-block"></i>
                VENTAS
            </asp:LinkButton>
        </div>

        <div class="col-md-3 col-sm-6">
            <asp:LinkButton ID="btnInformes" runat="server"
                CssClass="menu-btn"
                PostBackUrl="Consultas.aspx">
                <i class="bi bi-graph-up fs-1 mb-2 d-block"></i>
                INFORMES
            </asp:LinkButton>
        </div>

    </div>
</div>



</asp:Content>
