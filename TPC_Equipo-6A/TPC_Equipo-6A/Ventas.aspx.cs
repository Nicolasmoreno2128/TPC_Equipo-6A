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
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Valida que haya un usuario logueado
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }

            if (!IsPostBack)
            {
                CargarVentas();
            }

            if (Request.QueryString["alta"] == "ok")
            {
                lblMensaje.Text = "La venta se registró correctamente.";
                lblMensaje.CssClass = "text-success fw-bold";
            }
        }
        private void CargarVentas()
        {
            VentaNegocio negocio = new VentaNegocio();
            List<Venta> lista = negocio.ListarVentas();

            Session["listaVentas"] = lista;

            dgvVentas.DataSource = lista;
            dgvVentas.DataBind();
        }

        protected void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("NuevaVenta.aspx");
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void dgvVentas_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvVentas.Rows[index];

            Usuario user = (Usuario)Session["usuario"];


            if (e.CommandName == "Eliminar")
            {
                if (user.Rol != Rol.Administrador)
                {
                    lblMensaje.Text = "No tenés permisos para eliminar ventas.";
                    lblMensaje.CssClass = "text-danger fw-bold";
                    return;
                }

                row.FindControl("btnDetalles").Visible = false;
                row.FindControl("btnBorrar").Visible = false;
                row.FindControl("lblEliminar").Visible = true;
                row.FindControl("btnConfirmar").Visible = true;
                row.FindControl("btnCancelar").Visible = true;
            }

            if (e.CommandName == "Confirmar")
            {
                if (user.Rol != Rol.Administrador)
                {
                    lblMensaje.Text = "No tenés permisos para eliminar ventas.";
                    lblMensaje.CssClass = "text-danger fw-bold";
                    return;
                }

                int idVentas = Convert.ToInt32(dgvVentas.DataKeys[index].Value);
                VentaNegocio negocio = new VentaNegocio();
                negocio.AnularVenta(idVentas);
                Response.Redirect("Ventas");
            }

            if (e.CommandName == "Cancelar")
            {
                Response.Redirect("Ventas");
            }

            if (e.CommandName == "Detalles")
            {
                int idVentas = Convert.ToInt32(dgvVentas.DataKeys[index].Value);
                Response.Redirect("DetalleVentaPage.aspx?IdVenta=" + idVentas);
            }
        }

            protected void txtBuscarVenta_TextChanged(object sender, EventArgs e)
        {
            List<Venta> lista = Session["listaVentas"] as List<Venta>;

            if (lista == null)
            {
                CargarVentas();
                lista = Session["listaVentas"] as List<Venta>;
            }

            string filtro = txtBuscarVenta.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(filtro))
            {
                dgvVentas.DataSource = lista;
            }
            else
            {
                var listaFiltrada = lista.Where(v =>
                    v.IdVenta.ToString().Contains(filtro) ||
                    (v.Cliente != null && v.Cliente.Nombre != null &&
                        v.Cliente.Nombre.ToUpper().Contains(filtro)) ||
                    v.FechaVenta.ToString("dd/MM/yyyy").Contains(filtro)
                ).ToList();

                dgvVentas.DataSource = listaFiltrada;
            }

            dgvVentas.DataBind();
        }
    }
}