using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_6A
{
    public partial class Compras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }

            if (!IsPostBack)
            {
                CargarCompras();
            }
        }
        private void CargarCompras()
        {
            CompraNegocio negocio = new CompraNegocio();
            DgvCompra.DataSource = negocio.ListarCompras();
            DgvCompra.DataBind();
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
        protected void btnNueva_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarCompra");
        }
        protected void DgvCompra_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detalles")
            {                
                if (int.TryParse(e.CommandArgument?.ToString(), out int idCompra))
                {
                    Response.Redirect($"DetallesCompra.aspx?IdCompra={idCompra}", false);
                }
            }

            if (e.CommandName == "Recibido")
            {
                int idCompra = Convert.ToInt32(e.CommandArgument);

                try
                {
                    CompraNegocio negocio = new CompraNegocio();
                    negocio.RegistrarRecepcionYActualizarStock(idCompra);

                    CargarCompras();
                }
                catch (Exception ex)
                {
                    lblMensajeError.Text = "Error al recibir la compra: " + ex.Message;
                    lblMensajeError.Visible = true;
                }
            }
        }

    }
}