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
    public partial class Proveedores : System.Web.UI.Page
    {
        public List<Proveedor> ListaProveedor { get; set; }
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
                ProveedorNegocio negocio = new ProveedorNegocio();
                DgvProveedores.DataSource = negocio.ListarProveedores();
                DgvProveedores.DataBind();
            }
                
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarProveedor");
        }

        protected void DgvProveedores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = DgvProveedores.Rows[index];
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
                int idProveedor = Convert.ToInt32(DgvProveedores.DataKeys[index].Value);

                ProveedorNegocio negocio = new ProveedorNegocio();
                negocio.eliminarProveedorLogico(idProveedor);
                Response.Redirect("Proveedores");
            }

            if (e.CommandName == "Cancelar")
            {
                Response.Redirect("Proveedores");
            }

            if (e.CommandName == "Detalles")
            {
                int idProveedor = Convert.ToInt32(DgvProveedores.DataKeys[index].Value);
                Response.Redirect("FormularioProveedor.aspx?id=" + idProveedor);
            }
        }
        


    }
}