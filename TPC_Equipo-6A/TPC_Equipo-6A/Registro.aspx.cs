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
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }

            if (!IsPostBack)
            {
                ddlRol.DataSource = Enum.GetValues(typeof(Rol));
                ddlRol.DataBind();
            }
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
                usuario.Rol = (Rol)Enum.Parse(typeof(Rol), ddlRol.SelectedValue);
                usuario.Email = txbEmail.Text;
                usuario.Telefono = txbTelefono.Text;
                negocio.agregarUsuario(usuario);
                Response.Redirect("~/Default.aspx");
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                lblError.Visible = true;
            }            
        }
    }
}