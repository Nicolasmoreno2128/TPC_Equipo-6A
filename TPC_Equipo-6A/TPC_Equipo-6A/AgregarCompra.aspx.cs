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
        // DataTable en ViewState con los productos de la compra
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

        protected void Page_Load(object sender, EventArgs e)
        {
            // Validar login primero
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
                return;
            }

            if (!IsPostBack)
            {
                CargarProveedores();
                CargarProductos();

                // Fecha por defecto: hoy
                txtFecha.Text = DateTime.Now.ToString("yyyy-MM-dd");

                // Total inicial
                lblTotal.Text = "TOTAL: " + 0m.ToString("C");
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
            Response.Redirect("Compras.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblError.Text = string.Empty;

            // Validar producto
            if (string.IsNullOrEmpty(ddlProducto.SelectedValue))
            {
                lblError.Text = "Seleccioná un producto.";
                lblError.Visible = true;
                return;
            }

            // Validar cantidad
            if (string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                lblError.Text = "Ingresá una cantidad.";
                lblError.Visible = true;
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                lblError.Text = "La cantidad debe ser un número mayor que cero.";
                lblError.Visible = true;
                return;
            }

            int id = int.Parse(ddlProducto.SelectedValue);
            string nombre = ddlProducto.SelectedItem.Text;

            var negocio = new ProductoNegocio();
            var prod = negocio.ObtenerPorId(id);
            decimal precio = prod != null ? prod.PrecioProducto : 0m;

            decimal subtotal = cantidad * precio;

            DataTable dt = ProductosSeleccionados;
            dt.Rows.Add(id, nombre, cantidad, precio, subtotal);

            gvProductos.DataSource = dt;
            gvProductos.DataBind();

            txtCantidad.Text = string.Empty;
            ddlProducto.SelectedIndex = 0;

            CalcularTotal();
        }

        protected void btnCrear_Click(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblError.Text = string.Empty;

            // Validar proveedor
            if (string.IsNullOrEmpty(ddlProveedor.SelectedValue))
            {
                lblError.Text = "Seleccioná un proveedor.";
                lblError.Visible = true;
                return;
            }

            // Validar fecha
            if (string.IsNullOrWhiteSpace(txtFecha.Text))
            {
                lblError.Text = "Ingresá la fecha de la compra.";
                lblError.Visible = true;
                return;
            }

            if (!DateTime.TryParse(txtFecha.Text, out DateTime fechaCompra))
            {
                lblError.Text = "La fecha de la compra no es válida.";
                lblError.Visible = true;
                return;
            }

            // Validar que haya al menos un producto
            if (ProductosSeleccionados.Rows.Count == 0)
            {
                lblError.Text = "Agregá al menos un producto a la compra.";
                lblError.Visible = true;
                return;
            }

            // Armar objeto compra
            var compra = new Compra();
            compra.IdProveedor = int.Parse(ddlProveedor.SelectedValue);
            compra.FechaCompra = fechaCompra;
            compra.TotalCompra = CalcularTotal();
            compra.Estado = true; // compra activa

            var negocioCompra = new CompraNegocio();
            var negocioDetalle = new DetalleCompraNegocio();

            // PASO 1: Crear compra y obtener ID
            int idCompra = negocioCompra.AgregarCompra(compra);

            // PASO 2: Guardar los detalles y actualizar stock
            foreach (DataRow row in ProductosSeleccionados.Rows)
            {
                var detalle = new DetalleCompra();
                detalle.IdCompra = idCompra;
                detalle.IdProducto = (int)row["IdProducto"];
                detalle.Cantidad = (int)row["Cantidad"];
                detalle.PrecioUnitario = (decimal)row["Precio"];

                negocioDetalle.AgregarDetalleCompra(detalle);

                // SUMAR STOCK del producto
                negocioCompra.ActualizarStockProducto(detalle.IdProducto, detalle.Cantidad);
            }

            // Limpiar productos seleccionados
            ViewState["ProductosSeleccionados"] = null;

            // Redirigir al listado de compras (podés agregar querystring ?alta=ok si querés mensaje)
            Response.Redirect("Compras.aspx");
        }

        private decimal CalcularTotal()
        {
            DataTable dt = ProductosSeleccionados;

            decimal total = 0m;

            if (dt.Rows.Count > 0)
            {
                total = dt.AsEnumerable()
                          .Sum(row => row.Field<decimal>("Subtotal"));
            }

            lblTotal.Text = "TOTAL: " + total.ToString("C");
            return total;
        }
    }
}
