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
                    txtDescripcion.Text = marca.DescripcionMarca;   // tu dominio la tiene
                }
                // si _id <= 0 => es alta, campos vacíos
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
                // 1️⃣ Obtener el ID desde la URL
                int id;
                int.TryParse(Request.QueryString["id"], out id);

                // 2️⃣ Crear la instancia de negocio
                MarcaNegocio negocio = new MarcaNegocio();

                // 3️⃣ Crear y llenar el objeto Marca con los datos del formulario
                Marca marca = new Marca();
                marca.IdMarca = id;
                marca.NombreMarca = txtNombre.Text.Trim();
                marca.DescripcionMarca = txtDescripcion.Text.Trim();

                // 4️⃣ Ejecutar la actualización en base de datos
                negocio.ModificarMarca(marca);

                // 5️⃣ Redirigir al listado
                Response.Redirect("Marcas.aspx");
            }
            catch (Exception ex)
            {
                // 6️⃣ Mostrar cualquier error
                lblMensaje.Text = "Error al modificar la marca: " + ex.Message;
            }
        }

    }
}