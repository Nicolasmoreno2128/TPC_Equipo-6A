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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriaNegocio negocio = new CategoriaNegocio();
                ddlCategorias.DataSource = negocio.ListarCategoria();
                ddlCategorias.DataTextField = "NombreCategoria";
                ddlCategorias.DataValueField = "IdCategoria";
                ddlCategorias.DataBind();

                ddlCategorias.Items.Insert(0, new ListItem("-- Seleccionar Categoría --", "0"));
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

            int idCategoria = int.Parse(ddlCategorias.SelectedValue);

            CategoriaNegocio negocio = new CategoriaNegocio();
            negocio.eliminarCategoriaLogico(idCategoria);
            Response.Redirect("Categorias");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categorias");
        }
    }
}