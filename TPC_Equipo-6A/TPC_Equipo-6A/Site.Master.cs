using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_6A
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    Usuario usuario = (Usuario)Session["usuario"];
                    lblNombreUsuario.Text = "Usuario: " + usuario.NombreUsuario;
                    lblRol.Text = "Rol: " + usuario.Rol;

                    lblNombreUsuario.Visible = true;
                    lblRol.Visible = true;
                    btnCerrar.Visible = true;

                    lblNoLogueado.Visible = false;
                }
                else
                {
                    lblNoLogueado.Text = "NO HAY USUARIO LOGUEADO";
                    lblNoLogueado.Visible = true;

                    lblNombreUsuario.Visible = false;
                    lblRol.Visible = false;
                    btnCerrar.Visible = false;
                }
            }
           
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
        
            Session.Clear();
            Session.Abandon();

  
            Response.Redirect("Login", false);
        }
    }
}