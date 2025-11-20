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

            //Valida que haya un usuario logueado
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }


            if (!IsPostBack)
            {
                MarcaNegocio negocio = new MarcaNegocio();
                DgvMarca.DataSource = negocio.ListarMarcas();
                DgvMarca.DataBind();
            }

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
            if (e.CommandName == "Detalles")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                int idMarca = Convert.ToInt32(DgvMarca.DataKeys[indice].Value.ToString());
                Response.Redirect("FormularioMarca.aspx?id=" + idMarca);
            }
            if (e.CommandName == "Borrar")
            {
                int indice = Convert.ToInt32(e.CommandArgument);
                int idMarca = Convert.ToInt32(DgvMarca.DataKeys[indice].Value);

                MarcaNegocio negocio = new MarcaNegocio();
                negocio.eliminarMarcaLogico(idMarca);

                Response.Redirect("Marcas");
            }
        }
    }
    
}