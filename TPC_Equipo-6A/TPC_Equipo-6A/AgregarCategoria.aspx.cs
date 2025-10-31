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
    public partial class AgregarCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categorias");
        }
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Categoria categoria = new Categoria();
            CategoriaNegocio negocio = new CategoriaNegocio();

            try
            {
                categoria.Nombre = txtNombre.Text;
                categoria.Descripcion = txtDescripcion.Text;

                negocio.agregarCategoria(categoria);
            }
            catch (Exception ex)
            {
            }
            Response.Redirect("Categorias");
        }
    }
}