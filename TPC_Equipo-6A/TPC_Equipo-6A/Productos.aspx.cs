using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_6A
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               ProductoNegocio negocio = new ProductoNegocio();
                DgvProductos.DataSource = negocio.ListarProductos();
                DgvProductos.DataBind();
            }
            //Valida que haya un usuario logueado
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }            
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProducto.aspx");
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
        protected void DgvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = DgvProductos.Rows[index];
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
                int idProducto = Convert.ToInt32(DgvProductos.DataKeys[index].Value);

                ProductoNegocio negocio = new ProductoNegocio();
                negocio.eliminarProductoLogico(idProducto);
                Response.Redirect("Productos");
            }

            if (e.CommandName == "Cancelar")
            {
                Response.Redirect("Productos");
            }

            if (e.CommandName == "Detalles")
            {
                int idProducto = Convert.ToInt32(DgvProductos.DataKeys[index].Value);
                Response.Redirect("FormularioProducto.aspx?IdProducto=" + idProducto);
            }
        }
    }
}