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
    public partial class Categorias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }

            if (!IsPostBack)
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                var lista = negocio.ListarCategoria(false);
                DgvCategoria.DataSource = lista;
                DgvCategoria.DataBind();
            }
        }


        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
        protected void btnNueva_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCategoria");
        }

        protected void DgvCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = DgvCategoria.Rows[index];
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
                int idCategoria = Convert.ToInt32(DgvCategoria.DataKeys[index].Value);

                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.eliminarCategoriaLogico(idCategoria);
                Response.Redirect("Categorias");
            }

            if (e.CommandName == "Cancelar")
            {
                Response.Redirect("Categorias");
            }

            if (e.CommandName == "Detalles")
            {
                int idCategoria = Convert.ToInt32(DgvCategoria.DataKeys[index].Value);
                Response.Redirect("FormularioCategoria.aspx?IdCategoria=" + idCategoria);
            }
            if (e.CommandName == "ActivarCategoria")
            {
                row.FindControl("btnDetalles").Visible = false;
                row.FindControl("btnBorrar").Visible = false;
                row.FindControl("lblEliminar").Visible = false;
                row.FindControl("btnConfirmar").Visible = false;
                row.FindControl("btnCancelar").Visible = true;
                row.FindControl("btnActivar").Visible = false;
                row.FindControl("lblActivar").Visible = true;
                row.FindControl("btnConfirmarActivo").Visible = true;
            }

            if (e.CommandName == "ConfirmarActivo")
            {
                int idCategoria = Convert.ToInt32(DgvCategoria.DataKeys[index].Value);

                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.eliminarCategoriaLogico(idCategoria, true);

                Response.Redirect("Categorias.aspx");
            }

        }
        protected void chbMostrarTodos_CheckedChanged(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            bool mostrar = chbMostrarTodos.Checked;

            var lista = negocio.ListarCategoria(mostrar);
            DgvCategoria.DataSource = lista;
            DgvCategoria.DataBind();
        }

    }
}