using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_6A
{
    public partial class AgregarCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes");
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteNegocio negocio = new ClienteNegocio();

            try
            {
                cliente.Nombre = txtNombre.Text;
                cliente.Descripcion = txtDescripcion.Text;
                cliente.Cuit = txtCuit.Text;
                cliente.Email = txtEmail.Text;
                cliente.Telefono = txtTelefono.Text;

                negocio.agregarCliente(cliente);
                Response.Redirect("Clientes");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
            
        }
    }
}
