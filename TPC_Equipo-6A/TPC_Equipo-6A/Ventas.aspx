<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="TPC_Equipo_6A.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class="container mt-5">
     <div class="row justify-content-center">
         <div class="col-md-10">
             <div class="card shadow p-4">
                 <h2 class="text-center mb-4">Ventas</h2>


                 <div class="row justify-content-center mt-3">
                     <div class="col-4 col-md-3">
                         <asp:Button ID="btnAgregarVenta" runat="server" CssClass="btn btn-dark w-100" Text="Agregar" />
                     </div>
                     <div class="col-4 col-md-3">
                         <asp:Button ID="btnModificarVenta" runat="server" CssClass="btn btn-dark w-100" Text="Modificar" CausesValidation="false" />
                     </div>
                     <div class="col-4 col-md-3">
                         <asp:Button ID="btnEliminarVenta" runat="server" CssClass="btn btn-dark w-100" Text="Eliminar" CausesValidation="false" />
                     </div>
                     <div class="col-4 col-md-3">
                         <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-dark w-100" Text="Volver" CausesValidation="false" />
                     </div>
                 </div>
             </div>
         </div>
     </div>
 </div>
</asp:Content>
