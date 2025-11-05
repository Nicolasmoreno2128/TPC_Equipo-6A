using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace TPC_Equipo_6A
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
        protected void btnCrear_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            Usuario usuario = new Usuario();
            UsuarioNegocio negocio = new UsuarioNegocio();

            try
            {
                usuario.NombreUsuario = txbNombreUsuario.Text;
                usuario.Contrasena = txbContraseña.Text;
                usuario.Nombre = txbNombre.Text;
                usuario.Apellido = txbApellido.Text;
                usuario.Rol = Rol.Vendedor;
                usuario.Email = txbEmail.Text;
                usuario.Telefono = txbTelefono.Text;

                negocio.agregarUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw;
            }

            Response.Redirect("~/Default.aspx");
        }
    }
}