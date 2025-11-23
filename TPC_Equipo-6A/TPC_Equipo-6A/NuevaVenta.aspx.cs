using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TPC_Equipo_6A
{
    public partial class NuevaVenta : System.Web.UI.Page
    {
        // --- LISTA TEMPORAL DE DETALLES DE LA VENTA ---
        private List<DetalleVenta> Detalles
        {
            get
            {
                if (Session["DetallesVenta"] == null)
                    Session["DetallesVenta"] = new List<DetalleVenta>();

                return (List<DetalleVenta>)Session["DetallesVenta"];
            }
            set
            {
                Session["DetallesVenta"] = value;
            }
        }

        // --- CARGA INICIAL ---
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarClientes();
                cargarProductos();

                lblFechaVenta.Text = DateTime.Now.ToString("dd/MM/yyyy");

                // Usuario (lo ajustás según tu login)
                Usuario user = (Usuario)Session["usuario"];
                if (user != null)
                    lblUsuario.Text = user.NombreUsuario;

                // Apenas carga la página, mostrar stock del primer producto
                ActualizarStockDisponible();

                gvDetalleVenta.DataSource = Detalles;
                gvDetalleVenta.DataBind();
            }
        }

        // --- CARGAR CLIENTES ---
        private void cargarClientes()
        {
            ClienteNegocio negocio = new ClienteNegocio();
            ddlClientes.DataSource = negocio.ListarClientes();
            ddlClientes.DataTextField = "Nombre";
            ddlClientes.DataValueField = "IdCliente";
            ddlClientes.DataBind();
        }

        // --- CARGAR PRODUCTOS ---
        private void cargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            ddlProductos.DataSource = negocio.ListarProductos();
            ddlProductos.DataTextField = "NombreProducto";
            ddlProductos.DataValueField = "IdProducto";
            ddlProductos.DataBind();
        }

        //      BOTÓN AGREGAR PRODUCTO A LA LISTA
        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensajeError.Text = string.Empty;

                int cantidad = int.Parse(ddlCantidad.SelectedValue);
                if (cantidad <= 0)
                {
                    lblMensajeError.Text = "La cantidad debe ser mayor que cero.";
                    return;
                }

                int idProducto = int.Parse(ddlProductos.SelectedValue);

                // Buscar producto
                ProductoNegocio prodNeg = new ProductoNegocio();
                Producto prod = prodNeg.ObtenerPorId(idProducto);

                // Stock total en la base
                int stockTotal = prod.Stock;

                // Cantidad ya agregada de ESTE producto en la venta actual
                int cantidadYaAgregada = Detalles
                    .Where(d => d.IdProducto == idProducto)
                    .Sum(d => d.Cantidad);

                // Stock restante disponible
                int stockRestante = stockTotal - cantidadYaAgregada;

                if (cantidad > stockRestante)
                {
                    lblMensajeError.Text = $"No hay stock suficiente. Stock disponible: {stockRestante}.";
                    return;
                }


                // Crear detalle
                DetalleVenta nuevo = new DetalleVenta
                {
                    IdProducto = prod.IdProducto,
                    Cantidad = cantidad,
                    PrecioUnitario = prod.PrecioProducto,
                    Producto = prod  // Para mostrar el nombre correctamente
                };

                // Agregar a la lista
                Detalles.Add(nuevo);

                // Refrescar la grilla
                gvDetalleVenta.DataSource = Detalles;
                gvDetalleVenta.DataBind();

                // Recalcular total
                recalcularTotal();

                // Actualizar el stock restante y cantidades permitidas
                ActualizarStockDisponible();


            }
            catch (Exception ex)
            {
                lblMensajeError.Text = "Error al agregar producto: " + ex.Message;
            }
        }


        // --- QUITAR PRODUCTO DEL DETALLE ---
        protected void gvDetalleVenta_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            Detalles.RemoveAt(e.RowIndex);

            gvDetalleVenta.DataSource = Detalles;
            gvDetalleVenta.DataBind();

            recalcularTotal();
            ActualizarStockDisponible();
        }


        // --- CALCULAR TOTAL ---
        private void recalcularTotal()
        {
            decimal total = Detalles.Sum(x => x.PrecioUnitario * x.Cantidad);
            lblTotalVenta.Text = "$ " + total.ToString("0.00");
        }

        //      CONFIRMAR VENTA
        protected void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (Detalles.Count == 0)
                {
                    lblMensajeError.Text = "Debe agregar al menos un producto.";
                    return;
                }

                Venta venta = new Venta();

                venta.Cliente = new Cliente { IdCliente = int.Parse(ddlClientes.SelectedValue) };
                venta.FechaVenta = DateTime.Now;
                venta.Detalles = Detalles;
                venta.TotalVenta = Detalles.Sum(x => x.Cantidad * x.PrecioUnitario);
                venta.Estado = true;
                venta.Usuario = (Usuario)Session["usuario"];

                VentaNegocio negocio = new VentaNegocio();
                int idGenerado = negocio.AgregarVenta(venta);

                // LIMPIAR DETALLES
                Session["DetallesVenta"] = null;

                Response.Redirect("Ventas.aspx?alta=ok");
            }
            catch (Exception ex)
            {
                lblMensajeError.Text = "Error al guardar la venta: " + ex.Message;
            }
        }

        // --- CANCELAR ---
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session["DetallesVenta"] = null;
            Response.Redirect("Ventas.aspx");
        }

        private void ActualizarStockDisponible()
        {
            if (ddlProductos.SelectedItem == null)
                return;

            int idProducto = int.Parse(ddlProductos.SelectedValue);

            ProductoNegocio prodNeg = new ProductoNegocio();
            Producto prod = prodNeg.ObtenerPorId(idProducto);

            // Stock total en la base
            int stockTotal = prod.Stock;

            // Cantidad ya agregada de ESTE producto en la venta actual
            int cantidadYaAgregada = Detalles
                .Where(d => d.IdProducto == idProducto)
                .Sum(d => d.Cantidad);

            // Stock restante disponible para seguir agregando
            int stockRestante = stockTotal - cantidadYaAgregada;
            if (stockRestante < 0)
                stockRestante = 0;

            // Mostrar stock en el label (total o restante, como prefieras)
            lblStockDisponible.Text = stockRestante.ToString();

            // Llenar el combo de cantidad según el stock restante
            ddlCantidad.Items.Clear();

            if (stockRestante <= 0)
            {
                ddlCantidad.Items.Add("0");
                ddlCantidad.Enabled = false;
                btnAgregarProducto.Enabled = false;
                return;
            }

            ddlCantidad.Enabled = true;
            btnAgregarProducto.Enabled = true;

            for (int i = 1; i <= stockRestante; i++)
            {
                ddlCantidad.Items.Add(i.ToString());
            }

            // Por defecto, que quede seleccionada la primera opción (1)
            ddlCantidad.SelectedIndex = 0;
        }
        protected void ddlProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarStockDisponible();
        }
    }
}
