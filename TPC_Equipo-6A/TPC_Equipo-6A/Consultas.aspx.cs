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
    public partial class Consultas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session.Add("error", "Debes loguearte para ingresar");
                Response.Redirect("Login");
            }
            var reporte = new InformeNegocio().TopClientesCompras();
            gvComprasCliente.DataSource = reporte;
            gvComprasCliente.DataBind();

            if (!IsPostBack)
            {
                ddlPeriodos.Items.Clear();

                ddlPeriodos.Items.Add(new ListItem("Enero", "1"));
                ddlPeriodos.Items.Add(new ListItem("Febrero", "2"));
                ddlPeriodos.Items.Add(new ListItem("Marzo", "3"));
                ddlPeriodos.Items.Add(new ListItem("Abril", "4"));
                ddlPeriodos.Items.Add(new ListItem("Mayo", "5"));
                ddlPeriodos.Items.Add(new ListItem("Junio", "6"));
                ddlPeriodos.Items.Add(new ListItem("Julio", "7"));
                ddlPeriodos.Items.Add(new ListItem("Agosto", "8"));
                ddlPeriodos.Items.Add(new ListItem("Septiembre", "9"));
                ddlPeriodos.Items.Add(new ListItem("Octubre", "10"));
                ddlPeriodos.Items.Add(new ListItem("Noviembre", "11"));
                ddlPeriodos.Items.Add(new ListItem("Diciembre", "12"));

                ddlPeriodos.Items.Add(new ListItem("Anual", "Anual"));

                CargarProductos();

                int idProducto = 0;

                if (int.TryParse(Request.QueryString["id"], out int idProd) && idProd > 0)
                    ddlProducto.SelectedValue = idProd.ToString();

                var movimientos = new InformeNegocio().ObtenerMovimientosProducto(idProducto);

                gvMovimientos.DataSource = movimientos;
                gvMovimientos.DataBind();
            }
        }

        protected void ddlPeriodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            InformeNegocio negocio = new InformeNegocio();

            string opcion = ddlPeriodos.SelectedValue;

            if (opcion == "Anual")
            {
                decimal totalAnual = negocio.ObtenerTotalAnual();
                lblResultado.Text = "Total recaudado en el año: $" + totalAnual.ToString("N2");
            }
            else
            {
                int mes = int.Parse(opcion);
                decimal totalMes = negocio.ObtenerTotalPorMes(mes);
                lblResultado.Text = "Total recaudado en " + ddlPeriodos.SelectedItem.Text + ": $" + totalMes.ToString("N2");
            }
        }
        private void CargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            var productos = negocio.ListarProductos(); // trae solo activos

            ddlProducto.DataSource = productos;
            ddlProducto.DataTextField = "NombreProducto";
            ddlProducto.DataValueField = "IdProducto";
            ddlProducto.DataBind();

            ddlProducto.Items.Insert(0, new ListItem("-- Seleccione un producto --", "0"));
        }


        protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idProducto = int.Parse(ddlProducto.SelectedValue);

            if (idProducto == 0)
            {
                gvMovimientos.DataSource = null;
                gvMovimientos.DataBind();
                return;
            }

            InformeNegocio negocio = new InformeNegocio();
            var movimientos = negocio.ObtenerMovimientosProducto(idProducto);

            gvMovimientos.DataSource = movimientos;
            gvMovimientos.DataBind();
        }


    }
}