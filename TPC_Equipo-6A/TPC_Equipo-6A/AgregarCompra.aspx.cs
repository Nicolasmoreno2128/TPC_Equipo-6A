using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_6A
{
    public partial class AgregarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProveedores();
                CargarProductos();
            }
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }
        }

        private void CargarProveedores()
        {
            var proveedores = new ProveedorNegocio().ListarProveedores();
            ddlProveedor.DataSource = proveedores;
            ddlProveedor.DataTextField = "Nombre";
            ddlProveedor.DataValueField = "IdProveedor";
            ddlProveedor.DataBind();
            ddlProveedor.Items.Insert(0, new ListItem("-- Seleccioná un proveedor --", ""));
        }

        private void CargarProductos()
        {
            var productos = new ProductoNegocio().ListarProductos();
            ddlProducto.DataSource = productos;
            ddlProducto.DataTextField = "NombreProducto";
            ddlProducto.DataValueField = "IdProducto";
            ddlProducto.DataBind();
            ddlProducto.Items.Insert(0, new ListItem("-- Seleccioná un producto --", ""));
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Compras");
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ddlProducto.SelectedValue) || string.IsNullOrEmpty(txtCantidad.Text))
                return;

            int id = int.Parse(ddlProducto.SelectedValue);
            string nombre = ddlProducto.SelectedItem.Text;
            int cantidad = int.Parse(txtCantidad.Text);

            
            var negocio = new ProductoNegocio();
            var prod = negocio.ObtenerPorId(id);
            decimal precio = prod != null ? prod.PrecioProducto : 0;

            decimal subtotal = cantidad * precio;


            DataTable dt = ProductosSeleccionados;
            dt.Rows.Add(id, nombre, cantidad, precio, subtotal);

            gvProductos.DataSource = dt;
            gvProductos.DataBind();

            txtCantidad.Text = "";
            CalcularTotal();
        }

        private DataTable ProductosSeleccionados
        {
            get
            {
                if (ViewState["ProductosSeleccionados"] == null)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("IdProducto", typeof(int));
                    dt.Columns.Add("Nombre", typeof(string));
                    dt.Columns.Add("Cantidad", typeof(int));
                    dt.Columns.Add("Precio", typeof(decimal));
                    dt.Columns.Add("Subtotal", typeof(decimal));
                    ViewState["ProductosSeleccionados"] = dt;
                }
                return (DataTable)ViewState["ProductosSeleccionados"];
            }
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            var compra = new Compra();
            compra.IdProveedor = int.Parse(ddlProveedor.SelectedValue);
            compra.FechaCompra = DateTime.Parse(txtFecha.Text);
            compra.TotalCompra = CalcularTotal();

            var negocioCompra = new CompraNegocio();
            var negocioDetalle = new DetalleCompraNegocio();

            // PASO 1: Crear compra y obtener ID
            int idCompra = negocioCompra.AgregarCompra(compra);

            // PASO 2: Guardar los detalles
            foreach (DataRow row in ProductosSeleccionados.Rows)
            {
                var detalle = new DetalleCompra();
                detalle.IdCompra = idCompra;
                detalle.IdProducto = (int)row["IdProducto"];
                detalle.Cantidad = (int)row["Cantidad"];
                detalle.PrecioUnitario = (decimal)row["Precio"];

                negocioDetalle.AgregarDetalleCompra(detalle);
            }

            Response.Redirect("Compras.aspx");
        }

        private decimal CalcularTotal()
        {
            DataTable dt = ProductosSeleccionados;

            decimal total = dt.AsEnumerable()
                              .Sum(row => row.Field<decimal>("Subtotal"));

            lblTotal.Text = "TOTAL: " + total.ToString("C");

            return total;
        }
    }
}