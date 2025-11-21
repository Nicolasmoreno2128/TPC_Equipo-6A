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

        }
        private void CargarVentas()
        {
            VentaNegocio negocio = new VentaNegocio();
            dgvVentas.DataSource = negocio.ListarVentas();
            dgvVentas.DataBind();
        }

    }
}