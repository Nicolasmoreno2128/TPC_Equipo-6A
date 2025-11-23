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

            if (!IsPostBack)
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                DgvUsuario.DataSource = negocio.ListarUsuarios();
                DgvUsuario.DataBind();
            }
                
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
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = DgvUsuario.Rows[index];
            if (e.CommandName == "Borrar")
            {
                row.FindControl("btnDetalles").Visible = false;
                row.FindControl("btnBorrar").Visible = false;
                row.FindControl("lblEliminar").Visible = true;
                row.FindControl("btnConfirmar").Visible = true;
                row.FindControl("btnCancelar").Visible = true;
            }

            if (e.CommandName == "Confirmar")
            {
                int idUsuario = Convert.ToInt32(DgvUsuario.DataKeys[index].Value);

                UsuarioNegocio negocio = new UsuarioNegocio();
                negocio.eliminarUsuarioLogico(idUsuario);
                Response.Redirect("Usuarios");
            }

            if (e.CommandName == "Cancelar")
            {
                Response.Redirect("Usuarios");
            }

            if (e.CommandName == "Detalles")
            {
                int idUsuario = Convert.ToInt32(DgvUsuario.DataKeys[index].Value);
                Response.Redirect("FormularioUsuario.aspx?id=" + idUsuario);
            }
        }

    }
}