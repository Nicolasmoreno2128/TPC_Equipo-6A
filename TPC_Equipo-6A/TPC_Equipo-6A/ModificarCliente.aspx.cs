using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_6A
{
    public partial class WebForm2 : System.Web.UI.Page
    {

        private readonly ClienteNegocio _neg = new ClienteNegocio();
        private int _id;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out _id);

            if (!IsPostBack)
            {
                if (_id > 0)
                {
                    var cliente = _neg.ObtenerPorId(_id);
                    if (cliente == null)
                    {
                        lblMensajeCliente.Text = "Categoria no encontrada.";
                        btnModificarCliente.Enabled = false;
                        return;
                    }

                    txtNombre.Text = cliente.Nombre;
                    txtCuit.Text = cliente.Cuit;
                    txtDescripcion.Text = cliente.Descripcion;
                    txtTelefono.Text = cliente.Telefono;
                    txtEmail.Text = cliente.Email;

                }

            }
        }

        protected void btnModificarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                int.TryParse(Request.QueryString["id"], out id);

                ClienteNegocio negocio = new ClienteNegocio();

                Cliente cliente = new Cliente();
                cliente.IdCliente = id;
                cliente.Nombre = txtNombre.Text.Trim();
                cliente.Cuit = txtCuit.Text.Trim();
                cliente.Descripcion = txtDescripcion.Text.Trim();
                cliente.Telefono= txtTelefono.Text.Trim();
                cliente.Email = txtEmail.Text.Trim();


                negocio.ModificarCliente(cliente);

                Response.Redirect("Clientes.aspx");
            }
            catch (Exception ex)
            {

                lblMensajeCliente.Text = "Error al modificar el cliente: " + ex.Message;
            }
        }

        protected void btnCancelarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("Clientes");
        }
    }
}