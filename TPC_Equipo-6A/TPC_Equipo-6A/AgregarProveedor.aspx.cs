﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Equipo_6A
{
    public partial class AgregarProveedor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Proveedores");
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            Proveedor proveedor = new Proveedor();
            ProveedorNegocio negocio = new ProveedorNegocio();

            try
            {
                proveedor.Nombre = txtNombre.Text;
                proveedor.Descripcion = txtDescripcion.Text;
                proveedor.Cuit = int.Parse(txtCuit.Text);
                proveedor.Email = txtEmail.Text;
                proveedor.Telefono = int.Parse(txtTelefono.Text);

                negocio.agregarProveedor(proveedor);
            }
            catch (Exception ex)
            {
            }
            Response.Redirect("Proveedores");
        }
    }
}