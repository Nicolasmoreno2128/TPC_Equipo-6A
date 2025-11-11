using dominio;
using negocio;
using System;
using System.Web.UI;

namespace TPC_Equipo_6A
{
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        private readonly UsuarioNegocio _usuarioNegocio = new UsuarioNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRoles();

                string idQS = Request.QueryString["IdUsuario"];
                if (!string.IsNullOrEmpty(idQS))
                {
                    hfIdUsuario.Value = idQS;
                    CargarUsuario(int.Parse(idQS));
                }
            }
        }

        private void CargarRoles()
        {
            ddlRol.DataSource = Enum.GetValues(typeof(Rol));
            ddlRol.DataBind();
            ddlRol.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Seleccioná un rol --", ""));
        }

        private void CargarUsuario(int id)
        {
            Usuario usuario = _usuarioNegocio.ObtenerPorId(id);
            if (usuario == null) return;

            txbNombreUsuario.Text = usuario.NombreUsuario;
            txbNombre.Text = usuario.Nombre;
            txbApellido.Text = usuario.Apellido;
            txbEmail.Text = usuario.Email;
            txbTelefono.Text = usuario.Telefono;
            ddlRol.SelectedValue = usuario.Rol.ToString();
            ddlEstado.SelectedValue = usuario.Estado ? "true" : "false";
        }

        protected void btnModificarUsuario_Click(object sender, EventArgs e)
        {


            try
            {
                // Validación de contraseñas
                string contrasena = txtContrasena.Text.Trim();
                string repetir = txtRepetirContrasena.Text.Trim();

                if (!string.IsNullOrEmpty(contrasena) || !string.IsNullOrEmpty(repetir))
                {
                    if (string.IsNullOrEmpty(contrasena) || string.IsNullOrEmpty(repetir))
                    {
                        lblMensajeUsuario.Text = "Debes completar ambos campos de contraseña.";
                        lblMensajeUsuario.CssClass = "text-danger";
                        return;
                    }

                    if (contrasena != repetir)
                    {
                        lblMensajeUsuario.Text = "Las contraseñas no coinciden.";
                        lblMensajeUsuario.CssClass = "text-danger";
                        return;
                    }
                }

                Usuario usuario = new Usuario
                {
                    IdUsuario = int.Parse(hfIdUsuario.Value),
                    NombreUsuario = txbNombreUsuario.Text,
                    Nombre = txbNombre.Text,
                    Apellido = txbApellido.Text,
                    Email = txbEmail.Text,
                    Telefono = txbTelefono.Text,
                    Rol = (Rol)Enum.Parse(typeof(Rol), ddlRol.SelectedValue),
                    Estado = bool.Parse(ddlEstado.SelectedValue)
                };
                if (!string.IsNullOrEmpty(contrasena))
                    usuario.Contrasena = contrasena;

                new UsuarioNegocio().Modificar(usuario);
                Response.Redirect("Usuarios.aspx", false);
            }
            catch (Exception ex)
            {
                lblMensajeUsuario.Text = "Error al modificar el usuario: " + ex.Message;
                lblMensajeUsuario.CssClass = "text-danger";
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx", false);
        }
    }
}
