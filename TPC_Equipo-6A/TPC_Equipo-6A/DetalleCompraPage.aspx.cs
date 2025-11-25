using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace TPC_Equipo_6A
{
    public partial class DetalleCompraPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Validar login
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
                return;
            }

            if (!IsPostBack)
            {
                CargarDetalleCompra();
            }
        }

        private void CargarDetalleCompra()
        {
            try
            {
                // Leer IdCompra de la querystring
                string idCompraStr = Request.QueryString["IdCompra"];
                if (string.IsNullOrEmpty(idCompraStr) || !int.TryParse(idCompraStr, out int idCompra))
                {
                    lblError.Text = "No se encontró la compra seleccionada.";
                    lblError.Visible = true;
                    return;
                }

                var negocioCompra = new CompraNegocio();
                var negocioProducto = new ProductoNegocio();

                // Traemos todas las compras y buscamos la que corresponde
                Compra compra = negocioCompra.ListarCompras()
                                            .FirstOrDefault(c => c.idCompra == idCompra);

                if (compra == null)
                {
                    lblError.Text = "La compra no existe o fue eliminada.";
                    lblError.Visible = true;
                    return;
                }

                lblNroCompra.Text = compra.idCompra.ToString();
                lblFechaCompra.Text = compra.FechaCompra.ToString("dd/MM/yyyy");

                if (compra.FechaRecepcion.HasValue)
                    lblFechaRecepcion.Text = compra.FechaRecepcion.Value.ToString("dd/MM/yyyy");
                else
                    lblFechaRecepcion.Text = "Pendiente";

                try
                {
                    var provNeg = new ProveedorNegocio();
                    var proveedor = provNeg.ListarProveedores()
                                           .FirstOrDefault(p => p.IdProveedor == compra.IdProveedor);
                    lblProveedor.Text = proveedor != null ? proveedor.Nombre : $"Id {compra.IdProveedor}";
                }
                catch
                {
                    lblProveedor.Text = $"Id {compra.IdProveedor}";
                }

                // Estado
                lblEstado.Text = compra.Estado ? "Activa" : "Anulada";

                // Total
                lblTotal.Text = compra.TotalCompra.ToString("C");

                // Detalle de productos
                var detalles = negocioCompra.ObtenerDetalles(idCompra);

                var listaVista = new List<dynamic>();

                foreach (var d in detalles)
                {
                    var prod = negocioProducto.ObtenerPorId(d.IdProducto);

                    listaVista.Add(new
                    {
                        ProductoNombre = prod != null ? prod.NombreProducto : $"Id {d.IdProducto}",
                        Cantidad = d.Cantidad,
                        PrecioUnitario = d.PrecioUnitario,
                        Subtotal = d.Cantidad * d.PrecioUnitario
                    });
                }

                gvDetalleCompra.DataSource = listaVista;
                gvDetalleCompra.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al cargar el detalle de la compra: " + ex.Message;
                lblError.Visible = true;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Compras.aspx");
        }
    }
}
