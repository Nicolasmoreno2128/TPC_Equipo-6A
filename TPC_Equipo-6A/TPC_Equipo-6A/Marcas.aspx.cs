using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

using negocio;

namespace TPC_Equipo_6A
{
    public partial class Marcas : System.Web.UI.Page
    {
        public List<Marca> ListaMarca { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }

            if (!IsPostBack)
                cargarGrilla();
        }

        private void cargarGrilla()
        {
            MarcaNegocio negocio = new MarcaNegocio();
            bool mostrar = chbMostrarTodos.Checked;
            DgvMarca.DataSource = negocio.ListarMarcas(mostrar);
            DgvMarca.DataBind();
        }
        protected void chbMostrarTodos_CheckedChanged(object sender, EventArgs e)
        {
            cargarGrilla();
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
        protected void btnNueva_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarMarca");
        }

        protected void DgvMarca_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = DgvMarca.Rows[index];
            if (e.CommandName == "Borrar")
            {
                row.FindControl("btnDetalles").Visible = false;
                row.FindControl("btnBorrar").Visible = false;
                row.FindControl("lblEliminar").Visible = true;
                row.FindControl("btnConfirmar").Visible = true;
                row.FindControl("btnCancelar").Visible = true;
                row.FindControl("btnActivar").Visible = false;
            }

            if (e.CommandName == "Confirmar")
            {
                int idMarca = Convert.ToInt32(DgvMarca.DataKeys[index].Value);

                MarcaNegocio negocio = new MarcaNegocio();
                negocio.eliminarMarcaLogico(idMarca);

                Response.Redirect("Marcas");
            }

            if (e.CommandName == "Cancelar")
            {
                Response.Redirect("Marcas");
            }

            if (e.CommandName == "Detalles")
            {
                int idMarca = Convert.ToInt32(DgvMarca.DataKeys[index].Value);
                Response.Redirect("FormularioMarca.aspx?id=" + idMarca);
            }
            if (e.CommandName == "ActivarMarca")
            {
                row.FindControl("btnDetalles").Visible = false;
                row.FindControl("btnBorrar").Visible = false;
                row.FindControl("lblEliminar").Visible = false;
                row.FindControl("btnConfirmar").Visible = false;
                row.FindControl("btnCancelar").Visible = true;
                row.FindControl("btnActivar").Visible = false;
                row.FindControl("lblActivar").Visible = true;
                row.FindControl("btnConfirmarActivo").Visible = true;
            }

            if (e.CommandName == "ConfirmarActivo")
            {
                int idMarca = Convert.ToInt32(DgvMarca.DataKeys[index].Value);

                MarcaNegocio negocio = new MarcaNegocio();
                negocio.eliminarMarcaLogico(idMarca, true);

                Response.Redirect("Marcas.aspx");
            }
        }

    }

}