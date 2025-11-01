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
            DgvProveedor.DataSource = negocio.ListarProveedores();
            DgvProveedor.DataBind();
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgregarPRoveedor");
        }
    }
}