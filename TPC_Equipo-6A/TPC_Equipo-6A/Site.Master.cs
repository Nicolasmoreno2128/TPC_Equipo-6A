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

            Usuario usuario = (Usuario)Session["usuario"];
            if (!IsPostBack)
            {
                if (Session["usuario"] != null)
                {
                    lblNombreUsuario.Text = "Usuario: " + usuario.NombreUsuario;
                    lblRol.Text = "Rol: " + usuario.Rol;
                }
                else
                {
                    lblNoLogueado.Text = "NO HAY USUARIO LOGUEADO";
                }
            }
           
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {

        }
    }
}