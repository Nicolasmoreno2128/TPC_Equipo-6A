<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="TPC_Equipo_6A.Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div class="container mt-5">
     <div class="row justify-content-center">
         <div class="col-md-10">
             <div class="card shadow p-4">
                 <h2 class="text-center mb-4">Ventas</h2>

                 <asp:Label ID="lblMensaje" runat="server" CssClass="d-block mb-2"></asp:Label>
                 <asp:GridView ID="dgvVentas" runat="server" AutoGenerateColumns="false" DataKeyNames="IdVenta" OnRowCommand="dgvVentas_RowCommand" CssClass="table table-striped mt-3">
                  <Columns>
                        <asp:BoundField DataField="IdVenta" HeaderText="ID" />
                        <asp:BoundField DataField="FechaVenta" HeaderText="Fecha" 
                                        DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="Cliente.Nombre" HeaderText="Cliente" />
                        <asp:BoundField DataField="Usuario.NombreUsuario" HeaderText="Vendedor" />
                        <asp:BoundField DataField="TotalVenta" HeaderText="Total" DataFormatString="{0:C}" />
                        <asp:ButtonField Text="📄" CommandName="Detalles" ButtonType="Button" HeaderText="Detalles" />
                        <asp:ButtonField Text="❌" CommandName="Anular" ButtonType="Button" HeaderText="Anular Venta" />
                    </Columns>
                   </asp:GridView>

                 <div class="row justify-content-center mt-3">
                     <div class="col-4 col-md-3">
                         <asp:Button ID="btnAgregarVenta" runat="server" CssClass="btn btn-dark w-100" Text="Nueva Venta" OnClick="btnAgregarVenta_Click"    />
                     </div>
                     <div class="col-4 col-md-3">
                         <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-dark w-100" Text="Volver" CausesValidation="false" OnClick="btnVolver_Click" />
                     </div>
                 </div>
             </div>
         </div>
     </div>
 </div>
</asp:Content>
