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

    public partial class WebForm1 : System.Web.UI.Page
    {
        private readonly ProveedorNegocio _neg = new ProveedorNegocio();
        private int _id;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out _id);

            if (!IsPostBack)
            {
                if (_id > 0)
                {
                    var proveedor = _neg.ObtenerPorId(_id);
                    if (proveedor == null)
                    {
                        lblMensajeProveedor.Text = "Categoria no encontrada.";
                        btnModificarProveedor.Enabled = false;
                        return;
                    }

                    txtNombre.Text = proveedor.Nombre;
                    txtCuit.Text = proveedor.Cuit;
                    txtDescripcion.Text = proveedor.Descripcion;
                    txtTelefono.Text = proveedor.Telefono;
                    txtEmail.Text = proveedor.Email;

                }

            }
        }

        protected void btnModificarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                int.TryParse(Request.QueryString["id"], out id);

                ProveedorNegocio negocio = new ProveedorNegocio();

                Proveedor proveedor = new Proveedor();
                proveedor.IdProveedor = id;
                proveedor.Nombre = txtNombre.Text.Trim();
                proveedor.Cuit = txtCuit.Text.Trim();
                proveedor.Descripcion = txtDescripcion.Text.Trim();
                proveedor.Telefono = txtTelefono.Text.Trim();
                proveedor.Email = txtEmail.Text.Trim();


                negocio.ModificarProveedor(proveedor);

                Response.Redirect("Proveedores.aspx");
            }
            catch (Exception ex)
            {

                lblMensajeProveedor.Text = "Error al modificar el proveedor: " + ex.Message;
            }
        }

        protected void btnEliminarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                int.TryParse(Request.QueryString["id"], out id);

                ProveedorNegocio negocio = new ProveedorNegocio();
                negocio.eliminarProveedorLogico(id);
                Response.Redirect("Proveedores.aspx");
            }
            catch (Exception ex)
            {

                lblMensajeProveedor.Text = "Error al modificar el proveedor: " + ex.Message;
            }
        }

        protected void btnCancelarProveedor_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores");
        }
    }
}