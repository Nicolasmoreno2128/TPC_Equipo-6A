using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_6A
{
    public partial class ModificarMarca : System.Web.UI.Page
    {
        private readonly MarcaNegocio _neg = new MarcaNegocio();
        private int _id;
        protected void Page_Load(object sender, EventArgs e)
        {

            //Valida que haya un usuario logueado
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }

            int.TryParse(Request.QueryString["id"], out _id);

            if (!IsPostBack)
            {
                if (_id > 0)
                {
                    var marca = _neg.ObtenerPorId(_id);
                    if (marca == null)
                    {
                        lblMensaje.Text = "Marca no encontrada.";
                        btnModificarMarca.Enabled = false;
                        return;
                    }

                    txtNombre.Text = marca.NombreMarca;
                    txtDescripcion.Text = marca.DescripcionMarca;  
                }
              
            }
        }
        protected void btnCancelarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("Marcas");
        }
        protected void btnModificarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                int.TryParse(Request.QueryString["id"], out id);

                MarcaNegocio negocio = new MarcaNegocio();

                Marca marca = new Marca();
                marca.IdMarca = id;
                marca.NombreMarca = txtNombre.Text.Trim();
                marca.DescripcionMarca = txtDescripcion.Text.Trim();

                negocio.ModificarMarca(marca);

                Response.Redirect("Marcas");
            }
            catch (Exception ex)
            {

                lblMensaje.Text = "Error al modificar la marca: " + ex.Message;
            }
        }

        protected void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                int.TryParse(Request.QueryString["id"], out id);

                MarcaNegocio negocio = new MarcaNegocio();

                Marca marca = new Marca();
                negocio.eliminarMarcaLogico(id);
                Response.Redirect("Marcas");
            }
            catch (Exception ex)
            {

                lblMensaje.Text = "Error al eliminar la marca: " + ex.Message;
            }
        }
    }
}