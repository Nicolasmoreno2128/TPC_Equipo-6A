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
            dgvVentas.DataSource = negocio.ListarVentas();
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
            if (e.CommandName == "Anular")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int idVenta = Convert.ToInt32(dgvVentas.DataKeys[index].Value);

                VentaNegocio negocio = new VentaNegocio();
                negocio.AnularVenta(idVenta);

                // recargar listado
                CargarVentas();

                lblMensaje.Text = "La venta fue anulada correctamente.";
                lblMensaje.CssClass = "text-warning fw-bold";
            }
        }
    }
}