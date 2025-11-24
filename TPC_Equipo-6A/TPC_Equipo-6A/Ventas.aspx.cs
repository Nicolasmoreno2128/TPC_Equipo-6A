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
    }
}