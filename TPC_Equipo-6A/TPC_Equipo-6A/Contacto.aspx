<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TPC_Equipo_6A.Contacto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-10">
                <div class="card shadow p-4">
                    <h2 class="text-center mb-4">📩 Contactanos</h2>
                    <h5 class="text-center mb-4">Tenes alguna duda o pregunta? Dejala aca abajo y nuestro equipo se va a contactar con vos.</h5>

                    <div class="mb-3">
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Tu nombre completo"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="txtEmail" class="form-label">Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="nombre@ejemplo.com"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="txtAsunto" class="form-label">Asunto</label>
                        <asp:TextBox ID="txtAsunto" runat="server" CssClass="form-control" placeholder="Motivo del mensaje"></asp:TextBox>
                    </div>

                    <div class="mb-3">
                        <label for="txtMensaje" class="form-label">Mensaje</label>
                        <asp:TextBox ID="txtMensaje" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" placeholder="Escribí tu mensaje aquí..."></asp:TextBox>
                    </div>

                    <div class="row justify-content-center mt-3">
                        <div class="col-4 col-md-3">
                            <asp:Button ID="btnEnviar" runat="server" CssClass="btn btn-dark w-100" Text="Enviar mensaje" OnClick="btnEnviar_Click"/>
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
