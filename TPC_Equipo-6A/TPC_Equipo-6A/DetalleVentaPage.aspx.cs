using dominio;
using negocio;
using System;
using System.Web.UI;

namespace TPC_Equipo_6A
{
    public partial class DetalleVentaPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Validar login
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }

            if (!IsPostBack)
            {
                string idStr = Request.QueryString["IdVenta"];
                int idVenta;

                if (string.IsNullOrEmpty(idStr) || !int.TryParse(idStr, out idVenta))
                {
                    Session["error"] = "Venta no válida.";
                    Response.Redirect("Ventas.aspx");
                    return;
                }

                CargarVenta(idVenta);
                CargarDetalle(idVenta);
            }
        }

        private void CargarVenta(int idVenta)
        {
            VentaNegocio negocio = new VentaNegocio();
            Venta venta = negocio.ObtenerVentaPorId(idVenta);

            if (venta == null)
            {
                lblError.Text = "No se encontró la venta seleccionada.";
                lblError.Visible = true;
                return;
            }

            lblNroVenta.Text = venta.IdVenta.ToString();
            lblFecha.Text = venta.FechaVenta.ToString("dd/MM/yyyy");
            lblCliente.Text = venta.Cliente.Nombre;
            lblUsuario.Text = venta.Usuario.NombreUsuario;
            lblTotal.Text = venta.TotalVenta.ToString("C");

            if (venta.Estado)
            {
                lblEstado.Text = "Activa";
                lblEstado.CssClass = "badge bg-success";
            }
            else
            {
                lblEstado.Text = "Anulada";
                lblEstado.CssClass = "badge bg-warning text-dark";
            }
        }

        private void CargarDetalle(int idVenta)
        {
            VentaNegocio negocio = new VentaNegocio();
            gvDetalleVenta.DataSource = negocio.ListarDetallesPorVenta(idVenta);
            gvDetalleVenta.DataBind();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ventas.aspx");
        }
    }
}
