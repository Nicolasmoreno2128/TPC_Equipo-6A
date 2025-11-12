using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_6A
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();
            try
            {
                if (!Page.IsValid)
                    return; 
                usuario.NombreUsuario = txbUsuario.Text;
                usuario.Contrasena = txbContraseña.Text;

                if (negocio.Loguear(usuario))
                {
                    Session.Add("Usuario", usuario);
                    Response.Redirect("~/Default.aspx");

                }
                else
                {
                    Session.Add("error", "User o Pass incorrectos");
                    Response.Redirect("Error");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registro.aspx");
        }
    }
}