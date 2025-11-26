using negocio;
using dominio;
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
                bool mostrarInactivos = chbMostrarTodos.Checked;

                List<Producto> productos = negocio.ListarProductos(mostrarInactivos);
                Session["listaProductos"] = productos;

                DgvProductos.DataSource = productos;
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
                row.FindControl("btnActivar").Visible = false;
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
            if (e.CommandName == "ActivarProducto")
            {
                row.FindControl("btnDetalles").Visible = false;
                row.FindControl("btnBorrar").Visible = false;
                row.FindControl("lblEliminar").Visible = false;
                row.FindControl("btnConfirmar").Visible = false;
                row.FindControl("btnConfirmarActivo").Visible = true;
                row.FindControl("lblActivar").Visible = true;
                row.FindControl("btnCancelar").Visible = true;
                row.FindControl("btnActivar").Visible = false;
            }
            if (e.CommandName == "ConfirmarActivo")
            {

            int idProducto = Convert.ToInt32(DgvProductos.DataKeys[index].Value);

            ProductoNegocio negocio = new ProductoNegocio();
            negocio.eliminarProductoLogico(idProducto, true);

            Response.Redirect("Productos.aspx");
            }

        }

        protected void chbMostrarTodos_CheckedChanged(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();

            bool mostrarInactivos = chbMostrarTodos.Checked;
            List<Producto> productos = negocio.ListarProductos(mostrarInactivos);

            Session["listaProductos"] = productos;
            txtBuscar.Text = string.Empty;

            DgvProductos.DataSource = productos;
            DgvProductos.DataBind();
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Producto> lista = Session["listaProductos"] as List<Producto>;

            if (lista == null)
            {
                ProductoNegocio negocio = new ProductoNegocio();
                bool mostrarInactivos = chbMostrarTodos.Checked;
                lista = negocio.ListarProductos(mostrarInactivos);
                Session["listaProductos"] = lista;
            }

            string filtro = txtBuscar.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(filtro))
            {
                DgvProductos.DataSource = lista;
            }
            else
            {
                var listaFiltrada = lista.Where(p =>
                    (p.NombreProducto != null && p.NombreProducto.ToUpper().Contains(filtro)) ||
                    (p.IdMarca != null && p.IdMarca.NombreMarca != null &&
                        p.IdMarca.NombreMarca.ToUpper().Contains(filtro)) ||
                    (p.IdCategoria != null && p.IdCategoria.NombreCategoria != null &&
                        p.IdCategoria.NombreCategoria.ToUpper().Contains(filtro))
                ).ToList();

                DgvProductos.DataSource = listaFiltrada;
            }

            DgvProductos.DataBind();
        }
    }
}