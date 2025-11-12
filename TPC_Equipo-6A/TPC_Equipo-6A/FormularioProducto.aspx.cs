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
    public partial class ModificarProducto : System.Web.UI.Page
    {
        private readonly ProductoNegocio _productoNegocio = new ProductoNegocio();
        private readonly MarcaNegocio _marcaNegocio = new MarcaNegocio();
        private readonly CategoriaNegocio _categoriaNegocio = new CategoriaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMarcas();
                CargarCategorias();

                // ID por QueryString: ModificarProducto.aspx?id=123
                var idQS = Request.QueryString["IdProducto"];
                if (!string.IsNullOrEmpty(idQS))
                {
                    hfIdProducto.Value = idQS;
                    CargarProducto(int.Parse(idQS));
                }
            }
        }

        private void CargarMarcas()
        {
            var marcas = new MarcaNegocio().ListarMarcas();
            ddlMarcam.DataSource = marcas;
            ddlMarcam.DataTextField = "NombreMarca";
            ddlMarcam.DataValueField = "IdMarca";
            ddlMarcam.DataBind();
            ddlMarcam.Items.Insert(0, new ListItem("-- Seleccioná --", ""));
        }

        private void CargarCategorias()
        {
            var categorias = new CategoriaNegocio().ListarCategoria();
            ddlCategoriam.DataSource = categorias;
            ddlCategoriam.DataTextField = "NombreCategoria";
            ddlCategoriam.DataValueField = "IdCategoria";
            ddlCategoriam.DataBind();
            ddlCategoriam.Items.Insert(0, new ListItem("-- Seleccioná --", ""));
        }

        private void CargarProducto(int id)
        {
            var nego = new ProductoNegocio();
            var p = nego.ObtenerPorId(id);
            if (p == null) return;

            txtNombreProdm.Text = p.NombreProducto;
            txtDescripcionProdm.Text = p.DescripcionProducto;
            txtPrecioProdm.Text = p.PrecioProducto.ToString();
            txtStockProdm.Text = p.Stock.ToString();
            ddlMarcam.SelectedValue = p.IdMarcaFk.ToString();
            ddlCategoriam.SelectedValue = p.IdCategoriaFk.ToString();
            if (!string.IsNullOrEmpty(p.UrlImagen))
            {
                imgProducto.ImageUrl = p.UrlImagen;
            }
            else
            {
                imgProducto.ImageUrl = "~/Images/placeholder.png";
            }
        }

        protected void btnModificarProd_Click(object sender, EventArgs e)
        {
            try
            {
                var p = new Producto
                {
                    IdProducto = int.Parse(hfIdProducto.Value),
                    NombreProducto = txtNombreProdm.Text,
                    DescripcionProducto = txtDescripcionProdm.Text,
                    PrecioProducto = decimal.Parse(txtPrecioProdm.Text),
                    Stock = int.Parse(txtStockProdm.Text),
                    IdMarcaFk = int.Parse(ddlMarcam.SelectedValue),
                    IdCategoriaFk = int.Parse(ddlCategoriam.SelectedValue),
                };

                new ProductoNegocio().Modificar(p);
                Response.Redirect("Productos.aspx", false);
            }
            catch (Exception)
            {
                throw; // durante desarrollo, dejalo así para ver el error exacto
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx", false);
        }

        protected void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                int.TryParse(Request.QueryString["IdProducto"], out id);

                ProductoNegocio negocio = new ProductoNegocio();
                negocio.eliminarProductoLogico(id);
                Response.Redirect("Productos.aspx");
            }
            catch (Exception ex)
            {
                lblMensajeProducto.Text = "Error al modificar el producto: " + ex.Message;
            }
        }
    }
}