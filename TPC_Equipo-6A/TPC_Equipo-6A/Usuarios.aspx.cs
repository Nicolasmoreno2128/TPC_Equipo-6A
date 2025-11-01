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
    }
}