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
    public partial class AgregarProveedor : System.Web.UI.Page
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
            Response.Redirect("Proveedores");
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            Proveedor proveedor = new Proveedor();
            ProveedorNegocio negocio = new ProveedorNegocio();

            try
            {
                proveedor.Nombre = txtNombre.Text;
                proveedor.Descripcion = txtDescripcion.Text;
                proveedor.Cuit = txtCuit.Text;
                proveedor.Email = txtEmail.Text;
                proveedor.Telefono = txtTelefono.Text;

                negocio.agregarProveedor(proveedor);
                Response.Redirect("Proveedores");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }            
        }
    }
}