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
            ProductoNegocio negocio = new ProductoNegocio();
            DgvProductos.DataSource = negocio.ListarProductos();
            DgvProductos.DataBind();
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
            if (e.CommandName == "Detalles")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                int idProducto = Convert.ToInt32(DgvProductos.DataKeys[indice].Value.ToString());
                int idMarca = Convert.ToInt32(DgvProductos.DataKeys[indice].Values["IdMarcaFk"]);
                int idCat = Convert.ToInt32(DgvProductos.DataKeys[indice].Values["IdCategoriaFk"]);
                Response.Redirect($"FormularioProducto.aspx?IdProducto={idProducto}&IdMarcaFk={idMarca}&IdCategoriaFk={idCat}");

            }
        }
    }
}