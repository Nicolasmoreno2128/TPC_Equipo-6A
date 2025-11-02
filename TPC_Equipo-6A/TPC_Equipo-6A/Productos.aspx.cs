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

        protected void DgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProd = (int)DgvProductos.SelectedDataKey.Values["IdProducto"];
            int idMarca = (int)DgvProductos.SelectedDataKey.Values["IdMarcaFk"];
            int idCat = (int)DgvProductos.SelectedDataKey.Values["IdCategoriaFk"];

            Response.Redirect($"default.aspx?IdProducto={idProd}&IdMarcaFk={idMarca}&IdCategoriaFk={idCat}");
        }
    }
}