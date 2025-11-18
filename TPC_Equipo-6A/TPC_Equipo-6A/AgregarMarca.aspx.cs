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
    public partial class AgregarMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marcas");
        }
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            Marca marca = new Marca();
            MarcaNegocio negocio = new MarcaNegocio();

            try
            {
                marca.NombreMarca = txtNombre.Text.Trim();
                marca.DescripcionMarca = txtDescripcion.Text.Trim();

                negocio.agregarMarca(marca);

                Response.Redirect("Marcas");
            }
            catch (Exception ex)
            {
                // Mostramos el mensaje de error
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }
        }

    }

}