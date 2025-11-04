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
            ClienteNegocio negocio = new ClienteNegocio();
            DgvCliente.DataSource = negocio.ListarClientes();
            DgvCliente.DataBind();
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
            if (e.CommandName == "Eliminar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                int idCliente = Convert.ToInt32(DgvCliente.DataKeys[indice].Value);


                ClienteNegocio negocio = new ClienteNegocio();
                negocio.eliminarClienteLogico(idCliente);


                DgvCliente.DataSource = negocio.ListarClientes();
                DgvCliente.DataBind();
            }

            if (e.CommandName == "Modificar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                int idCliente = Convert.ToInt32(DgvCliente.DataKeys[indice].Value.ToString());
                Response.Redirect("ModificarCliente.aspx?id=" + idCliente);
            }
        }
    }
}
