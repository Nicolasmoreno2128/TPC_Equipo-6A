using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_6A
{
    public partial class AgregarProducto : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMarcas();
                CargarCategorias();
            }
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }
        }

        private void CargarMarcas()
        {
            var marcas = new MarcaNegocio().ListarMarcas();
            ddlMarcan.DataSource = marcas;
            ddlMarcan.DataTextField = "NombreMarca";
            ddlMarcan.DataValueField = "IdMarca";
            ddlMarcan.DataBind();
            ddlMarcan.Items.Insert(0, new ListItem("-- Seleccioná una marca --", ""));
        }

        private void CargarCategorias()
        {
            var categorias = new CategoriaNegocio().ListarCategoria();
            ddlCategorian.DataSource = categorias;
            ddlCategorian.DataTextField = "NombreCategoria";
            ddlCategorian.DataValueField = "IdCategoria";
            ddlCategorian.DataBind();
            ddlCategorian.Items.Insert(0, new ListItem("-- Seleccioná una categoría --", ""));
        }


        protected void btnNuevoProd_Click(object sender, EventArgs e)
        {
            try
            {


                Producto nuevo = new Producto();

                if (txtImagen.HasFile)
                {
                    string ruta = Server.MapPath("~/Images/");
                    string nombreArchivo = "producto-" + txtNombreProdn.Text.Trim() + ".jpg";
                    txtImagen.PostedFile.SaveAs(Path.Combine(ruta, nombreArchivo));
                    nuevo.UrlImagen = "~/Images/" + nombreArchivo;
                }
                else
                {
                    nuevo.UrlImagen = null;
                }


                nuevo.NombreProducto = txtNombreProdn.Text;
                nuevo.DescripcionProducto = txtDescripcionProdn.Text;
                nuevo.PrecioProducto = decimal.Parse(txtPrecioProdn.Text);
                nuevo.Stock = int.Parse(txtStockProdn.Text);
                nuevo.IdMarcaFk = int.Parse(ddlMarcan.SelectedValue);
                nuevo.IdCategoriaFk = int.Parse(ddlCategorian.SelectedValue);
                nuevo.Estado = true;

                ProductoNegocio negocio = new ProductoNegocio();
                negocio.AgregarProducto(nuevo);

                Response.Redirect("Productos.aspx", false);
            }
            catch (Exception ex)
            {
      
                throw;
            }

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }
    }
}