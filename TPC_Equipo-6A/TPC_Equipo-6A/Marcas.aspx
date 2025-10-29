<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Inherits="TPC_Equipo_6A.Marcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="container mt-5">
     <div class="row justify-content-center">
         <div class="col-md-10">
             <div class="card shadow p-4">
                 <h2 class="text-center mb-4">Marcas</h2>

                 <asp:GridView ID="DgvMarca"  runat="server" CssClass="table" ></asp:GridView>

                 <div class="col-4 col-md-3">
                     <asp:Button ID="btnVolver" runat="server" CssClass="btn btn-dark w-100" Text="Volver" CausesValidation="false" OnClick = "btnVolver_Click" />
                 </div>

             </div>
         </div>
     </div>
 </div>

    

</asp:Content>
