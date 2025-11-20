using negocio;
using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_6A
{
    public partial class AgregarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProveedores();
            }
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }
        }

        private void CargarProveedores()
        {
            var proveedores = new ProveedorNegocio().ListarProveedores();
            ddlProveedor.DataSource = proveedores;
            ddlProveedor.DataTextField = "Nombre";
            ddlProveedor.DataValueField = "IdProveedor";
            ddlProveedor.DataBind();
            ddlProveedor.Items.Insert(0, new ListItem("-- Seleccioná un proveedor --", ""));
        }



        protected void btnCrear_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Compras");
        }


        protected void btnAgregarProd_Click(object sender, EventArgs e)
        {

        }
    }
}