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
            ProveedorNegocio negocio = new ProveedorNegocio();
            DgvProveedores.DataSource = negocio.ListarProveedores();
            DgvProveedores.DataBind();
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
            {
                if (e.CommandName == "Eliminar")
                {
                    int indice = Convert.ToInt32(e.CommandArgument);
                    int idProveedor = Convert.ToInt32(DgvProveedores.DataKeys[indice].Value);


                    ProveedorNegocio negocio = new ProveedorNegocio();
                    negocio.eliminarProveedorLogico(idProveedor);


                    DgvProveedores.DataSource = negocio.ListarProveedores();
                    DgvProveedores.DataBind();
                }
                if (e.CommandName == "Modificar")
                {
                    int indice = Convert.ToInt32(e.CommandArgument);
                    int idProveedor = Convert.ToInt32(DgvProveedores.DataKeys[indice].Value.ToString());
                    Response.Redirect("ModificarProveedor.aspx?id=" + idProveedor);
                }
            }
        }
        


    }
}