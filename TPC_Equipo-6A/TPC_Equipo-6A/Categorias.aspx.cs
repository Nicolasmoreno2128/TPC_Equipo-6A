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
            if (!IsPostBack)
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                DgvCategoria.DataSource = negocio.ListarCategoria();
                DgvCategoria.DataBind();
            }

            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
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
            if (e.CommandName == "Detalles")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                int idCategoria = Convert.ToInt32(DgvCategoria.DataKeys[indice].Value.ToString());
                Response.Redirect("FormularioCategoria.aspx?id=" + idCategoria);
            }
            if (e.CommandName == "Borrar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                int idCategoria = Convert.ToInt32(DgvCategoria.DataKeys[indice].Value);

                CategoriaNegocio negocio = new CategoriaNegocio();
                negocio.eliminarCategoriaLogico(idCategoria);

                Response.Redirect("Categorias");
            }
        }
    }
}