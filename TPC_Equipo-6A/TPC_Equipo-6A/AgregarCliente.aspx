﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AgregarCliente.aspx.cs" Inherits="TPC_Equipo_6A.AgregarCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container d-flex justify-content-center align-items-center" style="min-height: 70vh;">
        <div class="col-md-4 text-center">
            <h2 class="mb-4">Agregar nuevo cliente</h2>

            <div class="mb-3">
                <asp:TextBox ID="txtNombre" CssClass="form-control mx-auto w-75" placeholder="Nombre del cliente" runat="server" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtDescripcion" CssClass="form-control mx-auto w-75" placeholder="Descripción" runat="server" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtCuit" CssClass="form-control mx-auto w-75" placeholder="CUIT del cliente" runat="server" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtTelefono" CssClass="form-control mx-auto w-75" placeholder="Teléfono del cliente" runat="server" />
            </div>
            <div class="mb-3">
                <asp:TextBox ID="txtEmail" CssClass="form-control mx-auto w-75" placeholder="Email del cliente" runat="server" />
            </div>

            <div class="d-flex justify-content-center gap-3 mt-3">
                <asp:Button Text="Nuevo" ID="btnCrear" OnClick="btnNuevo_Click" CssClass="btn btn-dark" runat="server" />
                <asp:Button Text="Cancelar" ID="btnCancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" runat="server" />
            </div>
        </div>
    </div>

</asp:Content>
