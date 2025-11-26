using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;

namespace TPC_Equipo_6A
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            EmailService email = new EmailService();
            email.armarCorreo(txtEmail.Text);
            email.enviarEmail();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login");
        }
    }
}