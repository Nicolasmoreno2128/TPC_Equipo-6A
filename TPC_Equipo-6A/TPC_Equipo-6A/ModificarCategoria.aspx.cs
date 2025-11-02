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
    public partial class ModificarCategoria : System.Web.UI.Page
    {

        private readonly CategoriaNegocio _neg = new CategoriaNegocio();
        private int _id;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out _id);

            if (!IsPostBack)
            {
                if (_id > 0)
                {
                    var categoria = _neg.ObtenerPorId(_id);
                    if (categoria == null)
                    {
                        lblMensajeCategoria.Text = "Categoria no encontrada.";
                        btnModificarCategoria.Enabled = false;
                        return;
                    }

                    txtNombre.Text = categoria.NombreCategoria;
                    txtDescripcion.Text = categoria.DescripcionCategoria;
                }

            }

        }

        protected void btnCancelarCategoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categorias.aspx");
        }

        protected void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                int id;
                int.TryParse(Request.QueryString["id"], out id);

                CategoriaNegocio negocio = new CategoriaNegocio();

                Categoria categoria = new Categoria();
                categoria.IdCategoria = id;
                categoria.NombreCategoria = txtNombre.Text.Trim();
                categoria.DescripcionCategoria = txtDescripcion.Text.Trim();

                negocio.ModificarCategoria(categoria);

                Response.Redirect("Categorias.aspx");
            }
            catch (Exception ex)
            {

                lblMensajeCategoria.Text = "Error al modificar la Categoria: " + ex.Message;
            }
        }
    }
}

