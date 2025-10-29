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
            MarcaNegocio negocio = new MarcaNegocio();
            DgvMarca.DataSource = negocio.Listar();
            DgvMarca.DataBind();


        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
    }
}