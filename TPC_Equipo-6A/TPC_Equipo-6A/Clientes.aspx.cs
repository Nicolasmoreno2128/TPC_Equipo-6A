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
    public partial class Clientes : System.Web.UI.Page
    {
        public List<Cliente> ListaCliente { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }

            if (!IsPostBack)      
            {
                ClienteNegocio negocio = new ClienteNegocio();
                DgvCliente.DataSource = negocio.ListarClientes();
                DgvCliente.DataBind();
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCliente");
        }

        protected void DgvCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = DgvCliente.Rows[index];
            if (e.CommandName == "Borrar")
            {
                row.FindControl("btnDetalles").Visible = false;
                row.FindControl("btnBorrar").Visible = false;
                row.FindControl("lblEliminar").Visible = true;
                row.FindControl("btnConfirmar").Visible = true;
                row.FindControl("btnCancelar").Visible = true;
            }

            if (e.CommandName == "Confirmar")
            {
                int idCliente = Convert.ToInt32(DgvCliente.DataKeys[index].Value);

                ClienteNegocio negocio = new ClienteNegocio();
                negocio.eliminarClienteLogico(idCliente);

                Response.Redirect("Clientes");
            }

            if (e.CommandName == "Cancelar")
            {
                Response.Redirect("Clientes");
            }

            if (e.CommandName == "Detalles")
            {
                int idCliente = Convert.ToInt32(DgvCliente.DataKeys[index].Value);
                Response.Redirect("FormularioCliente.aspx?id=" + idCliente);
            }
        }
    }
}
