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
    public partial class Usuarios : System.Web.UI.Page
    {
        public List<Usuario> ListaUsuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            //Valida que haya un usuario logueado
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }


            UsuarioNegocio negocio = new UsuarioNegocio();
            DgvUsuario.DataSource = negocio.ListarUsuarios();
            DgvUsuario.DataBind();
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro");
        }
        protected void DgvUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detalles")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = DgvUsuario.Rows[index];
                int idUsuario = Convert.ToInt32(DgvUsuario.DataKeys[index].Value);

                // Redirige a la página de edición con el ID del usuario seleccionado
                Response.Redirect("ModificarUsuario.aspx?IdUsuario=" + idUsuario, false);
            }
        }

    }
}